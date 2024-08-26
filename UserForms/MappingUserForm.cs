using System.Collections.Immutable;
using System.Text;
using coIT.AbsencesExport.Mapping;
using CSharpFunctionalExtensions;
using Newtonsoft.Json;

namespace coIT.AbsencesExport.UserForms;

public partial class MappingUserForm<TSource, TTarget> : UserControl
    where TSource : class, IEquatable<TSource>, IEquatable<int>, IComparable<TSource>
    where TTarget : class, IEquatable<TTarget>, IEquatable<int>, IComparable<TTarget>
{
    private string _configurationPointerFile =>
        Path.Combine(
            Directory.GetCurrentDirectory(),
            "config",
            $"{_savePathStart}-mapping-pointer.json"
        );

    private ConfigurationFilesInfo _configurationFilesInfo;

    private string? _configurationPath;
    private string _savePathStart;
    private readonly Func<TSource, object> _getSourceKey;
    private readonly Func<TTarget, object> _getTargetKey;

    private AbsenceTypeRelations<TSource, TTarget> _relations;

    private readonly HashSet<TSource> _sourceTypes;

    private readonly HashSet<TTarget> _targetTypes;

    public MappingUserForm(
        string savePathStart,
        HashSet<TSource> sourceTypes,
        Func<TSource, object> getSourceKey,
        string sourceName,
        HashSet<TTarget> targetTypes,
        Func<TTarget, object> getTargetKey,
        string targetName
    )
    {
        InitializeComponent();

        _savePathStart = savePathStart;
        _sourceTypes = sourceTypes;
        _getSourceKey = getSourceKey;

        _targetTypes = targetTypes;
        _getTargetKey = getTargetKey;

        lblSourceSystem.Text = sourceName;
        lblTargetSystem.Text = targetName;

        AddTextWrap(lbxAbsenceTypesTargetSystem);
        AddTextWrap(lbxAbsenceTypesSourceSystem);
        AddTextWrap(lbxIgnoredRelations);
        AddTextWrap(lbxRelationsWithExport);
        AddTextWrap(lbxRelationsWithoutExport);
    }

    public bool LoadedCorrectly { get; private set; } = true;
    public string LoadErrorMessage { get; private set; } = string.Empty;

    public bool AllMapped => _relations.NotMappedFromSourceToTarget().Count == 0;

    internal List<AbwesenheitseintragOhneMapping<TTarget>> MapAbsencesToTarget<TSource, TTarget>(
        List<Abwesenheitseintrag<TSource, TTarget>> exportAbsences
    )
        where TSource : class, IEquatable<TSource>, IEquatable<int>, IComparable<TSource>
        where TTarget : class, IEquatable<TTarget>, IEquatable<int>, IComparable<TTarget>
    {
        return exportAbsences
            .Select(absenceWitMapping => new AbwesenheitseintragOhneMapping<TTarget>(
                absenceWitMapping.Name,
                absenceWitMapping.Personalnummer,
                absenceWitMapping.ZielTyp,
                absenceWitMapping.Start,
                absenceWitMapping.Ende,
                absenceWitMapping.AbwesenheitsTage
            ))
            .ToList();
    }

    internal IImmutableList<Abwesenheitseintrag<TSource, TTarget>> MapAbsencesFromSource(
        IImmutableList<AbwesenheitseintragOhneMapping<TSource>> absencesWithoutMapping
    )
    {
        return absencesWithoutMapping
            .Select(absenceWithoutMapping => new Abwesenheitseintrag<TSource, TTarget>(
                absenceWithoutMapping.Name,
                absenceWithoutMapping.Personalnummer,
                absenceWithoutMapping.AbsenceType,
                GetMappedTargetType(absenceWithoutMapping.AbsenceType),
                absenceWithoutMapping.Start,
                absenceWithoutMapping.Ende,
                absenceWithoutMapping.AbwesenheitsTage
            ))
            .ToImmutableList();
    }

    public static async Task<MappingUserForm<TSource, TTarget>> Create(
        string pathAddon,
        HashSet<TSource> sourceTypes,
        Func<TSource, object> getSourceKey,
        string sourceName,
        HashSet<TTarget> targetTypes,
        Func<TTarget, object> getTargetKey,
        string targetName
    )
    {
        var form = new MappingUserForm<TSource, TTarget>(
            pathAddon,
            sourceTypes,
            getSourceKey,
            sourceName,
            targetTypes,
            getTargetKey,
            targetName
        );

        await form.LoadMappingFileList();
        form.UpdateListBoxes();

        return form;
    }

    public TTarget? GetMappedTargetType(TSource sourceAbsenceType)
    {
        return _relations.GetMappedTargetType(sourceAbsenceType);
    }

    public bool IsExport(TSource sourceAbsenceType)
    {
        return _relations.IsExport(sourceAbsenceType);
    }

    private async Task LoadMappingFileList()
    {
        await LoadJsonFile<ConfigurationFilesInfo>(_configurationPointerFile)
            .Tap(configurationFileInfoList => _configurationFilesInfo = configurationFileInfoList)
            .Tap(_ => UpdateConfigurationFileList())
            .Tap(configurationFileInfoList =>
                SelectMappingFile(configurationFileInfoList.Files.First())
            )
            .TapError(DisplayError);
    }

    private async Task SelectMappingFile(ConfigurationFileInfo mappingFileInfo)
    {
        var fileInfo = new FileInfo(mappingFileInfo.Path);
        var repository = new IdExportRelations(fileInfo);
        _relations = await AbsenceTypeRelations<TSource, TTarget>.Initialize(
            _sourceTypes,
            _getSourceKey,
            _targetTypes,
            _getTargetKey,
            repository
        );

        cbxConfigurationFiles.SelectedItem = mappingFileInfo;
        _configurationPath = mappingFileInfo.Path;

        if (IsHandleCreated)
            lblUnsavedChanges.BeginInvoke(() => lblUnsavedChanges.Visible = false);
    }

    private void UpdateConfigurationFileList()
    {
        cbxConfigurationFiles.Items.Clear();
        cbxConfigurationFiles.Items.AddRange(_configurationFilesInfo.Files.ToArray());
    }

    private void UpdateListBoxes()
    {
        lbxAbsenceTypesTargetSystem.Items.Clear();
        lbxAbsenceTypesTargetSystem.Items.AddRange(_targetTypes.ToArray());

        if (_relations is null)
            return;

        lbxAbsenceTypesSourceSystem.Items.Clear();
        lbxAbsenceTypesSourceSystem.Items.AddRange(
            _relations.NotMappedFromSourceToTarget().ToArray()
        );

        lbxIgnoredRelations.Items.Clear();
        lbxIgnoredRelations.Items.AddRange(
            _relations.MappedButIgnored().OrderBy(relation => relation.Source).ToArray()
        );

        lbxRelationsWithExport.Items.Clear();
        lbxRelationsWithExport.Items.AddRange(
            _relations
                .MappedWithoutIgnored()
                .Where(relation => relation.Export)
                .OrderBy(relation => relation.Source)
                .ToArray()
        );

        lbxRelationsWithoutExport.Items.Clear();
        lbxRelationsWithoutExport.Items.AddRange(
            _relations
                .MappedWithoutIgnored()
                .Where(relation => relation.Export is not true)
                .OrderBy(relation => relation.Source)
                .ToArray()
        );
    }

    private void DisplayError(string error)
    {
        LoadErrorMessage = error;
        LoadedCorrectly = false;
    }

    private void btnIgnoreSourceAbsence_Click(object sender, EventArgs e)
    {
        foreach (var selectedItem in lbxAbsenceTypesSourceSystem.SelectedItems)
            _relations.Ignore((TSource)selectedItem);

        lblUnsavedChanges.Visible = true;
        UpdateListBoxes();
    }

    private void btnCrateMapping_Click(object sender, EventArgs e)
    {
        var maybeSourceAbsenceType = MaybeSelected<TSource>(lbxAbsenceTypesSourceSystem);
        var maybeTargetAbsenceType = MaybeSelected<TTarget>(lbxAbsenceTypesTargetSystem);

        if (maybeTargetAbsenceType.HasNoValue || maybeSourceAbsenceType.HasNoValue)
        {
            MessageBox.Show("Bitte je einen Abwesenheitstyp aus Quell- und Zielsystem auswählen!");
            return;
        }

        maybeTargetAbsenceType
            .Map(_ =>
                AbsenceTypeRelation<TSource, TTarget>.Create(
                    maybeSourceAbsenceType.Value,
                    maybeTargetAbsenceType.Value
                )
            )
            .Execute(relation =>
            {
                _relations.Map(relation);
                ListBoxesChanged();
            });
    }

    private async void btnLoadConfig_Click(object sender, EventArgs e) { }

    private void btnMarkRelationForExport_Click(object sender, EventArgs e)
    {
        MaybeSelected<AbsenceTypeRelation<TSource, TTarget>>(lbxRelationsWithoutExport)
            .Map(relation => relation.Export = true)
            .Execute(_ => ListBoxesChanged());
    }

    private void btnDeleteRelation_Click(object sender, EventArgs e)
    {
        var maybeRelationWithoutExportSelected = MaybeSelected<
            AbsenceTypeRelation<TSource, TTarget>
        >(lbxRelationsWithoutExport);
        var maybeRelationWithExportSelected = MaybeSelected<AbsenceTypeRelation<TSource, TTarget>>(
            lbxRelationsWithExport
        );

        maybeRelationWithoutExportSelected.Execute(relation => _relations.Unmap(relation));

        maybeRelationWithExportSelected.Execute(relation => _relations.Unmap(relation));

        maybeRelationWithoutExportSelected
            .Or(maybeRelationWithExportSelected)
            .Execute(_ => ListBoxesChanged());
    }

    private void btnIgnoreRelationInExport_Click(object sender, EventArgs e)
    {
        MaybeSelected<AbsenceTypeRelation<TSource, TTarget>>(lbxRelationsWithExport)
            .Map(relation => relation.Export = false)
            .Execute(_ => ListBoxesChanged());
    }

    private void btnUnignoreSourceType_Click(object sender, EventArgs e)
    {
        MaybeSelected<AbsenceTypeRelation<TSource, TTarget>>(lbxIgnoredRelations)
            .Execute(relation =>
            {
                _relations.Unmap(relation);
                ListBoxesChanged();
            });
    }

    private void ListBoxesChanged()
    {
        lblUnsavedChanges.Visible = true;
        UpdateListBoxes();
    }

    private Maybe<T> MaybeSelected<T>(ListBox listBox)
    {
        return listBox.SelectedItem is null ? Maybe<T>.None : Maybe.From((T)listBox.SelectedItem);
    }

    private async Task<Result<T?>> LoadJsonFile<T>(string file)
    {
        return await Result
            .SuccessIf(File.Exists(file), $"Datei '{file}' konnte nicht gefunden werden.")
            .MapTry(() => File.ReadAllTextAsync(file, Encoding.UTF8))
            .MapTry(
                content => JsonConvert.DeserializeObject<T>(content),
                ex => $"Datei '{file}' ist ungültig: " + ex.Message
            )
            .Ensure(setting => setting is not null, $"Datei '{file}' war leer.");
    }

    private async void btnStoreConfig_Click(object sender, EventArgs e)
    {
        var serializedPointerFile = JsonConvert.SerializeObject(_configurationFilesInfo);
        File.WriteAllText(_configurationPointerFile, serializedPointerFile, Encoding.UTF8);

        await _relations.Save();

        lblUnsavedChanges.Visible = false;
    }

    private void AddTextWrap(ListBox listBox)
    {
        listBox.DrawMode = DrawMode.OwnerDrawVariable;
        listBox.MeasureItem += lst_MeasureItem;
        listBox.DrawItem += lst_DrawItem;

        void lst_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)
                e
                    .Graphics.MeasureString(
                        listBox.Items[e.Index].ToString(),
                        listBox.Font,
                        listBox.Width
                    )
                    .Height;
        }

        void lst_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            e.Graphics.DrawString(
                listBox.Items[e.Index].ToString(),
                e.Font,
                new SolidBrush(e.ForeColor),
                e.Bounds
            );
        }
    }

    private void btnNewConfig_Click(object sender, EventArgs e)
    {
        var textInputeForm = new TextInputForm(
            "Neue Konfiguration erstellen",
            "Konfigurationsname eingeben",
            "Konfiguration erstellen"
        );
        textInputeForm.ShowDialog();
        var input = textInputeForm.UserInput;

        var newConfigurationFileInfo = new ConfigurationFileInfo
        {
            Path = Path.Combine(
                _configurationFilesInfo.BasePath,
                $"clockodo-mapping-settings-{input}.json"
            ),
            Name = input
        };

        _configurationFilesInfo.Files.Add(newConfigurationFileInfo);
        UpdateConfigurationFileList();
        SelectMappingFile(newConfigurationFileInfo);
    }

    private async void cbxConfigurationFiles_SelectedValueChanged(object sender, EventArgs e)
    {
        var selectedConfig = (ConfigurationFileInfo)cbxConfigurationFiles.SelectedItem;
        await SelectMappingFile(selectedConfig);
        UpdateListBoxes();
    }
}

internal class ConfigurationFilesInfo
{
    public List<ConfigurationFileInfo> Files { get; set; }
    public string BasePath { get; set; }
}

internal class ConfigurationFileInfo
{
    public string Path { get; set; }
    public string Name { get; set; }

    public override string ToString() => Name;
}
