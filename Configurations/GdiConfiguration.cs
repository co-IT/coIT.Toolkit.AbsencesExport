using coIT.Libraries.Gdi.HumanResources;

namespace coIT.AbsencesExport.Configurations
{
    public class GdiConfiguration
    {
        public HashSet<GdiAbsenceType> AbsenceTypes { get; set; } = new();
    }
}
