namespace coIT.AbsencesExport
{
    public partial class TextInputForm : Form
    {
        public string UserInput { get; private set; }

        public TextInputForm(string title, string description, string buttonText)
        {
            InitializeComponent();
            Text = title;
            lblDescription.Text = description;
            btnClose.Text = buttonText;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            UserInput = tbxTextInput.Text;
            Close();
        }
    }
}
