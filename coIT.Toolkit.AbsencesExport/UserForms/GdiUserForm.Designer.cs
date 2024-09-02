namespace coIT.AbsencesExport.UserForms
{
    partial class GdiUserForm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            lbxAbsenceTypes = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(10, 17);
            label1.Name = "label1";
            label1.Size = new Size(396, 19);
            label1.TabIndex = 7;
            label1.Text = "Abwesenheitstypen";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbxAbsenceTypes
            // 
            lbxAbsenceTypes.FormattingEnabled = true;
            lbxAbsenceTypes.ItemHeight = 15;
            lbxAbsenceTypes.Location = new Point(10, 38);
            lbxAbsenceTypes.Margin = new Padding(3, 2, 3, 2);
            lbxAbsenceTypes.Name = "lbxAbsenceTypes";
            lbxAbsenceTypes.Size = new Size(397, 469);
            lbxAbsenceTypes.TabIndex = 6;
            // 
            // GdiUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(lbxAbsenceTypes);
            Margin = new Padding(3, 2, 3, 2);
            Name = "GdiUserForm";
            Size = new Size(896, 576);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private ListBox lbxAbsenceTypes;
    }
}
