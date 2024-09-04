using coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Mapping;
using coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Mapping.TimeCardToGdi;
using Newtonsoft.Json;

namespace coIT.Toolkit.AbsencesExport.Migration.TimeCard;

internal static class TimeCardMappingMigration
{
  public static async Task Durchführen(string connectionString)
  {
    var timeCardMappingRepository = new TimeCardExportRelationsRepository(connectionString);

    foreach (
      var mappingFile in Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Timecard", "Mappings"))
    )
    {
      var fileRelations = await File.ReadAllTextAsync(mappingFile);
      var relations = JsonConvert.DeserializeObject<HashSet<ExportRelation>>(fileRelations);
      var displayName = Path.GetFileNameWithoutExtension(mappingFile)
        .Replace("clockodo-mapping-settings-", string.Empty)
        .Replace("timecard-mapping-settings-", string.Empty);

      var exportRelations = new ExportRelations
      {
        DisplayName = displayName,
        Id = Guid.NewGuid().ToString(),
        Relations = relations!,
      };

      await timeCardMappingRepository.Save(exportRelations);
    }
  }
}
