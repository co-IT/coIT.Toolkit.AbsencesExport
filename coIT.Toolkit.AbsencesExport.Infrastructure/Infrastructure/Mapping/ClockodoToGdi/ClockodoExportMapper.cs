using Newtonsoft.Json;

namespace coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Mapping.ClockodoToGdi;

internal static class ClockodoExportMapper
{
  public static ExportRelations ZuExportRelations(ClockodoExportRelationsEntity entity)
  {
    var exportRelationHashset = JsonConvert.DeserializeObject<HashSet<ExportRelation>>(entity.Relations);

    return new ExportRelations
    {
      DisplayName = entity.DisplayName,
      ETag = entity.ETag,
      Id = entity.RowKey,
      Relations = exportRelationHashset,
      Timestamp = entity.Timestamp,
    };
  }

  public static ClockodoExportRelationsEntity ZuEntity(ExportRelations relations)
  {
    var relationHashsetSerialized = JsonConvert.SerializeObject(relations.Relations);

    return new ClockodoExportRelationsEntity
    {
      DisplayName = relations.DisplayName,
      ETag = relations.ETag,
      Relations = relationHashsetSerialized,
      RowKey = relations.Id,
      Timestamp = relations.Timestamp,
    };
  }
}
