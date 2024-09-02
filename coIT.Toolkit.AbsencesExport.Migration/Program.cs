using coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.GdiAbsences;

namespace coIT.Toolkit.AbsencesExport.Migration
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var connectionString = Environment.GetEnvironmentVariable("ConnectionString");

            await GdiAbwesenheitenMigration.Durchführen(connectionString, "gdi-settings.json");
        }
    }
}
