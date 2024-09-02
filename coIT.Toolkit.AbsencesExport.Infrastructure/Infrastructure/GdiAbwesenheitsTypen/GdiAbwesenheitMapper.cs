using coIT.Libraries.Gdi.HumanResources;

namespace coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.GdiAbwesenheitsTypen
{
    internal static class GdiAbwesenheitMapper
    {
        public static GdiAbsenceType ZuGdiAbwesenheit(GdiAbwesenheitsTypEntity abwesenheitDto)
        {
            return new GdiAbsenceType
            {
                Id = abwesenheitDto.Id,
                DisplayText = abwesenheitDto.DisplayText,
                IsSickness = abwesenheitDto.IsSickness,
                IsHoliday = abwesenheitDto.IsHoliday,
            };
        }

        public static GdiAbwesenheitsTypEntity ZuAbwesenheitEntity(GdiAbsenceType abwesenheitsTyp)
        {
            return new GdiAbwesenheitsTypEntity
            {
                RowKey = abwesenheitsTyp.Id.ToString(),
                Id = abwesenheitsTyp.Id,
                DisplayText = abwesenheitsTyp.DisplayText,
                IsSickness = abwesenheitsTyp.IsSickness,
                IsHoliday = abwesenheitsTyp.IsHoliday,
            };
        }
    }
}
