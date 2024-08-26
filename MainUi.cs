using System.Collections.Immutable;
using System.ComponentModel;
using coIT.AbsencesExport.Specifications;
using coIT.AbsencesExport.UserForms;
using coIT.Libraries.WinForms.DateTimeButtons;

namespace coIT.AbsencesExport
{
    public partial class MainUi<TSource, TTarget> : UserControl
        where TSource : class, IEquatable<TSource>, IEquatable<int>, IComparable<TSource>
        where TTarget : class, IEquatable<TTarget>, IEquatable<int>, IComparable<TTarget>
    {
        private readonly string _absenceSourceName;
        private readonly string _absenceTargetName;

        private readonly IExportAbsences<TSource> _absencesSource;
        private readonly IImportAbsences<TTarget> _absencesTarget;

        private readonly MappingUserForm<TSource, TTarget> _mappingControl;

        private AktivierteFilter<TSource, TTarget> _aktivierteMitarbeiterFilter =
            new AktivierteFilter<TSource, TTarget>();

        private Func<TSource, object> _getSourceKey;
        private Func<TTarget, object> _getTargetKey;

        public IImmutableList<Abwesenheitseintrag<TSource, TTarget>> Abwesenheiten = new List<
            Abwesenheitseintrag<TSource, TTarget>
        >().ToImmutableList();

        internal MainUi(
            MappingUserForm<TSource, TTarget> mappingControl,
            IExportAbsences<TSource> absencesSource,
            Func<TSource, object> getSourceKey,
            string absenceSourceName,
            IImportAbsences<TTarget> absencesTarget,
            Func<TTarget, object> getTargetKey,
            string absenceTargetName
        )
        {
            InitializeComponent();
            ((Control)this.tbpAnzeige).Enabled = false;

            _absenceSourceName = absenceSourceName;
            _absenceTargetName = absenceTargetName;

            _mappingControl = mappingControl;
            _absencesSource = absencesSource;
            _absencesTarget = absencesTarget;

            _getSourceKey = getSourceKey;
            _getTargetKey = getTargetKey;
        }

        private async void MainUi_Load(object sender, EventArgs e)
        {
            tbpAbsenceExportSettings.Text = _absenceSourceName;
            tbgAbsenceImportSettings.Text = _absenceTargetName;

            var targetControl = _absencesTarget.GetControl();
            tbgAbsenceImportSettings.Controls.Add(targetControl);
            targetControl.Dock = DockStyle.Fill;

            if (!_absencesTarget.HasLoadedCorrectly())
                MessageBox.Show(_absencesTarget.GetLoadErrorMessage(), nameof(_absencesTarget));

            var sourceControl = _absencesSource.GetControl();
            tbpAbsenceExportSettings.Controls.Add(sourceControl);
            sourceControl.Dock = DockStyle.Fill;

            if (!_absencesSource.HasLoadedCorrectly())
                MessageBox.Show(_absencesSource.GetLoadErrorMessage(), nameof(_absencesSource));

            tbpRelations.Controls.Add(_mappingControl);
            _mappingControl.Dock = DockStyle.Fill;

            if (!_mappingControl.LoadedCorrectly)
                MessageBox.Show(_mappingControl.LoadErrorMessage, "Beziehungs Konfiguration");
            if (!_mappingControl.AllMapped)
                MessageBox.Show(
                    "Bitte für alle Abwesenheitstypen eine Beziehung festlegen oder sie ignorieren",
                    $"{_absenceSourceName} zu {_absenceTargetName}"
                );

            if (
                !_mappingControl.LoadedCorrectly
                || !_mappingControl.AllMapped
                || !_absencesSource.HasLoadedCorrectly()
                || !_absencesTarget.HasLoadedCorrectly()
            )
            {
                tabControl1.SelectedTab = tbpEinstellungen;

                SetTabControlChildren(tbpAnzeige, false);
            }

            LetztenMonatAlsZeitraumSetzen();

            btnAktualisieren.Click += async (_, _) =>
            {
                Enabled = false;
                Abwesenheiten = await AbwesenheitenAbfragen(_absencesSource.GetAllAbsenceTypes());
                MitarbeiterListeAktualisieren(Abwesenheiten);
                MitarbeiterFilterSetzen();
                TabelleAktualisieren();
                Enabled = true;
            };

            ((Control)this.tbpAnzeige).Enabled = true;
        }

        private void MitarbeiterListeAktualisieren(
            IImmutableList<Abwesenheitseintrag<TSource, TTarget>> abwesenheiten
        )
        {
            clbxMitarbeiterFilter.Items.Clear();

            var auswahl = abwesenheiten
                .Select(a => (a.Name, a.Personalnummer))
                .Distinct()
                .OrderBy(t => t.Name)
                .ToList();

            auswahl.ForEach(t =>
                clbxMitarbeiterFilter.Items.Add($"{t.Name} | {t.Personalnummer}", true)
            );
        }

        private void MitarbeiterFilterSetzen()
        {
            MitarbeiterListeAktualisieren(Abwesenheiten);
            MitarbeiterFilterAktivieren();

            clbxMitarbeiterFilter.SelectedValueChanged += (_, _) =>
            {
                MitarbeiterFilterAktivieren();
                TabelleAktualisieren();
            };
        }

        public void MitarbeiterFilterAktivieren()
        {
            foreach (var mitarbeiter in clbxMitarbeiterFilter.Items)
            {
                _aktivierteMitarbeiterFilter.WerteFilterAktivierenOderDeaktivieren(
                    clbxMitarbeiterFilter.CheckedItems.Contains(mitarbeiter),
                    new MitarbeiterSpezifikation<TSource, TTarget>((string)mitarbeiter)
                );
            }
        }

        private void BtnEigenenZeitraumExportieren_Click(object sender, EventArgs e)
        {
            var gefilterteAbwesenheiten = GefilterteAbwesenheitenErhalten();
            AbwesenheitenExportieren(gefilterteAbwesenheiten);
        }

        private void BtnLetzterMonat_Click(object sender, EventArgs e)
        {
            LetztenMonatAlsZeitraumSetzen();
        }

        private void LetztenMonatAlsZeitraumSetzen()
        {
            var irgendwannLetzterMonat = DateTime.Now.AddMonths(-1);
            var anfangLetzterMonat = irgendwannLetzterMonat.GetFirstDayInMonth();
            var endeLetzterMonat = irgendwannLetzterMonat.GetLastDayInMonth();

            dtpEigenerZeitraumStart.Value = anfangLetzterMonat;
            dtpEigenerZeitraumEnde.Value = endeLetzterMonat;
        }

        private void BtnDieserMonat_Click(object sender, EventArgs e)
        {
            var anfangDieserMonat = DateTime.Now.GetFirstDayInMonth();

            dtpEigenerZeitraumStart.Value = anfangDieserMonat;
            dtpEigenerZeitraumEnde.Value = DateTime.Now.Date;
        }

        private IImmutableList<Abwesenheitseintrag<TSource, TTarget>> AbwesenheitenFiltern(
            IImmutableList<Abwesenheitseintrag<TSource, TTarget>> absences,
            Spezifikation<Abwesenheitseintrag<TSource, TTarget>> spezifikationen
        )
        {
            return absences
                .ToList()
                .Where(abwesenheit => spezifikationen.IsSatisfiedBy(abwesenheit))
                .ToImmutableList();
        }

        private void AbwesenheitenExportieren(
            IImmutableList<Abwesenheitseintrag<TSource, TTarget>> gefilterteAbwesenheiten
        )
        {
            var exportAbsences = gefilterteAbwesenheiten
                .Where(a => _mappingControl.IsExport(a.AusgangsTyp))
                .ToList();

            List<AbwesenheitseintragOhneMapping<TTarget>> absencesMappedToTarget =
                _mappingControl.MapAbsencesToTarget(exportAbsences);

            _absencesTarget.ExportAbsences(absencesMappedToTarget);
        }

        private void UpdateUi(IImmutableList<Abwesenheitseintrag<TSource, TTarget>> absences)
        {
            var bindingList = new SortableBindingList<Abwesenheitseintrag<TSource, TTarget>>(
                absences.ToList()
            );
            var source = new BindingSource(bindingList, null);

            dgvDateneintraege.DataSource = source;
            TabellenEinstellungenAnwenden();

            Update();
        }

        private void TabellenEinstellungenAnwenden()
        {
            foreach (DataGridViewColumn column in dgvDateneintraege.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }

            dgvDateneintraege.Columns[1].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            dgvDateneintraege.Columns[6].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            dgvDateneintraege.Columns[7].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            dgvDateneintraege.Sort(dgvDateneintraege.Columns[1], ListSortDirection.Ascending);
        }

        private async Task<
            IImmutableList<Abwesenheitseintrag<TSource, TTarget>>
        > AbwesenheitenAbfragen(HashSet<TSource> absenceTypes)
        {
            var start = dtpEigenerZeitraumStart.Value;
            var ende = dtpEigenerZeitraumEnde.Value;

            var loadingForm = new LoadingForm();
            loadingForm.Show();

            var absencesWithoutMapping = _absencesSource.AllAbsences(start, ende, loadingForm);
            var absencesWithMapping = _mappingControl.MapAbsencesFromSource(
                await absencesWithoutMapping
            );
            var absencesThatAreNotIgnored = absencesWithMapping
                .Where(absence => absence.ZielTyp is not null)
                .ToImmutableList();
            return absencesThatAreNotIgnored;
        }

        private IImmutableList<
            Abwesenheitseintrag<TSource, TTarget>
        > GefilterteAbwesenheitenErhalten()
        {
            var mitarbeiterFilter = _aktivierteMitarbeiterFilter.Kombinieren();
            var noPertialSicknessDaysFilter = new IsHalfSicknessDay<TSource, TTarget>().Not();

            var mitarbeiterUndKrankheitsFilter = mitarbeiterFilter.And(noPertialSicknessDaysFilter);

            var gefilterteAbwesenheiten = AbwesenheitenFiltern(
                Abwesenheiten,
                mitarbeiterUndKrankheitsFilter
            );

            return gefilterteAbwesenheiten.ToImmutableList();
        }

        private void TabelleAktualisieren()
        {
            var insgesamtGefilterteAbwesenheiten = GefilterteAbwesenheitenErhalten();
            UpdateUi(insgesamtGefilterteAbwesenheiten);
        }

        /// <summary>
        ///     Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void SetTabControlChildren(Control control, bool enabled)
        {
            foreach (Control child in control.Controls)
                child.Enabled = enabled;
        }

        private void tabControl1_TabIndexChanged(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tbpAnzeige && !_mappingControl.AllMapped)
            {
                MessageBox.Show(
                    "Bitte für alle Abwesenheitstypen eine Beziehung festlegen oder sie ignorieren",
                    $"{_absenceSourceName} zu {_absenceTargetName}"
                );

                SetTabControlChildren(tbpAnzeige, false);
            }
            else
            {
                SetTabControlChildren(tbpAnzeige, true);
            }
        }
    }
}
