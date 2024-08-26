using System.Linq.Expressions;

namespace coIT.AbsencesExport.Specifications
{
    internal class MitarbeiterSpezifikation<TSource, TTarget>
        : Spezifikation<Abwesenheitseintrag<TSource, TTarget>>
    {
        private readonly string _name;

        public MitarbeiterSpezifikation(string name)
        {
            _name = name;
        }

        public override Expression<Func<Abwesenheitseintrag<TSource, TTarget>, bool>> ToExpression()
        {
            return abwesenheit => $"{abwesenheit.Name} | {abwesenheit.Personalnummer}" == _name;
        }

        public override int GetHashCode()
        {
            return _name.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, null))
                return false;

            if (GetType() != obj.GetType())
                return false;

            return _name == ((MitarbeiterSpezifikation<TSource, TTarget>)obj)._name;
        }
    }
}
