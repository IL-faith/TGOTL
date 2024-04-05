namespace TGOTL
{
    partial class StageSelectionScreen
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
            this.lblBackBtn = new System.Windows.Forms.Label();
            this.lblStageSelect = new System.Windows.Forms.Label();
            this.lblStageScore = new System.Windows.Forms.Label();
            this.lblPlayerScore = new System.Windows.Forms.Label();
            this.lblStageLockedMessage = new System.Windows.Forms.Label();
            this.lblSelect0BackBtn = new System.Windows.Forms.Label();
            this.lblSelect1PauseBtn = new System.Windows.Forms.Label();
            this.lblSelect3PrevArrow = new System.Windows.Forms.Label();
            this.lblSelect4NextArrow = new System.Windows.Forms.Label();
            this.lblSelect2StagePreview = new System.Windows.Forms.Label();
            this.pbNextArrow = new System.Windows.Forms.PictureBox();
            this.pbPrevArrow = new System.Windows.Forms.PictureBox();
            this.pbStagePreview = new System.Windows.Forms.PictureBox();
            this.pbPauseBtn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbNextArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrevArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStagePreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPauseBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBackBtn
            // 
            this.lblBackBtn.AutoSize = true;
            this.lblBackBtn.BackColor = System.Drawing.Color.RosyBrown;
            this.lblBackBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBackBtn.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackBtn.Location = new System.Drawing.Point(12, 9);
            this.lblBackBtn.Name = "lblBackBtn";
            this.lblBackBtn.Size = new System.Drawing.Size(173, 53);
            this.lblBackBtn.TabIndex = 15;
            this.lblBackBtn.Tag = "";
            this.lblBackBtn.Text = "Back";
            this.lblBackBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BackBtnClick);
            // 
            // lblStageSelect
            // 
            this.lblStageSelect.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblStageSelect.Font = new System.Drawing.Font("ROG Fonts", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStageSelect.Location = new System.Drawing.Point(191, 26);
            this.lblStageSelect.Name = "lblStageSelect";
            this.lblStageSelect.Size = new System.Drawing.Size(780, 96);
            this.lblStageSelect.TabIndex = 19;
            this.lblStageSelect.Text = "Stage Select";
            // 
            // lblStageScore
            // 
            this.lblStageScore.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStageScore.Location = new System.Drawing.Point(36, 591);
            this.lblStageScore.Name = "lblStageScore";
            this.lblStageScore.Size = new System.Drawing.Size(295, 165);
            this.lblStageScore.TabIndex = 21;
            this.lblStageScore.Text = "Best score: #";
            // 
            // lblPlayerScore
            // 
            this.lblPlayerScore.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerScore.Location = new System.Drawing.Point(867, 591);
            this.lblPlayerScore.Name = "lblPlayerScore";
            this.lblPlayerScore.Size = new System.Drawing.Size(295, 165);
            this.lblPlayerScore.TabIndex = 20;
            this.lblPlayerScore.Text = "Your score: #";
            // 
            // lblStageLockedMessage
            // 
            this.lblStageLockedMessage.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStageLockedMessage.Location = new System.Drawing.Point(296, 573);
            this.lblStageLockedMessage.Name = "lblStageLockedMessage";
            this.lblStageLockedMessage.Size = new System.Drawing.Size(530, 174);
            this.lblStageLockedMessage.TabIndex = 22;
            this.lblStageLockedMessage.Text = "Beat previous stage to unlock";
            this.lblStageLockedMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSelect0BackBtn
            // 
            this.lblSelect0BackBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect0BackBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelect0BackBtn.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect0BackBtn.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect0BackBtn.Location = new System.Drawing.Point(2, 2);
            this.lblSelect0BackBtn.Name = "lblSelect0BackBtn";
            this.lblSelect0BackBtn.Size = new System.Drawing.Size(195, 68);
            this.lblSelect0BackBtn.TabIndex = 23;
            this.lblSelect0BackBtn.Tag = "select";
            this.lblSelect0BackBtn.Text = "BACK";
            this.lblSelect0BackBtn.Visible = false;
            // 
            // lblSelect1PauseBtn
            // 
            this.lblSelect1PauseBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect1PauseBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelect1PauseBtn.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect1PauseBtn.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect1PauseBtn.Location = new System.Drawing.Point(983, 0);
            this.lblSelect1PauseBtn.Name = "lblSelect1PauseBtn";
            this.lblSelect1PauseBtn.Size = new System.Drawing.Size(179, 143);
            this.lblSelect1PauseBtn.TabIndex = 24;
            this.lblSelect1PauseBtn.Tag = "select";
            this.lblSelect1PauseBtn.Text = "BACK";
            this.lblSelect1PauseBtn.Visible = false;
            // 
            // lblSelect3PrevArrow
            // 
            this.lblSelect3PrevArrow.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect3PrevArrow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelect3PrevArrow.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect3PrevArrow.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect3PrevArrow.Location = new System.Drawing.Point(59, 332);
            this.lblSelect3PrevArrow.Name = "lblSelect3PrevArrow";
            this.lblSelect3PrevArrow.Size = new System.Drawing.Size(160, 94);
            this.lblSelect3PrevArrow.TabIndex = 25;
            this.lblSelect3PrevArrow.Tag = "select";
            this.lblSelect3PrevArrow.Text = "BACK";
            this.lblSelect3PrevArrow.Visible = false;
            // 
            // lblSelect4NextArrow
            // 
            this.lblSelect4NextArrow.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect4NextArrow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelect4NextArrow.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect4NextArrow.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect4NextArrow.Location = new System.Drawing.Point(916, 332);
            this.lblSelect4NextArrow.Name = "lblSelect4NextArrow";
            this.lblSelect4NextArrow.Size = new System.Drawing.Size(160, 94);
            this.lblSelect4NextArrow.TabIndex = 25;
            this.lblSelect4NextArrow.Tag = "select";
            this.lblSelect4NextArrow.Text = "BACK";
            this.lblSelect4NextArrow.Visible = false;
            // 
            // lblSelect2StagePreview
            // 
            this.lblSelect2StagePreview.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect2StagePreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelect2StagePreview.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect2StagePreview.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect2StagePreview.Location = new System.Drawing.Point(286, 145);
            this.lblSelect2StagePreview.Name = "lblSelect2StagePreview";
            this.lblSelect2StagePreview.Size = new System.Drawing.Size(550, 428);
            this.lblSelect2StagePreview.TabIndex = 26;
            this.lblSelect2StagePreview.Tag = "select";
            this.lblSelect2StagePreview.Text = "BACK";
            this.lblSelect2StagePreview.Visible = false;
            // 
            // pbNextArrow
            // 
            this.pbNextArrow.BackColor = System.Drawing.Color.Transparent;
            this.pbNextArrow.BackgroundImage = global::TGOTL.Properties.Resources.next_transparent;
            this.pbNextArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbNextArrow.Location = new System.Drawing.Point(926, 343);
            this.pbNextArrow.Name = "pbNextArrow";
            this.pbNextArrow.Size = new System.Drawing.Size(140, 74);
            this.pbNextArrow.TabIndex = 17;
            this.pbNextArrow.TabStop = false;
            this.pbNextArrow.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NextBtnClick);
            // 
            // pbPrevArrow
            // 
            this.pbPrevArrow.BackColor = System.Drawing.Color.Transparent;
            this.pbPrevArrow.BackgroundImage = global::TGOTL.Properties.Resources.back_transparent;
            this.pbPrevArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPrevArrow.Location = new System.Drawing.Point(69, 343);
            this.pbPrevArrow.Name = "pbPrevArrow";
            this.pbPrevArrow.Size = new System.Drawing.Size(140, 74);
            this.pbPrevArrow.TabIndex = 18;
            this.pbPrevArrow.TabStop = false;
            this.pbPrevArrow.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PrevBtnClick);
            // 
            // pbStagePreview
            // 
            this.pbStagePreview.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pbStagePreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbStagePreview.Location = new System.Drawing.Point(296, 155);
            this.pbStagePreview.Name = "pbStagePreview";
            this.pbStagePreview.Size = new System.Drawing.Size(530, 408);
            this.pbStagePreview.TabIndex = 16;
            this.pbStagePreview.TabStop = false;
            this.pbStagePreview.MouseClick += new System.Windows.Forms.MouseEventHandler(this.StageClick);
            // 
            // pbPauseBtn
            // 
            this.pbPauseBtn.BackColor = System.Drawing.Color.Transparent;
            this.pbPauseBtn.BackgroundImage = global::TGOTL.Properties.Resources.pause_transparent;
            this.pbPauseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPauseBtn.Location = new System.Drawing.Point(992, 0);
            this.pbPauseBtn.Name = "pbPauseBtn";
            this.pbPauseBtn.Size = new System.Drawing.Size(169, 133);
            this.pbPauseBtn.TabIndex = 14;
            this.pbPauseBtn.TabStop = false;
            this.pbPauseBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PauseBtnClick);
            // 
            // StageSelectionScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1160, 756);
            this.Controls.Add(this.lblStageScore);
            this.Controls.Add(this.lblPlayerScore);
            this.Controls.Add(this.pbNextArrow);
            this.Controls.Add(this.pbPrevArrow);
            this.Controls.Add(this.pbStagePreview);
            this.Controls.Add(this.lblBackBtn);
            this.Controls.Add(this.pbPauseBtn);
            this.Controls.Add(this.lblSelect0BackBtn);
            this.Controls.Add(this.lblStageSelect);
            this.Controls.Add(this.lblStageLockedMessage);
            this.Controls.Add(this.lblSelect1PauseBtn);
            this.Controls.Add(this.lblSelect4NextArrow);
            this.Controls.Add(this.lblSelect3PrevArrow);
            this.Controls.Add(this.lblSelect2StagePreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "StageSelectionScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "The Game of Traffic Lights";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyboardKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbNextArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrevArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStagePreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPauseBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPauseBtn;
        private System.Windows.Forms.Label lblBackBtn;
        private System.Windows.Forms.PictureBox pbStagePreview;
        private System.Windows.Forms.PictureBox pbNextArrow;
        private System.Windows.Forms.PictureBox pbPrevArrow;
        private System.Windows.Forms.Label lblStageSelect;
        private System.Windows.Forms.Label lblStageScore;
        private System.Windows.Forms.Label lblPlayerScore;
        private System.Windows.Forms.Label lblStageLockedMessage;
        private System.Windows.Forms.Label lblSelect0BackBtn;
        private System.Windows.Forms.Label lblSelect1PauseBtn;
        private System.Windows.Forms.Label lblSelect3PrevArrow;
        private System.Windows.Forms.Label lblSelect4NextArrow;
        private System.Windows.Forms.Label lblSelect2StagePreview;
    }
}

