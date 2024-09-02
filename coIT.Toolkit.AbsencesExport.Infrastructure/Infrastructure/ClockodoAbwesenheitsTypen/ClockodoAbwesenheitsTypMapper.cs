using coIT.Libraries.Clockodo.Absences.Contracts;

namespace coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.ClockodoAbwesenheitsTypen
{
    internal static class ClockodoAbwesenheitsTypMapper
    {
        public static ClockodoAbsenceType ZuClockodoAbwesenheitsTyp(
            ClockodoAbwesenheitsTypEntity abwesenheitsTypEntity
        )
        {
            return new ClockodoAbsenceType
            {
                Id = abwesenheitsTypEntity.Id,
                DisplayText = abwesenheitsTypEntity.DisplayText,
            };
        }

        public static ClockodoAbwesenheitsTypEntity ZuClockodoAbwesenheitsTypEntity(
            ClockodoAbsenceType abwesenheitsTyp
        )
        {
            return new ClockodoAbwesenheitsTypEntity
            {
                Id = abwesenheitsTyp.Id,
                DisplayText = abwesenheitsTyp.DisplayText,
                RowKey = abwesenheitsTyp.Id.ToString(),
            };
        }
    }
}
