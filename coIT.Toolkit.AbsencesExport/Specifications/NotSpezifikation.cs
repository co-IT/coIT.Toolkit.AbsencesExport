using System.Linq.Expressions;

namespace coIT.Toolkit.AbsencesExport.Specifications;

internal class NotSpezifikation<T> : Spezifikation<T>
{
  private readonly Spezifikation<T> _spezifikation;

  public NotSpezifikation(Spezifikation<T> spezifikation)
  {
    _spezifikation = spezifikation;
  }

  public override Expression<Func<T, bool>> ToExpression()
  {
    var expression = _spezifikation.ToExpression();
    var notExpression = Expression.Not(expression.Body);

    return Expression.Lambda<Func<T, bool>>(notExpression, expression.Parameters.Single());
  }
}
