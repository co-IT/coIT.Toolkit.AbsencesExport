using System.Linq.Expressions;

namespace coIT.AbsencesExport.Specifications
{
    public abstract class Spezifikation<T>
    {
        public static readonly Spezifikation<T> All = new IdentitätsSpezifikation<T>();

        public bool IsSatisfiedBy(T entity)
        {
            Func<T, bool> predicate = ToExpression().Compile();
            return predicate.Invoke(entity);
        }

        public abstract Expression<Func<T, bool>> ToExpression();

        public Spezifikation<T> Or(Spezifikation<T> specification)
        {
            return new OrSpezifikation<T>(this, specification);
        }

        public Spezifikation<T> And(Spezifikation<T> specification)
        {
            return new AndSpezifikation<T>(this, specification);
        }

        public Spezifikation<T> Not()
        {
            return new NotSpezifikation<T>(this);
        }
    }
}
