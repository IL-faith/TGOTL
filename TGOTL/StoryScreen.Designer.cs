namespace TGOTL
{
    partial class StoryScreen
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
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.lblDialogueBox = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbImage
            // 
            this.pbImage.BackColor = System.Drawing.SystemColors.Control;
            this.pbImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbImage.Location = new System.Drawing.Point(0, 0);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(1160, 475);
            this.pbImage.TabIndex = 1;
            this.pbImage.TabStop = false;
            // 
            // lblDialogueBox
            // 
            this.lblDialogueBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.lblDialogueBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblDialogueBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDialogueBox.Location = new System.Drawing.Point(12, 488);
            this.lblDialogueBox.Name = "lblDialogueBox";
            this.lblDialogueBox.Size = new System.Drawing.Size(1136, 256);
            this.lblDialogueBox.TabIndex = 2;
            this.lblDialogueBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DialogueClicked);
            // 
            // StoryScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(1160, 756);
            this.Controls.Add(this.lblDialogueBox);
            this.Controls.Add(this.pbImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "StoryScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "The Game of Traffic Lights";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyboardKeyPressed);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Label lblDialogueBox;
    }
}

