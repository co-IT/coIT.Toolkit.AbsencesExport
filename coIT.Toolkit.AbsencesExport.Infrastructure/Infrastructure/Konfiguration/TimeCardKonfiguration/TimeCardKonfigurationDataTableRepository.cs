using Azure;
using Azure.Data.Tables;
using coIT.Libraries.ConfigurationManager.Cryptography;
using coIT.Libraries.TimeCard;
using CSharpFunctionalExtensions;

namespace coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Konfiguration.ClockodoKonfiguration
{
    public class TimeCardKonfigurationDataTableRepository : ITimeCardKonfigurationRepository
    {
        private readonly TimeCardKonfigurationMapper _mapper;
        private readonly TableClient _tableClient;

        public TimeCardKonfigurationDataTableRepository(
            string connectionString,
            IDoCryptography cryptographyService
        )
        {
            _mapper = new TimeCardKonfigurationMapper(cryptographyService);
            _tableClient = new TableClient(
                connectionString,
                TimeCardKonfigurationEntity.TabellenName
            );
        }

        public async Task<Result<TimeCardSettings>> Get(
            CancellationToken cancellationToken = default
        )
        {
            try
            {
                return await Result
                    .Success()
                    .Map(
                        () =>
                            _tableClient.GetEntityIfExistsAsync<TimeCardKonfigurationEntity>(
                                TimeCardKonfigurationEntity.TabellenName,
                                TimeCardKonfigurationEntity.GlobalIdentifier,
                                cancellationToken: cancellationToken
                            )
                    )
                    .Ensure(
                        response => response.HasValue,
                        $"Der Eintrag mit dem Namen '{TimeCardKonfigurationEntity.GlobalIdentifier}' konnte nicht gefunden werden."
                    )
                    .Map(response => response.Value)
                    .Bind(_mapper.VonEntity!);
            }
            catch (Exception ex) when (ex is RequestFailedException or InvalidOperationException)
            {
                return Result.Failure<TimeCardSettings>(ex.Message);
            }
        }

        public async Task<Result> Upsert(
            TimeCardSettings clockodoKonfiguration,
            CancellationToken cancellationToken = default
        )
        {
            try
            {
                return await _mapper
                    .ZuEntity(clockodoKonfiguration)
                    .Tap(_ =>
                        _tableClient.CreateIfNotExistsAsync(cancellationToken: cancellationToken)
                    )
                    .Tap(konfigurationEntity =>
                        _tableClient.UpsertEntityAsync(
                            konfigurationEntity,
                            cancellationToken: cancellationToken
                        )
                    );
            }
            catch (RequestFailedException ex)
            {
                return Result.Failure(ex.Message);
            }
        }
    }
}
