using coIT.AbsencesExport.Specifications;

namespace coIT.AbsencesExport;

internal class AktivierteFilter<TSource, TTarget>
{
    private readonly IList<Spezifikation<Abwesenheitseintrag<TSource, TTarget>>> _filter =
        new List<Spezifikation<Abwesenheitseintrag<TSource, TTarget>>>();

    public Spezifikation<Abwesenheitseintrag<TSource, TTarget>> Kombinieren()
    {
        var spezifikationen = Spezifikation<Abwesenheitseintrag<TSource, TTarget>>.All.Not();

        foreach (var filter in _filter)
            spezifikationen = spezifikationen.Or(filter);

        return spezifikationen;
    }

    private void FilterAktivieren<T>(T filter)
        where T : Spezifikation<Abwesenheitseintrag<TSource, TTarget>>
    {
        _filter.Add(filter);
    }

    private void FilterDeaktivieren<T>(T geanderterFilter)
        where T : Spezifikation<Abwesenheitseintrag<TSource, TTarget>>
    {
        var matches = _filter
            .Where(filter => filter.GetType() == geanderterFilter.GetType())
            .ToList();

        matches.ForEach(filter => _filter.Remove(filter));
    }

    private void WerteFilterDeaktivieren<T>(T filter)
        where T : Spezifikation<Abwesenheitseintrag<TSource, TTarget>>
    {
        var matches = _filter.Where(andererFilter => andererFilter.Equals(filter)).ToList();

        matches.ForEach(filter => _filter.Remove(filter));
    }

    public void FilterAktivierenOderDeaktivieren<T>(bool isChecked, T specification)
        where T : Spezifikation<Abwesenheitseintrag<TSource, TTarget>>
    {
        if (isChecked)
            FilterAktivieren(specification);
        else
            FilterDeaktivieren(specification);
    }

    public void WerteFilterAktivierenOderDeaktivieren<T>(bool isChecked, T specification)
        where T : Spezifikation<Abwesenheitseintrag<TSource, TTarget>>
    {
        if (isChecked)
            FilterAktivieren(specification);
        else
            WerteFilterDeaktivieren(specification);
    }
}
