namespace coIT.AbsencesExport.Mapping
{
    internal class AbsenceTypeRelation<TSource, TTarget>
        where TSource : class, IEquatable<TSource>, IEquatable<int>, IComparable<TSource>
        where TTarget : class, IEquatable<TTarget>, IEquatable<int>, IComparable<TTarget>
    {
        public TSource Source { get; set; }
        public TTarget? Target { get; set; }
        public bool Export { get; set; }

        public static AbsenceTypeRelation<TSource, TTarget> Ignore(TSource source)
        {
            return new AbsenceTypeRelation<TSource, TTarget>()
            {
                Source = source,
                Target = null,
                Export = false
            };
        }

        public static AbsenceTypeRelation<TSource, TTarget> Create(
            TSource source,
            TTarget target,
            bool export = false
        )
        {
            return new AbsenceTypeRelation<TSource, TTarget>()
            {
                Source = source,
                Target = target,
                Export = export
            };
        }

        public override string ToString()
        {
            return Target is null
                ? $"{Source} wird ignoriert und daher nicht exportiert"
                : $"{Source} => {Target}";
        }
    }
}
