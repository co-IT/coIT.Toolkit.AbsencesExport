using coIT.Libraries.Clockodo.Absences;
using CSharpFunctionalExtensions;

namespace coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Konfiguration.ClockodoKonfiguration
{
    public interface IClockodoKonfigurationRepository
    {
        public Task<Result<AbsencesServiceSettings>> Get(
            CancellationToken cancellationToken = default
        );

        public Task<Result> Upsert(
            AbsencesServiceSettings clockodoKonfiguration,
            CancellationToken cancellationToken = default
        );
    }
}
