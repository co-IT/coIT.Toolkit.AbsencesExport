using Azure;
using Azure.Data.Tables;

namespace coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.ClockodoAbwesenheitsTypen
{
    internal class ClockodoAbwesenheitsTypEntity : ITableEntity
    {
        internal static readonly string TabellenName = "ClockodoAbwesenheitsTypen";

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
    }
}
