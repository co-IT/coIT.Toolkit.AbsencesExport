namespace coIT.AbsencesExport
{
    internal interface IImportAbsences<TTarget>
        where TTarget : class, IEquatable<TTarget>, IEquatable<int>, IComparable<TTarget>
    {
        HashSet<TTarget> GetAllAbsenceTypes();

        UserControl GetControl();

        bool HasLoadedCorrectly();

        string GetLoadErrorMessage();
        void ExportAbsences(List<AbwesenheitseintragOhneMapping<TTarget>> exportAbsences);
    }
}
