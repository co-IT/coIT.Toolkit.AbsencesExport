using System.Linq.Expressions;

namespace coIT.AbsencesExport.Specifications
{
    internal class IdentitätsSpezifikation<T> : Spezifikation<T>
    {
        public override Expression<Func<T, bool>> ToExpression()
        {
            return x => true;
        }
    }
}
