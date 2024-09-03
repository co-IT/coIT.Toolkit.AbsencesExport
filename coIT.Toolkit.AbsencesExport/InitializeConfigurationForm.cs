using coIT.AbsencesExport.Configurations;
using coIT.Libraries.Gdi.HumanResources;
using coIT.Toolkit.AbsencesExport;

namespace coIT.AbsencesExport
{
    public partial class InitializeConfigurationForm : Form
    {
        public AzureTableKonfiguration AzureTableKonfiguration { get; private set; }

        public InitializeConfigurationForm()
        {
            InitializeComponent();
        }

        private void btnCreateConfig_Click(object sender, EventArgs e)
        {
            AzureTableKonfiguration = new AzureTableKonfiguration { ConnectionString = tbxConnectionString.Text };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
