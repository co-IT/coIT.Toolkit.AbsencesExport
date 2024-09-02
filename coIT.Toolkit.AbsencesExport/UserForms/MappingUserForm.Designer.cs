namespace coIT.AbsencesExport.UserForms
{
    partial class MappingUserForm<TSource, TTarget>
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
            this.lbxAbsenceTypesSourceSystem = new System.Windows.Forms.ListBox();
            this.lbxAbsenceTypesTargetSystem = new System.Windows.Forms.ListBox();
            this.lblSourceSystem = new System.Windows.Forms.Label();
            this.lblTargetSystem = new System.Windows.Forms.Label();
            this.lblMapping = new System.Windows.Forms.Label();
            this.btnUnignoreSourceType = new System.Windows.Forms.Button();
            this.btnCrateMapping = new System.Windows.Forms.Button();
            this.btnIgnoreSourceAbsence = new System.Windows.Forms.Button();
            this.btnStoreConfiguration = new System.Windows.Forms.Button();
            this.lblApiAdress = new System.Windows.Forms.Label();
            this.btnLoadConfiguration = new System.Windows.Forms.Button();
            this.btnStoreConfig = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnNewConfig = new System.Windows.Forms.Button();
            this.cbxConfigurationFiles = new System.Windows.Forms.ComboBox();
            this.lblUnsavedChanges = new System.Windows.Forms.Label();
            this.lbxRelationsWithExport = new System.Windows.Forms.ListBox();
            this.lbxRelationsWithoutExport = new System.Windows.Forms.ListBox();
            this.lbxIgnoredRelations = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMarkRelationForExport = new System.Windows.Forms.Button();
            this.btnIgnoreRelationInExport = new System.Windows.Forms.Button();
            this.btnDeleteRelation = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxAbsenceTypesSourceSystem
            // 
            this.lbxAbsenceTypesSourceSystem.FormattingEnabled = true;
            this.lbxAbsenceTypesSourceSystem.ItemHeight = 15;
            this.lbxAbsenceTypesSourceSystem.Location = new System.Drawing.Point(17, 52);
            this.lbxAbsenceTypesSourceSystem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbxAbsenceTypesSourceSystem.Name = "lbxAbsenceTypesSourceSystem";
            this.lbxAbsenceTypesSourceSystem.Size = new System.Drawing.Size(216, 424);
            this.lbxAbsenceTypesSourceSystem.TabIndex = 0;
            // 
            // lbxAbsenceTypesTargetSystem
            // 
            this.lbxAbsenceTypesTargetSystem.FormattingEnabled = true;
            this.lbxAbsenceTypesTargetSystem.ItemHeight = 15;
            this.lbxAbsenceTypesTargetSystem.Location = new System.Drawing.Point(237, 52);
            this.lbxAbsenceTypesTargetSystem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbxAbsenceTypesTargetSystem.Name = "lbxAbsenceTypesTargetSystem";
            this.lbxAbsenceTypesTargetSystem.Size = new System.Drawing.Size(216, 424);
            this.lbxAbsenceTypesTargetSystem.TabIndex = 1;
            // 
            // lblSourceSystem
            // 
            this.lblSourceSystem.Location = new System.Drawing.Point(17, 33);
            this.lblSourceSystem.Name = "lblSourceSystem";
            this.lblSourceSystem.Size = new System.Drawing.Size(215, 19);
            this.lblSourceSystem.TabIndex = 3;
            this.lblSourceSystem.Text = "Ausgangssystem Name";
            this.lblSourceSystem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTargetSystem
            // 
            this.lblTargetSystem.Location = new System.Drawing.Point(237, 33);
            this.lblTargetSystem.Name = "lblTargetSystem";
            this.lblTargetSystem.Size = new System.Drawing.Size(215, 19);
            this.lblTargetSystem.TabIndex = 4;
            this.lblTargetSystem.Text = "Zielsystem Name";
            this.lblTargetSystem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMapping
            // 
            this.lblMapping.Location = new System.Drawing.Point(458, 33);
            this.lblMapping.Name = "lblMapping";
            this.lblMapping.Size = new System.Drawing.Size(408, 19);
            this.lblMapping.TabIndex = 5;
            this.lblMapping.Text = "Verknüpfungen mit Export";
            this.lblMapping.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnUnignoreSourceType
            // 
            this.btnUnignoreSourceType.Location = new System.Drawing.Point(457, 479);
            this.btnUnignoreSourceType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUnignoreSourceType.Name = "btnUnignoreSourceType";
            this.btnUnignoreSourceType.Size = new System.Drawing.Size(423, 22);
            this.btnUnignoreSourceType.TabIndex = 7;
            this.btnUnignoreSourceType.Text = "Ausschluss entfernen";
            this.btnUnignoreSourceType.UseVisualStyleBackColor = true;
            this.btnUnignoreSourceType.Click += new System.EventHandler(this.btnUnignoreSourceType_Click);
            // 
            // btnCrateMapping
            // 
            this.btnCrateMapping.Location = new System.Drawing.Point(237, 479);
            this.btnCrateMapping.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCrateMapping.Name = "btnCrateMapping";
            this.btnCrateMapping.Size = new System.Drawing.Size(215, 22);
            this.btnCrateMapping.TabIndex = 8;
            this.btnCrateMapping.Text = "Verknüpfung Erstellen";
            this.btnCrateMapping.UseVisualStyleBackColor = true;
            this.btnCrateMapping.Click += new System.EventHandler(this.btnCrateMapping_Click);
            // 
            // btnIgnoreSourceAbsence
            // 
            this.btnIgnoreSourceAbsence.Location = new System.Drawing.Point(17, 479);
            this.btnIgnoreSourceAbsence.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIgnoreSourceAbsence.Name = "btnIgnoreSourceAbsence";
            this.btnIgnoreSourceAbsence.Size = new System.Drawing.Size(215, 22);
            this.btnIgnoreSourceAbsence.TabIndex = 9;
            this.btnIgnoreSourceAbsence.Text = "Ausschließen";
            this.btnIgnoreSourceAbsence.UseVisualStyleBackColor = true;
            this.btnIgnoreSourceAbsence.Click += new System.EventHandler(this.btnIgnoreSourceAbsence_Click);
            // 
            // btnStoreConfiguration
            // 
            this.btnStoreConfiguration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStoreConfiguration.Location = new System.Drawing.Point(1405, 22);
            this.btnStoreConfiguration.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStoreConfiguration.Name = "btnStoreConfiguration";
            this.btnStoreConfiguration.Size = new System.Drawing.Size(184, 5);
            this.btnStoreConfiguration.TabIndex = 4;
            this.btnStoreConfiguration.Text = "Konfiguration speichern";
            this.btnStoreConfiguration.UseVisualStyleBackColor = true;
            // 
            // lblApiAdress
            // 
            this.lblApiAdress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblApiAdress.AutoSize = true;
            this.lblApiAdress.Location = new System.Drawing.Point(17, 32);
            this.lblApiAdress.Name = "lblApiAdress";
            this.lblApiAdress.Size = new System.Drawing.Size(154, 15);
            this.lblApiAdress.TabIndex = 8;
            this.lblApiAdress.Text = "Ausgewählte Konfiguration:";
            // 
            // btnLoadConfiguration
            // 
            this.btnLoadConfiguration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadConfiguration.Location = new System.Drawing.Point(1197, 23);
            this.btnLoadConfiguration.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoadConfiguration.Name = "btnLoadConfiguration";
            this.btnLoadConfiguration.Size = new System.Drawing.Size(184, 5);
            this.btnLoadConfiguration.TabIndex = 9;
            this.btnLoadConfiguration.Text = "Konfiguration laden";
            this.btnLoadConfiguration.UseVisualStyleBackColor = true;
            // 
            // btnStoreConfig
            // 
            this.btnStoreConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStoreConfig.Location = new System.Drawing.Point(674, 29);
            this.btnStoreConfig.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStoreConfig.Name = "btnStoreConfig";
            this.btnStoreConfig.Size = new System.Drawing.Size(188, 21);
            this.btnStoreConfig.TabIndex = 11;
            this.btnStoreConfig.Text = "Konfiguration speichern";
            this.btnStoreConfig.UseVisualStyleBackColor = true;
            this.btnStoreConfig.Click += new System.EventHandler(this.btnStoreConfig_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnNewConfig);
            this.groupBox2.Controls.Add(this.cbxConfigurationFiles);
            this.groupBox2.Controls.Add(this.lblUnsavedChanges);
            this.groupBox2.Controls.Add(this.btnStoreConfig);
            this.groupBox2.Controls.Add(this.btnLoadConfiguration);
            this.groupBox2.Controls.Add(this.lblApiAdress);
            this.groupBox2.Controls.Add(this.btnStoreConfiguration);
            this.groupBox2.Location = new System.Drawing.Point(3, 515);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(891, 58);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Konfiguration";
            // 
            // btnNewConfig
            // 
            this.btnNewConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewConfig.Location = new System.Drawing.Point(460, 29);
            this.btnNewConfig.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNewConfig.Name = "btnNewConfig";
            this.btnNewConfig.Size = new System.Drawing.Size(173, 21);
            this.btnNewConfig.TabIndex = 15;
            this.btnNewConfig.Text = "Neue Konfiguration";
            this.btnNewConfig.UseVisualStyleBackColor = true;
            this.btnNewConfig.Click += new System.EventHandler(this.btnNewConfig_Click);
            // 
            // cbxConfigurationFiles
            // 
            this.cbxConfigurationFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxConfigurationFiles.FormattingEnabled = true;
            this.cbxConfigurationFiles.Location = new System.Drawing.Point(177, 27);
            this.cbxConfigurationFiles.Name = "cbxConfigurationFiles";
            this.cbxConfigurationFiles.Size = new System.Drawing.Size(242, 23);
            this.cbxConfigurationFiles.TabIndex = 14;
            this.cbxConfigurationFiles.SelectedValueChanged += new System.EventHandler(this.cbxConfigurationFiles_SelectedValueChanged);
            // 
            // lblUnsavedChanges
            // 
            this.lblUnsavedChanges.AutoSize = true;
            this.lblUnsavedChanges.ForeColor = System.Drawing.Color.Red;
            this.lblUnsavedChanges.Location = new System.Drawing.Point(689, 12);
            this.lblUnsavedChanges.Name = "lblUnsavedChanges";
            this.lblUnsavedChanges.Size = new System.Drawing.Size(158, 15);
            this.lblUnsavedChanges.TabIndex = 13;
            this.lblUnsavedChanges.Text = "Ungespeicherte Änderungen";
            this.lblUnsavedChanges.Visible = false;
            // 
            // lbxRelationsWithExport
            // 
            this.lbxRelationsWithExport.FormattingEnabled = true;
            this.lbxRelationsWithExport.ItemHeight = 15;
            this.lbxRelationsWithExport.Location = new System.Drawing.Point(457, 54);
            this.lbxRelationsWithExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbxRelationsWithExport.Name = "lbxRelationsWithExport";
            this.lbxRelationsWithExport.Size = new System.Drawing.Size(421, 124);
            this.lbxRelationsWithExport.TabIndex = 11;
            // 
            // lbxRelationsWithoutExport
            // 
            this.lbxRelationsWithoutExport.FormattingEnabled = true;
            this.lbxRelationsWithoutExport.ItemHeight = 15;
            this.lbxRelationsWithoutExport.Location = new System.Drawing.Point(458, 226);
            this.lbxRelationsWithoutExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbxRelationsWithoutExport.Name = "lbxRelationsWithoutExport";
            this.lbxRelationsWithoutExport.Size = new System.Drawing.Size(422, 124);
            this.lbxRelationsWithoutExport.TabIndex = 12;
            // 
            // lbxIgnoredRelations
            // 
            this.lbxIgnoredRelations.FormattingEnabled = true;
            this.lbxIgnoredRelations.ItemHeight = 15;
            this.lbxIgnoredRelations.Location = new System.Drawing.Point(457, 382);
            this.lbxIgnoredRelations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbxIgnoredRelations.Name = "lbxIgnoredRelations";
            this.lbxIgnoredRelations.Size = new System.Drawing.Size(422, 94);
            this.lbxIgnoredRelations.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(470, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(408, 19);
            this.label1.TabIndex = 14;
            this.label1.Text = "Verknüpfungen ohne Export";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(458, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(422, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "Ausgeschlossen Verknüpfungen";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMarkRelationForExport
            // 
            this.btnMarkRelationForExport.Location = new System.Drawing.Point(551, 182);
            this.btnMarkRelationForExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMarkRelationForExport.Name = "btnMarkRelationForExport";
            this.btnMarkRelationForExport.Size = new System.Drawing.Size(46, 22);
            this.btnMarkRelationForExport.TabIndex = 16;
            this.btnMarkRelationForExport.Text = "▲";
            this.btnMarkRelationForExport.UseVisualStyleBackColor = true;
            this.btnMarkRelationForExport.Click += new System.EventHandler(this.btnMarkRelationForExport_Click);
            // 
            // btnIgnoreRelationInExport
            // 
            this.btnIgnoreRelationInExport.Location = new System.Drawing.Point(752, 182);
            this.btnIgnoreRelationInExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIgnoreRelationInExport.Name = "btnIgnoreRelationInExport";
            this.btnIgnoreRelationInExport.Size = new System.Drawing.Size(46, 22);
            this.btnIgnoreRelationInExport.TabIndex = 17;
            this.btnIgnoreRelationInExport.Text = "▼";
            this.btnIgnoreRelationInExport.UseVisualStyleBackColor = true;
            this.btnIgnoreRelationInExport.Click += new System.EventHandler(this.btnIgnoreRelationInExport_Click);
            // 
            // btnDeleteRelation
            // 
            this.btnDeleteRelation.Location = new System.Drawing.Point(603, 182);
            this.btnDeleteRelation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteRelation.Name = "btnDeleteRelation";
            this.btnDeleteRelation.Size = new System.Drawing.Size(144, 22);
            this.btnDeleteRelation.TabIndex = 18;
            this.btnDeleteRelation.Text = "Verküpfunge löschen";
            this.btnDeleteRelation.UseVisualStyleBackColor = true;
            this.btnDeleteRelation.Click += new System.EventHandler(this.btnDeleteRelation_Click);
            // 
            // MappingUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDeleteRelation);
            this.Controls.Add(this.btnIgnoreRelationInExport);
            this.Controls.Add(this.btnMarkRelationForExport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxIgnoredRelations);
            this.Controls.Add(this.lbxRelationsWithoutExport);
            this.Controls.Add(this.lbxRelationsWithExport);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnIgnoreSourceAbsence);
            this.Controls.Add(this.btnCrateMapping);
            this.Controls.Add(this.btnUnignoreSourceType);
            this.Controls.Add(this.lblMapping);
            this.Controls.Add(this.lblTargetSystem);
            this.Controls.Add(this.lblSourceSystem);
            this.Controls.Add(this.lbxAbsenceTypesTargetSystem);
            this.Controls.Add(this.lbxAbsenceTypesSourceSystem);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MappingUserForm";
            this.Size = new System.Drawing.Size(896, 576);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox lbxAbsenceTypesSourceSystem;
        private ListBox lbxAbsenceTypesTargetSystem;
        private Label lblSourceSystem;
        private Label lblTargetSystem;
        private Label lblMapping;
        private Button btnUnignoreSourceType;
        private Button btnCrateMapping;
        private Button btnIgnoreSourceAbsence;
        private Button btnStoreConfiguration;
        private Label lblApiAdress;
        private Button btnLoadConfiguration;
        private Button btnStoreConfig;
        private GroupBox groupBox2;
        private Label lblUnsavedChanges;
        private ListBox lbxRelationsWithExport;
        private ListBox lbxRelationsWithoutExport;
        private ListBox lbxIgnoredRelations;
        private Label label1;
        private Label label2;
        private Button btnMarkRelationForExport;
        private Button btnIgnoreRelationInExport;
        private Button btnDeleteRelation;
        private Button btnNewConfig;
        private ComboBox cbxConfigurationFiles;
    }
}
