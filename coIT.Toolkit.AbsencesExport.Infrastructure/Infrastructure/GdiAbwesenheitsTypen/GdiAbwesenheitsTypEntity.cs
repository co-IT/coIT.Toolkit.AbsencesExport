using Azure;
using Azure.Data.Tables;

namespace coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.GdiAbwesenheitsTypen
{
    internal class GdiAbwesenheitsTypEntity : ITableEntity
    {
        internal static readonly string TabellenName = "GdiAbwesenheitsTypen";

        public string PartitionKey
        {
            get { return TabellenName; }
            set { return; }
        }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        public int Id { get; set; }
        public string DisplayText { get; set; }
        public bool IsSickness { get; set; }
        public bool IsHoliday { get; set; }
    }
}
