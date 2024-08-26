namespace coIT.AbsencesExport
{
    partial class TextInputForm
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
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbxTextInput = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDescription.Location = new System.Drawing.Point(12, 9);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(236, 37);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "label1";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxTextInput
            // 
            this.tbxTextInput.Location = new System.Drawing.Point(12, 49);
            this.tbxTextInput.Name = "tbxTextInput";
            this.tbxTextInput.Size = new System.Drawing.Size(236, 23);
            this.tbxTextInput.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(71, 78);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Speichern";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // TextInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 114);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbxTextInput);
            this.Controls.Add(this.lblDescription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TextInputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TextInputForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblDescription;
        private TextBox tbxTextInput;
        private Button btnClose;
    }
}