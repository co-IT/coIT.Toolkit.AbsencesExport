using System.Collections.Immutable;
using coIT.Libraries.Clockodo.Absences;
using coIT.Libraries.Clockodo.Absences.Contracts;
using coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.ClockodoAbwesenheitsTypen;
using coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Konfiguration.ClockodoKonfiguration;
using CSharpFunctionalExtensions;

namespace coIT.Toolkit.AbsencesExport.UserForms;

public partial class ClockodoUserForm : UserControl, IExportAbsences<ClockodoAbsenceType>
{
    private HashSet<ClockodoAbsenceType> _absenceTypes = new();
    private AbsencesService _clockodoService;
    private IImmutableList<EmployeeInfo> _employeeInfos;

    private readonly IClockodoKonfigurationRepository _clockodoConfiguration;
    private readonly IClockodoAbwesenheitsTypRepository _abwesenheitsTypRepository;

    public static async Task<ClockodoUserForm> Create(
        IClockodoKonfigurationRepository clockodoConfiguration,
        IClockodoAbwesenheitsTypRepository abwesenheitsTypRepository
    )
    {
        var userForm = new ClockodoUserForm(clockodoConfiguration, abwesenheitsTypRepository);
        await userForm.LoadConfiguration();
        await userForm.UpdateDisplay();
        return userForm;
    }

    private ClockodoUserForm()
    {
        InitializeComponent();
    }

    private ClockodoUserForm(
        IClockodoKonfigurationRepository clockodoConfiguration,
        IClockodoAbwesenheitsTypRepository abwesenheitsTypRepository
    )
        : this()
    {
        _clockodoConfiguration = clockodoConfiguration;
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
            .BindZip(typen => _clockodoConfiguration.Get())
            .MapTry(
                config => service = new AbsencesService(config.Second, config.First.ToList()),
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

    private async Task UpdateDisplay()
    {
        await DisplayConfiguration();
        DisplayAbsenceTypeList();
    }

    private async Task DisplayConfiguration()
    {
        var config = await _clockodoConfiguration.Get();
        if (config.IsFailure)
            return;

        tbxApiUser.Text = config.Value.EmailAddress ?? string.Empty;
        tbxApiSchluessel.Text = config.Value.ApiToken ?? string.Empty;
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
