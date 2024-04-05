namespace TGOTL
{
    partial class Stage2Prep
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stage2Prep));
            this.lblBackBtn = new System.Windows.Forms.Label();
            this.pbPauseBtn = new System.Windows.Forms.PictureBox();
            this.lblFinishPrepBtn = new System.Windows.Forms.Label();
            this.lblPrep = new System.Windows.Forms.Label();
            this.lblSelect0BackBtn = new System.Windows.Forms.Label();
            this.lblSelect1PauseBtn = new System.Windows.Forms.Label();
            this.lblSelect2FinishPrepBtn = new System.Windows.Forms.Label();
            this.pbTrafficLightH1 = new System.Windows.Forms.PictureBox();
            this.pbTrafficLightH2 = new System.Windows.Forms.PictureBox();
            this.pbTrafficLightV1 = new System.Windows.Forms.PictureBox();
            this.timeStageTimer = new System.Windows.Forms.Timer(this.components);
            this.pbH1Car1 = new System.Windows.Forms.PictureBox();
            this.pbH2Car1 = new System.Windows.Forms.PictureBox();
            this.pbV1Car1 = new System.Windows.Forms.PictureBox();
            this.timeRedLightTimerH = new System.Windows.Forms.Timer(this.components);
            this.timeYellowLightTimerH = new System.Windows.Forms.Timer(this.components);
            this.timeGreenLightTimerH = new System.Windows.Forms.Timer(this.components);
            this.timeRedLightTimerV = new System.Windows.Forms.Timer(this.components);
            this.timeYellowLightTimerV = new System.Windows.Forms.Timer(this.components);
            this.timeGreenLightTimerV = new System.Windows.Forms.Timer(this.components);
            this.lblStageScore = new System.Windows.Forms.Label();
            this.timeStageTimer2 = new System.Windows.Forms.Timer(this.components);
            this.lblIntersectionArea = new System.Windows.Forms.Label();
            this.flpTimerTrafficLightMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.pbTrafficLight = new System.Windows.Forms.PictureBox();
            this.flpSettings = new System.Windows.Forms.FlowLayoutPanel();
            this.flpSetting1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtLightTime1 = new System.Windows.Forms.TextBox();
            this.cmbTimeUnit1 = new System.Windows.Forms.ComboBox();
            this.flpSetting2 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtLightTime2 = new System.Windows.Forms.TextBox();
            this.cmbTimeUnit2 = new System.Windows.Forms.ComboBox();
            this.flpSetting3 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtLightTime3 = new System.Windows.Forms.TextBox();
            this.cmbTimeUnit3 = new System.Windows.Forms.ComboBox();
            this.lblLowerLeftIntersection = new System.Windows.Forms.Label();
            this.lblLowerRightIntersection = new System.Windows.Forms.Label();
            this.lblUpperRightIntersection = new System.Windows.Forms.Label();
            this.lblUpperLeftIntersection = new System.Windows.Forms.Label();
            this.lblSelect3TrafficLight1 = new System.Windows.Forms.Label();
            this.lblSelect5TrafficLight3 = new System.Windows.Forms.Label();
            this.lblSelect4TrafficLight4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPauseBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrafficLightH1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrafficLightH2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrafficLightV1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbH1Car1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbH2Car1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbV1Car1)).BeginInit();
            this.flpTimerTrafficLightMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrafficLight)).BeginInit();
            this.flpSettings.SuspendLayout();
            this.flpSetting1.SuspendLayout();
            this.flpSetting2.SuspendLayout();
            this.flpSetting3.SuspendLayout();
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
            this.lblBackBtn.TabIndex = 20;
            this.lblBackBtn.Tag = "";
            this.lblBackBtn.Text = "Back";
            this.lblBackBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BackBtnClick);
            // 
            // pbPauseBtn
            // 
            this.pbPauseBtn.BackColor = System.Drawing.Color.Transparent;
            this.pbPauseBtn.BackgroundImage = global::TGOTL.Properties.Resources.pause_transparent;
            this.pbPauseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPauseBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPauseBtn.Location = new System.Drawing.Point(992, 0);
            this.pbPauseBtn.Name = "pbPauseBtn";
            this.pbPauseBtn.Size = new System.Drawing.Size(169, 133);
            this.pbPauseBtn.TabIndex = 19;
            this.pbPauseBtn.TabStop = false;
            this.pbPauseBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PauseBtnClick);
            // 
            // lblFinishPrepBtn
            // 
            this.lblFinishPrepBtn.BackColor = System.Drawing.Color.OliveDrab;
            this.lblFinishPrepBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFinishPrepBtn.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinishPrepBtn.Location = new System.Drawing.Point(828, 644);
            this.lblFinishPrepBtn.Name = "lblFinishPrepBtn";
            this.lblFinishPrepBtn.Size = new System.Drawing.Size(321, 103);
            this.lblFinishPrepBtn.TabIndex = 18;
            this.lblFinishPrepBtn.Tag = "";
            this.lblFinishPrepBtn.Text = "Finish";
            this.lblFinishPrepBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFinishPrepBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FinishPrepBtnClick);
            // 
            // lblPrep
            // 
            this.lblPrep.BackColor = System.Drawing.Color.Transparent;
            this.lblPrep.Font = new System.Drawing.Font("ROG Fonts", 24F);
            this.lblPrep.Location = new System.Drawing.Point(26, 108);
            this.lblPrep.Name = "lblPrep";
            this.lblPrep.Size = new System.Drawing.Size(228, 127);
            this.lblPrep.TabIndex = 21;
            this.lblPrep.Text = "Prep";
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
            this.lblSelect0BackBtn.TabIndex = 22;
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
            this.lblSelect1PauseBtn.TabIndex = 25;
            this.lblSelect1PauseBtn.Tag = "select";
            this.lblSelect1PauseBtn.Text = "BACK";
            this.lblSelect1PauseBtn.Visible = false;
            // 
            // lblSelect2FinishPrepBtn
            // 
            this.lblSelect2FinishPrepBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect2FinishPrepBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelect2FinishPrepBtn.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect2FinishPrepBtn.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect2FinishPrepBtn.Location = new System.Drawing.Point(816, 632);
            this.lblSelect2FinishPrepBtn.Name = "lblSelect2FinishPrepBtn";
            this.lblSelect2FinishPrepBtn.Size = new System.Drawing.Size(344, 125);
            this.lblSelect2FinishPrepBtn.TabIndex = 26;
            this.lblSelect2FinishPrepBtn.Tag = "select";
            this.lblSelect2FinishPrepBtn.Text = "BACK";
            this.lblSelect2FinishPrepBtn.Visible = false;
            // 
            // pbTrafficLightH1
            // 
            this.pbTrafficLightH1.BackColor = System.Drawing.Color.Transparent;
            this.pbTrafficLightH1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbTrafficLightH1.Image = ((System.Drawing.Image)(resources.GetObject("pbTrafficLightH1.Image")));
            this.pbTrafficLightH1.Location = new System.Drawing.Point(365, 220);
            this.pbTrafficLightH1.Name = "pbTrafficLightH1";
            this.pbTrafficLightH1.Size = new System.Drawing.Size(90, 164);
            this.pbTrafficLightH1.TabIndex = 27;
            this.pbTrafficLightH1.TabStop = false;
            this.pbTrafficLightH1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ShowTrafficLightSettingsClick);
            // 
            // pbTrafficLightH2
            // 
            this.pbTrafficLightH2.BackColor = System.Drawing.Color.Transparent;
            this.pbTrafficLightH2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbTrafficLightH2.Image = ((System.Drawing.Image)(resources.GetObject("pbTrafficLightH2.Image")));
            this.pbTrafficLightH2.Location = new System.Drawing.Point(727, 425);
            this.pbTrafficLightH2.Name = "pbTrafficLightH2";
            this.pbTrafficLightH2.Size = new System.Drawing.Size(90, 164);
            this.pbTrafficLightH2.TabIndex = 28;
            this.pbTrafficLightH2.TabStop = false;
            this.pbTrafficLightH2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ShowTrafficLightSettingsClick);
            // 
            // pbTrafficLightV1
            // 
            this.pbTrafficLightV1.BackColor = System.Drawing.Color.Transparent;
            this.pbTrafficLightV1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbTrafficLightV1.Image = ((System.Drawing.Image)(resources.GetObject("pbTrafficLightV1.Image")));
            this.pbTrafficLightV1.Location = new System.Drawing.Point(598, 225);
            this.pbTrafficLightV1.Name = "pbTrafficLightV1";
            this.pbTrafficLightV1.Size = new System.Drawing.Size(164, 90);
            this.pbTrafficLightV1.TabIndex = 29;
            this.pbTrafficLightV1.TabStop = false;
            this.pbTrafficLightV1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ShowTrafficLightSettingsClick);
            // 
            // timeStageTimer
            // 
            this.timeStageTimer.Interval = 150;
            this.timeStageTimer.Tick += new System.EventHandler(this.TrafficGeneration1);
            // 
            // pbH1Car1
            // 
            this.pbH1Car1.Location = new System.Drawing.Point(1149, 330);
            this.pbH1Car1.Name = "pbH1Car1";
            this.pbH1Car1.Size = new System.Drawing.Size(100, 50);
            this.pbH1Car1.TabIndex = 32;
            this.pbH1Car1.TabStop = false;
            this.pbH1Car1.Visible = false;
            // 
            // pbH2Car1
            // 
            this.pbH2Car1.Location = new System.Drawing.Point(-90, 437);
            this.pbH2Car1.Name = "pbH2Car1";
            this.pbH2Car1.Size = new System.Drawing.Size(100, 50);
            this.pbH2Car1.TabIndex = 33;
            this.pbH2Car1.TabStop = false;
            this.pbH2Car1.Visible = false;
            // 
            // pbV1Car1
            // 
            this.pbV1Car1.Location = new System.Drawing.Point(617, 747);
            this.pbV1Car1.Name = "pbV1Car1";
            this.pbV1Car1.Size = new System.Drawing.Size(50, 100);
            this.pbV1Car1.TabIndex = 35;
            this.pbV1Car1.TabStop = false;
            this.pbV1Car1.Visible = false;
            // 
            // timeRedLightTimerH
            // 
            this.timeRedLightTimerH.Enabled = true;
            this.timeRedLightTimerH.Tick += new System.EventHandler(this.LightIsRedH);
            // 
            // timeYellowLightTimerH
            // 
            this.timeYellowLightTimerH.Enabled = true;
            this.timeYellowLightTimerH.Tick += new System.EventHandler(this.LightIsYellowH);
            // 
            // timeGreenLightTimerH
            // 
            this.timeGreenLightTimerH.Enabled = true;
            this.timeGreenLightTimerH.Tick += new System.EventHandler(this.LightIsGreenH);
            // 
            // timeRedLightTimerV
            // 
            this.timeRedLightTimerV.Enabled = true;
            this.timeRedLightTimerV.Tick += new System.EventHandler(this.LightIsRedV);
            // 
            // timeYellowLightTimerV
            // 
            this.timeYellowLightTimerV.Enabled = true;
            this.timeYellowLightTimerV.Tick += new System.EventHandler(this.LightIsYellowV);
            // 
            // timeGreenLightTimerV
            // 
            this.timeGreenLightTimerV.Enabled = true;
            this.timeGreenLightTimerV.Tick += new System.EventHandler(this.LightIsGreenV);
            // 
            // lblStageScore
            // 
            this.lblStageScore.BackColor = System.Drawing.Color.Transparent;
            this.lblStageScore.Font = new System.Drawing.Font("ROG Fonts", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStageScore.Location = new System.Drawing.Point(6, 620);
            this.lblStageScore.Name = "lblStageScore";
            this.lblStageScore.Size = new System.Drawing.Size(228, 127);
            this.lblStageScore.TabIndex = 37;
            this.lblStageScore.Text = "Stage Score: ";
            // 
            // timeStageTimer2
            // 
            this.timeStageTimer2.Interval = 150;
            this.timeStageTimer2.Tick += new System.EventHandler(this.TrafficGeneration2);
            // 
            // lblIntersectionArea
            // 
            this.lblIntersectionArea.Location = new System.Drawing.Point(475, 318);
            this.lblIntersectionArea.Name = "lblIntersectionArea";
            this.lblIntersectionArea.Size = new System.Drawing.Size(225, 208);
            this.lblIntersectionArea.TabIndex = 39;
            this.lblIntersectionArea.Visible = false;
            // 
            // flpTimerTrafficLightMenu
            // 
            this.flpTimerTrafficLightMenu.Controls.Add(this.pbTrafficLight);
            this.flpTimerTrafficLightMenu.Controls.Add(this.flpSettings);
            this.flpTimerTrafficLightMenu.Location = new System.Drawing.Point(356, 330);
            this.flpTimerTrafficLightMenu.Name = "flpTimerTrafficLightMenu";
            this.flpTimerTrafficLightMenu.Size = new System.Drawing.Size(365, 366);
            this.flpTimerTrafficLightMenu.TabIndex = 38;
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
            this.flpSettings.Controls.Add(this.flpSetting2);
            this.flpSettings.Controls.Add(this.flpSetting3);
            this.flpSettings.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpSettings.Location = new System.Drawing.Point(187, 3);
            this.flpSettings.Name = "flpSettings";
            this.flpSettings.Size = new System.Drawing.Size(175, 363);
            this.flpSettings.TabIndex = 1;
            // 
            // flpSetting1
            // 
            this.flpSetting1.Controls.Add(this.txtLightTime1);
            this.flpSetting1.Controls.Add(this.cmbTimeUnit1);
            this.flpSetting1.Location = new System.Drawing.Point(3, 3);
            this.flpSetting1.Name = "flpSetting1";
            this.flpSetting1.Size = new System.Drawing.Size(168, 110);
            this.flpSetting1.TabIndex = 0;
            // 
            // txtLightTime1
            // 
            this.txtLightTime1.Location = new System.Drawing.Point(3, 50);
            this.txtLightTime1.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.txtLightTime1.Name = "txtLightTime1";
            this.txtLightTime1.Size = new System.Drawing.Size(67, 26);
            this.txtLightTime1.TabIndex = 0;
            this.txtLightTime1.Text = "###";
            this.txtLightTime1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLightTime1.TextChanged += new System.EventHandler(this.TimeInputted);
            // 
            // cmbTimeUnit1
            // 
            this.cmbTimeUnit1.FormattingEnabled = true;
            this.cmbTimeUnit1.Items.AddRange(new object[] {
            "sec",
            "min"});
            this.cmbTimeUnit1.Location = new System.Drawing.Point(76, 50);
            this.cmbTimeUnit1.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.cmbTimeUnit1.Name = "cmbTimeUnit1";
            this.cmbTimeUnit1.Size = new System.Drawing.Size(87, 28);
            this.cmbTimeUnit1.TabIndex = 1;
            this.cmbTimeUnit1.SelectedIndexChanged += new System.EventHandler(this.TimeUnitChanged);
            // 
            // flpSetting2
            // 
            this.flpSetting2.Controls.Add(this.txtLightTime2);
            this.flpSetting2.Controls.Add(this.cmbTimeUnit2);
            this.flpSetting2.Location = new System.Drawing.Point(3, 119);
            this.flpSetting2.Name = "flpSetting2";
            this.flpSetting2.Size = new System.Drawing.Size(168, 110);
            this.flpSetting2.TabIndex = 2;
            // 
            // txtLightTime2
            // 
            this.txtLightTime2.Location = new System.Drawing.Point(3, 50);
            this.txtLightTime2.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.txtLightTime2.Name = "txtLightTime2";
            this.txtLightTime2.Size = new System.Drawing.Size(67, 26);
            this.txtLightTime2.TabIndex = 0;
            this.txtLightTime2.Text = "###";
            this.txtLightTime2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLightTime2.TextChanged += new System.EventHandler(this.TimeInputted);
            // 
            // cmbTimeUnit2
            // 
            this.cmbTimeUnit2.FormattingEnabled = true;
            this.cmbTimeUnit2.Items.AddRange(new object[] {
            "sec",
            "min"});
            this.cmbTimeUnit2.Location = new System.Drawing.Point(76, 50);
            this.cmbTimeUnit2.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.cmbTimeUnit2.Name = "cmbTimeUnit2";
            this.cmbTimeUnit2.Size = new System.Drawing.Size(87, 28);
            this.cmbTimeUnit2.TabIndex = 1;
            this.cmbTimeUnit2.SelectedIndexChanged += new System.EventHandler(this.TimeUnitChanged);
            // 
            // flpSetting3
            // 
            this.flpSetting3.Controls.Add(this.txtLightTime3);
            this.flpSetting3.Controls.Add(this.cmbTimeUnit3);
            this.flpSetting3.Location = new System.Drawing.Point(3, 235);
            this.flpSetting3.Name = "flpSetting3";
            this.flpSetting3.Size = new System.Drawing.Size(168, 110);
            this.flpSetting3.TabIndex = 2;
            // 
            // txtLightTime3
            // 
            this.txtLightTime3.Location = new System.Drawing.Point(3, 50);
            this.txtLightTime3.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.txtLightTime3.Name = "txtLightTime3";
            this.txtLightTime3.Size = new System.Drawing.Size(67, 26);
            this.txtLightTime3.TabIndex = 0;
            this.txtLightTime3.Text = "###";
            this.txtLightTime3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLightTime3.TextChanged += new System.EventHandler(this.TimeInputted);
            // 
            // cmbTimeUnit3
            // 
            this.cmbTimeUnit3.FormattingEnabled = true;
            this.cmbTimeUnit3.Items.AddRange(new object[] {
            "sec",
            "min"});
            this.cmbTimeUnit3.Location = new System.Drawing.Point(76, 50);
            this.cmbTimeUnit3.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.cmbTimeUnit3.Name = "cmbTimeUnit3";
            this.cmbTimeUnit3.Size = new System.Drawing.Size(87, 28);
            this.cmbTimeUnit3.TabIndex = 1;
            this.cmbTimeUnit3.SelectedIndexChanged += new System.EventHandler(this.TimeUnitChanged);
            // 
            // lblLowerLeftIntersection
            // 
            this.lblLowerLeftIntersection.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblLowerLeftIntersection.Location = new System.Drawing.Point(481, 420);
            this.lblLowerLeftIntersection.Name = "lblLowerLeftIntersection";
            this.lblLowerLeftIntersection.Size = new System.Drawing.Size(102, 92);
            this.lblLowerLeftIntersection.TabIndex = 43;
            this.lblLowerLeftIntersection.Visible = false;
            // 
            // lblLowerRightIntersection
            // 
            this.lblLowerRightIntersection.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblLowerRightIntersection.Location = new System.Drawing.Point(598, 416);
            this.lblLowerRightIntersection.Name = "lblLowerRightIntersection";
            this.lblLowerRightIntersection.Size = new System.Drawing.Size(102, 92);
            this.lblLowerRightIntersection.TabIndex = 41;
            this.lblLowerRightIntersection.Visible = false;
            // 
            // lblUpperRightIntersection
            // 
            this.lblUpperRightIntersection.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblUpperRightIntersection.Location = new System.Drawing.Point(598, 318);
            this.lblUpperRightIntersection.Name = "lblUpperRightIntersection";
            this.lblUpperRightIntersection.Size = new System.Drawing.Size(102, 92);
            this.lblUpperRightIntersection.TabIndex = 40;
            this.lblUpperRightIntersection.Visible = false;
            // 
            // lblUpperLeftIntersection
            // 
            this.lblUpperLeftIntersection.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblUpperLeftIntersection.Location = new System.Drawing.Point(483, 318);
            this.lblUpperLeftIntersection.Name = "lblUpperLeftIntersection";
            this.lblUpperLeftIntersection.Size = new System.Drawing.Size(102, 92);
            this.lblUpperLeftIntersection.TabIndex = 42;
            this.lblUpperLeftIntersection.Visible = false;
            // 
            // lblSelect3TrafficLight1
            // 
            this.lblSelect3TrafficLight1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect3TrafficLight1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelect3TrafficLight1.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect3TrafficLight1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect3TrafficLight1.Location = new System.Drawing.Point(585, 214);
            this.lblSelect3TrafficLight1.Name = "lblSelect3TrafficLight1";
            this.lblSelect3TrafficLight1.Size = new System.Drawing.Size(191, 113);
            this.lblSelect3TrafficLight1.TabIndex = 44;
            this.lblSelect3TrafficLight1.Tag = "select";
            this.lblSelect3TrafficLight1.Text = "BACK";
            this.lblSelect3TrafficLight1.Visible = false;
            // 
            // lblSelect5TrafficLight3
            // 
            this.lblSelect5TrafficLight3.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect5TrafficLight3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelect5TrafficLight3.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect5TrafficLight3.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect5TrafficLight3.Location = new System.Drawing.Point(715, 412);
            this.lblSelect5TrafficLight3.Name = "lblSelect5TrafficLight3";
            this.lblSelect5TrafficLight3.Size = new System.Drawing.Size(113, 191);
            this.lblSelect5TrafficLight3.TabIndex = 45;
            this.lblSelect5TrafficLight3.Tag = "select";
            this.lblSelect5TrafficLight3.Text = "BACK";
            this.lblSelect5TrafficLight3.Visible = false;
            // 
            // lblSelect4TrafficLight4
            // 
            this.lblSelect4TrafficLight4.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect4TrafficLight4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelect4TrafficLight4.Font = new System.Drawing.Font("ROG Fonts", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect4TrafficLight4.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSelect4TrafficLight4.Location = new System.Drawing.Point(352, 209);
            this.lblSelect4TrafficLight4.Name = "lblSelect4TrafficLight4";
            this.lblSelect4TrafficLight4.Size = new System.Drawing.Size(113, 191);
            this.lblSelect4TrafficLight4.TabIndex = 46;
            this.lblSelect4TrafficLight4.Tag = "select";
            this.lblSelect4TrafficLight4.Text = "BACK";
            this.lblSelect4TrafficLight4.Visible = false;
            // 
            // Stage2Prep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1160, 756);
            this.Controls.Add(this.pbV1Car1);
            this.Controls.Add(this.pbH2Car1);
            this.Controls.Add(this.pbH1Car1);
            this.Controls.Add(this.lblLowerLeftIntersection);
            this.Controls.Add(this.lblUpperLeftIntersection);
            this.Controls.Add(this.lblLowerRightIntersection);
            this.Controls.Add(this.lblUpperRightIntersection);
            this.Controls.Add(this.lblIntersectionArea);
            this.Controls.Add(this.lblStageScore);
            this.Controls.Add(this.pbTrafficLightV1);
            this.Controls.Add(this.pbTrafficLightH2);
            this.Controls.Add(this.pbTrafficLightH1);
            this.Controls.Add(this.lblPrep);
            this.Controls.Add(this.lblBackBtn);
            this.Controls.Add(this.pbPauseBtn);
            this.Controls.Add(this.lblFinishPrepBtn);
            this.Controls.Add(this.lblSelect0BackBtn);
            this.Controls.Add(this.lblSelect1PauseBtn);
            this.Controls.Add(this.lblSelect2FinishPrepBtn);
            this.Controls.Add(this.flpTimerTrafficLightMenu);
            this.Controls.Add(this.lblSelect3TrafficLight1);
            this.Controls.Add(this.lblSelect5TrafficLight3);
            this.Controls.Add(this.lblSelect4TrafficLight4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Stage2Prep";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "The Game of Traffic Lights";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.HideTrafficLightSettingsClick);
            ((System.ComponentModel.ISupportInitialize)(this.pbPauseBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrafficLightH1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrafficLightH2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrafficLightV1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbH1Car1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbH2Car1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbV1Car1)).EndInit();
            this.flpTimerTrafficLightMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTrafficLight)).EndInit();
            this.flpSettings.ResumeLayout(false);
            this.flpSetting1.ResumeLayout(false);
            this.flpSetting1.PerformLayout();
            this.flpSetting2.ResumeLayout(false);
            this.flpSetting2.PerformLayout();
            this.flpSetting3.ResumeLayout(false);
            this.flpSetting3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBackBtn;
        private System.Windows.Forms.PictureBox pbPauseBtn;
        private System.Windows.Forms.Label lblFinishPrepBtn;
        private System.Windows.Forms.Label lblPrep;
        private System.Windows.Forms.Label lblSelect0BackBtn;
        private System.Windows.Forms.Label lblSelect1PauseBtn;
        private System.Windows.Forms.Label lblSelect2FinishPrepBtn;
        private System.Windows.Forms.PictureBox pbTrafficLightH1;
        private System.Windows.Forms.PictureBox pbTrafficLightH2;
        private System.Windows.Forms.PictureBox pbTrafficLightV1;
        private System.Windows.Forms.Timer timeStageTimer;
        private System.Windows.Forms.PictureBox pbH1Car1;
        private System.Windows.Forms.PictureBox pbH2Car1;
        private System.Windows.Forms.PictureBox pbV1Car1;
        private System.Windows.Forms.Timer timeRedLightTimerH;
        private System.Windows.Forms.Timer timeYellowLightTimerH;
        private System.Windows.Forms.Timer timeGreenLightTimerH;
        private System.Windows.Forms.Timer timeRedLightTimerV;
        private System.Windows.Forms.Timer timeYellowLightTimerV;
        private System.Windows.Forms.Timer timeGreenLightTimerV;
        private System.Windows.Forms.Label lblStageScore;
        private System.Windows.Forms.Timer timeStageTimer2;
        private System.Windows.Forms.Label lblIntersectionArea;
        private System.Windows.Forms.FlowLayoutPanel flpTimerTrafficLightMenu;
        private System.Windows.Forms.PictureBox pbTrafficLight;
        private System.Windows.Forms.FlowLayoutPanel flpSettings;
        private System.Windows.Forms.FlowLayoutPanel flpSetting1;
        private System.Windows.Forms.TextBox txtLightTime1;
        private System.Windows.Forms.ComboBox cmbTimeUnit1;
        private System.Windows.Forms.FlowLayoutPanel flpSetting2;
        private System.Windows.Forms.TextBox txtLightTime2;
        private System.Windows.Forms.ComboBox cmbTimeUnit2;
        private System.Windows.Forms.FlowLayoutPanel flpSetting3;
        private System.Windows.Forms.TextBox txtLightTime3;
        private System.Windows.Forms.ComboBox cmbTimeUnit3;
        private System.Windows.Forms.Label lblLowerLeftIntersection;
        private System.Windows.Forms.Label lblLowerRightIntersection;
        private System.Windows.Forms.Label lblUpperRightIntersection;
        private System.Windows.Forms.Label lblUpperLeftIntersection;
        private System.Windows.Forms.Label lblSelect3TrafficLight1;
        private System.Windows.Forms.Label lblSelect5TrafficLight3;
        private System.Windows.Forms.Label lblSelect4TrafficLight4;
    }
}

