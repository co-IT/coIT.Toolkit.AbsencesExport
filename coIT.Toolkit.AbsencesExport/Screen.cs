using System.Reflection;
using coIT.AbsencesExport.UserForms;
using coIT.Libraries.Clockodo.Absences.Contracts;
using coIT.Libraries.ConfigurationManager.Cryptography;
using coIT.Libraries.Gdi.HumanResources;
using coIT.Libraries.TimeCard.DataContracts;
using coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.ClockodoAbwesenheitsTypen;
using coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.GdiAbwesenheitsTypen;
using coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Konfiguration.ClockodoKonfiguration;
using coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Mapping;
using coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Mapping.ClockodoToGdi;
using coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Mapping.TimeCardToGdi;

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

            // TODO: Man braucht nur connection string
            var initialConfigurationNeeded = _appConfig.IsInitialConfigurationNeeded();

            if (initialConfigurationNeeded)
                StartFirstInitialization();

            var encryptionService = AesCryptographyService
                .FromKey(
                    "eyJJdGVtMSI6InlLdHdrUDJraEJRbTRTckpEaXFjQWpkM3pBc3NVdG8rSUNrTmFwYUgwbWs9IiwiSXRlbTIiOiJUblRxT1RUbXI3ajBCZlUwTEtnOS9BPT0ifQ=="
                )
                .Value;

            var gdiRepository = new GdiAbwesenheitDataTableRepository(
                _appConfig.GetConnectionString()
            );
            var clockodoAbsenceTypesRepository = new ClockodoAbwesenheitsTypeDataTableRespository(
                _appConfig.GetConnectionString()
            );
            var clockodoSettingsRepository = new ClockodoKonfigurationDataTableRepository(
                _appConfig.GetConnectionString(),
                encryptionService
            );
            var clockodoExportRelationsRepository = new ClockodoExportRelationsRepository(
                _appConfig.GetConnectionString()
            );
            var timeCardSettingsRepository = new TimeCardKonfigurationDataTableRepository(
                _appConfig.GetConnectionString(),
                encryptionService
            );
            var timeCardExportRelationsRepository = new TimeCardExportRelationsRepository(
                _appConfig.GetConnectionString()
            );

            loadingForm.Show();
            loadingForm.TopMost = true;
            loadingForm.SetStatus("Clockodo Einstellungen Laden", 0);
            await LoadClockodoToGdi(
                gdiRepository,
                clockodoAbsenceTypesRepository,
                clockodoSettingsRepository,
                clockodoExportRelationsRepository
            );

            loadingForm.SetStatus("TimeCard Einstellungen Laden", 20);
            await LoadTimeCardToGdi(
                gdiRepository,
                timeCardSettingsRepository,
                timeCardExportRelationsRepository
            );
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

                var gdiConfig = initializeConfigurationForm.GdiConfiguration!;

                _appConfig.Save(new List<object> { gdiConfig });
            }
        }

        private async Task LoadClockodoToGdi(
            IGdiAbwesenheitRepository gdiRepository,
            IClockodoAbwesenheitsTypRepository clockodoAbsenceTypeRepository,
            IClockodoKonfigurationRepository clockodoKonfigurationRepository,
            IExportRelationsRepository exportRelationsRepository
        )
        {
            var absenceSourceName = "Clockodo";
            var absenceTargetName = "GDI";

            var gdiUserForm = await GdiUserForm.Create(gdiRepository);
            var targetAbsenceTypes = gdiUserForm.GetAllAbsenceTypes();
            Func<GdiAbsenceType, object> _getTargetKey = gdiAbsenceType => gdiAbsenceType.Id;

            var clockodoUserForm = await ClockodoUserForm.Create(
                clockodoKonfigurationRepository,
                clockodoAbsenceTypeRepository
            );
            var sourceAbsenceTypes = clockodoUserForm.GetAllAbsenceTypes();
            Func<ClockodoAbsenceType, object> _getSourceKey = timeCardAbsence => timeCardAbsence.Id;

            var mappingUserForm = await MappingUserForm<ClockodoAbsenceType, GdiAbsenceType>.Create(
                exportRelationsRepository,
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

        private async Task LoadTimeCardToGdi(
            IGdiAbwesenheitRepository gdiRepository,
            ITimeCardKonfigurationRepository timeCardRepository,
            IExportRelationsRepository exportRelationsRepository
        )
        {
            var absenceSourceName = "TimeCard";
            var absenceTargetName = "GDI";

            var gdiUserForm = await GdiUserForm.Create(gdiRepository);
            var targetAbsenceTypes = gdiUserForm.GetAllAbsenceTypes();
            Func<GdiAbsenceType, object> _getTargetKey = gdiAbsenceType => gdiAbsenceType.Id;

            var timeCardUserForm = await TimeCardUserForm.Create(timeCardRepository);
            var sourceAbsenceTypes = timeCardUserForm.GetAllAbsenceTypes();
            Func<TimeCardAbsenceType, object> _getSourceKey = timeCardAbsence => timeCardAbsence.Id;

            var mappingUserForm = await MappingUserForm<TimeCardAbsenceType, GdiAbsenceType>.Create(
                exportRelationsRepository,
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
