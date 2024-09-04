using Azure;
using Azure.Data.Tables;

namespace coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Konfiguration.TimeCardKonfiguration;

internal class TimeCardKonfigurationEntity : ITableEntity
{
  internal static readonly string TabellenName = "TimeCardKonfiguration";

  // Globale Konfiguration für alle Nutzer
  internal static readonly string GlobalIdentifier = "global";

  public string WebAddress { get; set; }
  public string Username { get; set; }
  public string Password { get; set; }
  public int NoExportGroup { get; set; }

  public string PartitionKey
  {
    get => TabellenName;
    set { }
  }

  public string RowKey
  {
    get => GlobalIdentifier;
    set { }
  }

  public DateTimeOffset? Timestamp { get; set; }
  public ETag ETag { get; set; }
}
