using Azure;
using Azure.Data.Tables;
using coIT.Libraries.Clockodo.Absences.Contracts;
using coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.GdiAbwesenheitsTypen;
using CSharpFunctionalExtensions;

namespace coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.ClockodoAbwesenheitsTypen
{
    public class ClockodoAbwesenheitsTypeDataTableRespository : IClockodoAbwesenheitsTypRepository
    {
        private readonly TableClient _tableClient;

        public ClockodoAbwesenheitsTypeDataTableRespository(string connectionString)
        {
            _tableClient = new TableClient(
                connectionString,
                ClockodoAbwesenheitsTypEntity.TabellenName
            );
        }

        public async Task<Result<HashSet<ClockodoAbsenceType>>> GetAll(
            CancellationToken cancellationToken = default
        )
        {
            var abwesenheiten = new HashSet<ClockodoAbsenceType>();

            try
            {
                var clockodoAbwesenheitsTypenAbfrage =
                    _tableClient.QueryAsync<ClockodoAbwesenheitsTypEntity>(
                        cancellationToken: cancellationToken
                    );

                await foreach (
                    var clockodoAbwesenheitsTypEntity in clockodoAbwesenheitsTypenAbfrage
                )
                {
                    var clockodoAbwesenheitsTyp =
                        ClockodoAbwesenheitsTypMapper.ZuClockodoAbwesenheitsTyp(
                            clockodoAbwesenheitsTypEntity
                        );
                    abwesenheiten.Add(clockodoAbwesenheitsTyp);
                }
            }
            catch (RequestFailedException ex)
            {
                return Result.Failure<HashSet<ClockodoAbsenceType>>(ex.Message);
            }

            return abwesenheiten;
        }

        public async Task<Result> UpsertManyAsync(
            List<ClockodoAbsenceType> gdiAbwesenheitsTypen,
            CancellationToken cancellationToken = default
        )
        {
            var upsertActions = gdiAbwesenheitsTypen
                .Select(ClockodoAbwesenheitsTypMapper.ZuClockodoAbwesenheitsTypEntity)
                .Select(abwesenheitsTypEntity => new TableTransactionAction(
                    TableTransactionActionType.UpsertMerge,
                    abwesenheitsTypEntity
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
