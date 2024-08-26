using System.Linq.Expressions;

namespace coIT.AbsencesExport.Specifications
{
    internal class NotSpezifikation<T> : Spezifikation<T>
    {
        private readonly Spezifikation<T> _spezifikation;

        public NotSpezifikation(Spezifikation<T> spezifikation)
        {
            _spezifikation = spezifikation;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> expression = _spezifikation.ToExpression();
            UnaryExpression notExpression = Expression.Not(expression.Body);

            return Expression.Lambda<Func<T, bool>>(notExpression, expression.Parameters.Single());
        }
    }
}
