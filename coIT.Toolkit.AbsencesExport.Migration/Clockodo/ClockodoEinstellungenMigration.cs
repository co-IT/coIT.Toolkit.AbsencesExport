using coIT.Libraries.Clockodo.Absences;
using coIT.Libraries.ConfigurationManager.Cryptography;
using coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.ClockodoAbwesenheitsTypen;
using coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Konfiguration.ClockodoKonfiguration;
using CSharpFunctionalExtensions;

namespace coIT.Toolkit.AbsencesExport.Migration.Clockodo
{
    internal class ClockodoEinstellungenMigration
    {
        public static async Task Durchführen(string connectionString)
        {
            Console.WriteLine("Benutzer E-Mail: ");
            var email = Console.ReadLine();

            Console.WriteLine("Api Token: ");
            var apiToken = Console.ReadLine();

            Console.WriteLine("Api Address: ");
            var apiAddress = Console.ReadLine();

            var serviceSettings = new AbsencesServiceSettings(email, apiToken, apiAddress);

            //var cryptographyService = new AesCryptographyService();
            //var schlüssel = cryptographyService.SchlüsselExportieren();

            var cryptographyService = AesCryptographyService
                .FromKey(
                    "eyJJdGVtMSI6InlLdHdrUDJraEJRbTRTckpEaXFjQWpkM3pBc3NVdG8rSUNrTmFwYUgwbWs9IiwiSXRlbTIiOiJUblRxT1RUbXI3ajBCZlUwTEtnOS9BPT0ifQ=="
                )
                .Value;

            var repository = new ClockodoKonfigurationDataTableRepository(
                connectionString,
                cryptographyService
            );

            await repository
                .Upsert(serviceSettings)
                .Bind(() => repository.Get())
                .Match(
                    einstellungen =>
                        Console.WriteLine(
                            $"Erfolgreich angelegt: {einstellungen.EmailAddress}, {einstellungen.ApiToken}, {einstellungen.BaseAdress}"
                        ),
                    error => Console.WriteLine(error)
                );
        }
    }
}
