using System.Linq.Expressions;

namespace coIT.Toolkit.AbsencesExport.Specifications;

internal class IsTargetTypeSpecification<TSource, TTarget> : Spezifikation<Abwesenheitseintrag<TSource, TTarget>>
{
  private readonly Func<TTarget, object> _getTargetKey;
  public readonly TTarget _targetType;

  public IsTargetTypeSpecification(TTarget abwesenheitstyp, Func<TTarget, object> getTargetKey)
  {
    _targetType = abwesenheitstyp;
    _getTargetKey = getTargetKey;
  }

  public override Expression<Func<Abwesenheitseintrag<TSource, TTarget>, bool>> ToExpression()
  {
    return abwesenheit =>
      abwesenheit.ZielTyp != null && _getTargetKey(abwesenheit.ZielTyp) == _getTargetKey(_targetType);
  }

  public override int GetHashCode()
  {
    return _targetType.GetHashCode();
  }

  public override bool Equals(object? obj)
  {
    if (ReferenceEquals(obj, null))
      return false;

    if (GetType() != obj.GetType())
      return false;

    return _getTargetKey(_targetType) == _getTargetKey(((IsTargetTypeSpecification<TSource, TTarget>)obj)._targetType);
  }
}
