using coIT.Libraries.Clockodo.Absences.Contracts;
using CSharpFunctionalExtensions;

namespace coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.ClockodoAbwesenheitsTypen
{
    public interface IClockodoAbwesenheitsTypRepository
    {
        public Task<Result<HashSet<ClockodoAbsenceType>>> GetAll(
            CancellationToken cancellationToken = default
        );
        Task<Result> UpsertManyAsync(
            List<ClockodoAbsenceType> gdiAbwesenheitsTypen,
            CancellationToken cancellationToken = default
        );
    }
}
