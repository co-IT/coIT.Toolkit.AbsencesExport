using Azure;
using Azure.Data.Tables;

namespace coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Konfiguration.ClockodoKonfiguration;

internal class ClockodoKonfigurationEntity : ITableEntity
{
  internal static readonly string TabellenName = "ClockodoKonfiguration";

  // Globale Konfiguration für alle Nutzer
  internal static readonly string GlobalIdentifier = "global";

  public string EmailAddress { get; set; }
  public string ApiToken { get; set; }
  public string BaseAddress { get; set; }

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
