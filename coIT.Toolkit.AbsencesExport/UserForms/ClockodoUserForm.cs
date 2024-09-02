using System.Collections.Immutable;
using coIT.AbsencesExport.Configurations;
using coIT.Libraries.Clockodo.Absences;
using coIT.Libraries.Clockodo.Absences.Contracts;
using coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.ClockodoAbwesenheitsTypen;
using CSharpFunctionalExtensions;

namespace coIT.AbsencesExport.UserForms;

public partial class ClockodoUserForm : UserControl, IExportAbsences<ClockodoAbsenceType>
{
    private HashSet<ClockodoAbsenceType> _absenceTypes = new();
    private AbsencesService _clockodoService;
    private IImmutableList<EmployeeInfo> _employeeInfos;

    private readonly AppConfiguration _appConfig;
    private readonly IClockodoAbwesenheitsTypRepository _abwesenheitsTypRepository;

    public static async Task<ClockodoUserForm> Create(
        AppConfiguration appConfig,
        IClockodoAbwesenheitsTypRepository abwesenheitsTypRepository
    )
    {
        var userForm = new ClockodoUserForm(appConfig, abwesenheitsTypRepository);
        await userForm.LoadConfiguration();
        userForm.UpdateDisplay();
        return userForm;
    }

    private ClockodoUserForm()
    {
        InitializeComponent();
    }

    private ClockodoUserForm(
        AppConfiguration appConfig,
        IClockodoAbwesenheitsTypRepository abwesenheitsTypRepository
    )
        : this()
    {
        _appConfig = appConfig;
        _abwesenheitsTypRepository = abwesenheitsTypRepository;
    }

    public bool LoadedCorrectly { get; private set; } = true;
    public string LoadErrorMessage { get; private set; } = string.Empty;

    public async Task<
        IImmutableList<AbwesenheitseintragOhneMapping<ClockodoAbsenceType>>
    > AllAbsences(DateTime start, DateTime ende, LoadingForm loadingForm)
    {
        var periodfilter = ClockodoPeriodFilter.Create(start, ende);

        if (periodfilter.IsFailure)
        {
            MessageBox.Show(periodfilter.Error);
            return new List<
                AbwesenheitseintragOhneMapping<ClockodoAbsenceType>
            >().ToImmutableList();
        }

        var test = await _clockodoService.AllAbsences(periodfilter.Value);
        loadingForm.Hide();

        return test.Select(absence => new AbwesenheitseintragOhneMapping<ClockodoAbsenceType>(
                _employeeInfos.FirstOrDefault(e => e.Id == absence.UserId).Name,
                _employeeInfos.FirstOrDefault(e => e.Id == absence.UserId).Number,
                absence.AbsenceType,
                absence.Start,
                absence.End,
                absence.Duration
            ))
            .ToImmutableList();
    }

    public UserControl GetControl() => this;

    public string GetLoadErrorMessage() => LoadErrorMessage;

    public bool HasLoadedCorrectly() => LoadedCorrectly;

    public HashSet<ClockodoAbsenceType> GetAllAbsenceTypes()
    {
        return _absenceTypes;
    }

    private async Task LoadConfiguration()
    {
        AbsencesService service = null;
        IImmutableList<EmployeeInfo> employees = null;

        await _abwesenheitsTypRepository
            .GetAll()
            .Tap(abwesenheitsTypen => _absenceTypes = abwesenheitsTypen)
            .Bind(_ => _appConfig.Load<ClockodoConfiguration>())
            .MapTry(
                async config =>
                    service = new AbsencesService(config.Settings, config.AbsenceTypes.ToList()),
                ex => "Verbindung zu TimeCard konnte nicht hergestellt werden"
            )
            .MapTry(
                async clockodoService => employees = await clockodoService.AllEmployees(),
                ex => "TimeCard Mitarbeiterliste konnte nicht abgerufen werden"
            )
            .TapError(DisplayError);

        _clockodoService = service;
        _employeeInfos = employees;
    }

    private void UpdateDisplay()
    {
        DisplayConfiguration();
        DisplayAbsenceTypeList();
    }

    private void DisplayConfiguration()
    {
        var config = _appConfig.Load<ClockodoConfiguration>();
        if (config.IsFailure)
            return;

        tbxApiUser.Text = config.Value.Settings?.EmailAddress ?? string.Empty;
        tbxApiSchluessel.Text = config.Value.Settings?.ApiToken ?? string.Empty;
    }

    private void DisplayAbsenceTypeList()
    {
        lbxAbsenceTypes.Items.Clear();
        var orderedAbsenceArray = _absenceTypes.OrderBy(a => a.DisplayText).ToArray();
        lbxAbsenceTypes.Items.AddRange(orderedAbsenceArray);
    }

    private void DisplayError(string error)
    {
        LoadErrorMessage = error;
        LoadedCorrectly = false;
    }
}
