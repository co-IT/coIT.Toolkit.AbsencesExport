using Azure;
using Azure.Data.Tables;
using coIT.Libraries.Gdi.HumanResources;
using CSharpFunctionalExtensions;

namespace coIT.Toolkit.AbsencesExport.Infrastructure.GdiAbsences
{
    internal class GdiAbwesenheitDataTableRepository : IGdiAbwesenheitRepository
    {
        private readonly TableClient _tableClient;

        public GdiAbwesenheitDataTableRepository(string connectionString)
        {
            _tableClient = new TableClient(connectionString, GdiAbwesenheitEntity.TabellenName);
        }

        public async Task<Result<HashSet<GdiAbsenceType>>> GetAll(
            CancellationToken cancellationToken = default
        )
        {
            var abwesenheiten = new HashSet<GdiAbsenceType>();

            try
            {
                var kundenAbfrage = _tableClient.QueryAsync<GdiAbwesenheitEntity>(
                    cancellationToken: cancellationToken
                );

                await foreach (var kundeDto in kundenAbfrage)
                {
                    var gdiAbwesenheit = GdiAbwesenheitMapper.ZuGdiAbwesenheit(kundeDto);
                    abwesenheiten.Add(gdiAbwesenheit);
                }
            }
            catch (RequestFailedException ex)
            {
                return Result.Failure<HashSet<GdiAbsenceType>>(ex.Message);
            }

            return abwesenheiten;
        }
    }
}
