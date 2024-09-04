using coIT.Libraries.ConfigurationManager.Cryptography;
using coIT.Libraries.TimeCard;
using coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Konfiguration.ClockodoKonfiguration;
using coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Konfiguration.TimeCardKonfiguration;
using CSharpFunctionalExtensions;

namespace coIT.Toolkit.AbsencesExport.Migration.TimeCard
{
    internal class TimeCardEinstellungenMigration
    {
        public static async Task Durchführen(string connectionString)
        {
            Console.WriteLine("WebAddress: ");
            var webAddress = Console.ReadLine();

            Console.WriteLine("Username: ");
            var username = Console.ReadLine();

            Console.WriteLine("Password: ");
            var password = Console.ReadLine();

            Console.WriteLine("NoExportGroup: ");
            var noExportGroup = int.Parse(Console.ReadLine());

            var settings = new TimeCardSettings(webAddress, username, password, noExportGroup);

            var cryptographyService = AesCryptographyService
                .FromKey(
                    "eyJJdGVtMSI6InlLdHdrUDJraEJRbTRTckpEaXFjQWpkM3pBc3NVdG8rSUNrTmFwYUgwbWs9IiwiSXRlbTIiOiJUblRxT1RUbXI3ajBCZlUwTEtnOS9BPT0ifQ=="
                )
                .Value;

            var repository = new TimeCardKonfigurationDataTableRepository(
                connectionString,
                cryptographyService
            );

            await repository
                .Upsert(settings)
                .Bind(() => repository.Get())
                .Match(
                    einstellungen =>
                        Console.WriteLine(
                            $"Erfolgreich angelegt: {einstellungen.WebAddress}, {einstellungen.Username}, {einstellungen.Password}, {einstellungen.NoExportGroup}"
                        ),
                    error => Console.WriteLine(error)
                );
        }
    }
}
