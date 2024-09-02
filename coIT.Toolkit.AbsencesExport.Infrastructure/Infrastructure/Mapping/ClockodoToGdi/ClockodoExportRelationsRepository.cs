using Azure;
using Azure.Data.Tables;
using CSharpFunctionalExtensions;

namespace coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Mapping.ClockodoToGdi
{
    public class ClockodoExportRelationsRepository : IExportRelationsRepository
    {
        private readonly TableClient _tableClient;

        public ClockodoExportRelationsRepository(string connectionString)
        {
            _tableClient = new TableClient(
                connectionString,
                ClockodoExportRelationsEntity.TabellenName
            );
        }

        public async Task<Result<List<ExportRelations>>> GetAll(
            CancellationToken cancellationToken = default
        )
        {
            var relationen = new List<ExportRelations>();

            try
            {
                var relationenAbfrage = _tableClient.QueryAsync<ClockodoExportRelationsEntity>(
                    cancellationToken: cancellationToken
                );

                await foreach (var kundeDto in relationenAbfrage)
                {
                    var gdiAbwesenheit = ClockodoExportMapper.ZuExportRelations(kundeDto);
                    relationen.Add(gdiAbwesenheit);
                }
            }
            catch (RequestFailedException ex)
            {
                return Result.Failure<List<ExportRelations>>(ex.Message);
            }

            return relationen;
        }

        public async Task<Result> Save(
            ExportRelations exportRelation,
            CancellationToken cancellationToken = default
        )
        {
            var exportRelationEntity = ClockodoExportMapper.ZuEntity(exportRelation);

            try
            {
                await _tableClient.CreateIfNotExistsAsync(cancellationToken: cancellationToken);
                await _tableClient.UpsertEntityAsync(
                    exportRelationEntity,
                    cancellationToken: cancellationToken
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
