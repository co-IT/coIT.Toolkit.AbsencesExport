using System.Collections.Immutable;

namespace coIT.AbsencesExport
{
    internal interface IExportAbsences<TSource>
        where TSource : class, IEquatable<TSource>, IEquatable<int>, IComparable<TSource>
    {
        HashSet<TSource> GetAllAbsenceTypes();

        Task<IImmutableList<AbwesenheitseintragOhneMapping<TSource>>> AllAbsences(
            DateTime start,
            DateTime ende,
            LoadingForm loadingForm
        );

        UserControl GetControl();

        bool HasLoadedCorrectly();

        string GetLoadErrorMessage();
    }
}
