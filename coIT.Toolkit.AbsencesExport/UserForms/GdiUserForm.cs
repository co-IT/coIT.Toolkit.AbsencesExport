using System.Text;
using coIT.AbsencesExport.Configurations;
using coIT.Libraries.Gdi.HumanResources;
using coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.GdiAbwesenheitsTypen;
using CSharpFunctionalExtensions;

namespace coIT.AbsencesExport.UserForms
{
    public partial class GdiUserForm : UserControl, IImportAbsences<GdiAbsenceType>
    {
        private readonly IGdiAbwesenheitRepository _repository;
        private HashSet<GdiAbsenceType> _absenceTypes = new();

        public bool LoadedCorrectly { get; private set; } = true;
        public string LoadErrorMessage { get; private set; } = string.Empty;

        public static async Task<GdiUserForm> Create(IGdiAbwesenheitRepository repository)
        {
            var gdiForm = new GdiUserForm(repository);
            await gdiForm.LoadConfiguration();
            return gdiForm;
        }

        private GdiUserForm()
        {
            InitializeComponent();
        }

        private GdiUserForm(IGdiAbwesenheitRepository repository)
            : this()
        {
            _repository = repository;
        }

        public void ExportAbsences(
            List<AbwesenheitseintragOhneMapping<GdiAbsenceType>> gefilterteAbwesenheiten
        )
        {
            if (gefilterteAbwesenheiten.Count == 0)
            {
                MessageBox.Show(
                    $"Die Liste der Abwesenheiten ist leer.{Environment.NewLine}Export wurde abgebrochen!",
                    "Exportfehler",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            var csvLines = new StringBuilder();

            foreach (var abwesenheit in gefilterteAbwesenheiten)
            {
                if (abwesenheit.AbsenceType is null)
                    continue;

                var gdiApi = new GdiApi(abwesenheit.AbsenceType);

                csvLines.AppendLine(
                    gdiApi
                        .SetPersonalnr(abwesenheit.Personalnummer)
                        .SetFehlzeitennr(abwesenheit.AbsenceType)
                        .SetMonat(abwesenheit.Start.Month)
                        .SetBeginn(abwesenheit.Start)
                        .SetEnde(abwesenheit.Ende)
                        .SetGanzeTage(
                            Math.Round(abwesenheit.AbwesenheitsTage)
                                .Equals(abwesenheit.AbwesenheitsTage)
                        )
                        .SetAnzahlTage(abwesenheit.AbwesenheitsTage)
                        .SetBemerkungZuFehlzeit(string.Empty)
                        .GetCsvLine()
                );
            }

            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            SaveFileDialog1.Title = "Speicherort für Export auswählen";
            SaveFileDialog1.Filter = "GDI Datei (*.csv)|*.csv";
            SaveFileDialog1.DefaultExt = "csv";
            SaveFileDialog1.CheckPathExists = true;
            SaveFileDialog1.FileName = "heco-timecard-";
            SaveFileDialog1.RestoreDirectory = true;

            if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(SaveFileDialog1.FileName, csvLines.ToString(), Encoding.UTF8);
                System.Diagnostics.Process.Start(
                    "explorer.exe",
                    $"/select, \"{SaveFileDialog1.FileName}\""
                );
            }
        }

        private async Task LoadConfiguration()
        {
            await _repository
                .GetAll()
                .Tap(abwesenheitsTypen => _absenceTypes = abwesenheitsTypen)
                .TapError(DisplayError)
                .OnSuccessTry(_ => DisplayAbsenceTypeList());
        }

        private void DisplayAbsenceTypeList()
        {
            lbxAbsenceTypes.Items.Clear();

            var orderedAbsenceArray = _absenceTypes
                .OrderBy(absence => absence.DisplayText)
                .ToArray();

            lbxAbsenceTypes.Items.AddRange(orderedAbsenceArray);
        }

        private void DisplayError(string error)
        {
            LoadErrorMessage = error;
            LoadedCorrectly = false;
        }

        public HashSet<GdiAbsenceType> GetAllAbsenceTypes() => _absenceTypes;

        public UserControl GetControl() => this;

        public bool HasLoadedCorrectly() => LoadedCorrectly;

        public string GetLoadErrorMessage() => LoadErrorMessage;
    }
}
