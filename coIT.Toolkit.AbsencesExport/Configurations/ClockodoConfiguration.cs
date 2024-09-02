using coIT.Libraries.Clockodo.Absences;
using coIT.Libraries.Clockodo.Absences.Contracts;

namespace coIT.AbsencesExport.Configurations
{
    public struct ClockodoConfiguration
    {
        public HashSet<ClockodoAbsenceType> AbsenceTypes { get; set; }

        public AbsencesServiceSettings Settings { get; set; }
    }
}
