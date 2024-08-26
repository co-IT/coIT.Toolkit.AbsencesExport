using System.Linq.Expressions;

namespace coIT.AbsencesExport.Specifications
{
    internal class IsHalfSicknessDay<TSource, TTarget>
        : Spezifikation<Abwesenheitseintrag<TSource, TTarget>>
    {
        public IsHalfSicknessDay() { }

        public override Expression<Func<Abwesenheitseintrag<TSource, TTarget>, bool>> ToExpression()
        {
            return abwesenheit =>
                abwesenheit.ZielTyp == null
                    ? false
                    : abwesenheit.ZielTyp.ToString().ToLower().Contains("krank")
                        && abwesenheit.AbwesenheitsTage % 1 != 0;
        }

        public override int GetHashCode()
        {
            return "full-day".GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, null))
                return false;

            if (GetType() != obj.GetType())
                return false;

            return true;
        }
    }
}
