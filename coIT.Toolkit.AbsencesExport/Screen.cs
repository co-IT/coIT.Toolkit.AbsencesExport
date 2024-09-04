using coIT.Libraries.Clockodo.Absences.Contracts;
using coIT.Libraries.ConfigurationManager;
using coIT.Libraries.ConfigurationManager.Cryptography;
using coIT.Libraries.ConfigurationManager.Serialization;
using coIT.Libraries.Gdi.HumanResources;
using coIT.Libraries.TimeCard.DataContracts;
using coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.ClockodoAbwesenheitsTypen;
using coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.GdiAbwesenheitsTypen;
using coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Konfiguration.ClockodoKonfiguration;
using coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Konfiguration.TimeCardKonfiguration;
using coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Mapping;
using coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Mapping.ClockodoToGdi;
using coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Mapping.TimeCardToGdi;
using coIT.Toolkit.AbsencesExport.UserForms;

namespace coIT.Toolkit.AbsencesExport;

public partial class Screen : Form
{
  private AzureTableKonfiguration _azureTableKonfiguration;

  public Screen()
  {
    InitializeComponent();
  }

  private async void LoadMain(object sender, EventArgs e)
  {
    var loadingForm = new LoadingForm();
    Enabled = false;

    var encryptionService = AesCryptographyService
      .FromKey(
        "eyJJdGVtMSI6InlLdHdrUDJraEJRbTRTckpEaXFjQWpkM3pBc3NVdG8rSUNrTmFwYUgwbWs9IiwiSXRlbTIiOiJUblRxT1RUbXI3ajBCZlUwTEtnOS9BPT0ifQ=="
      )
      .Value;
    var serializer = new NewtonsoftJsonSerializer();
    var environmentManager = new EnvironmentManager(encryptionService, serializer);

    var loadConnectionStringResult = await environmentManager.Get<AzureTableKonfiguration>(
      "COIT_TOOLKIT_DATABASE_CONNECTIONSTRING"
    );

    if (loadConnectionStringResult.IsFailure)
      await StartFirstInitialization(environmentManager);
    else
      _azureTableKonfiguration = loadConnectionStringResult.Value;

    var gdiRepository = new GdiAbwesenheitDataTableRepository(_azureTableKonfiguration.ConnectionString);
    var clockodoAbsenceTypesRepository = new ClockodoAbwesenheitsTypeDataTableRespository(
      _azureTableKonfiguration.ConnectionString
    );
    var clockodoSettingsRepository = new ClockodoKonfigurationDataTableRepository(
      _azureTableKonfiguration.ConnectionString,
      encryptionService
    );
    var clockodoExportRelationsRepository = new ClockodoExportRelationsRepository(
      _azureTableKonfiguration.ConnectionString
    );
    var timeCardSettingsRepository = new TimeCardKonfigurationDataTableRepository(
      _azureTableKonfiguration.ConnectionString,
      encryptionService
    );
    var timeCardExportRelationsRepository = new TimeCardExportRelationsRepository(
      _azureTableKonfiguration.ConnectionString
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
    await LoadTimeCardToGdi(gdiRepository, timeCardSettingsRepository, timeCardExportRelationsRepository);
    loadingForm.Close();

    Enabled = true;
  }

  private async Task StartFirstInitialization(EnvironmentManager environmentManager)
  {
    using (var initializeConfigurationForm = new InitializeConfigurationForm())
    {
      var result = initializeConfigurationForm.ShowDialog();

      if (result != DialogResult.OK)
        throw new NotImplementedException();

      _azureTableKonfiguration = initializeConfigurationForm.AzureTableKonfiguration;
      await environmentManager.Save(_azureTableKonfiguration, "COIT_TOOLKIT_DATABASE_CONNECTIONSTRING");
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
