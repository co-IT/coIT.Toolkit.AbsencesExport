namespace coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Mapping;

public class ExportRelation : IEquatable<ExportRelation>
{
  public object IdOfSourceSystem { get; set; }
  public object? IdOfTargetSystem { get; set; }
  public bool Export { get; set; }

  public bool Equals(ExportRelation? other)
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
    return obj is ExportRelation other && Equals(other);
  }

  private bool IsTransient()
  {
    return IdOfSourceSystem.Equals(default);
  }

  public static bool operator ==(ExportRelation? a, ExportRelation? b)
  {
    if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
      return true;

    if (a is null || b is null)
      return false;

    return a.Equals(b);
  }

  public static bool operator !=(ExportRelation a, ExportRelation b)
  {
    return !(a == b);
  }

  public override int GetHashCode()
  {
    return IdOfSourceSystem.GetHashCode();
  }
}
