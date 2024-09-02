namespace coIT.AbsencesExport
{
    partial class LoadingForm
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
            this.pgbStatus = new System.Windows.Forms.ProgressBar();
            this.lblStatusText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pgbStatus
            // 
            this.pgbStatus.Location = new System.Drawing.Point(12, 12);
            this.pgbStatus.Name = "pgbStatus";
            this.pgbStatus.Size = new System.Drawing.Size(294, 41);
            this.pgbStatus.TabIndex = 0;
            // 
            // lblStatusText
            // 
            this.lblStatusText.Location = new System.Drawing.Point(12, 59);
            this.lblStatusText.Name = "lblStatusText";
            this.lblStatusText.Size = new System.Drawing.Size(294, 38);
            this.lblStatusText.TabIndex = 1;
            this.lblStatusText.Text = "Abwesenheiten werden geladen";
            this.lblStatusText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 106);
            this.Controls.Add(this.lblStatusText);
            this.Controls.Add(this.pgbStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "LoadingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wird geladen";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private ProgressBar pgbStatus;
        private Label lblStatusText;
    }
}