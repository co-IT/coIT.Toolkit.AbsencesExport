namespace coIT.AbsencesExport
{
    partial class MainUi<TSource, TTarget>
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLetzterMonat = new System.Windows.Forms.Button();
            this.btnDieserMonat = new System.Windows.Forms.Button();
            this.dtpEigenerZeitraumStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEigenerZeitraumEnde = new System.Windows.Forms.DateTimePicker();
            this.gbxEigenerZeitraum = new System.Windows.Forms.GroupBox();
            this.btnAktualisieren = new System.Windows.Forms.Button();
            this.lblEigenerZeitraumEnde = new System.Windows.Forms.Label();
            this.lblEigenerZeitraumStart = new System.Windows.Forms.Label();
            this.btnEigenenZeitraumExportieren = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.clbxMitarbeiterFilter = new System.Windows.Forms.CheckedListBox();
            this.gbxAktionen = new System.Windows.Forms.GroupBox();
            this.dgvDateneintraege = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpAnzeige = new System.Windows.Forms.TabPage();
            this.tbpEinstellungen = new System.Windows.Forms.TabPage();
            this.tbcSettings = new System.Windows.Forms.TabControl();
            this.tbpAbsenceExportSettings = new System.Windows.Forms.TabPage();
            this.tbgAbsenceImportSettings = new System.Windows.Forms.TabPage();
            this.tbpRelations = new System.Windows.Forms.TabPage();
            this.gbxEigenerZeitraum.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbxAktionen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDateneintraege)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tbpAnzeige.SuspendLayout();
            this.tbpEinstellungen.SuspendLayout();
            this.tbcSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLetzterMonat
            // 
            this.btnLetzterMonat.Location = new System.Drawing.Point(558, 41);
            this.btnLetzterMonat.Name = "btnLetzterMonat";
            this.btnLetzterMonat.Size = new System.Drawing.Size(143, 56);
            this.btnLetzterMonat.TabIndex = 0;
            this.btnLetzterMonat.Text = "Letzter Monat";
            this.btnLetzterMonat.UseVisualStyleBackColor = true;
            this.btnLetzterMonat.Click += new System.EventHandler(this.BtnLetzterMonat_Click);
            // 
            // btnDieserMonat
            // 
            this.btnDieserMonat.Location = new System.Drawing.Point(409, 41);
            this.btnDieserMonat.Name = "btnDieserMonat";
            this.btnDieserMonat.Size = new System.Drawing.Size(143, 56);
            this.btnDieserMonat.TabIndex = 1;
            this.btnDieserMonat.Text = "Dieser Monat";
            this.btnDieserMonat.UseVisualStyleBackColor = true;
            this.btnDieserMonat.Click += new System.EventHandler(this.BtnDieserMonat_Click);
            // 
            // dtpEigenerZeitraumStart
            // 
            this.dtpEigenerZeitraumStart.Location = new System.Drawing.Point(97, 38);
            this.dtpEigenerZeitraumStart.Name = "dtpEigenerZeitraumStart";
            this.dtpEigenerZeitraumStart.Size = new System.Drawing.Size(256, 27);
            this.dtpEigenerZeitraumStart.TabIndex = 2;
            // 
            // dtpEigenerZeitraumEnde
            // 
            this.dtpEigenerZeitraumEnde.Location = new System.Drawing.Point(97, 71);
            this.dtpEigenerZeitraumEnde.Name = "dtpEigenerZeitraumEnde";
            this.dtpEigenerZeitraumEnde.Size = new System.Drawing.Size(256, 27);
            this.dtpEigenerZeitraumEnde.TabIndex = 3;
            // 
            // gbxEigenerZeitraum
            // 
            this.gbxEigenerZeitraum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxEigenerZeitraum.Controls.Add(this.btnAktualisieren);
            this.gbxEigenerZeitraum.Controls.Add(this.btnDieserMonat);
            this.gbxEigenerZeitraum.Controls.Add(this.btnLetzterMonat);
            this.gbxEigenerZeitraum.Controls.Add(this.lblEigenerZeitraumEnde);
            this.gbxEigenerZeitraum.Controls.Add(this.lblEigenerZeitraumStart);
            this.gbxEigenerZeitraum.Controls.Add(this.dtpEigenerZeitraumStart);
            this.gbxEigenerZeitraum.Controls.Add(this.dtpEigenerZeitraumEnde);
            this.gbxEigenerZeitraum.Location = new System.Drawing.Point(8, 6);
            this.gbxEigenerZeitraum.Name = "gbxEigenerZeitraum";
            this.gbxEigenerZeitraum.Size = new System.Drawing.Size(1023, 134);
            this.gbxEigenerZeitraum.TabIndex = 3;
            this.gbxEigenerZeitraum.TabStop = false;
            this.gbxEigenerZeitraum.Text = "Zeitraum";
            // 
            // btnAktualisieren
            // 
            this.btnAktualisieren.Location = new System.Drawing.Point(707, 41);
            this.btnAktualisieren.Name = "btnAktualisieren";
            this.btnAktualisieren.Size = new System.Drawing.Size(143, 56);
            this.btnAktualisieren.TabIndex = 3;
            this.btnAktualisieren.Text = "Aktualisieren";
            this.btnAktualisieren.UseVisualStyleBackColor = true;
            // 
            // lblEigenerZeitraumEnde
            // 
            this.lblEigenerZeitraumEnde.Location = new System.Drawing.Point(29, 74);
            this.lblEigenerZeitraumEnde.Name = "lblEigenerZeitraumEnde";
            this.lblEigenerZeitraumEnde.Size = new System.Drawing.Size(62, 25);
            this.lblEigenerZeitraumEnde.TabIndex = 6;
            this.lblEigenerZeitraumEnde.Text = "Ende: ";
            this.lblEigenerZeitraumEnde.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEigenerZeitraumStart
            // 
            this.lblEigenerZeitraumStart.Location = new System.Drawing.Point(29, 41);
            this.lblEigenerZeitraumStart.Name = "lblEigenerZeitraumStart";
            this.lblEigenerZeitraumStart.Size = new System.Drawing.Size(62, 25);
            this.lblEigenerZeitraumStart.TabIndex = 4;
            this.lblEigenerZeitraumStart.Text = "Start: ";
            this.lblEigenerZeitraumStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnEigenenZeitraumExportieren
            // 
            this.btnEigenenZeitraumExportieren.Location = new System.Drawing.Point(409, 194);
            this.btnEigenenZeitraumExportieren.Name = "btnEigenenZeitraumExportieren";
            this.btnEigenenZeitraumExportieren.Size = new System.Drawing.Size(143, 84);
            this.btnEigenenZeitraumExportieren.TabIndex = 2;
            this.btnEigenenZeitraumExportieren.Text = "Exportieren";
            this.btnEigenenZeitraumExportieren.UseVisualStyleBackColor = true;
            this.btnEigenenZeitraumExportieren.Click += new System.EventHandler(this.BtnEigenenZeitraumExportieren_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.clbxMitarbeiterFilter);
            this.groupBox1.Location = new System.Drawing.Point(25, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 258);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Mitarbeiter";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // clbxMitarbeiterFilter
            // 
            this.clbxMitarbeiterFilter.CheckOnClick = true;
            this.clbxMitarbeiterFilter.FormattingEnabled = true;
            this.clbxMitarbeiterFilter.Location = new System.Drawing.Point(6, 50);
            this.clbxMitarbeiterFilter.Name = "clbxMitarbeiterFilter";
            this.clbxMitarbeiterFilter.Size = new System.Drawing.Size(328, 202);
            this.clbxMitarbeiterFilter.TabIndex = 12;
            // 
            // gbxAktionen
            // 
            this.gbxAktionen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxAktionen.Controls.Add(this.btnEigenenZeitraumExportieren);
            this.gbxAktionen.Controls.Add(this.groupBox1);
            this.gbxAktionen.Location = new System.Drawing.Point(8, 146);
            this.gbxAktionen.Name = "gbxAktionen";
            this.gbxAktionen.Size = new System.Drawing.Size(1023, 293);
            this.gbxAktionen.TabIndex = 11;
            this.gbxAktionen.TabStop = false;
            this.gbxAktionen.Text = "Aktionen";
            // 
            // dgvDateneintraege
            // 
            this.dgvDateneintraege.AllowUserToOrderColumns = true;
            this.dgvDateneintraege.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDateneintraege.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDateneintraege.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDateneintraege.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDateneintraege.Location = new System.Drawing.Point(6, 445);
            this.dgvDateneintraege.Name = "dgvDateneintraege";
            this.dgvDateneintraege.ReadOnly = true;
            this.dgvDateneintraege.RowHeadersWidth = 51;
            this.dgvDateneintraege.RowTemplate.Height = 29;
            this.dgvDateneintraege.Size = new System.Drawing.Size(1025, 337);
            this.dgvDateneintraege.TabIndex = 12;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbpAnzeige);
            this.tabControl1.Controls.Add(this.tbpEinstellungen);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1047, 839);
            this.tabControl1.TabIndex = 13;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_TabIndexChanged);
            // 
            // tbpAnzeige
            // 
            this.tbpAnzeige.Controls.Add(this.dgvDateneintraege);
            this.tbpAnzeige.Controls.Add(this.gbxEigenerZeitraum);
            this.tbpAnzeige.Controls.Add(this.gbxAktionen);
            this.tbpAnzeige.Location = new System.Drawing.Point(4, 29);
            this.tbpAnzeige.Name = "tbpAnzeige";
            this.tbpAnzeige.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAnzeige.Size = new System.Drawing.Size(1039, 806);
            this.tbpAnzeige.TabIndex = 0;
            this.tbpAnzeige.Text = "Exportieren";
            this.tbpAnzeige.UseVisualStyleBackColor = true;
            // 
            // tbpEinstellungen
            // 
            this.tbpEinstellungen.Controls.Add(this.tbcSettings);
            this.tbpEinstellungen.Location = new System.Drawing.Point(4, 29);
            this.tbpEinstellungen.Name = "tbpEinstellungen";
            this.tbpEinstellungen.Padding = new System.Windows.Forms.Padding(3);
            this.tbpEinstellungen.Size = new System.Drawing.Size(1039, 806);
            this.tbpEinstellungen.TabIndex = 1;
            this.tbpEinstellungen.Text = "Einstellungen";
            this.tbpEinstellungen.UseVisualStyleBackColor = true;
            // 
            // tbcSettings
            // 
            this.tbcSettings.Controls.Add(this.tbpAbsenceExportSettings);
            this.tbcSettings.Controls.Add(this.tbgAbsenceImportSettings);
            this.tbcSettings.Controls.Add(this.tbpRelations);
            this.tbcSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcSettings.Location = new System.Drawing.Point(3, 3);
            this.tbcSettings.Name = "tbcSettings";
            this.tbcSettings.SelectedIndex = 0;
            this.tbcSettings.Size = new System.Drawing.Size(1033, 800);
            this.tbcSettings.TabIndex = 3;
            // 
            // tbpAbsenceExportSettings
            // 
            this.tbpAbsenceExportSettings.Location = new System.Drawing.Point(4, 29);
            this.tbpAbsenceExportSettings.Name = "tbpAbsenceExportSettings";
            this.tbpAbsenceExportSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAbsenceExportSettings.Size = new System.Drawing.Size(1025, 767);
            this.tbpAbsenceExportSettings.TabIndex = 0;
            this.tbpAbsenceExportSettings.UseVisualStyleBackColor = true;
            // 
            // tbgAbsenceImportSettings
            // 
            this.tbgAbsenceImportSettings.Location = new System.Drawing.Point(4, 29);
            this.tbgAbsenceImportSettings.Name = "tbgAbsenceImportSettings";
            this.tbgAbsenceImportSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tbgAbsenceImportSettings.Size = new System.Drawing.Size(1025, 767);
            this.tbgAbsenceImportSettings.TabIndex = 1;
            this.tbgAbsenceImportSettings.UseVisualStyleBackColor = true;
            // 
            // tbpRelations
            // 
            this.tbpRelations.Location = new System.Drawing.Point(4, 29);
            this.tbpRelations.Name = "tbpRelations";
            this.tbpRelations.Padding = new System.Windows.Forms.Padding(3);
            this.tbpRelations.Size = new System.Drawing.Size(1025, 767);
            this.tbpRelations.TabIndex = 2;
            this.tbpRelations.Text = "Beziehungen";
            this.tbpRelations.UseVisualStyleBackColor = true;
            // 
            // MainUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "MainUi";
            this.Size = new System.Drawing.Size(1047, 839);
            this.Load += new System.EventHandler(this.MainUi_Load);
            this.gbxEigenerZeitraum.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.gbxAktionen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDateneintraege)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tbpAnzeige.ResumeLayout(false);
            this.tbpEinstellungen.ResumeLayout(false);
            this.tbcSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnLetzterMonat;
        private Button btnDieserMonat;
        private DateTimePicker dtpEigenerZeitraumStart;
        private DateTimePicker dtpEigenerZeitraumEnde;
        private GroupBox gbxEigenerZeitraum;
        private Label lblEigenerZeitraumEnde;
        private Label lblEigenerZeitraumStart;
        private Button btnEigenenZeitraumExportieren;
        private GroupBox groupBox1;
        private GroupBox gbxAktionen;
        private Button btnAktualisieren;
        private DataGridView dgvDateneintraege;
        private TabControl tabControl1;
        private TabPage tbpAnzeige;
        private TabPage tbpEinstellungen;
        private CheckedListBox clbxMitarbeiterFilter;
        private Label label1;
        private TabControl tbcSettings;
        private TabPage tbpAbsenceExportSettings;
        private TabPage tbgAbsenceImportSettings;
        private TabPage tbpRelations;
    }
}