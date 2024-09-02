using coIT.AbsencesExport.Configurations;
using coIT.Libraries.Clockodo.Absences;
using coIT.Libraries.Clockodo.Absences.Contracts;
using coIT.Libraries.Gdi.HumanResources;
using coIT.Libraries.TimeCard;

namespace coIT.AbsencesExport
{
    public partial class InitializeConfigurationForm : Form
    {
        public ClockodoConfiguration? ClockodoConfiguration { get; private set; }
        public TimeCardConfiguration? TimeCardConfiguration { get; private set; }
        public GdiConfiguration? GdiConfiguration { get; private set; }

        public InitializeConfigurationForm()
        {
            InitializeComponent();
        }

        private void btnCreateConfig_Click(object sender, EventArgs e)
        {
            TimeCardConfiguration = new TimeCardConfiguration
            {
                Settings = new TimeCardSettings(
                    timecard_ApiAdresse.Text,
                    timecard_ApiUser.Text,
                    timecard_ApiSchluessel.Text,
                    Convert.ToInt32(timecard_ApiKeinExportGroup.Text)
                )
            };

            var absenceTypes = new HashSet<ClockodoAbsenceType>
            {
                new ClockodoAbsenceType { DisplayText = "Normaler Urlaubstag", Id = 1 },
                new ClockodoAbsenceType { DisplayText = "Sonderurlaub", Id = 2 }
            };

            ClockodoConfiguration = new ClockodoConfiguration
            {
                AbsenceTypes = absenceTypes,
                Settings = new AbsencesServiceSettings(
                    clockodo_ApiEmail.Text,
                    clockodo_ApiSchluessel.Text,
                    "https://my.clockodo.com/"
                )
            };

            var gdiAbsenceTypes = new List<GdiAbsenceType>()
            {
                new GdiAbsenceType
                {
                    Id = -1,
                    DisplayText = "Kein Export",
                    IsHoliday = false,
                    IsSickness = false
                },
                new GdiAbsenceType
                {
                    Id = -2,
                    DisplayText = "Unbekannt",
                    IsHoliday = false,
                    IsSickness = false
                },
                new GdiAbsenceType
                {
                    Id = 7,
                    DisplayText = "Krank ab 43. Tag",
                    IsHoliday = false,
                    IsSickness = true
                },
                new GdiAbsenceType
                {
                    Id = 8,
                    DisplayText = "Krank",
                    IsHoliday = false,
                    IsSickness = true
                },
                new GdiAbsenceType
                {
                    Id = 44,
                    DisplayText = "Kind Krank",
                    IsHoliday = true,
                    IsSickness = false
                },
                new GdiAbsenceType
                {
                    Id = 23,
                    DisplayText = "Erholungsurlaub",
                    IsHoliday = true,
                    IsSickness = false
                },
                new GdiAbsenceType
                {
                    Id = 24,
                    DisplayText = "Sonderurlaub",
                    IsHoliday = true,
                    IsSickness = false
                }
            };
            GdiConfiguration = new GdiConfiguration { AbsenceTypes = gdiAbsenceTypes.ToHashSet() };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
