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
            this.label2 = new System.Windows.Forms.Label();
            this.clearCode = new System.Windows.Forms.Button();
            this.lbTimer = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.caseRadio = new System.Windows.Forms.RadioButton();
            this.difficultyBox = new System.Windows.Forms.ComboBox();
            this.scoresButton = new System.Windows.Forms.Button();
            this.gameScreen = new System.Windows.Forms.PictureBox();
            this.pCoordLabel = new System.Windows.Forms.Label();
            this.pFloorLabel = new System.Windows.Forms.Label();
            this.labelFloor = new System.Windows.Forms.Label();
            this.coordinateLabel = new System.Windows.Forms.Label();
            doorRadio = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.gameScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // doorRadio
            // 
            doorRadio.AutoSize = true;
            doorRadio.ForeColor = System.Drawing.Color.Black;
            doorRadio.Location = new System.Drawing.Point(627, 136);
            doorRadio.Name = "doorRadio";
            doorRadio.Size = new System.Drawing.Size(48, 17);
            doorRadio.TabIndex = 30;
            doorRadio.Text = "Door";
            doorRadio.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.MenuText;
            this.textBox1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(12, 50);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(534, 403);
            this.textBox1.TabIndex = 0;
            this.textBox1.Click += new System.EventHandler(this.windowClick);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 641);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 15;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(93, 641);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Help";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.SystemColors.MenuText;
            this.textBox2.Location = new System.Drawing.Point(12, 459);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(381, 139);
            this.textBox2.TabIndex = 16;
            this.textBox2.Click += new System.EventHandler(this.windowClick);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(174, 641);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 17;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // digit1
            // 
            this.digit1.Location = new System.Drawing.Point(582, 159);
            this.digit1.MaxLength = 1;
            this.digit1.Name = "digit1";
            this.digit1.Size = new System.Drawing.Size(24, 20);
            this.digit1.TabIndex = 18;
            this.digit1.Click += new System.EventHandler(this.clickDigits);
            // 
            // digit3
            // 
            this.digit3.Location = new System.Drawing.Point(642, 159);
            this.digit3.MaxLength = 1;
            this.digit3.Name = "digit3";
            this.digit3.Size = new System.Drawing.Size(24, 20);
            this.digit3.TabIndex = 20;
            this.digit3.Click += new System.EventHandler(this.clickDigits);
            // 
            // digit2
            // 
            this.digit2.Location = new System.Drawing.Point(612, 159);
            this.digit2.MaxLength = 1;
            this.digit2.Name = "digit2";
            this.digit2.Size = new System.Drawing.Size(24, 20);
            this.digit2.TabIndex = 19;
            this.digit2.Click += new System.EventHandler(this.clickDigits);
            // 
            // tryCase
            // 
            this.tryCase.Location = new System.Drawing.Point(582, 187);
            this.tryCase.Name = "tryCase";
            this.tryCase.Size = new System.Drawing.Size(84, 23);
            this.tryCase.TabIndex = 21;
            this.tryCase.Text = "Send";
            this.tryCase.UseVisualStyleBackColor = true;
            this.tryCase.Click += new System.EventHandler(this.button2_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(561, 98);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(144, 23);
            this.progressBar1.TabIndex = 25;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(588, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Frightened Meter";
            // 
            // clearCode
            // 
            this.clearCode.Location = new System.Drawing.Point(582, 216);
            this.clearCode.Margin = new System.Windows.Forms.Padding(2);
            this.clearCode.Name = "clearCode";
            this.clearCode.Size = new System.Drawing.Size(84, 23);
            this.clearCode.TabIndex = 27;
            this.clearCode.Text = "Clear";
            this.clearCode.UseVisualStyleBackColor = true;
            this.clearCode.Click += new System.EventHandler(this.clearCode_Click);
            // 
            // lbTimer
            // 
            this.lbTimer.AutoSize = true;
            this.lbTimer.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbTimer.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimer.ForeColor = System.Drawing.Color.Lime;
            this.lbTimer.Location = new System.Drawing.Point(587, 36);
            this.lbTimer.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lbTimer.Name = "lbTimer";
            this.lbTimer.Size = new System.Drawing.Size(69, 24);
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
            this.caseRadio.ForeColor = System.Drawing.Color.Black;
            this.caseRadio.Location = new System.Drawing.Point(575, 136);
            this.caseRadio.Name = "caseRadio";
            this.caseRadio.Size = new System.Drawing.Size(49, 17);
            this.caseRadio.TabIndex = 29;
            this.caseRadio.TabStop = true;
            this.caseRadio.Text = "Case";
            this.caseRadio.UseVisualStyleBackColor = true;
            // 
            // difficultyBox
            // 
            this.difficultyBox.FormattingEnabled = true;
            this.difficultyBox.Items.AddRange(new object[] {
            "Easy",
            "Medium",
            "Hard"});
            this.difficultyBox.Location = new System.Drawing.Point(12, 604);
            this.difficultyBox.Name = "difficultyBox";
            this.difficultyBox.Size = new System.Drawing.Size(121, 21);
            this.difficultyBox.TabIndex = 31;
            this.difficultyBox.Text = "Easy";
            // 
            // scoresButton
            // 
            this.scoresButton.Location = new System.Drawing.Point(256, 640);
            this.scoresButton.Name = "scoresButton";
            this.scoresButton.Size = new System.Drawing.Size(75, 23);
            this.scoresButton.TabIndex = 32;
            this.scoresButton.Text = "Scores";
            this.scoresButton.UseVisualStyleBackColor = true;
            this.scoresButton.Click += new System.EventHandler(this.scoresButton_Click);
            // 
            // gameScreen
            // 
            this.gameScreen.Location = new System.Drawing.Point(399, 459);
            this.gameScreen.Name = "gameScreen";
            this.gameScreen.Size = new System.Drawing.Size(250, 150);
            this.gameScreen.TabIndex = 33;
            this.gameScreen.TabStop = false;
            // 
            // pCoordLabel
            // 
            this.pCoordLabel.AutoSize = true;
            this.pCoordLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pCoordLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pCoordLabel.ForeColor = System.Drawing.Color.Lime;
            this.pCoordLabel.Location = new System.Drawing.Point(69, 30);
            this.pCoordLabel.Name = "pCoordLabel";
            this.pCoordLabel.Size = new System.Drawing.Size(37, 15);
            this.pCoordLabel.TabIndex = 34;
            this.pCoordLabel.Text = "(0,0)";
            // 
            // pFloorLabel
            // 
            this.pFloorLabel.AutoSize = true;
            this.pFloorLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pFloorLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pFloorLabel.ForeColor = System.Drawing.Color.Lime;
            this.pFloorLabel.Location = new System.Drawing.Point(30, 31);
            this.pFloorLabel.Name = "pFloorLabel";
            this.pFloorLabel.Size = new System.Drawing.Size(15, 15);
            this.pFloorLabel.TabIndex = 35;
            this.pFloorLabel.Text = "0";
            // 
            // labelFloor
            // 
            this.labelFloor.AutoSize = true;
            this.labelFloor.Location = new System.Drawing.Point(23, 15);
            this.labelFloor.Name = "labelFloor";
            this.labelFloor.Size = new System.Drawing.Size(30, 13);
            this.labelFloor.TabIndex = 36;
            this.labelFloor.Text = "Floor";
            // 
            // coordinateLabel
            // 
            this.coordinateLabel.AutoSize = true;
            this.coordinateLabel.Location = new System.Drawing.Point(59, 15);
            this.coordinateLabel.Name = "coordinateLabel";
            this.coordinateLabel.Size = new System.Drawing.Size(58, 13);
            this.coordinateLabel.TabIndex = 37;
            this.coordinateLabel.Text = "Coordinate";
            // 
            // fmPlayGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 694);
            this.Controls.Add(this.coordinateLabel);
            this.Controls.Add(this.labelFloor);
            this.Controls.Add(this.pFloorLabel);
            this.Controls.Add(this.pCoordLabel);
            this.Controls.Add(this.gameScreen);
            this.Controls.Add(this.scoresButton);
            this.Controls.Add(this.difficultyBox);
            this.Controls.Add(doorRadio);
            this.Controls.Add(this.caseRadio);
            this.Controls.Add(this.lbTimer);
            this.Controls.Add(this.clearCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.tryCase);
            this.Controls.Add(this.digit2);
            this.Controls.Add(this.digit3);
            this.Controls.Add(this.digit1);
            this.Controls.Add(this.save);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmPlayGame";
            this.Text = "Haunted Building";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fmPlayGame_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.windowClick);
            ((System.ComponentModel.ISupportInitialize)(this.gameScreen)).EndInit();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button clearCode;
        private System.Windows.Forms.Label lbTimer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RadioButton caseRadio;
        private System.Windows.Forms.ComboBox difficultyBox;
        private System.Windows.Forms.Button scoresButton;
        private System.Windows.Forms.PictureBox gameScreen;
        private System.Windows.Forms.Label pCoordLabel;
        private System.Windows.Forms.Label pFloorLabel;
        private System.Windows.Forms.Label labelFloor;
        private System.Windows.Forms.Label coordinateLabel;
    }
}

