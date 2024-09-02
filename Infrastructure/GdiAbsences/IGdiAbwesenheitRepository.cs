using coIT.Libraries.Gdi.HumanResources;
using CSharpFunctionalExtensions;

namespace coIT.Toolkit.AbsencesExport.Infrastructure.GdiAbsences
{
    public interface IGdiAbwesenheitRepository
    {
        public Task<Result<HashSet<GdiAbsenceType>>> GetAll(
            CancellationToken cancellationToken = default
        );
    }
}
