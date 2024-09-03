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
            //await TimeCardEinstellungenMigration.Durchführen(connectionString);
            //await ClockodoMappingMigration.Durchführen(connectionString);
            //await TimeCardMappingMigration.Durchführen(connectionString);
        }
    }
}
