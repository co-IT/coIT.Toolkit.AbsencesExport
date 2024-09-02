using coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Mapping;
using coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Mapping.ClockodoToGdi;
using Newtonsoft.Json;

namespace coIT.Toolkit.AbsencesExport.Migration.Clockodo
{
    internal static class ClockodoMappingMigration
    {
        public static async Task Durchführen(string connectionString)
        {
            var clockodoMappingRepository = new ClockodoExportRelationsRepository(connectionString);

            foreach (
                var mappingFile in Directory.GetFiles(
                    Path.Combine(Directory.GetCurrentDirectory(), "Clockodo", "Mappings")
                )
            )
            {
                var fileRelations = await File.ReadAllTextAsync(mappingFile);
                var relations = JsonConvert.DeserializeObject<HashSet<ExportRelation>>(fileRelations);
                var displayName = Path.GetFileNameWithoutExtension(mappingFile).Replace("clockodo-mapping-settings-", string.Empty);

                var exportRelations = new ExportRelations
                {
                    DisplayName = displayName,
                    Id = Guid.NewGuid().ToString(),
                    Relations = relations!
                };

                await clockodoMappingRepository.Save(exportRelations);
            }
        }
    }
}
