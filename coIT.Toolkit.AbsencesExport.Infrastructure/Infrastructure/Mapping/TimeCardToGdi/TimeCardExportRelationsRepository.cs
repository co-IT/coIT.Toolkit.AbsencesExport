using Azure;
using Azure.Data.Tables;
using CSharpFunctionalExtensions;

namespace coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Mapping.TimeCardToGdi;

public class TimeCardExportRelationsRepository : IExportRelationsRepository
{
  private readonly TableClient _tableClient;

  public TimeCardExportRelationsRepository(string connectionString)
  {
    _tableClient = new TableClient(connectionString, TimeCardExportRelationsEntity.TabellenName);
  }

  public async Task<Result<List<ExportRelations>>> GetAll(CancellationToken cancellationToken = default)
  {
    var relationen = new List<ExportRelations>();

    try
    {
      var relationenAbfrage = _tableClient.QueryAsync<TimeCardExportRelationsEntity>(
        cancellationToken: cancellationToken
      );

      await foreach (var kundeDto in relationenAbfrage)
      {
        var exportRelations = TimeCardExportMapper.ZuExportRelations(kundeDto);
        relationen.Add(exportRelations);
      }
    }
    catch (RequestFailedException ex)
    {
      return Result.Failure<List<ExportRelations>>(ex.Message);
    }

    return relationen;
  }

  public async Task<Result> Save(ExportRelations exportRelation, CancellationToken cancellationToken = default)
  {
    var exportRelationEntity = TimeCardExportMapper.ZuEntity(exportRelation);

    try
    {
      await _tableClient.CreateIfNotExistsAsync(cancellationToken);
      await _tableClient.UpsertEntityAsync(exportRelationEntity, cancellationToken: cancellationToken);
    }
    catch (RequestFailedException ex)
    {
      return Result.Failure(ex.Message);
    }

    return Result.Success();
  }
}
