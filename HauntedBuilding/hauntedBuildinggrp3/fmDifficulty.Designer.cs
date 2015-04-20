namespace hauntedBuildinggrp3
{
    partial class fmDifficulty
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
            this.easy = new System.Windows.Forms.Button();
            this.medium = new System.Windows.Forms.Button();
            this.hard = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // easy
            // 
            this.easy.BackgroundImage = global::hauntedBuildinggrp3.Properties.Resources.da7e89d01535977a6d3d2c6b18e43a18;
            this.easy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.easy.Location = new System.Drawing.Point(145, 147);
            this.easy.Margin = new System.Windows.Forms.Padding(6);
            this.easy.Name = "easy";
            this.easy.Size = new System.Drawing.Size(274, 102);
            this.easy.TabIndex = 0;
            this.easy.Text = "Easy";
            this.easy.UseVisualStyleBackColor = true;
            this.easy.Click += new System.EventHandler(this.easy_Click);
            // 
            // medium
            // 
            this.medium.BackgroundImage = global::hauntedBuildinggrp3.Properties.Resources.da7e89d01535977a6d3d2c6b18e43a18;
            this.medium.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.medium.ForeColor = System.Drawing.SystemColors.ControlText;
            this.medium.Location = new System.Drawing.Point(145, 283);
            this.medium.Margin = new System.Windows.Forms.Padding(6);
            this.medium.Name = "medium";
            this.medium.Size = new System.Drawing.Size(274, 102);
            this.medium.TabIndex = 1;
            this.medium.Text = "Medium";
            this.medium.UseVisualStyleBackColor = true;
            this.medium.Click += new System.EventHandler(this.medium_Click);
            // 
            // hard
            // 
            this.hard.BackgroundImage = global::hauntedBuildinggrp3.Properties.Resources.da7e89d01535977a6d3d2c6b18e43a18;
            this.hard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hard.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hard.Location = new System.Drawing.Point(145, 420);
            this.hard.Margin = new System.Windows.Forms.Padding(6);
            this.hard.Name = "hard";
            this.hard.Size = new System.Drawing.Size(274, 102);
            this.hard.TabIndex = 2;
            this.hard.Text = "Hard";
            this.hard.UseVisualStyleBackColor = true;
            this.hard.Click += new System.EventHandler(this.hard_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::hauntedBuildinggrp3.Properties.Resources.da7e89d01535977a6d3d2c6b18e43a18;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(151, 561);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(268, 102);
            this.button1.TabIndex = 3;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(61, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(452, 33);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select the game difficulty mode";
            // 
            // fmDifficulty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::hauntedBuildinggrp3.Properties.Resources.da7e89d01535977a6d3d2c6b18e43a18;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(568, 717);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.hard);
            this.Controls.Add(this.medium);
            this.Controls.Add(this.easy);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "fmDifficulty";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.fmDifficulty_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button easy;
        private System.Windows.Forms.Button medium;
        private System.Windows.Forms.Button hard;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}