using System.Text;
using coIT.Libraries.Gdi.HumanResources;
using coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.GdiAbwesenheitsTypen;
using Newtonsoft.Json;

namespace coIT.Toolkit.AbsencesExport.Migration.Gdi;

internal class GdiAbwesenheitenMigration
{
  public static async Task Durchführen(string connectionString, string pfadZuJson)
  {
    var repository = new GdiAbwesenheitDataTableRepository(connectionString);

    var abwesenheiten = await AbwesenheitenEinlesen(pfadZuJson);

    var einfügenErgebnis = await repository.UpsertManyAsync(abwesenheiten);

    if (einfügenErgebnis.IsSuccess)
      Console.WriteLine($"{abwesenheiten.Count} erfolgreich hinzugefügt");
    else
      Console.WriteLine($"{einfügenErgebnis.Error}");
  }

  public static async Task<List<GdiAbsenceType>> AbwesenheitenEinlesen(string pfadZuJson)
  {
    var abwesenheitsTypenJson = await File.ReadAllTextAsync(pfadZuJson, Encoding.UTF8);
    var abwesenheitsTypen = JsonConvert.DeserializeObject<List<GdiAbsenceType>>(abwesenheitsTypenJson);
    return abwesenheitsTypen;
  }
}
