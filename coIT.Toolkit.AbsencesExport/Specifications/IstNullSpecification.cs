using System.Linq.Expressions;

namespace coIT.AbsencesExport.Specifications
{
    internal class IstNullSpecification<TSource, TTarget>
        : Spezifikation<Abwesenheitseintrag<TSource, TTarget>>
    {
        public override Expression<Func<Abwesenheitseintrag<TSource, TTarget>, bool>> ToExpression()
        {
            return abwesenheit => abwesenheit.ZielTyp == null;
        }
    }
}
