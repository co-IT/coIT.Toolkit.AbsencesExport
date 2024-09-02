using coIT.AbsencesExport.Configurations;
using coIT.Libraries.Gdi.HumanResources;

namespace coIT.AbsencesExport
{
    public partial class InitializeConfigurationForm : Form
    {
        public GdiConfiguration? GdiConfiguration { get; private set; }

        public InitializeConfigurationForm()
        {
            InitializeComponent();
        }

        private void btnCreateConfig_Click(object sender, EventArgs e)
        {
            var gdiAbsenceTypes = new List<GdiAbsenceType>()
            {
                new GdiAbsenceType
                {
                    Id = -1,
                    DisplayText = "Kein Export",
                    IsHoliday = false,
                    IsSickness = false,
                },
                new GdiAbsenceType
                {
                    Id = -2,
                    DisplayText = "Unbekannt",
                    IsHoliday = false,
                    IsSickness = false,
                },
                new GdiAbsenceType
                {
                    Id = 7,
                    DisplayText = "Krank ab 43. Tag",
                    IsHoliday = false,
                    IsSickness = true,
                },
                new GdiAbsenceType
                {
                    Id = 8,
                    DisplayText = "Krank",
                    IsHoliday = false,
                    IsSickness = true,
                },
                new GdiAbsenceType
                {
                    Id = 44,
                    DisplayText = "Kind Krank",
                    IsHoliday = true,
                    IsSickness = false,
                },
                new GdiAbsenceType
                {
                    Id = 23,
                    DisplayText = "Erholungsurlaub",
                    IsHoliday = true,
                    IsSickness = false,
                },
                new GdiAbsenceType
                {
                    Id = 24,
                    DisplayText = "Sonderurlaub",
                    IsHoliday = true,
                    IsSickness = false,
                },
            };
            GdiConfiguration = new GdiConfiguration { AbsenceTypes = gdiAbsenceTypes.ToHashSet() };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
