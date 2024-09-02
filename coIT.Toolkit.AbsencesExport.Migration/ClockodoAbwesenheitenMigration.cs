using System.Text;
using coIT.Libraries.Clockodo.Absences.Contracts;
using coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.ClockodoAbwesenheitsTypen;
using Newtonsoft.Json;

namespace coIT.Toolkit.AbsencesExport.Migration
{
    internal class ClockodoAbwesenheitenMigration
    {
        public static async Task Durchführen(string connectionString, string pfadZuJson)
        {
            var repository = new ClockodoAbwesenheitsTypeDataTableRespository(connectionString);

            var abwesenheiten = await AbwesenheitenEinlesen(pfadZuJson);

            var einfügenErgebnis = await repository.UpsertManyAsync(abwesenheiten);

            if (einfügenErgebnis.IsSuccess)
                Console.WriteLine($"{abwesenheiten.Count} erfolgreich hinzugefügt");
            else
                Console.WriteLine($"{einfügenErgebnis.Error}");
        }

        public static async Task<List<ClockodoAbsenceType>> AbwesenheitenEinlesen(string pfadZuJson)
        {
            var abwesenheitsTypenJson = await File.ReadAllTextAsync(pfadZuJson, Encoding.UTF8);
            var abwesenheitsTypen = JsonConvert.DeserializeObject<List<ClockodoAbsenceType>>(
                abwesenheitsTypenJson
            );
            return abwesenheitsTypen;
        }
    }
}
