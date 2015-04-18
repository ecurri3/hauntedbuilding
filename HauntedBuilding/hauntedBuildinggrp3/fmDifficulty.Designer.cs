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
            this.SuspendLayout();
            // 
            // easy
            // 
            this.easy.Location = new System.Drawing.Point(134, 52);
            this.easy.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.easy.Name = "easy";
            this.easy.Size = new System.Drawing.Size(274, 102);
            this.easy.TabIndex = 0;
            this.easy.Text = "Easy";
            this.easy.UseVisualStyleBackColor = true;
            this.easy.Click += new System.EventHandler(this.easy_Click);
            // 
            // medium
            // 
            this.medium.Location = new System.Drawing.Point(134, 188);
            this.medium.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.medium.Name = "medium";
            this.medium.Size = new System.Drawing.Size(274, 102);
            this.medium.TabIndex = 1;
            this.medium.Text = "Medium";
            this.medium.UseVisualStyleBackColor = true;
            this.medium.Click += new System.EventHandler(this.medium_Click);
            // 
            // hard
            // 
            this.hard.Location = new System.Drawing.Point(134, 325);
            this.hard.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.hard.Name = "hard";
            this.hard.Size = new System.Drawing.Size(274, 102);
            this.hard.TabIndex = 2;
            this.hard.Text = "Hard";
            this.hard.UseVisualStyleBackColor = true;
            this.hard.Click += new System.EventHandler(this.hard_Click);
            // 
            // fmDifficulty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 504);
            this.Controls.Add(this.hard);
            this.Controls.Add(this.medium);
            this.Controls.Add(this.easy);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "fmDifficulty";
            this.Text = "fmDifficulty";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.fmDifficulty_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button easy;
        private System.Windows.Forms.Button medium;
        private System.Windows.Forms.Button hard;
    }
}