namespace coIT.AbsencesExport
{
    partial class InitializeConfigurationForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            label4 = new Label();
            timecard_ApiKeinExportGroup = new TextBox();
            label3 = new Label();
            timecard_ApiSchluessel = new TextBox();
            label2 = new Label();
            timecard_ApiAdresse = new TextBox();
            label1 = new Label();
            timecard_ApiUser = new TextBox();
            btnCreateConfig = new Button();
            groupBox2 = new GroupBox();
            label5 = new Label();
            clockodo_ApiSchluessel = new TextBox();
            label6 = new Label();
            clockodo_ApiEmail = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(timecard_ApiKeinExportGroup);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(timecard_ApiSchluessel);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(timecard_ApiAdresse);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(timecard_ApiUser);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(677, 203);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "TimeCard";
            // 
            // label4
            // 
            label4.Location = new Point(6, 156);
            label4.Name = "label4";
            label4.Size = new Size(136, 23);
            label4.TabIndex = 8;
            label4.Text = "ID \"Kein Export\":";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // timecard_ApiKeinExportGroup
            // 
            timecard_ApiKeinExportGroup.Location = new Point(148, 156);
            timecard_ApiKeinExportGroup.Name = "timecard_ApiKeinExportGroup";
            timecard_ApiKeinExportGroup.Size = new Size(494, 23);
            timecard_ApiKeinExportGroup.TabIndex = 7;
            // 
            // label3
            // 
            label3.Location = new Point(6, 114);
            label3.Name = "label3";
            label3.Size = new Size(136, 23);
            label3.TabIndex = 5;
            label3.Text = "API Schlüssel:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // timecard_ApiSchluessel
            // 
            timecard_ApiSchluessel.Location = new Point(148, 114);
            timecard_ApiSchluessel.Name = "timecard_ApiSchluessel";
            timecard_ApiSchluessel.Size = new Size(494, 23);
            timecard_ApiSchluessel.TabIndex = 4;
            // 
            // label2
            // 
            label2.Location = new Point(6, 73);
            label2.Name = "label2";
            label2.Size = new Size(136, 23);
            label2.TabIndex = 3;
            label2.Text = "API Adresse:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // timecard_ApiAdresse
            // 
            timecard_ApiAdresse.Location = new Point(148, 73);
            timecard_ApiAdresse.Name = "timecard_ApiAdresse";
            timecard_ApiAdresse.Size = new Size(494, 23);
            timecard_ApiAdresse.TabIndex = 2;
            // 
            // label1
            // 
            label1.Location = new Point(6, 33);
            label1.Name = "label1";
            label1.Size = new Size(136, 23);
            label1.TabIndex = 1;
            label1.Text = "API Benutzer:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // timecard_ApiUser
            // 
            timecard_ApiUser.Location = new Point(148, 33);
            timecard_ApiUser.Name = "timecard_ApiUser";
            timecard_ApiUser.PlaceholderText = "Name";
            timecard_ApiUser.Size = new Size(494, 23);
            timecard_ApiUser.TabIndex = 0;
            // 
            // btnCreateConfig
            // 
            btnCreateConfig.Location = new Point(256, 375);
            btnCreateConfig.Name = "btnCreateConfig";
            btnCreateConfig.Size = new Size(197, 54);
            btnCreateConfig.TabIndex = 6;
            btnCreateConfig.Text = "Anlegen";
            btnCreateConfig.UseVisualStyleBackColor = true;
            btnCreateConfig.Click += btnCreateConfig_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(clockodo_ApiSchluessel);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(clockodo_ApiEmail);
            groupBox2.Location = new Point(12, 230);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(677, 127);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Clockodo";
            // 
            // label5
            // 
            label5.Location = new Point(6, 87);
            label5.Name = "label5";
            label5.Size = new Size(136, 23);
            label5.TabIndex = 5;
            label5.Text = "Api Schlüssel:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // clockodo_ApiSchluessel
            // 
            clockodo_ApiSchluessel.Location = new Point(148, 87);
            clockodo_ApiSchluessel.Name = "clockodo_ApiSchluessel";
            clockodo_ApiSchluessel.Size = new Size(494, 23);
            clockodo_ApiSchluessel.TabIndex = 4;
            // 
            // label6
            // 
            label6.Location = new Point(6, 43);
            label6.Name = "label6";
            label6.Size = new Size(136, 23);
            label6.TabIndex = 3;
            label6.Text = "Api Email:";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // clockodo_ApiEmail
            // 
            clockodo_ApiEmail.Location = new Point(148, 43);
            clockodo_ApiEmail.Name = "clockodo_ApiEmail";
            clockodo_ApiEmail.Size = new Size(494, 23);
            clockodo_ApiEmail.TabIndex = 2;
            // 
            // InitializeConfigurationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(712, 441);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnCreateConfig);
            Name = "InitializeConfigurationForm";
            Text = "Konfiguration";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnCreateConfig;
        private Label label3;
        private TextBox timecard_ApiSchluessel;
        private Label label2;
        private TextBox timecard_ApiAdresse;
        private Label label1;
        private TextBox timecard_ApiUser;
        private Label label4;
        private TextBox timecard_ApiKeinExportGroup;
        private GroupBox groupBox2;
        private Label label5;
        private TextBox clockodo_ApiSchluessel;
        private Label label6;
        private TextBox clockodo_ApiEmail;
    }
}