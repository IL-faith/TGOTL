namespace TGOTL
{
    partial class ResultsScreen
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
            this.lblStageSelectBtn = new System.Windows.Forms.Label();
            this.lblNextStageBtn = new System.Windows.Forms.Label();
            this.lblStageScore = new System.Windows.Forms.Label();
            this.lblPlayerScore = new System.Windows.Forms.Label();
            this.lblPassed = new System.Windows.Forms.Label();
            this.lblFailed = new System.Windows.Forms.Label();
            this.pbRetryBtn = new System.Windows.Forms.PictureBox();
            this.lblSelect0StageSelectBtn = new System.Windows.Forms.Label();
            this.lblSelect1NextStageBtn = new System.Windows.Forms.Label();
            this.lblSelect2RetryBtn = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbRetryBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStageSelectBtn
            // 
            this.lblStageSelectBtn.BackColor = System.Drawing.Color.RosyBrown;
            this.lblStageSelectBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblStageSelectBtn.Font = new System.Drawing.Font("ROG Fonts", 19F);
            this.lblStageSelectBtn.Location = new System.Drawing.Point(74, 527);
            this.lblStageSelectBtn.Name = "lblStageSelectBtn";
            this.lblStageSelectBtn.Size = new System.Drawing.Size(321, 146);
            this.lblStageSelectBtn.TabIndex = 11;
            this.lblStageSelectBtn.Tag = "";
            this.lblStageSelectBtn.Text = "Back to Stage Select";
            this.lblStageSelectBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblStageSelectBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.StageSelectBtnClick);
            // 
            // lblNextStageBtn
            // 
            this.lblNextStageBtn.BackColor = System.Drawing.Color.OliveDrab;
            this.lblNextStageBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNextStageBtn.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextStageBtn.Location = new System.Drawing.Point(743, 527);
            this.lblNextStageBtn.Name = "lblNextStageBtn";
            this.lblNextStageBtn.Size = new System.Drawing.Size(321, 146);
            this.lblNextStageBtn.TabIndex = 11;
            this.lblNextStageBtn.Tag = "";
            this.lblNextStageBtn.Text = "Next Stage";
            this.lblNextStageBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNextStageBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NextStageBtnClick);
            // 
            // lblStageScore
            // 
            this.lblStageScore.AutoSize = true;
            this.lblStageScore.Font = new System.Drawing.Font("ROG Fonts", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStageScore.Location = new System.Drawing.Point(311, 22);
            this.lblStageScore.Name = "lblStageScore";
            this.lblStageScore.Size = new System.Drawing.Size(529, 62);
            this.lblStageScore.TabIndex = 12;
            this.lblStageScore.Text = "Best score: #";
            // 
            // lblPlayerScore
            // 
            this.lblPlayerScore.AutoSize = true;
            this.lblPlayerScore.Font = new System.Drawing.Font("ROG Fonts", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerScore.Location = new System.Drawing.Point(311, 95);
            this.lblPlayerScore.Name = "lblPlayerScore";
            this.lblPlayerScore.Size = new System.Drawing.Size(530, 62);
            this.lblPlayerScore.TabIndex = 12;
            this.lblPlayerScore.Text = "Your score: #";
            // 
            // lblPassed
            // 
            this.lblPassed.AutoSize = true;
            this.lblPassed.Font = new System.Drawing.Font("ROG Fonts", 100F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassed.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPassed.Location = new System.Drawing.Point(192, 215);
            this.lblPassed.Name = "lblPassed";
            this.lblPassed.Size = new System.Drawing.Size(748, 240);
            this.lblPassed.TabIndex = 12;
            this.lblPassed.Text = "Nice!";
            // 
            // lblFailed
            // 
            this.lblFailed.AutoSize = true;
            this.lblFailed.Font = new System.Drawing.Font("ROG Fonts", 65F);
            this.lblFailed.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblFailed.Location = new System.Drawing.Point(46, 269);
            this.lblFailed.Name = "lblFailed";
            this.lblFailed.Size = new System.Drawing.Size(1090, 156);
            this.lblFailed.TabIndex = 12;
            this.lblFailed.Text = "Not Quite...";
            // 
            // pbRetryBtn
            // 
            this.pbRetryBtn.BackColor = System.Drawing.Color.Wheat;
            this.pbRetryBtn.Location = new System.Drawing.Point(477, 527);
            this.pbRetryBtn.Name = "pbRetryBtn";
            this.pbRetryBtn.Size = new System.Drawing.Size(191, 146);
            this.pbRetryBtn.TabIndex = 13;
            this.pbRetryBtn.TabStop = false;
            this.pbRetryBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RetryStageBtnClick);
            // 
            // lblSelect0StageSelectBtn
            // 
            this.lblSelect0StageSelectBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect0StageSelectBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelect0StageSelectBtn.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect0StageSelectBtn.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect0StageSelectBtn.Location = new System.Drawing.Point(64, 517);
            this.lblSelect0StageSelectBtn.Name = "lblSelect0StageSelectBtn";
            this.lblSelect0StageSelectBtn.Size = new System.Drawing.Size(341, 166);
            this.lblSelect0StageSelectBtn.TabIndex = 27;
            this.lblSelect0StageSelectBtn.Tag = "select";
            this.lblSelect0StageSelectBtn.Text = "BACK";
            // 
            // lblSelect1NextStageBtn
            // 
            this.lblSelect1NextStageBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect1NextStageBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelect1NextStageBtn.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect1NextStageBtn.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect1NextStageBtn.Location = new System.Drawing.Point(733, 517);
            this.lblSelect1NextStageBtn.Name = "lblSelect1NextStageBtn";
            this.lblSelect1NextStageBtn.Size = new System.Drawing.Size(341, 166);
            this.lblSelect1NextStageBtn.TabIndex = 28;
            this.lblSelect1NextStageBtn.Tag = "select";
            this.lblSelect1NextStageBtn.Text = "BACK";
            // 
            // lblSelect2RetryBtn
            // 
            this.lblSelect2RetryBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect2RetryBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelect2RetryBtn.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect2RetryBtn.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect2RetryBtn.Location = new System.Drawing.Point(467, 517);
            this.lblSelect2RetryBtn.Name = "lblSelect2RetryBtn";
            this.lblSelect2RetryBtn.Size = new System.Drawing.Size(211, 166);
            this.lblSelect2RetryBtn.TabIndex = 29;
            this.lblSelect2RetryBtn.Tag = "select";
            this.lblSelect2RetryBtn.Text = "BACK";
            // 
            // ResultsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1160, 756);
            this.Controls.Add(this.pbRetryBtn);
            this.Controls.Add(this.lblPassed);
            this.Controls.Add(this.lblFailed);
            this.Controls.Add(this.lblPlayerScore);
            this.Controls.Add(this.lblStageScore);
            this.Controls.Add(this.lblNextStageBtn);
            this.Controls.Add(this.lblStageSelectBtn);
            this.Controls.Add(this.lblSelect0StageSelectBtn);
            this.Controls.Add(this.lblSelect1NextStageBtn);
            this.Controls.Add(this.lblSelect2RetryBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ResultsScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "The Game of Traffic Lights";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyboardKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbRetryBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStageSelectBtn;
        private System.Windows.Forms.Label lblNextStageBtn;
        private System.Windows.Forms.Label lblStageScore;
        private System.Windows.Forms.Label lblPlayerScore;
        private System.Windows.Forms.Label lblPassed;
        private System.Windows.Forms.Label lblFailed;
        private System.Windows.Forms.PictureBox pbRetryBtn;
        private System.Windows.Forms.Label lblSelect0StageSelectBtn;
        private System.Windows.Forms.Label lblSelect1NextStageBtn;
        private System.Windows.Forms.Label lblSelect2RetryBtn;
    }
}

