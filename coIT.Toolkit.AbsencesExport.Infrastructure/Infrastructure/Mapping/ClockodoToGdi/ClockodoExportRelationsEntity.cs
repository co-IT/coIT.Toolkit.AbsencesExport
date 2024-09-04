using Azure;
using Azure.Data.Tables;

namespace coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Mapping.ClockodoToGdi;

internal class ClockodoExportRelationsEntity : ITableEntity
{
  internal static readonly string TabellenName = "ClockodoExportRelations";

  public string Relations { get; set; } // als JSON
  public string DisplayName { get; set; }

  public string PartitionKey
  {
    get => TabellenName;
    set { }
  }

  public string RowKey { get; set; }
  public DateTimeOffset? Timestamp { get; set; }
  public ETag ETag { get; set; }
}
