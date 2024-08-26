namespace coIT.AbsencesExport
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
        }

        public void SetStatus(string text, int percent)
        {
            lblStatusText.Text = text;
            pgbStatus.Value = percent;
        }
    }
}
