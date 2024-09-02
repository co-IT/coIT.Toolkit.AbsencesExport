using System.Text;
using Newtonsoft.Json;

namespace coIT.AbsencesExport.Mapping
{
    internal class IdExportRelations : HashSet<IdExportRelation>
    {
        private readonly FileInfo _settingsfile;
        private HashSet<IdExportRelation> _relations;

        public IdExportRelations(FileInfo settingsfile)
        {
            _settingsfile = settingsfile;
            _relations = new HashSet<IdExportRelation>();
        }

        public async Task LoadFromSettings()
        {
            if (!_settingsfile.Exists)
                return;

            var fileContent = await File.ReadAllTextAsync(_settingsfile.FullName);
            var allRelations =
                JsonConvert.DeserializeObject<List<IdExportRelation>>(fileContent)
                ?? new List<IdExportRelation>();
            var uniqueRelations = allRelations.ToHashSet();

            Clear();

            if (allRelations.Count != uniqueRelations.Count)
            {
                Console.WriteLine(
                    "Relations reset since there were multiple relations of the same source type"
                );
            }
            else
            {
                UnionWith(uniqueRelations);
            }

            await OverwriteSettings(this);
        }

        public async Task OverwriteSettings(HashSet<IdExportRelation> timeEntriesRelations)
        {
            _relations.Clear();
            _relations = timeEntriesRelations;
            var fileContent = JsonConvert.SerializeObject(_relations);
            await File.WriteAllTextAsync(_settingsfile.FullName, fileContent, Encoding.UTF8);
        }
    }
}
