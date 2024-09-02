namespace coIT.AbsencesExport.Mapping
{
    internal class IdExportRelation : IEquatable<IdExportRelation>
    {
        public object IdOfSourceSystem { get; set; }
        public object? IdOfTargetSystem { get; set; }
        public bool Export { get; set; }

        public bool Equals(IdExportRelation? other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (IsTransient() || other.IsTransient())
                return false;

            return IdOfSourceSystem.Equals(other.IdOfSourceSystem);
        }

        public override bool Equals(object? obj)
        {
            return obj is IdExportRelation other && Equals(other);
        }

        private bool IsTransient()
        {
            return IdOfSourceSystem.Equals(default);
        }

        public static bool operator ==(IdExportRelation? a, IdExportRelation? b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(IdExportRelation a, IdExportRelation b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return IdOfSourceSystem.GetHashCode();
        }
    }
}
