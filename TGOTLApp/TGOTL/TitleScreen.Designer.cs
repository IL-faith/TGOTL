namespace TGOTL
{
    partial class TitleScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TitleScreen));
            this.lblMenu1StartBtn = new System.Windows.Forms.Label();
            this.lblMenu2LoadBtn = new System.Windows.Forms.Label();
            this.lblMenu3AlbumBtn = new System.Windows.Forms.Label();
            this.lblMenu4TutorialBtn = new System.Windows.Forms.Label();
            this.lblMenu5PlaystyleBtn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMenu1StartBtn
            // 
            this.lblMenu1StartBtn.AutoSize = true;
            this.lblMenu1StartBtn.BackColor = System.Drawing.Color.Transparent;
            this.lblMenu1StartBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMenu1StartBtn.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu1StartBtn.Location = new System.Drawing.Point(468, 424);
            this.lblMenu1StartBtn.Name = "lblMenu1StartBtn";
            this.lblMenu1StartBtn.Size = new System.Drawing.Size(220, 53);
            this.lblMenu1StartBtn.TabIndex = 0;
            this.lblMenu1StartBtn.Tag = "menu";
            this.lblMenu1StartBtn.Text = "Start";
            this.lblMenu1StartBtn.Click += new System.EventHandler(this.StartGameClick);
            this.lblMenu1StartBtn.MouseEnter += new System.EventHandler(this.MouseOnMenuChoice);
            this.lblMenu1StartBtn.MouseLeave += new System.EventHandler(this.MouseOffMenuChoice);
            // 
            // lblMenu2LoadBtn
            // 
            this.lblMenu2LoadBtn.AutoSize = true;
            this.lblMenu2LoadBtn.BackColor = System.Drawing.Color.Transparent;
            this.lblMenu2LoadBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMenu2LoadBtn.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu2LoadBtn.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblMenu2LoadBtn.Location = new System.Drawing.Point(467, 488);
            this.lblMenu2LoadBtn.Name = "lblMenu2LoadBtn";
            this.lblMenu2LoadBtn.Size = new System.Drawing.Size(221, 53);
            this.lblMenu2LoadBtn.TabIndex = 1;
            this.lblMenu2LoadBtn.Tag = "menu";
            this.lblMenu2LoadBtn.Text = "  Load  ";
            this.lblMenu2LoadBtn.Click += new System.EventHandler(this.LoadGameClick);
            this.lblMenu2LoadBtn.MouseEnter += new System.EventHandler(this.MouseOnMenuChoice);
            this.lblMenu2LoadBtn.MouseLeave += new System.EventHandler(this.MouseOffMenuChoice);
            // 
            // lblMenu3AlbumBtn
            // 
            this.lblMenu3AlbumBtn.AutoSize = true;
            this.lblMenu3AlbumBtn.BackColor = System.Drawing.Color.Transparent;
            this.lblMenu3AlbumBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMenu3AlbumBtn.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu3AlbumBtn.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblMenu3AlbumBtn.Location = new System.Drawing.Point(440, 550);
            this.lblMenu3AlbumBtn.Name = "lblMenu3AlbumBtn";
            this.lblMenu3AlbumBtn.Size = new System.Drawing.Size(262, 53);
            this.lblMenu3AlbumBtn.TabIndex = 0;
            this.lblMenu3AlbumBtn.Tag = "menu";
            this.lblMenu3AlbumBtn.Text = "  Album  ";
            this.lblMenu3AlbumBtn.Click += new System.EventHandler(this.ViewAlbumClick);
            this.lblMenu3AlbumBtn.MouseEnter += new System.EventHandler(this.MouseOnMenuChoice);
            this.lblMenu3AlbumBtn.MouseLeave += new System.EventHandler(this.MouseOffMenuChoice);
            // 
            // lblMenu4TutorialBtn
            // 
            this.lblMenu4TutorialBtn.AutoSize = true;
            this.lblMenu4TutorialBtn.BackColor = System.Drawing.Color.Transparent;
            this.lblMenu4TutorialBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMenu4TutorialBtn.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu4TutorialBtn.Location = new System.Drawing.Point(419, 618);
            this.lblMenu4TutorialBtn.Name = "lblMenu4TutorialBtn";
            this.lblMenu4TutorialBtn.Size = new System.Drawing.Size(305, 53);
            this.lblMenu4TutorialBtn.TabIndex = 1;
            this.lblMenu4TutorialBtn.Tag = "menu";
            this.lblMenu4TutorialBtn.Text = "Tutorial";
            this.lblMenu4TutorialBtn.Click += new System.EventHandler(this.ViewTutorialClick);
            this.lblMenu4TutorialBtn.MouseEnter += new System.EventHandler(this.MouseOnMenuChoice);
            this.lblMenu4TutorialBtn.MouseLeave += new System.EventHandler(this.MouseOffMenuChoice);
            // 
            // lblMenu5PlaystyleBtn
            // 
            this.lblMenu5PlaystyleBtn.AutoSize = true;
            this.lblMenu5PlaystyleBtn.BackColor = System.Drawing.Color.Transparent;
            this.lblMenu5PlaystyleBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMenu5PlaystyleBtn.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu5PlaystyleBtn.Location = new System.Drawing.Point(365, 686);
            this.lblMenu5PlaystyleBtn.Name = "lblMenu5PlaystyleBtn";
            this.lblMenu5PlaystyleBtn.Size = new System.Drawing.Size(397, 53);
            this.lblMenu5PlaystyleBtn.TabIndex = 1;
            this.lblMenu5PlaystyleBtn.Tag = "menu";
            this.lblMenu5PlaystyleBtn.Text = "Mode: Mouse";
            this.lblMenu5PlaystyleBtn.Click += new System.EventHandler(this.ChangePlaystyleClick);
            this.lblMenu5PlaystyleBtn.MouseEnter += new System.EventHandler(this.MouseOnMenuChoice);
            this.lblMenu5PlaystyleBtn.MouseLeave += new System.EventHandler(this.MouseOffMenuChoice);
            // 
            // TitleScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1160, 756);
            this.Controls.Add(this.lblMenu5PlaystyleBtn);
            this.Controls.Add(this.lblMenu4TutorialBtn);
            this.Controls.Add(this.lblMenu2LoadBtn);
            this.Controls.Add(this.lblMenu3AlbumBtn);
            this.Controls.Add(this.lblMenu1StartBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TitleScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Game of Traffic Lights";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyboardKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMenu1StartBtn;
        private System.Windows.Forms.Label lblMenu2LoadBtn;
        private System.Windows.Forms.Label lblMenu3AlbumBtn;
        private System.Windows.Forms.Label lblMenu4TutorialBtn;
        private System.Windows.Forms.Label lblMenu5PlaystyleBtn;
    }
}

