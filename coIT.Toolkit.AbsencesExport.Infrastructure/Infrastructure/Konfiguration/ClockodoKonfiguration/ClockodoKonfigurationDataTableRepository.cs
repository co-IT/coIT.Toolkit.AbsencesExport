using System.Threading;
using Azure;
using Azure.Data.Tables;
using coIT.Libraries.Clockodo.Absences;
using coIT.Libraries.ConfigurationManager.Cryptography;
using CSharpFunctionalExtensions;

namespace coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Konfiguration.ClockodoKonfiguration
{
    public class ClockodoKonfigurationDataTableRepository : IClockodoKonfigurationRepository
    {
        private readonly ClockodoKonfigurationMapper _mapper;
        private readonly TableClient _tableClient;

        public ClockodoKonfigurationDataTableRepository(
            string connectionString,
            IDoCryptography cryptographyService
        )
        {
            _mapper = new ClockodoKonfigurationMapper(cryptographyService);
            _tableClient = new TableClient(
                connectionString,
                ClockodoKonfigurationEntity.TabellenName
            );
        }

        public async Task<Result<AbsencesServiceSettings>> Get(
            CancellationToken cancellationToken = default
        )
        {
            try
            {
                return await Result
                    .Success()
                    .Map(
                        () =>
                            _tableClient.GetEntityIfExistsAsync<ClockodoKonfigurationEntity>(
                                ClockodoKonfigurationEntity.TabellenName,
                                ClockodoKonfigurationEntity.GlobalIdentifier,
                                cancellationToken: cancellationToken
                            )
                    )
                    .Ensure(
                        response => response.HasValue,
                        $"Der Eintrag mit dem Namen '{ClockodoKonfigurationEntity.GlobalIdentifier}' konnte nicht gefunden werden."
                    )
                    .Map(response => response.Value)
                    .Bind(_mapper.VonEntity!);
            }
            catch (Exception ex) when (ex is RequestFailedException or InvalidOperationException)
            {
                return Result.Failure<AbsencesServiceSettings>(ex.Message);
            }
        }

        public async Task<Result> Upsert(
            AbsencesServiceSettings clockodoKonfiguration,
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

            return Result.Success();
        }
    }
}
