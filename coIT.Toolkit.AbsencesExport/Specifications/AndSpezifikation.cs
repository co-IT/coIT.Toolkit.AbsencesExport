using System.Linq.Expressions;

namespace coIT.Toolkit.AbsencesExport.Specifications;

internal class OrSpezifikation<T> : Spezifikation<T>
{
  private readonly Spezifikation<T> _left;
  private readonly Spezifikation<T> _right;

  public OrSpezifikation(Spezifikation<T> left, Spezifikation<T> right)
  {
    _left = left;
    _right = right;
  }

  public override Expression<Func<T, bool>> ToExpression()
  {
    var leftExpression = _left.ToExpression();
    var rightExpression = _right.ToExpression();

    var invokedExpression = Expression.Invoke(rightExpression, leftExpression.Parameters);

    return (Expression<Func<T, bool>>)
      Expression.Lambda(Expression.OrElse(leftExpression.Body, invokedExpression), leftExpression.Parameters);
  }
}
