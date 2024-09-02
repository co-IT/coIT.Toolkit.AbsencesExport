using Azure;
using Azure.Data.Tables;
using coIT.Libraries.Gdi.HumanResources;
using CSharpFunctionalExtensions;

namespace coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.GdiAbwesenheitsTypen
{
    public class GdiAbwesenheitDataTableRepository : IGdiAbwesenheitRepository
    {
        private readonly TableClient _tableClient;

        public GdiAbwesenheitDataTableRepository(string connectionString)
        {
            _tableClient = new TableClient(connectionString, GdiAbwesenheitsTypEntity.TabellenName);
        }

        public async Task<Result<HashSet<GdiAbsenceType>>> GetAll(
            CancellationToken cancellationToken = default
        )
        {
            var abwesenheiten = new HashSet<GdiAbsenceType>();

            try
            {
                var kundenAbfrage = _tableClient.QueryAsync<GdiAbwesenheitsTypEntity>(
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

        public async Task<Result> UpsertManyAsync(
            List<GdiAbsenceType> gdiAbwesenheitsTypen,
            CancellationToken cancellationToken = default
        )
        {
            var upsertActions = gdiAbwesenheitsTypen
                .Select(GdiAbwesenheitMapper.ZuAbwesenheitEntity)
                .Select(kundeRelationDto => new TableTransactionAction(
                    TableTransactionActionType.UpsertMerge,
                    kundeRelationDto
                ));

            try
            {
                await _tableClient.CreateIfNotExistsAsync(cancellationToken);
                var antworten = await _tableClient
                    .SubmitTransactionAsync(upsertActions)
                    .ConfigureAwait(false);

                var fehler = antworten.Value.Where(antwort => antwort.IsError);

                if (fehler.Any())
                {
                    var fehlerTexte = fehler.Select(f => f.ReasonPhrase);
                    return Result.Failure(string.Join(Environment.NewLine, fehlerTexte));
                }
            }
            catch (Exception ex) when (ex is RequestFailedException or InvalidOperationException)
            {
                return Result.Failure(ex.Message);
            }

            return Result.Success();
        }
    }
}
