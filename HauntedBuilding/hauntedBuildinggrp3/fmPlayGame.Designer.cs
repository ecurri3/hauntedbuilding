namespace hauntedBuildinggrp3
{
    partial class fmPlayGame
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
            System.Windows.Forms.RadioButton doorRadio;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmPlayGame));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.save = new System.Windows.Forms.Button();
            this.digit1 = new System.Windows.Forms.TextBox();
            this.digit3 = new System.Windows.Forms.TextBox();
            this.digit2 = new System.Windows.Forms.TextBox();
            this.tryCase = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.clearCode = new System.Windows.Forms.Button();
            this.lbTimer = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.caseRadio = new System.Windows.Forms.RadioButton();
            this.gameScreen = new System.Windows.Forms.PictureBox();
            this.pCoordLabel = new System.Windows.Forms.Label();
            this.pFloorLabel = new System.Windows.Forms.Label();
            this.labelFloor = new System.Windows.Forms.Label();
            this.coordinateLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.player = new System.Windows.Forms.Label();
            this.playerDisplay = new System.Windows.Forms.Label();
            this.Date = new System.Windows.Forms.Label();
            this.fmeterLabel = new System.Windows.Forms.Label();
            this.keyPadGroup = new System.Windows.Forms.GroupBox();
            doorRadio = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.gameScreen)).BeginInit();
            this.keyPadGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // doorRadio
            // 
            doorRadio.AutoSize = true;
            doorRadio.FlatAppearance.BorderSize = 4;
            doorRadio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            doorRadio.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            doorRadio.ForeColor = System.Drawing.Color.White;
            doorRadio.Location = new System.Drawing.Point(128, 85);
            doorRadio.Margin = new System.Windows.Forms.Padding(6);
            doorRadio.Name = "doorRadio";
            doorRadio.Size = new System.Drawing.Size(127, 49);
            doorRadio.TabIndex = 30;
            doorRadio.Text = "Door";
            doorRadio.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.MenuText;
            this.textBox1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(24, 135);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(1064, 746);
            this.textBox1.TabIndex = 0;
            this.textBox1.Click += new System.EventHandler(this.windowClick);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.BackgroundImage = global::hauntedBuildinggrp3.Properties.Resources.main_3595fca5_b038_4f8f_ab73a5ae3ef5e023;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderSize = 4;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1238, 931);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 75);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-2, -6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 29);
            this.label1.TabIndex = 15;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkBlue;
            this.button3.BackgroundImage = global::hauntedBuildinggrp3.Properties.Resources.main_3595fca5_b038_4f8f_ab73a5ae3ef5e023;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button3.FlatAppearance.BorderSize = 4;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(1238, 1017);
            this.button3.Margin = new System.Windows.Forms.Padding(6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(200, 75);
            this.button3.TabIndex = 5;
            this.button3.Text = "Help";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Silver;
            this.textBox2.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.Blue;
            this.textBox2.Location = new System.Drawing.Point(24, 896);
            this.textBox2.Margin = new System.Windows.Forms.Padding(6);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(1064, 289);
            this.textBox2.TabIndex = 16;
            this.textBox2.Click += new System.EventHandler(this.windowClick);
            // 
            // save
            // 
            this.save.BackColor = System.Drawing.Color.DarkBlue;
            this.save.BackgroundImage = global::hauntedBuildinggrp3.Properties.Resources.main_3595fca5_b038_4f8f_ab73a5ae3ef5e023;
            this.save.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.save.FlatAppearance.BorderSize = 4;
            this.save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save.ForeColor = System.Drawing.Color.White;
            this.save.Location = new System.Drawing.Point(1238, 1104);
            this.save.Margin = new System.Windows.Forms.Padding(6);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(202, 75);
            this.save.TabIndex = 17;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = false;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // digit1
            // 
            this.digit1.BackColor = System.Drawing.SystemColors.InfoText;
            this.digit1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.digit1.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.digit1.ForeColor = System.Drawing.Color.Chartreuse;
            this.digit1.Location = new System.Drawing.Point(100, 162);
            this.digit1.Margin = new System.Windows.Forms.Padding(6);
            this.digit1.MaxLength = 1;
            this.digit1.Name = "digit1";
            this.digit1.Size = new System.Drawing.Size(46, 62);
            this.digit1.TabIndex = 18;
            this.digit1.Click += new System.EventHandler(this.clickDigits);
            // 
            // digit3
            // 
            this.digit3.BackColor = System.Drawing.SystemColors.InfoText;
            this.digit3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.digit3.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.digit3.ForeColor = System.Drawing.Color.Chartreuse;
            this.digit3.Location = new System.Drawing.Point(220, 162);
            this.digit3.Margin = new System.Windows.Forms.Padding(6);
            this.digit3.MaxLength = 1;
            this.digit3.Name = "digit3";
            this.digit3.Size = new System.Drawing.Size(46, 62);
            this.digit3.TabIndex = 20;
            this.digit3.Click += new System.EventHandler(this.clickDigits);
            // 
            // digit2
            // 
            this.digit2.BackColor = System.Drawing.SystemColors.InfoText;
            this.digit2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.digit2.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.digit2.ForeColor = System.Drawing.Color.Chartreuse;
            this.digit2.Location = new System.Drawing.Point(160, 162);
            this.digit2.Margin = new System.Windows.Forms.Padding(6);
            this.digit2.MaxLength = 1;
            this.digit2.Name = "digit2";
            this.digit2.Size = new System.Drawing.Size(46, 62);
            this.digit2.TabIndex = 19;
            this.digit2.Click += new System.EventHandler(this.clickDigits);
            // 
            // tryCase
            // 
            this.tryCase.BackColor = System.Drawing.Color.Silver;
            this.tryCase.BackgroundImage = global::hauntedBuildinggrp3.Properties.Resources.main_3595fca5_b038_4f8f_ab73a5ae3ef5e023;
            this.tryCase.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tryCase.FlatAppearance.BorderSize = 4;
            this.tryCase.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.tryCase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tryCase.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tryCase.ForeColor = System.Drawing.Color.White;
            this.tryCase.Location = new System.Drawing.Point(100, 244);
            this.tryCase.Margin = new System.Windows.Forms.Padding(6);
            this.tryCase.Name = "tryCase";
            this.tryCase.Size = new System.Drawing.Size(168, 65);
            this.tryCase.TabIndex = 21;
            this.tryCase.Text = "Send";
            this.tryCase.UseVisualStyleBackColor = false;
            this.tryCase.Click += new System.EventHandler(this.button2_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(1212, 81);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(288, 44);
            this.progressBar1.TabIndex = 25;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // clearCode
            // 
            this.clearCode.BackColor = System.Drawing.Color.DarkRed;
            this.clearCode.BackgroundImage = global::hauntedBuildinggrp3.Properties.Resources.main_3595fca5_b038_4f8f_ab73a5ae3ef5e023;
            this.clearCode.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.clearCode.FlatAppearance.BorderSize = 4;
            this.clearCode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.clearCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearCode.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearCode.ForeColor = System.Drawing.Color.White;
            this.clearCode.Location = new System.Drawing.Point(100, 319);
            this.clearCode.Margin = new System.Windows.Forms.Padding(4);
            this.clearCode.Name = "clearCode";
            this.clearCode.Size = new System.Drawing.Size(168, 65);
            this.clearCode.TabIndex = 27;
            this.clearCode.Text = "Clear";
            this.clearCode.UseVisualStyleBackColor = false;
            this.clearCode.Click += new System.EventHandler(this.clearCode_Click);
            // 
            // lbTimer
            // 
            this.lbTimer.AutoSize = true;
            this.lbTimer.BackColor = System.Drawing.Color.Transparent;
            this.lbTimer.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimer.ForeColor = System.Drawing.Color.Lime;
            this.lbTimer.Location = new System.Drawing.Point(420, 38);
            this.lbTimer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTimer.Name = "lbTimer";
            this.lbTimer.Size = new System.Drawing.Size(180, 62);
            this.lbTimer.TabIndex = 28;
            this.lbTimer.Text = "Timer";
            this.lbTimer.Click += new System.EventHandler(this.lbTimer_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // caseRadio
            // 
            this.caseRadio.AutoSize = true;
            this.caseRadio.Checked = true;
            this.caseRadio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.caseRadio.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.caseRadio.ForeColor = System.Drawing.Color.White;
            this.caseRadio.Location = new System.Drawing.Point(128, 42);
            this.caseRadio.Margin = new System.Windows.Forms.Padding(6);
            this.caseRadio.Name = "caseRadio";
            this.caseRadio.Size = new System.Drawing.Size(123, 49);
            this.caseRadio.TabIndex = 29;
            this.caseRadio.TabStop = true;
            this.caseRadio.Text = "Case";
            this.caseRadio.UseVisualStyleBackColor = true;
            // 
            // gameScreen
            // 
            this.gameScreen.BackColor = System.Drawing.Color.Transparent;
            this.gameScreen.Location = new System.Drawing.Point(1104, 162);
            this.gameScreen.Margin = new System.Windows.Forms.Padding(6);
            this.gameScreen.Name = "gameScreen";
            this.gameScreen.Size = new System.Drawing.Size(500, 288);
            this.gameScreen.TabIndex = 33;
            this.gameScreen.TabStop = false;
            // 
            // pCoordLabel
            // 
            this.pCoordLabel.AutoSize = true;
            this.pCoordLabel.BackColor = System.Drawing.Color.Transparent;
            this.pCoordLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pCoordLabel.ForeColor = System.Drawing.Color.Lime;
            this.pCoordLabel.Location = new System.Drawing.Point(982, 71);
            this.pCoordLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.pCoordLabel.Name = "pCoordLabel";
            this.pCoordLabel.Size = new System.Drawing.Size(87, 37);
            this.pCoordLabel.TabIndex = 34;
            this.pCoordLabel.Text = "(0,0)";
            // 
            // pFloorLabel
            // 
            this.pFloorLabel.AutoSize = true;
            this.pFloorLabel.BackColor = System.Drawing.Color.Transparent;
            this.pFloorLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pFloorLabel.ForeColor = System.Drawing.Color.Lime;
            this.pFloorLabel.Location = new System.Drawing.Point(982, 17);
            this.pFloorLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.pFloorLabel.Name = "pFloorLabel";
            this.pFloorLabel.Size = new System.Drawing.Size(36, 37);
            this.pFloorLabel.TabIndex = 35;
            this.pFloorLabel.Text = "0";
            this.pFloorLabel.Click += new System.EventHandler(this.pFloorLabel_Click);
            // 
            // labelFloor
            // 
            this.labelFloor.AutoSize = true;
            this.labelFloor.BackColor = System.Drawing.Color.Transparent;
            this.labelFloor.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFloor.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelFloor.Location = new System.Drawing.Point(878, 12);
            this.labelFloor.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelFloor.Name = "labelFloor";
            this.labelFloor.Size = new System.Drawing.Size(100, 45);
            this.labelFloor.TabIndex = 36;
            this.labelFloor.Text = "Floor";
            this.labelFloor.Click += new System.EventHandler(this.labelFloor_Click);
            // 
            // coordinateLabel
            // 
            this.coordinateLabel.AutoSize = true;
            this.coordinateLabel.BackColor = System.Drawing.Color.Transparent;
            this.coordinateLabel.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coordinateLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.coordinateLabel.Location = new System.Drawing.Point(800, 65);
            this.coordinateLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.coordinateLabel.Name = "coordinateLabel";
            this.coordinateLabel.Size = new System.Drawing.Size(192, 45);
            this.coordinateLabel.TabIndex = 37;
            this.coordinateLabel.Text = "Coordinate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(142, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 37);
            this.label3.TabIndex = 38;
            this.label3.Text = "...";
            // 
            // player
            // 
            this.player.AutoSize = true;
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.player.Location = new System.Drawing.Point(32, 15);
            this.player.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(115, 45);
            this.player.TabIndex = 39;
            this.player.Text = "Player";
            // 
            // playerDisplay
            // 
            this.playerDisplay.AutoSize = true;
            this.playerDisplay.BackColor = System.Drawing.Color.Transparent;
            this.playerDisplay.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerDisplay.ForeColor = System.Drawing.Color.Lime;
            this.playerDisplay.Location = new System.Drawing.Point(142, 21);
            this.playerDisplay.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.playerDisplay.Name = "playerDisplay";
            this.playerDisplay.Size = new System.Drawing.Size(47, 37);
            this.playerDisplay.TabIndex = 40;
            this.playerDisplay.Text = "...";
            // 
            // Date
            // 
            this.Date.AutoSize = true;
            this.Date.BackColor = System.Drawing.Color.Transparent;
            this.Date.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Date.Location = new System.Drawing.Point(48, 60);
            this.Date.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(94, 45);
            this.Date.TabIndex = 41;
            this.Date.Text = "Date";
            this.Date.Click += new System.EventHandler(this.Date_Click);
            // 
            // fmeterLabel
            // 
            this.fmeterLabel.AutoSize = true;
            this.fmeterLabel.BackColor = System.Drawing.Color.Transparent;
            this.fmeterLabel.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fmeterLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.fmeterLabel.Location = new System.Drawing.Point(1212, 21);
            this.fmeterLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.fmeterLabel.Name = "fmeterLabel";
            this.fmeterLabel.Size = new System.Drawing.Size(285, 45);
            this.fmeterLabel.TabIndex = 42;
            this.fmeterLabel.Text = "Frightened Meter";
            // 
            // keyPadGroup
            // 
            this.keyPadGroup.BackColor = System.Drawing.Color.Transparent;
            this.keyPadGroup.Controls.Add(this.digit2);
            this.keyPadGroup.Controls.Add(this.digit1);
            this.keyPadGroup.Controls.Add(this.digit3);
            this.keyPadGroup.Controls.Add(this.tryCase);
            this.keyPadGroup.Controls.Add(this.clearCode);
            this.keyPadGroup.Controls.Add(this.caseRadio);
            this.keyPadGroup.Controls.Add(doorRadio);
            this.keyPadGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.keyPadGroup.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyPadGroup.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.keyPadGroup.Location = new System.Drawing.Point(1154, 487);
            this.keyPadGroup.Margin = new System.Windows.Forms.Padding(6);
            this.keyPadGroup.Name = "keyPadGroup";
            this.keyPadGroup.Padding = new System.Windows.Forms.Padding(6);
            this.keyPadGroup.Size = new System.Drawing.Size(374, 413);
            this.keyPadGroup.TabIndex = 43;
            this.keyPadGroup.TabStop = false;
            this.keyPadGroup.Text = "KeyPad";
            // 
            // fmPlayGame
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackgroundImage = global::hauntedBuildinggrp3.Properties.Resources.main_3595fca5_b038_4f8f_ab73a5ae3ef5e023;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1640, 1227);
            this.Controls.Add(this.keyPadGroup);
            this.Controls.Add(this.fmeterLabel);
            this.Controls.Add(this.Date);
            this.Controls.Add(this.playerDisplay);
            this.Controls.Add(this.player);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.coordinateLabel);
            this.Controls.Add(this.labelFloor);
            this.Controls.Add(this.pFloorLabel);
            this.Controls.Add(this.pCoordLabel);
            this.Controls.Add(this.gameScreen);
            this.Controls.Add(this.lbTimer);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.save);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "fmPlayGame";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Haunted Building";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fmPlayGame_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.windowClick);
            ((System.ComponentModel.ISupportInitialize)(this.gameScreen)).EndInit();
            this.keyPadGroup.ResumeLayout(false);
            this.keyPadGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.TextBox digit1;
        private System.Windows.Forms.TextBox digit3;
        private System.Windows.Forms.TextBox digit2;
        private System.Windows.Forms.Button tryCase;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button clearCode;
        private System.Windows.Forms.Label lbTimer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RadioButton caseRadio;
        private System.Windows.Forms.PictureBox gameScreen;
        private System.Windows.Forms.Label pCoordLabel;
        private System.Windows.Forms.Label pFloorLabel;
        private System.Windows.Forms.Label labelFloor;
        private System.Windows.Forms.Label coordinateLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label player;
        private System.Windows.Forms.Label playerDisplay;
        private System.Windows.Forms.Label Date;
        private System.Windows.Forms.Label fmeterLabel;
        private System.Windows.Forms.GroupBox keyPadGroup;
    }
}

