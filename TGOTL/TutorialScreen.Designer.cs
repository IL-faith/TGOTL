namespace TGOTL
{
    partial class TutorialScreen
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
            this.lblTutorial = new System.Windows.Forms.Label();
            this.lblBackBtn = new System.Windows.Forms.Label();
            this.lblSelect0BackBtn = new System.Windows.Forms.Label();
            this.lblSelect1PrevArrow = new System.Windows.Forms.Label();
            this.lblSelect2NextArrow = new System.Windows.Forms.Label();
            this.pbNextArrow = new System.Windows.Forms.PictureBox();
            this.pbPrevArrow = new System.Windows.Forms.PictureBox();
            this.pbTutorialImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbNextArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrevArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTutorialImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTutorial
            // 
            this.lblTutorial.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTutorial.Font = new System.Drawing.Font("ROG Fonts", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTutorial.Location = new System.Drawing.Point(243, 26);
            this.lblTutorial.Name = "lblTutorial";
            this.lblTutorial.Size = new System.Drawing.Size(672, 96);
            this.lblTutorial.TabIndex = 3;
            this.lblTutorial.Text = "How To Play";
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
            this.lblBackBtn.TabIndex = 4;
            this.lblBackBtn.Tag = "";
            this.lblBackBtn.Text = "Back";
            this.lblBackBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BackBtnClick);
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
            this.lblSelect0BackBtn.TabIndex = 6;
            this.lblSelect0BackBtn.Tag = "select";
            this.lblSelect0BackBtn.Text = "BACK";
            this.lblSelect0BackBtn.Visible = false;
            // 
            // lblSelect1PrevArrow
            // 
            this.lblSelect1PrevArrow.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect1PrevArrow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelect1PrevArrow.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect1PrevArrow.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect1PrevArrow.Location = new System.Drawing.Point(24, 641);
            this.lblSelect1PrevArrow.Name = "lblSelect1PrevArrow";
            this.lblSelect1PrevArrow.Size = new System.Drawing.Size(160, 94);
            this.lblSelect1PrevArrow.TabIndex = 30;
            this.lblSelect1PrevArrow.Tag = "select";
            this.lblSelect1PrevArrow.Text = "BACK";
            this.lblSelect1PrevArrow.Visible = false;
            // 
            // lblSelect2NextArrow
            // 
            this.lblSelect2NextArrow.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect2NextArrow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelect2NextArrow.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect2NextArrow.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect2NextArrow.Location = new System.Drawing.Point(970, 641);
            this.lblSelect2NextArrow.Name = "lblSelect2NextArrow";
            this.lblSelect2NextArrow.Size = new System.Drawing.Size(160, 94);
            this.lblSelect2NextArrow.TabIndex = 29;
            this.lblSelect2NextArrow.Tag = "select";
            this.lblSelect2NextArrow.Text = "BACK";
            this.lblSelect2NextArrow.Visible = false;
            // 
            // pbNextArrow
            // 
            this.pbNextArrow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(79)))), ((int)(((byte)(114)))));
            this.pbNextArrow.BackgroundImage = global::TGOTL.Properties.Resources.next_transparent;
            this.pbNextArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbNextArrow.Location = new System.Drawing.Point(980, 651);
            this.pbNextArrow.Name = "pbNextArrow";
            this.pbNextArrow.Size = new System.Drawing.Size(140, 74);
            this.pbNextArrow.TabIndex = 5;
            this.pbNextArrow.TabStop = false;
            this.pbNextArrow.Click += new System.EventHandler(this.pbNextArrow_Click);
            // 
            // pbPrevArrow
            // 
            this.pbPrevArrow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(79)))), ((int)(((byte)(114)))));
            this.pbPrevArrow.BackgroundImage = global::TGOTL.Properties.Resources.back_transparent;
            this.pbPrevArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPrevArrow.Location = new System.Drawing.Point(34, 651);
            this.pbPrevArrow.Name = "pbPrevArrow";
            this.pbPrevArrow.Size = new System.Drawing.Size(140, 74);
            this.pbPrevArrow.TabIndex = 5;
            this.pbPrevArrow.TabStop = false;
            this.pbPrevArrow.Visible = false;
            this.pbPrevArrow.Click += new System.EventHandler(this.pbPrevArrow_Click);
            // 
            // pbTutorialImage
            // 
            this.pbTutorialImage.BackColor = System.Drawing.SystemColors.Info;
            this.pbTutorialImage.BackgroundImage = global::TGOTL.Properties.Resources.tutorial_one;
            this.pbTutorialImage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbTutorialImage.Location = new System.Drawing.Point(0, 134);
            this.pbTutorialImage.Name = "pbTutorialImage";
            this.pbTutorialImage.Size = new System.Drawing.Size(1160, 622);
            this.pbTutorialImage.TabIndex = 0;
            this.pbTutorialImage.TabStop = false;
            // 
            // TutorialScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1160, 756);
            this.Controls.Add(this.pbNextArrow);
            this.Controls.Add(this.pbPrevArrow);
            this.Controls.Add(this.lblBackBtn);
            this.Controls.Add(this.lblTutorial);
            this.Controls.Add(this.lblSelect0BackBtn);
            this.Controls.Add(this.lblSelect1PrevArrow);
            this.Controls.Add(this.lblSelect2NextArrow);
            this.Controls.Add(this.pbTutorialImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TutorialScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "The Game of Traffic Lights";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyboardKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbNextArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrevArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTutorialImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTutorialImage;
        private System.Windows.Forms.Label lblTutorial;
        private System.Windows.Forms.Label lblBackBtn;
        private System.Windows.Forms.PictureBox pbPrevArrow;
        private System.Windows.Forms.PictureBox pbNextArrow;
        private System.Windows.Forms.Label lblSelect0BackBtn;
        private System.Windows.Forms.Label lblSelect1PrevArrow;
        private System.Windows.Forms.Label lblSelect2NextArrow;
    }
}

