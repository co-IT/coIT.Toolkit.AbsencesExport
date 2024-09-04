namespace coIT.Toolkit.AbsencesExport;

public partial class InitializeConfigurationForm : Form
{
  public InitializeConfigurationForm()
  {
    InitializeComponent();
  }

  public AzureTableKonfiguration AzureTableKonfiguration { get; private set; }

  private void btnCreateConfig_Click(object sender, EventArgs e)
  {
    AzureTableKonfiguration = new AzureTableKonfiguration { ConnectionString = tbxConnectionString.Text };

    DialogResult = DialogResult.OK;
    Close();
  }
}
