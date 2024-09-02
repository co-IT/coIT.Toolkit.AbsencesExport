using Azure;
using Azure.Data.Tables;

namespace coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Konfiguration.ClockodoKonfiguration
{
    internal class TimeCardKonfigurationEntity : ITableEntity
    {
        internal static readonly string TabellenName = "TimeCardKonfiguration";

        // Globale Konfiguration für alle Nutzer
        internal static readonly string GlobalIdentifier = "global";

        public string PartitionKey
        {
            get { return TabellenName; }
            set { return; }
        }
        public string RowKey
        {
            get { return GlobalIdentifier; }
            set { return; }
        }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        public string WebAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int NoExportGroup { get; set; }
    }
}
