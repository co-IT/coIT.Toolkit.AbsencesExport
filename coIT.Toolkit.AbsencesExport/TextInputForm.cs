﻿namespace coIT.Toolkit.AbsencesExport;

public partial class TextInputForm : Form
{
  public TextInputForm(string title, string description, string buttonText)
  {
    InitializeComponent();
    Text = title;
    lblDescription.Text = description;
    btnClose.Text = buttonText;
  }

  public string UserInput { get; private set; }

  private void btnClose_Click(object sender, EventArgs e)
  {
    UserInput = tbxTextInput.Text;
    Close();
  }
}
