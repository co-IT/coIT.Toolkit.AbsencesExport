namespace coIT.AbsencesExport.Mapping
{
    internal class AbsenceTypeRelations<TSource, TTarget>
        where TSource : class, IEquatable<TSource>, IEquatable<int>, IComparable<TSource>
        where TTarget : class, IEquatable<TTarget>, IEquatable<int>, IComparable<TTarget>
    {
        private readonly IdExportRelations _repository;
        private readonly HashSet<TSource> _sourceAbsenceTypes;
        private readonly Func<TSource, object> _getSourceKey;
        private readonly HashSet<TTarget> _targetAbsenceTypes;
        private readonly Func<TTarget, object> _getTargetKey;
        private HashSet<AbsenceTypeRelation<TSource, TTarget>> _relations;

        private AbsenceTypeRelations(
            HashSet<TSource> sourceTypes,
            Func<TSource, object> getSourceKey,
            HashSet<TTarget> targetTypes,
            Func<TTarget, object> getTargetKey,
            IdExportRelations repository
        )
        {
            _sourceAbsenceTypes = sourceTypes;
            _getSourceKey = getSourceKey;
            _targetAbsenceTypes = targetTypes;
            _getTargetKey = getTargetKey;
            _repository = repository;
            _relations = new();
        }

        public static async Task<AbsenceTypeRelations<TSource, TTarget>> Initialize(
            HashSet<TSource> sourceTypes,
            Func<TSource, object> getSourceKey,
            HashSet<TTarget> targetTypes,
            Func<TTarget, object> getTargetKey,
            IdExportRelations repository
        )
        {
            var relations = new AbsenceTypeRelations<TSource, TTarget>(
                sourceTypes,
                getSourceKey,
                targetTypes,
                getTargetKey,
                repository
            );

            await relations.LoadSettings();

            return relations;
        }

        private async Task LoadSettings()
        {
            await _repository.LoadFromSettings();
            Update();
            await Save();
        }

        private void Update()
        {
            _relations.Clear();

            foreach (var configuredRelation in _repository)
            {
                var source = _sourceAbsenceTypes.SingleOrDefault(absence =>
                    absence.Equals(configuredRelation.IdOfSourceSystem)
                );
                var target = _targetAbsenceTypes.SingleOrDefault(absence =>
                    absence.Equals(configuredRelation.IdOfTargetSystem)
                );

                if (source == null)
                    continue;

                var validRelation = new AbsenceTypeRelation<TSource, TTarget>()
                {
                    Source = source,
                    Target = target,
                    Export = configuredRelation.Export
                };

                _relations.Add(validRelation);
            }
        }

        public TTarget? GetMappedTargetType(TSource sourceAbsence)
        {
            return _relations.FirstOrDefault(relation => relation.Source == sourceAbsence)?.Target;
        }

        public bool IsExport(TSource sourceAbsence)
        {
            var result = _relations
                .FirstOrDefault(relation => relation.Source == sourceAbsence)
                ?.Export;

            result ??= false;

            return (bool)result;
        }

        public HashSet<TSource> NotMappedFromSourceToTarget()
        {
            var existing = _relations.Select(rel => rel.Source).ToList();

            var notMapped = new HashSet<TSource>();

            foreach (var source in _sourceAbsenceTypes)
            {
                if (existing.Contains(source))
                    continue;

                notMapped.Add(source);
            }

            return notMapped;
        }

        public HashSet<AbsenceTypeRelation<TSource, TTarget>> MappedButIgnored()
        {
            return _relations.Where(rel => rel.Target is null).ToHashSet();
        }

        public HashSet<AbsenceTypeRelation<TSource, TTarget>> MappedWithoutIgnored()
        {
            return _relations.Where(rel => rel.Target is not null).ToHashSet();
        }

        public (bool doExport, TTarget? toType) CheckExport(TSource source)
        {
            var relation = _relations.SingleOrDefault(rel => rel.Source.Equals(source));

            if (relation == null)
                throw new InvalidOperationException(
                    $"Call {nameof(NotMappedFromSourceToTarget)} first"
                );

            return (relation.Export, relation.Target);
        }

        public void Ignore(TSource source)
        {
            var existsing = _relations.SingleOrDefault(rel => rel.Source == source);

            if (existsing != null)
                _relations.Remove(existsing);

            _relations.Add(AbsenceTypeRelation<TSource, TTarget>.Ignore(source));
        }

        public void Map(AbsenceTypeRelation<TSource, TTarget> relation)
        {
            Unmap(relation);
            _relations.Add(relation);
        }

        public void Unmap(AbsenceTypeRelation<TSource, TTarget> relation)
        {
            var found = _relations
                .Where(existing => existing.Source == relation.Source)
                .SingleOrDefault(existing => existing.Target == relation.Target);

            if (found != null)
                _relations.Remove(found);
        }

        public async Task Save()
        {
            var update = _relations
                .Select(rel => new IdExportRelation
                {
                    Export = rel.Export,
                    IdOfSourceSystem = _getSourceKey(rel.Source),
                    IdOfTargetSystem = rel.Target == null ? null : _getTargetKey(rel.Target)
                })
                .ToHashSet();

            await _repository.OverwriteSettings(update);
        }
    }
}
