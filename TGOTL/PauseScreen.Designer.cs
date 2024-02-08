namespace TGOTL
{
    partial class PauseScreen
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
            this.lblResumeButton = new System.Windows.Forms.Label();
            this.lblSaveButton = new System.Windows.Forms.Label();
            this.lblQuitButton = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblResumeButton
            // 
            this.lblResumeButton.AutoSize = true;
            this.lblResumeButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblResumeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblResumeButton.Font = new System.Drawing.Font("ROG Fonts", 71.99999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResumeButton.Location = new System.Drawing.Point(159, 46);
            this.lblResumeButton.Name = "lblResumeButton";
            this.lblResumeButton.Size = new System.Drawing.Size(837, 173);
            this.lblResumeButton.TabIndex = 1;
            this.lblResumeButton.Tag = "menu";
            this.lblResumeButton.Text = "Resume";
            this.lblResumeButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ResumeBtnClick);
            // 
            // lblSaveButton
            // 
            this.lblSaveButton.AutoSize = true;
            this.lblSaveButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblSaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSaveButton.Font = new System.Drawing.Font("ROG Fonts", 71.99999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaveButton.Location = new System.Drawing.Point(284, 305);
            this.lblSaveButton.Name = "lblSaveButton";
            this.lblSaveButton.Size = new System.Drawing.Size(574, 173);
            this.lblSaveButton.TabIndex = 1;
            this.lblSaveButton.Tag = "menu";
            this.lblSaveButton.Text = "Save";
            this.lblSaveButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SaveBtnClick);
            // 
            // lblQuitButton
            // 
            this.lblQuitButton.AutoSize = true;
            this.lblQuitButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblQuitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblQuitButton.Font = new System.Drawing.Font("ROG Fonts", 71.99999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuitButton.Location = new System.Drawing.Point(317, 562);
            this.lblQuitButton.Name = "lblQuitButton";
            this.lblQuitButton.Size = new System.Drawing.Size(513, 173);
            this.lblQuitButton.TabIndex = 1;
            this.lblQuitButton.Tag = "menu";
            this.lblQuitButton.Text = "Quit";
            this.lblQuitButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.QuitBtnClick);
            // 
            // PauseScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1160, 756);
            this.Controls.Add(this.lblQuitButton);
            this.Controls.Add(this.lblSaveButton);
            this.Controls.Add(this.lblResumeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PauseScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "The Game of Traffic Lights";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblResumeButton;
        private System.Windows.Forms.Label lblSaveButton;
        private System.Windows.Forms.Label lblQuitButton;
    }
}

