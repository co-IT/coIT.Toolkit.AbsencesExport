using System.Reflection;
using coIT.AbsencesExport.UserForms;
using coIT.Libraries.Clockodo.Absences.Contracts;
using coIT.Libraries.Gdi.HumanResources;
using coIT.Libraries.TimeCard.DataContracts;
using coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.GdiAbwesenheitsTypen;

namespace coIT.AbsencesExport
{
    public partial class Screen : Form
    {
        private readonly AppConfiguration _appConfig;

        public Screen()
        {
            InitializeComponent();

            var appName =
                Assembly.GetEntryAssembly()?.GetName().Name ?? throw new NullReferenceException();
            var connectionString = Environment.GetEnvironmentVariable("ConnectionString");
            _appConfig = new AppConfiguration(appName, connectionString);
        }

        private async void LoadMain(object sender, EventArgs e)
        {
            var loadingForm = new LoadingForm();
            Enabled = false;

            var initialConfigurationNeeded = _appConfig.IsInitialConfigurationNeeded();

            if (initialConfigurationNeeded)
                StartFirstInitialization();

            var gdiRepository = new GdiAbwesenheitDataTableRepository(
                _appConfig.GetConnectionString()
            );

            loadingForm.Show();
            loadingForm.TopMost = true;
            loadingForm.SetStatus("Clockodo Einstellungen Laden", 0);
            await LoadClockodoToGdi(gdiRepository);

            loadingForm.SetStatus("TimeCard Einstellungen Laden", 20);
            await LoadTimeCardToGdi(gdiRepository);
            loadingForm.Close();

            Enabled = true;
        }

        private void StartFirstInitialization()
        {
            using (var initializeConfigurationForm = new InitializeConfigurationForm())
            {
                var result = initializeConfigurationForm.ShowDialog();

                if (result != DialogResult.OK)
                {
                    throw new NotImplementedException();
                }

                var timecardConfig = initializeConfigurationForm.TimeCardConfiguration!;
                var clockodoConfig = initializeConfigurationForm.ClockodoConfiguration!;
                var gdiConfig = initializeConfigurationForm.GdiConfiguration!;

                _appConfig.Save(new List<object> { timecardConfig, clockodoConfig, gdiConfig });
            }
        }

        private async Task LoadClockodoToGdi(IGdiAbwesenheitRepository gdiRepository)
        {
            var absenceSourceName = "Clockodo";
            var absenceTargetName = "GDI";

            var gdiUserForm = await GdiUserForm.Create(gdiRepository);
            var targetAbsenceTypes = gdiUserForm.GetAllAbsenceTypes();
            Func<GdiAbsenceType, object> _getTargetKey = gdiAbsenceType => gdiAbsenceType.Id;

            var clockodoUserForm = await ClockodoUserForm.Create(_appConfig);
            var sourceAbsenceTypes = clockodoUserForm.GetAllAbsenceTypes();
            Func<ClockodoAbsenceType, object> _getSourceKey = timeCardAbsence => timeCardAbsence.Id;

            var mappingUserForm = await MappingUserForm<ClockodoAbsenceType, GdiAbsenceType>.Create(
                "clockodo",
                sourceAbsenceTypes,
                _getSourceKey,
                absenceSourceName,
                targetAbsenceTypes,
                _getTargetKey,
                absenceTargetName
            );

            var timeCardToGdiExport = new MainUi<ClockodoAbsenceType, GdiAbsenceType>(
                mappingUserForm,
                clockodoUserForm,
                _getSourceKey,
                absenceSourceName,
                gdiUserForm,
                _getTargetKey,
                absenceTargetName
            );

            tbpClockodoToGdi.Controls.Add(timeCardToGdiExport);
            timeCardToGdiExport.Dock = DockStyle.Fill;
        }

        private async Task LoadTimeCardToGdi(IGdiAbwesenheitRepository gdiRepository)
        {
            var absenceSourceName = "TimeCard";
            var absenceTargetName = "GDI";

            var gdiUserForm = await GdiUserForm.Create(gdiRepository);
            var targetAbsenceTypes = gdiUserForm.GetAllAbsenceTypes();
            Func<GdiAbsenceType, object> _getTargetKey = gdiAbsenceType => gdiAbsenceType.Id;

            var timeCardUserForm = await TimeCardUserForm.Create(_appConfig);
            var sourceAbsenceTypes = timeCardUserForm.GetAllAbsenceTypes();
            Func<TimeCardAbsenceType, object> _getSourceKey = timeCardAbsence => timeCardAbsence.Id;

            var mappingUserForm = await MappingUserForm<TimeCardAbsenceType, GdiAbsenceType>.Create(
                "timecard",
                sourceAbsenceTypes,
                _getSourceKey,
                absenceSourceName,
                targetAbsenceTypes,
                _getTargetKey,
                absenceTargetName
            );

            var timeCardToGdiExport = new MainUi<TimeCardAbsenceType, GdiAbsenceType>(
                mappingUserForm,
                timeCardUserForm,
                _getSourceKey,
                absenceSourceName,
                gdiUserForm,
                _getTargetKey,
                absenceTargetName
            );

            tbpTimeCardToGdi.Controls.Add(timeCardToGdiExport);
            timeCardToGdiExport.Dock = DockStyle.Fill;
        }
    }
}
