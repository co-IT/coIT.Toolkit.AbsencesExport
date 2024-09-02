using Azure;

namespace coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Mapping
{
    public class ExportRelations
    {
        public HashSet<ExportRelation> Relations { get; set; }
        public string DisplayName { get; set; }
        public string Id { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}
