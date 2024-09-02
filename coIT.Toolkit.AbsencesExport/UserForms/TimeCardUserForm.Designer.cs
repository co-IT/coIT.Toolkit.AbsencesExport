namespace coIT.AbsencesExport.UserForms
{
    partial class TimeCardUserForm
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
            groupBox2 = new GroupBox();
            btnLoadConfiguration = new Button();
            nbxKeinExportGruppenId = new NumericUpDown();
            lblKeinExportGruppenId = new Label();
            lblApiAdress = new Label();
            tbxApiAddress = new TextBox();
            btnStoreConfiguration = new Button();
            tbxApiUser = new TextBox();
            lblApiSchluessel = new Label();
            tbxApiSchluessel = new TextBox();
            lblApiUser = new Label();
            lbxAbsenceTypes = new ListBox();
            label1 = new Label();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nbxKeinExportGruppenId).BeginInit();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(btnLoadConfiguration);
            groupBox2.Controls.Add(nbxKeinExportGruppenId);
            groupBox2.Controls.Add(lblKeinExportGruppenId);
            groupBox2.Controls.Add(lblApiAdress);
            groupBox2.Controls.Add(tbxApiAddress);
            groupBox2.Controls.Add(btnStoreConfiguration);
            groupBox2.Controls.Add(tbxApiUser);
            groupBox2.Controls.Add(lblApiSchluessel);
            groupBox2.Controls.Add(tbxApiSchluessel);
            groupBox2.Controls.Add(lblApiUser);
            groupBox2.Location = new Point(3, 484);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(885, 90);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Konfiguration";
            // 
            // btnLoadConfiguration
            // 
            btnLoadConfiguration.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnLoadConfiguration.Location = new Point(409, 53);
            btnLoadConfiguration.Margin = new Padding(3, 2, 3, 2);
            btnLoadConfiguration.Name = "btnLoadConfiguration";
            btnLoadConfiguration.Size = new Size(184, 36);
            btnLoadConfiguration.TabIndex = 11;
            btnLoadConfiguration.Text = "Konfiguration laden";
            btnLoadConfiguration.UseVisualStyleBackColor = true;
            btnLoadConfiguration.Click += btnLoadConfiguration_Click;
            // 
            // nbxKeinExportGruppenId
            // 
            nbxKeinExportGruppenId.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            nbxKeinExportGruppenId.Location = new Point(587, 15);
            nbxKeinExportGruppenId.Margin = new Padding(3, 2, 3, 2);
            nbxKeinExportGruppenId.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nbxKeinExportGruppenId.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
            nbxKeinExportGruppenId.Name = "nbxKeinExportGruppenId";
            nbxKeinExportGruppenId.Size = new Size(282, 23);
            nbxKeinExportGruppenId.TabIndex = 10;
            // 
            // lblKeinExportGruppenId
            // 
            lblKeinExportGruppenId.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lblKeinExportGruppenId.AutoSize = true;
            lblKeinExportGruppenId.Location = new Point(409, 17);
            lblKeinExportGruppenId.Name = "lblKeinExportGruppenId";
            lblKeinExportGruppenId.Size = new Size(156, 15);
            lblKeinExportGruppenId.TabIndex = 9;
            lblKeinExportGruppenId.Text = "ID der \"Kein Export\" Gruppe:";
            // 
            // lblApiAdress
            // 
            lblApiAdress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lblApiAdress.AutoSize = true;
            lblApiAdress.Location = new Point(12, 67);
            lblApiAdress.Name = "lblApiAdress";
            lblApiAdress.Size = new Size(79, 15);
            lblApiAdress.TabIndex = 8;
            lblApiAdress.Text = "Api Addresse:";
            lblApiAdress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbxApiAddress
            // 
            tbxApiAddress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            tbxApiAddress.Location = new Point(98, 64);
            tbxApiAddress.Margin = new Padding(3, 2, 3, 2);
            tbxApiAddress.Name = "tbxApiAddress";
            tbxApiAddress.Size = new Size(282, 23);
            tbxApiAddress.TabIndex = 7;
            // 
            // btnStoreConfiguration
            // 
            btnStoreConfiguration.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnStoreConfiguration.Location = new Point(685, 53);
            btnStoreConfiguration.Margin = new Padding(3, 2, 3, 2);
            btnStoreConfiguration.Name = "btnStoreConfiguration";
            btnStoreConfiguration.Size = new Size(184, 36);
            btnStoreConfiguration.TabIndex = 4;
            btnStoreConfiguration.Text = "Konfiguration speichern";
            btnStoreConfiguration.UseVisualStyleBackColor = true;
            btnStoreConfiguration.Click += btnStoreConfiguration_click;
            // 
            // tbxApiUser
            // 
            tbxApiUser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            tbxApiUser.Location = new Point(98, 15);
            tbxApiUser.Margin = new Padding(3, 2, 3, 2);
            tbxApiUser.Name = "tbxApiUser";
            tbxApiUser.Size = new Size(282, 23);
            tbxApiUser.TabIndex = 3;
            // 
            // lblApiSchluessel
            // 
            lblApiSchluessel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lblApiSchluessel.AutoSize = true;
            lblApiSchluessel.Location = new Point(7, 42);
            lblApiSchluessel.Name = "lblApiSchluessel";
            lblApiSchluessel.Size = new Size(79, 15);
            lblApiSchluessel.TabIndex = 2;
            lblApiSchluessel.Text = "Api Schlüssel:";
            lblApiSchluessel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbxApiSchluessel
            // 
            tbxApiSchluessel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            tbxApiSchluessel.Location = new Point(98, 40);
            tbxApiSchluessel.Margin = new Padding(3, 2, 3, 2);
            tbxApiSchluessel.Name = "tbxApiSchluessel";
            tbxApiSchluessel.Size = new Size(282, 23);
            tbxApiSchluessel.TabIndex = 1;
            // 
            // lblApiUser
            // 
            lblApiUser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lblApiUser.AutoSize = true;
            lblApiUser.Location = new Point(8, 16);
            lblApiUser.Name = "lblApiUser";
            lblApiUser.Size = new Size(77, 15);
            lblApiUser.TabIndex = 0;
            lblApiUser.Text = "Api Benutzer:";
            lblApiUser.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbxAbsenceTypes
            // 
            lbxAbsenceTypes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lbxAbsenceTypes.FormattingEnabled = true;
            lbxAbsenceTypes.ItemHeight = 15;
            lbxAbsenceTypes.Location = new Point(10, 38);
            lbxAbsenceTypes.Margin = new Padding(3, 2, 3, 2);
            lbxAbsenceTypes.Name = "lbxAbsenceTypes";
            lbxAbsenceTypes.Size = new Size(397, 439);
            lbxAbsenceTypes.TabIndex = 4;
            // 
            // label1
            // 
            label1.Location = new Point(10, 17);
            label1.Name = "label1";
            label1.Size = new Size(397, 19);
            label1.TabIndex = 5;
            label1.Text = "Abwesenheitstypen";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TimeCardUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(lbxAbsenceTypes);
            Controls.Add(groupBox2);
            Margin = new Padding(3, 2, 3, 2);
            Name = "TimeCardUserForm";
            Size = new Size(896, 576);
            Load += TimeCardUserForm_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nbxKeinExportGruppenId).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private NumericUpDown nbxKeinExportGruppenId;
        private Label lblKeinExportGruppenId;
        private Label lblApiAdress;
        private TextBox tbxApiAddress;
        private Button btnStoreConfiguration;
        private TextBox tbxApiUser;
        private Label lblApiSchluessel;
        private TextBox tbxApiSchluessel;
        private Label lblApiUser;
        private ListBox lbxAbsenceTypes;
        private Label label1;
        private Button btnLoadConfiguration;
    }
}
