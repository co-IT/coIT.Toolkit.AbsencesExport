using Azure;
using Azure.Data.Tables;

namespace coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Konfiguration.ClockodoKonfiguration
{
    internal class ClockodoKonfigurationEntity : ITableEntity
    {
        internal static readonly string TabellenName = "GdiAbwesenheitsTypen";

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

        public string EmailAddress { get; set; }
        public string ApiToken { get; set; }
        public string BaseAddress { get; set; }
    }
}
