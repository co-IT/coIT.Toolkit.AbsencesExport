using coIT.Libraries.Gdi.HumanResources;

namespace coIT.Toolkit.AbsencesExport.Infrastructure.GdiAbsences
{
    internal static class GdiAbwesenheitMapper
    {
        public static GdiAbsenceType ZuGdiAbwesenheit(GdiAbwesenheitEntity abwesenheitDto)
        {
            return new GdiAbsenceType
            {
                Id = abwesenheitDto.Id,
                DisplayText = abwesenheitDto.DisplayText,
                IsSickness = abwesenheitDto.IsSickness,
                IsHoliday = abwesenheitDto.IsHoliday,
            };
        }
    }
}
