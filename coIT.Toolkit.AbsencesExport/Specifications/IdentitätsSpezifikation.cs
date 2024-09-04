using System.Linq.Expressions;

namespace coIT.Toolkit.AbsencesExport.Specifications;

internal class IdentitätsSpezifikation<T> : Spezifikation<T>
{
  public override Expression<Func<T, bool>> ToExpression()
  {
    return x => true;
  }
}
