using coIT.Libraries.TimeCard;
using CSharpFunctionalExtensions;

namespace coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Konfiguration.TimeCardKonfiguration;

public interface ITimeCardKonfigurationRepository
{
  public Task<Result<TimeCardSettings>> Get(CancellationToken cancellationToken = default);

  public Task<Result> Upsert(TimeCardSettings timecardKonfiguration, CancellationToken cancellationToken = default);
}
