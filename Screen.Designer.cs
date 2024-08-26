namespace coIT.AbsencesExport
{
    partial class Screen
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
            this.tbcMainScreen = new System.Windows.Forms.TabControl();
            this.tbpTimeCardToGdi = new System.Windows.Forms.TabPage();
            this.tbpClockodoToGdi = new System.Windows.Forms.TabPage();
            this.tbcMainScreen.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcMainScreen
            // 
            this.tbcMainScreen.Controls.Add(this.tbpTimeCardToGdi);
            this.tbcMainScreen.Controls.Add(this.tbpClockodoToGdi);
            this.tbcMainScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcMainScreen.Location = new System.Drawing.Point(0, 0);
            this.tbcMainScreen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbcMainScreen.Name = "tbcMainScreen";
            this.tbcMainScreen.SelectedIndex = 0;
            this.tbcMainScreen.Size = new System.Drawing.Size(934, 682);
            this.tbcMainScreen.TabIndex = 0;
            // 
            // tbpTimeCardToGdi
            // 
            this.tbpTimeCardToGdi.Location = new System.Drawing.Point(4, 24);
            this.tbpTimeCardToGdi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbpTimeCardToGdi.Name = "tbpTimeCardToGdi";
            this.tbpTimeCardToGdi.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbpTimeCardToGdi.Size = new System.Drawing.Size(926, 654);
            this.tbpTimeCardToGdi.TabIndex = 0;
            this.tbpTimeCardToGdi.Text = "TimeCard -> GDI";
            this.tbpTimeCardToGdi.UseVisualStyleBackColor = true;
            // 
            // tbpClockodoToGdi
            // 
            this.tbpClockodoToGdi.Location = new System.Drawing.Point(4, 24);
            this.tbpClockodoToGdi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbpClockodoToGdi.Name = "tbpClockodoToGdi";
            this.tbpClockodoToGdi.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbpClockodoToGdi.Size = new System.Drawing.Size(926, 654);
            this.tbpClockodoToGdi.TabIndex = 1;
            this.tbpClockodoToGdi.Text = "Clockodo -> GDI";
            this.tbpClockodoToGdi.UseVisualStyleBackColor = true;
            // 
            // Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 682);
            this.Controls.Add(this.tbcMainScreen);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Screen";
            this.Text = "co-IT.eu GmbH | Zeiterfassungs Export";
            this.Load += new System.EventHandler(this.LoadMain);
            this.tbcMainScreen.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tbcMainScreen;
        private TabPage tbpTimeCardToGdi;
        private TabPage tbpClockodoToGdi;
    }
}