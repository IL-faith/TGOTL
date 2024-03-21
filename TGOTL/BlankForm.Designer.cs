namespace TGOTL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Screen));
            this.flpTimerTrafficLightMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.pbTrafficLight = new System.Windows.Forms.PictureBox();
            this.flpSettings = new System.Windows.Forms.FlowLayoutPanel();
            this.flpSetting1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtLightTime = new System.Windows.Forms.TextBox();
            this.cmbTimeUnit = new System.Windows.Forms.ComboBox();
            this.flpTimerTrafficLightMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrafficLight)).BeginInit();
            this.flpSettings.SuspendLayout();
            this.flpSetting1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpTimerTrafficLightMenu
            // 
            this.flpTimerTrafficLightMenu.Controls.Add(this.pbTrafficLight);
            this.flpTimerTrafficLightMenu.Controls.Add(this.flpSettings);
            this.flpTimerTrafficLightMenu.Location = new System.Drawing.Point(466, 143);
            this.flpTimerTrafficLightMenu.Name = "flpTimerTrafficLightMenu";
            this.flpTimerTrafficLightMenu.Size = new System.Drawing.Size(365, 366);
            this.flpTimerTrafficLightMenu.TabIndex = 0;
            // 
            // pbTrafficLight
            // 
            this.pbTrafficLight.Image = ((System.Drawing.Image)(resources.GetObject("pbTrafficLight.Image")));
            this.pbTrafficLight.Location = new System.Drawing.Point(3, 3);
            this.pbTrafficLight.Name = "pbTrafficLight";
            this.pbTrafficLight.Size = new System.Drawing.Size(178, 363);
            this.pbTrafficLight.TabIndex = 0;
            this.pbTrafficLight.TabStop = false;
            // 
            // flpSettings
            // 
            this.flpSettings.Controls.Add(this.flpSetting1);
            this.flpSettings.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpSettings.Location = new System.Drawing.Point(187, 3);
            this.flpSettings.Name = "flpSettings";
            this.flpSettings.Size = new System.Drawing.Size(175, 363);
            this.flpSettings.TabIndex = 1;
            // 
            // flpSetting1
            // 
            this.flpSetting1.Controls.Add(this.txtLightTime);
            this.flpSetting1.Controls.Add(this.cmbTimeUnit);
            this.flpSetting1.Location = new System.Drawing.Point(3, 3);
            this.flpSetting1.Name = "flpSetting1";
            this.flpSetting1.Size = new System.Drawing.Size(168, 110);
            this.flpSetting1.TabIndex = 0;
            // 
            // txtLightTime
            // 
            this.txtLightTime.Location = new System.Drawing.Point(3, 50);
            this.txtLightTime.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.txtLightTime.Name = "txtLightTime";
            this.txtLightTime.Size = new System.Drawing.Size(67, 26);
            this.txtLightTime.TabIndex = 0;
            this.txtLightTime.Text = "###";
            this.txtLightTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbTimeUnit
            // 
            this.cmbTimeUnit.FormattingEnabled = true;
            this.cmbTimeUnit.Items.AddRange(new object[] {
            "sec",
            "min"});
            this.cmbTimeUnit.Location = new System.Drawing.Point(76, 50);
            this.cmbTimeUnit.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.cmbTimeUnit.Name = "cmbTimeUnit";
            this.cmbTimeUnit.Size = new System.Drawing.Size(87, 28);
            this.cmbTimeUnit.TabIndex = 1;
            // 
            // Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1160, 756);
            this.Controls.Add(this.flpTimerTrafficLightMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Screen";
            this.Text = "The Game of Traffic Lights";
            this.flpTimerTrafficLightMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTrafficLight)).EndInit();
            this.flpSettings.ResumeLayout(false);
            this.flpSetting1.ResumeLayout(false);
            this.flpSetting1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpTimerTrafficLightMenu;
        private System.Windows.Forms.PictureBox pbTrafficLight;
        private System.Windows.Forms.FlowLayoutPanel flpSettings;
        private System.Windows.Forms.FlowLayoutPanel flpSetting1;
        private System.Windows.Forms.TextBox txtLightTime;
        private System.Windows.Forms.ComboBox cmbTimeUnit;
    }
}

