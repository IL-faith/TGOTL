namespace TGOTL
{
    partial class AlbumScreen
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
            this.pbTrivia1 = new System.Windows.Forms.PictureBox();
            this.lblBackBtn = new System.Windows.Forms.Label();
            this.lblAlbum = new System.Windows.Forms.Label();
            this.pbTrivia4 = new System.Windows.Forms.PictureBox();
            this.pbNextArrow = new System.Windows.Forms.PictureBox();
            this.pbPrevArrow = new System.Windows.Forms.PictureBox();
            this.pbTrivia2 = new System.Windows.Forms.PictureBox();
            this.pbTrivia5 = new System.Windows.Forms.PictureBox();
            this.pbTrivia3 = new System.Windows.Forms.PictureBox();
            this.pbTrivia6 = new System.Windows.Forms.PictureBox();
            this.pbSelectedTrivia = new System.Windows.Forms.PictureBox();
            this.lblGalleryModeBtn = new System.Windows.Forms.Label();
            this.lblSelect0BackBtn = new System.Windows.Forms.Label();
            this.lblSelect8NextArrow = new System.Windows.Forms.Label();
            this.lblSelect7PrevArrow = new System.Windows.Forms.Label();
            this.lblSelect9GalleryModeBtn = new System.Windows.Forms.Label();
            this.lblSelect1Trivia1 = new System.Windows.Forms.Label();
            this.lblSelect4Trivia4 = new System.Windows.Forms.Label();
            this.lblSelect2Trivia2 = new System.Windows.Forms.Label();
            this.lblSelect5Trivia5 = new System.Windows.Forms.Label();
            this.lblSelect3Trivia3 = new System.Windows.Forms.Label();
            this.lblSelect6Trivia6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrivia1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrivia4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNextArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrevArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrivia2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrivia5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrivia3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrivia6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectedTrivia)).BeginInit();
            this.SuspendLayout();
            // 
            // pbTrivia1
            // 
            this.pbTrivia1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbTrivia1.Location = new System.Drawing.Point(54, 161);
            this.pbTrivia1.Name = "pbTrivia1";
            this.pbTrivia1.Size = new System.Drawing.Size(292, 178);
            this.pbTrivia1.TabIndex = 0;
            this.pbTrivia1.TabStop = false;
            this.pbTrivia1.Tag = "gallery";
            this.pbTrivia1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TriviaClick);
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
            this.lblBackBtn.TabIndex = 6;
            this.lblBackBtn.Tag = "";
            this.lblBackBtn.Text = "Back";
            this.lblBackBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BackBtnClick);
            // 
            // lblAlbum
            // 
            this.lblAlbum.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblAlbum.Font = new System.Drawing.Font("ROG Fonts", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlbum.Location = new System.Drawing.Point(382, 26);
            this.lblAlbum.Name = "lblAlbum";
            this.lblAlbum.Size = new System.Drawing.Size(364, 96);
            this.lblAlbum.TabIndex = 5;
            this.lblAlbum.Text = "Album";
            // 
            // pbTrivia4
            // 
            this.pbTrivia4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbTrivia4.Location = new System.Drawing.Point(54, 409);
            this.pbTrivia4.Name = "pbTrivia4";
            this.pbTrivia4.Size = new System.Drawing.Size(292, 178);
            this.pbTrivia4.TabIndex = 0;
            this.pbTrivia4.TabStop = false;
            this.pbTrivia4.Tag = "gallery";
            this.pbTrivia4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TriviaClick);
            // 
            // pbNextArrow
            // 
            this.pbNextArrow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pbNextArrow.Location = new System.Drawing.Point(980, 651);
            this.pbNextArrow.Name = "pbNextArrow";
            this.pbNextArrow.Size = new System.Drawing.Size(140, 74);
            this.pbNextArrow.TabIndex = 7;
            this.pbNextArrow.TabStop = false;
            this.pbNextArrow.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NextBtnClick);
            // 
            // pbPrevArrow
            // 
            this.pbPrevArrow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pbPrevArrow.Location = new System.Drawing.Point(34, 651);
            this.pbPrevArrow.Name = "pbPrevArrow";
            this.pbPrevArrow.Size = new System.Drawing.Size(140, 74);
            this.pbPrevArrow.TabIndex = 8;
            this.pbPrevArrow.TabStop = false;
            this.pbPrevArrow.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PrevBtnClick);
            // 
            // pbTrivia2
            // 
            this.pbTrivia2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbTrivia2.Location = new System.Drawing.Point(439, 161);
            this.pbTrivia2.Name = "pbTrivia2";
            this.pbTrivia2.Size = new System.Drawing.Size(292, 178);
            this.pbTrivia2.TabIndex = 0;
            this.pbTrivia2.TabStop = false;
            this.pbTrivia2.Tag = "gallery";
            this.pbTrivia2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TriviaClick);
            // 
            // pbTrivia5
            // 
            this.pbTrivia5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbTrivia5.Location = new System.Drawing.Point(439, 409);
            this.pbTrivia5.Name = "pbTrivia5";
            this.pbTrivia5.Size = new System.Drawing.Size(292, 178);
            this.pbTrivia5.TabIndex = 0;
            this.pbTrivia5.TabStop = false;
            this.pbTrivia5.Tag = "gallery";
            this.pbTrivia5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TriviaClick);
            // 
            // pbTrivia3
            // 
            this.pbTrivia3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbTrivia3.Location = new System.Drawing.Point(808, 161);
            this.pbTrivia3.Name = "pbTrivia3";
            this.pbTrivia3.Size = new System.Drawing.Size(292, 178);
            this.pbTrivia3.TabIndex = 0;
            this.pbTrivia3.TabStop = false;
            this.pbTrivia3.Tag = "gallery";
            this.pbTrivia3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TriviaClick);
            // 
            // pbTrivia6
            // 
            this.pbTrivia6.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbTrivia6.Location = new System.Drawing.Point(808, 409);
            this.pbTrivia6.Name = "pbTrivia6";
            this.pbTrivia6.Size = new System.Drawing.Size(292, 178);
            this.pbTrivia6.TabIndex = 0;
            this.pbTrivia6.TabStop = false;
            this.pbTrivia6.Tag = "gallery";
            this.pbTrivia6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TriviaClick);
            // 
            // pbSelectedTrivia
            // 
            this.pbSelectedTrivia.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbSelectedTrivia.Location = new System.Drawing.Point(82, 140);
            this.pbSelectedTrivia.Name = "pbSelectedTrivia";
            this.pbSelectedTrivia.Size = new System.Drawing.Size(990, 487);
            this.pbSelectedTrivia.TabIndex = 9;
            this.pbSelectedTrivia.TabStop = false;
            // 
            // lblGalleryModeBtn
            // 
            this.lblGalleryModeBtn.BackColor = System.Drawing.Color.Wheat;
            this.lblGalleryModeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblGalleryModeBtn.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGalleryModeBtn.Location = new System.Drawing.Point(299, 651);
            this.lblGalleryModeBtn.Name = "lblGalleryModeBtn";
            this.lblGalleryModeBtn.Size = new System.Drawing.Size(568, 74);
            this.lblGalleryModeBtn.TabIndex = 10;
            this.lblGalleryModeBtn.Tag = "";
            this.lblGalleryModeBtn.Text = "Back to Gallery";
            this.lblGalleryModeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblGalleryModeBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GalleryBtnClick);
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
            this.lblSelect0BackBtn.TabIndex = 11;
            this.lblSelect0BackBtn.Tag = "select";
            this.lblSelect0BackBtn.Text = "BACK";
            // 
            // lblSelect8NextArrow
            // 
            this.lblSelect8NextArrow.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect8NextArrow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelect8NextArrow.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect8NextArrow.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect8NextArrow.Location = new System.Drawing.Point(970, 641);
            this.lblSelect8NextArrow.Name = "lblSelect8NextArrow";
            this.lblSelect8NextArrow.Size = new System.Drawing.Size(160, 94);
            this.lblSelect8NextArrow.TabIndex = 26;
            this.lblSelect8NextArrow.Tag = "select";
            this.lblSelect8NextArrow.Text = "BACK";
            // 
            // lblSelect7PrevArrow
            // 
            this.lblSelect7PrevArrow.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect7PrevArrow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelect7PrevArrow.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect7PrevArrow.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect7PrevArrow.Location = new System.Drawing.Point(24, 641);
            this.lblSelect7PrevArrow.Name = "lblSelect7PrevArrow";
            this.lblSelect7PrevArrow.Size = new System.Drawing.Size(160, 94);
            this.lblSelect7PrevArrow.TabIndex = 27;
            this.lblSelect7PrevArrow.Tag = "select";
            this.lblSelect7PrevArrow.Text = "BACK";
            // 
            // lblSelect9GalleryModeBtn
            // 
            this.lblSelect9GalleryModeBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect9GalleryModeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelect9GalleryModeBtn.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect9GalleryModeBtn.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect9GalleryModeBtn.Location = new System.Drawing.Point(289, 641);
            this.lblSelect9GalleryModeBtn.Name = "lblSelect9GalleryModeBtn";
            this.lblSelect9GalleryModeBtn.Size = new System.Drawing.Size(588, 94);
            this.lblSelect9GalleryModeBtn.TabIndex = 28;
            this.lblSelect9GalleryModeBtn.Tag = "select";
            this.lblSelect9GalleryModeBtn.Text = "BACK";
            // 
            // lblSelect1Trivia1
            // 
            this.lblSelect1Trivia1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect1Trivia1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelect1Trivia1.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect1Trivia1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect1Trivia1.Location = new System.Drawing.Point(44, 151);
            this.lblSelect1Trivia1.Name = "lblSelect1Trivia1";
            this.lblSelect1Trivia1.Size = new System.Drawing.Size(312, 198);
            this.lblSelect1Trivia1.TabIndex = 29;
            this.lblSelect1Trivia1.Tag = "select";
            this.lblSelect1Trivia1.Text = "BACK";
            // 
            // lblSelect4Trivia4
            // 
            this.lblSelect4Trivia4.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect4Trivia4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelect4Trivia4.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect4Trivia4.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect4Trivia4.Location = new System.Drawing.Point(44, 398);
            this.lblSelect4Trivia4.Name = "lblSelect4Trivia4";
            this.lblSelect4Trivia4.Size = new System.Drawing.Size(312, 198);
            this.lblSelect4Trivia4.TabIndex = 29;
            this.lblSelect4Trivia4.Tag = "select";
            this.lblSelect4Trivia4.Text = "BACK";
            // 
            // lblSelect2Trivia2
            // 
            this.lblSelect2Trivia2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect2Trivia2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelect2Trivia2.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect2Trivia2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect2Trivia2.Location = new System.Drawing.Point(429, 151);
            this.lblSelect2Trivia2.Name = "lblSelect2Trivia2";
            this.lblSelect2Trivia2.Size = new System.Drawing.Size(312, 198);
            this.lblSelect2Trivia2.TabIndex = 29;
            this.lblSelect2Trivia2.Tag = "select";
            this.lblSelect2Trivia2.Text = "BACK";
            // 
            // lblSelect5Trivia5
            // 
            this.lblSelect5Trivia5.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect5Trivia5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelect5Trivia5.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect5Trivia5.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect5Trivia5.Location = new System.Drawing.Point(429, 398);
            this.lblSelect5Trivia5.Name = "lblSelect5Trivia5";
            this.lblSelect5Trivia5.Size = new System.Drawing.Size(312, 198);
            this.lblSelect5Trivia5.TabIndex = 29;
            this.lblSelect5Trivia5.Tag = "select";
            this.lblSelect5Trivia5.Text = "BACK";
            // 
            // lblSelect3Trivia3
            // 
            this.lblSelect3Trivia3.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect3Trivia3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelect3Trivia3.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect3Trivia3.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect3Trivia3.Location = new System.Drawing.Point(798, 151);
            this.lblSelect3Trivia3.Name = "lblSelect3Trivia3";
            this.lblSelect3Trivia3.Size = new System.Drawing.Size(312, 198);
            this.lblSelect3Trivia3.TabIndex = 29;
            this.lblSelect3Trivia3.Tag = "select";
            this.lblSelect3Trivia3.Text = "BACK";
            // 
            // lblSelect6Trivia6
            // 
            this.lblSelect6Trivia6.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect6Trivia6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelect6Trivia6.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect6Trivia6.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect6Trivia6.Location = new System.Drawing.Point(798, 398);
            this.lblSelect6Trivia6.Name = "lblSelect6Trivia6";
            this.lblSelect6Trivia6.Size = new System.Drawing.Size(312, 198);
            this.lblSelect6Trivia6.TabIndex = 29;
            this.lblSelect6Trivia6.Tag = "select";
            this.lblSelect6Trivia6.Text = "BACK";
            // 
            // AlbumScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1160, 756);
            this.Controls.Add(this.lblGalleryModeBtn);
            this.Controls.Add(this.pbNextArrow);
            this.Controls.Add(this.pbPrevArrow);
            this.Controls.Add(this.lblBackBtn);
            this.Controls.Add(this.lblAlbum);
            this.Controls.Add(this.pbTrivia6);
            this.Controls.Add(this.pbTrivia3);
            this.Controls.Add(this.pbTrivia5);
            this.Controls.Add(this.pbTrivia2);
            this.Controls.Add(this.pbTrivia4);
            this.Controls.Add(this.pbTrivia1);
            this.Controls.Add(this.lblSelect0BackBtn);
            this.Controls.Add(this.lblSelect7PrevArrow);
            this.Controls.Add(this.lblSelect8NextArrow);
            this.Controls.Add(this.lblSelect9GalleryModeBtn);
            this.Controls.Add(this.lblSelect6Trivia6);
            this.Controls.Add(this.lblSelect3Trivia3);
            this.Controls.Add(this.lblSelect5Trivia5);
            this.Controls.Add(this.lblSelect2Trivia2);
            this.Controls.Add(this.lblSelect4Trivia4);
            this.Controls.Add(this.lblSelect1Trivia1);
            this.Controls.Add(this.pbSelectedTrivia);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AlbumScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "The Game of Traffic Lights";
            ((System.ComponentModel.ISupportInitialize)(this.pbTrivia1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrivia4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNextArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrevArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrivia2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrivia5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrivia3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrivia6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectedTrivia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTrivia1;
        private System.Windows.Forms.Label lblBackBtn;
        private System.Windows.Forms.Label lblAlbum;
        private System.Windows.Forms.PictureBox pbTrivia4;
        private System.Windows.Forms.PictureBox pbNextArrow;
        private System.Windows.Forms.PictureBox pbPrevArrow;
        private System.Windows.Forms.PictureBox pbTrivia2;
        private System.Windows.Forms.PictureBox pbTrivia5;
        private System.Windows.Forms.PictureBox pbTrivia3;
        private System.Windows.Forms.PictureBox pbTrivia6;
        private System.Windows.Forms.PictureBox pbSelectedTrivia;
        private System.Windows.Forms.Label lblGalleryModeBtn;
        private System.Windows.Forms.Label lblSelect0BackBtn;
        private System.Windows.Forms.Label lblSelect8NextArrow;
        private System.Windows.Forms.Label lblSelect7PrevArrow;
        private System.Windows.Forms.Label lblSelect9GalleryModeBtn;
        private System.Windows.Forms.Label lblSelect1Trivia1;
        private System.Windows.Forms.Label lblSelect4Trivia4;
        private System.Windows.Forms.Label lblSelect2Trivia2;
        private System.Windows.Forms.Label lblSelect5Trivia5;
        private System.Windows.Forms.Label lblSelect3Trivia3;
        private System.Windows.Forms.Label lblSelect6Trivia6;
    }
}

