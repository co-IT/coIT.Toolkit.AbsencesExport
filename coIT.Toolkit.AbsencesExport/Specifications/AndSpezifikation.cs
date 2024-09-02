using System.Linq.Expressions;

namespace coIT.AbsencesExport.Specifications
{
    internal class OrSpezifikation<T> : Spezifikation<T>
    {
        private Spezifikation<T> _left;
        private Spezifikation<T> _right;

        public OrSpezifikation(Spezifikation<T> left, Spezifikation<T> right)
        {
            _left = left;
            _right = right;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> leftExpression = _left.ToExpression();
            Expression<Func<T, bool>> rightExpression = _right.ToExpression();

            var invokedExpression = Expression.Invoke(rightExpression, leftExpression.Parameters);

            return (Expression<Func<T, Boolean>>)
                Expression.Lambda(
                    Expression.OrElse(leftExpression.Body, invokedExpression),
                    leftExpression.Parameters
                );
        }
    }
}
