using coIT.Libraries.Gdi.HumanResources;
using CSharpFunctionalExtensions;

namespace coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.GdiAbwesenheitsTypen;

public interface IGdiAbwesenheitRepository
{
  public Task<Result<HashSet<GdiAbsenceType>>> GetAll(CancellationToken cancellationToken = default);

  Task<Result> UpsertManyAsync(
    List<GdiAbsenceType> gdiAbwesenheitsTypen,
    CancellationToken cancellationToken = default
  );
}
