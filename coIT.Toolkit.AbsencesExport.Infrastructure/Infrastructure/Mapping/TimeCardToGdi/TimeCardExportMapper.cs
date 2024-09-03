using coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Mapping.ClockodoToGdi;
using Newtonsoft.Json;

namespace coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Mapping.TimeCardToGdi
{
    internal class TimeCardExportMapper
    {
        public static ExportRelations ZuExportRelations(TimeCardExportRelationsEntity entity)
        {
            var exportRelationHashset = JsonConvert.DeserializeObject<HashSet<ExportRelation>>(
                entity.Relations
            );

            return new ExportRelations
            {
                DisplayName = entity.DisplayName,
                ETag = entity.ETag,
                Id = entity.RowKey,
                Relations = exportRelationHashset,
                Timestamp = entity.Timestamp,
            };
        }

        public static TimeCardExportRelationsEntity ZuEntity(ExportRelations relations)
        {
            var relationHashsetSerialized = JsonConvert.SerializeObject(relations.Relations);

            return new TimeCardExportRelationsEntity
            {
                DisplayName = relations.DisplayName,
                ETag = relations.ETag,
                Relations = relationHashsetSerialized,
                RowKey = relations.Id,
                Timestamp = relations.Timestamp,
            };
        }
    }
}
