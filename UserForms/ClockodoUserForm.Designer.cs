namespace coIT.AbsencesExport.UserForms
{
    partial class ClockodoUserForm
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
            groupBox2 = new GroupBox();
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            btnLoadConfiguration = new Button();
            btnStoreConfiguration = new Button();
            tbxApiUser = new TextBox();
            lblApiSchluessel = new Label();
            tbxApiSchluessel = new TextBox();
            lblApiUser = new Label();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(13, 10);
            label1.Name = "label1";
            label1.Size = new Size(397, 19);
            label1.TabIndex = 8;
            label1.Text = "Abwesenheitstypen";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbxAbsenceTypes
            // 
            lbxAbsenceTypes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lbxAbsenceTypes.FormattingEnabled = true;
            lbxAbsenceTypes.ItemHeight = 15;
            lbxAbsenceTypes.Location = new Point(14, 31);
            lbxAbsenceTypes.Margin = new Padding(3, 2, 3, 2);
            lbxAbsenceTypes.Name = "lbxAbsenceTypes";
            lbxAbsenceTypes.Size = new Size(397, 439);
            lbxAbsenceTypes.TabIndex = 7;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(btnLoadConfiguration);
            groupBox2.Controls.Add(btnStoreConfiguration);
            groupBox2.Controls.Add(tbxApiUser);
            groupBox2.Controls.Add(lblApiSchluessel);
            groupBox2.Controls.Add(tbxApiSchluessel);
            groupBox2.Controls.Add(lblApiUser);
            groupBox2.Location = new Point(3, 496);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(885, 77);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Konfiguration";
            // 
            // button1
            // 
            button1.Location = new Point(399, 21);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(167, 22);
            button1.TabIndex = 14;
            button1.Text = "Konfiguration speichern";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(399, 52);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(167, 22);
            button2.TabIndex = 15;
            button2.Text = "Konfiguration laden";
            button2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(1204, 42);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 12;
            label2.Text = "Speicherpfad:";
            // 
            // btnLoadConfiguration
            // 
            btnLoadConfiguration.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnLoadConfiguration.Location = new Point(1206, 63);
            btnLoadConfiguration.Margin = new Padding(3, 2, 3, 2);
            btnLoadConfiguration.Name = "btnLoadConfiguration";
            btnLoadConfiguration.Size = new Size(184, 24);
            btnLoadConfiguration.TabIndex = 11;
            btnLoadConfiguration.Text = "Konfiguration laden";
            btnLoadConfiguration.UseVisualStyleBackColor = true;
            // 
            // btnStoreConfiguration
            // 
            btnStoreConfiguration.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnStoreConfiguration.Location = new Point(1395, 63);
            btnStoreConfiguration.Margin = new Padding(3, 2, 3, 2);
            btnStoreConfiguration.Name = "btnStoreConfiguration";
            btnStoreConfiguration.Size = new Size(184, 24);
            btnStoreConfiguration.TabIndex = 4;
            btnStoreConfiguration.Text = "Konfiguration speichern";
            btnStoreConfiguration.UseVisualStyleBackColor = true;
            // 
            // tbxApiUser
            // 
            tbxApiUser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            tbxApiUser.Location = new Point(95, 20);
            tbxApiUser.Margin = new Padding(3, 2, 3, 2);
            tbxApiUser.Name = "tbxApiUser";
            tbxApiUser.Size = new Size(282, 23);
            tbxApiUser.TabIndex = 3;
            // 
            // lblApiSchluessel
            // 
            lblApiSchluessel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lblApiSchluessel.AutoSize = true;
            lblApiSchluessel.Location = new Point(5, 54);
            lblApiSchluessel.Name = "lblApiSchluessel";
            lblApiSchluessel.Size = new Size(79, 15);
            lblApiSchluessel.TabIndex = 2;
            lblApiSchluessel.Text = "Api Schlüssel:";
            // 
            // tbxApiSchluessel
            // 
            tbxApiSchluessel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            tbxApiSchluessel.Location = new Point(95, 52);
            tbxApiSchluessel.Margin = new Padding(3, 2, 3, 2);
            tbxApiSchluessel.Name = "tbxApiSchluessel";
            tbxApiSchluessel.Size = new Size(282, 23);
            tbxApiSchluessel.TabIndex = 1;
            // 
            // lblApiUser
            // 
            lblApiUser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lblApiUser.AutoSize = true;
            lblApiUser.Location = new Point(6, 25);
            lblApiUser.Name = "lblApiUser";
            lblApiUser.Size = new Size(65, 15);
            lblApiUser.TabIndex = 0;
            lblApiUser.Text = "Api E-Mail:";
            lblApiUser.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ClockodoUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox2);
            Controls.Add(label1);
            Controls.Add(lbxAbsenceTypes);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ClockodoUserForm";
            Size = new Size(896, 576);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private ListBox lbxAbsenceTypes;
        private GroupBox groupBox2;
        private Label label2;
        private Button btnLoadConfiguration;
        private Button btnStoreConfiguration;
        private TextBox tbxApiUser;
        private Label lblApiSchluessel;
        private TextBox tbxApiSchluessel;
        private Label lblApiUser;
        private Button button1;
        private Button button2;
    }
}
