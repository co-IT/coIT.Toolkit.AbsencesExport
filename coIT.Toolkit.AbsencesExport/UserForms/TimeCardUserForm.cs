using System.Collections.Immutable;
using coIT.AbsencesExport.Configurations;
using coIT.Libraries.TimeCard;
using coIT.Libraries.TimeCard.DataContracts;
using CSharpFunctionalExtensions;

namespace coIT.AbsencesExport.UserForms;

public partial class TimeCardUserForm : UserControl, IExportAbsences<TimeCardAbsenceType>
{
    private readonly AppConfiguration _appConfig;
    private TimeCardService _timeCardService;

    private TimeCardUserForm()
    {
        InitializeComponent();
    }

    private TimeCardUserForm(AppConfiguration appConfig)
        : this()
    {
        _appConfig = appConfig;
    }

    public bool LoadedCorrectly { get; private set; } = true;
    public string LoadErrorMessage { get; private set; } = string.Empty;
    private HashSet<TimeCardAbsenceType> _absenceTypes = new();

    private int NoExportGroup
    {
        get
        {
            var config = _appConfig.Load<TimeCardConfiguration>();
            if (config.IsFailure)
                return -1;

            return config.Value.Settings.NoExportGroup;
        }
    }

    private IImmutableList<TimeCardEmployeesWithGroups> _employees =
        new List<TimeCardEmployeesWithGroups>().ToImmutableList();

    public static async Task<TimeCardUserForm> Create(AppConfiguration appConfig)
    {
        var userForm = new TimeCardUserForm(appConfig);

        await userForm.LoadConfiguration();
        userForm.UpdateDisplay();
        return userForm;
    }

    public async Task<
        IImmutableList<AbwesenheitseintragOhneMapping<TimeCardAbsenceType>>
    > AllAbsences(DateTime start, DateTime ende, LoadingForm loadingForm)
    {
        var rawAbsences = await ReceiveAllAbsences(start, ende, loadingForm);

        var holidayAbsenceType = _absenceTypes.FirstOrDefault(absence =>
            absence.ToString() == "Feiertag"
        );
        var feiertage = FilterHolidays(rawAbsences, holidayAbsenceType);
        var abwesenheitenGruppiert = GroupOngoingSingleDayEvents(rawAbsences, holidayAbsenceType);
        return AbwesenheitenMitMitarbeiterKombinieren(
            abwesenheitenGruppiert,
            _employees,
            feiertage
        );
    }

    private IImmutableList<
        AbwesenheitseintragOhneMapping<TimeCardAbsenceType>
    > AbwesenheitenMitMitarbeiterKombinieren(
        IImmutableList<GroupedTimeCardAbsence> absences,
        IImmutableList<TimeCardEmployeesWithGroups> alleMitarbeiter,
        ImmutableList<DateTime> feiertage
    )
    {
        var abwesenheiten = new List<AbwesenheitseintragOhneMapping<TimeCardAbsenceType>>();

        foreach (var abwesenheit in absences)
        {
            var mitarbeiter = alleMitarbeiter.Single(m => m.Id == abwesenheit.Employee);

            var name = mitarbeiter.Name;
            var nummer = mitarbeiter.PersonNo.ToString();

            var timeCardAbwesenheit = abwesenheit.AbsenceType;

            var anzahlTage = 1f;
            if (abwesenheit.Time.Contains("%"))
            {
                var bruchteilTagInProzent = abwesenheit.Time.Replace(" %", "");
                var bruchteilTag = int.Parse(bruchteilTagInProzent) / 100f;
                anzahlTage = bruchteilTag;
            }
            else if (abwesenheit.Time != "Ganzer Tag")
            {
                anzahlTage = 0.5f;
            }

            var nettoDuration = 0f;
            var current = abwesenheit.Date;

            while (current <= abwesenheit.End)
            {
                if (
                    current.DayOfWeek != DayOfWeek.Saturday
                    && current.DayOfWeek != DayOfWeek.Sunday
                )
                    nettoDuration++;

                current = current.AddDays(1);
            }
            ;

            foreach (var feiertag in feiertage)
            {
                if (feiertag <= abwesenheit.End && feiertag >= abwesenheit.Date)
                    nettoDuration -= 1;
            }

            if (nettoDuration == 1)
                nettoDuration = anzahlTage;

            abwesenheiten.Add(
                new AbwesenheitseintragOhneMapping<TimeCardAbsenceType>(
                    name,
                    int.Parse(nummer),
                    timeCardAbwesenheit,
                    abwesenheit.Date,
                    abwesenheit.End,
                    nettoDuration
                )
            );
        }

        return abwesenheiten.ToImmutableList();
    }

    private async Task<IImmutableList<TimeCardAbsence>> ReceiveAllAbsences(
        DateTime start,
        DateTime ende,
        LoadingForm loadingForm
    )
    {
        var current = start;

        var total = (ende - start).Days + 1;

        var absences = new List<TimeCardAbsence>();
        while (current <= ende)
        {
            var daysLeft = (ende - current).Days + 1;
            var daysDone = (float)total - daysLeft;
            var percent = (int)Math.Round((daysDone) / (float)(total) * 100);
            loadingForm.SetStatus($"{daysDone}/{total} Tage abgefragt", percent);

            if (current.DayOfWeek != DayOfWeek.Saturday && current.DayOfWeek != DayOfWeek.Sunday)
            {
                var getAbsencesTask = await _timeCardService.AllAbsences(
                    _employees.ToList(),
                    current
                );
                absences.AddRange(getAbsencesTask);
            }

            current = current.AddDays(1);
        }
        loadingForm.Hide();
        return absences.ToImmutableList();
    }

    private ImmutableList<DateTime> FilterHolidays(
        IImmutableList<TimeCardAbsence> absences,
        TimeCardAbsenceType holidayType
    )
    {
        return _timeCardService.FilterHolidays(absences, holidayType);
    }

    private ImmutableList<GroupedTimeCardAbsence> GroupOngoingSingleDayEvents(
        IImmutableList<TimeCardAbsence> absences,
        TimeCardAbsenceType holidayType
    )
    {
        return _timeCardService.GroupOngoingSingleDayEvents(absences, holidayType);
    }

    private async Task LoadConfiguration()
    {
        TimeCardService service = null;
        IImmutableList<TimeCardEmployeesWithGroups> employees = null;
        ImmutableHashSet<TimeCardAbsenceType> absenceTypes = null;

        await _appConfig
            .Load<TimeCardConfiguration>()
            .MapTry(
                async config => service = await StartTimeCardService(config.Settings),
                ex => "Verbindung zu TimeCard konnte nicht hergestellt werden"
            )
            .MapTry(
                async timecardService => employees = await timecardService.AllEmployees(),
                ex => "TimeCard Mitarbeiterliste konnte nicht abgerufen werden"
            )
            .MapTry(
                async _ => absenceTypes = await service.GetAllAbsenceTypes(),
                ex => "TimeCard Abwesenheitsliste konnte nicht abgerufen werden"
            )
            .TapError(DisplayError);

        _timeCardService = service;
        _employees = employees;
        _absenceTypes = absenceTypes.ToHashSet();
    }

    private void UpdateDisplay()
    {
        DisplayConfiguration();
        DisplayAbsenceTypeList();
    }

    private void DisplayError(string error)
    {
        LoadErrorMessage = error;
        LoadedCorrectly = false;
    }

    private void DisplayConfiguration()
    {
        var config = _appConfig.Load<TimeCardConfiguration>();
        if (config.IsFailure)
            return;

        tbxApiAddress.Text = config.Value.Settings.WebAddress;
        tbxApiUser.Text = config.Value.Settings.Username;
        tbxApiSchluessel.Text = config.Value.Settings.Password;
        nbxKeinExportGruppenId.Value = config.Value.Settings.NoExportGroup;
    }

    private void DisplayAbsenceTypeList()
    {
        lbxAbsenceTypes.Items.Clear();
        var orderedAbsenceArray = _absenceTypes.OrderBy(a => a.DisplayText).ToArray();
        lbxAbsenceTypes.Items.AddRange(orderedAbsenceArray);
    }

    private async Task<TimeCardService> StartTimeCardService(TimeCardSettings timeCardSettings)
    {
        var timeCardService = await TimeCardService.Login(timeCardSettings);

        return timeCardService;
    }

    private void btnStoreConfiguration_click(object sender, EventArgs e)
    {
        var config = new TimeCardSettings(
            tbxApiAddress.Text,
            tbxApiUser.Text,
            tbxApiSchluessel.Text,
            (int)nbxKeinExportGruppenId.Value
        );

        _appConfig.Save(new List<object> { config });
    }

    private async void btnLoadConfiguration_Click(object sender, EventArgs e)
    {
        await LoadConfiguration();
        UpdateDisplay();
    }

    public HashSet<TimeCardAbsenceType> GetAllAbsenceTypes() => _absenceTypes;

    public UserControl GetControl() => this;

    public bool HasLoadedCorrectly() => LoadedCorrectly;

    public string GetLoadErrorMessage() => LoadErrorMessage;

    private void TimeCardUserForm_Load(object sender, EventArgs e) { }
}
