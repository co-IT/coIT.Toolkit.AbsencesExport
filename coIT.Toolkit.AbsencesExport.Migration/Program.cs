using coIT.Toolkit.AbsencesExport.Migration.Clockodo;
using coIT.Toolkit.AbsencesExport.Migration.Gdi;
using coIT.Toolkit.AbsencesExport.Migration.TimeCard;

namespace coIT.Toolkit.AbsencesExport.Migration
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var connectionString = Environment.GetEnvironmentVariable("ConnectionString");

            //await GdiAbwesenheitenMigration.Durchführen(connectionString, "gdi-settings.json");
            //await ClockodoAbwesenheitenMigration.Durchführen(
            //    connectionString,
            //    "clockodo-settings.json"
            //);
            //await ClockodoEinstellungenMigration.Durchführen(connectionString);

            await TimeCardEinstellungenMigration.Durchführen(connectionString);
        }
    }
}
