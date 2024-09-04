namespace coIT.Toolkit.AbsencesExport
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
            btnCreateConfig = new Button();
            tbxConnectionString = new TextBox();
            label7 = new Label();
            SuspendLayout();
            // 
            // btnCreateConfig
            // 
            btnCreateConfig.Location = new Point(124, 100);
            btnCreateConfig.Name = "btnCreateConfig";
            btnCreateConfig.Size = new Size(197, 54);
            btnCreateConfig.TabIndex = 6;
            btnCreateConfig.Text = "Initiale Konfiguration vornehmen";
            btnCreateConfig.UseVisualStyleBackColor = true;
            btnCreateConfig.Click += btnCreateConfig_Click;
            // 
            // tbxConnectionString
            // 
            tbxConnectionString.Location = new Point(45, 48);
            tbxConnectionString.Name = "tbxConnectionString";
            tbxConnectionString.Size = new Size(372, 23);
            tbxConnectionString.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(45, 30);
            label7.Name = "label7";
            label7.Size = new Size(103, 15);
            label7.TabIndex = 8;
            label7.Text = "Connection String";
            // 
            // InitializeConfigurationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(471, 165);
            Controls.Add(label7);
            Controls.Add(tbxConnectionString);
            Controls.Add(btnCreateConfig);
            Name = "InitializeConfigurationForm";
            Text = "Konfiguration";
            ResumeLayout(false);
            PerformLayout();
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
        private TextBox tbxConnectionString;
        private Label label7;
    }
}