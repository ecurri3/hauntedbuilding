namespace hauntedBuildinggrp3
{
    partial class fmSelectGame
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
            this.btnPlaySaved = new System.Windows.Forms.Button();
            this.btnPlayNew = new System.Windows.Forms.Button();
            this.btnShowScores = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPlaySaved
            // 
            this.btnPlaySaved.Location = new System.Drawing.Point(68, 76);
            this.btnPlaySaved.Name = "btnPlaySaved";
            this.btnPlaySaved.Size = new System.Drawing.Size(377, 125);
            this.btnPlaySaved.TabIndex = 0;
            this.btnPlaySaved.Text = "Continue Saved Game";
            this.btnPlaySaved.UseVisualStyleBackColor = true;
            this.btnPlaySaved.Click += new System.EventHandler(this.btnPlaySaved_Click);
            // 
            // btnPlayNew
            // 
            this.btnPlayNew.Location = new System.Drawing.Point(64, 261);
            this.btnPlayNew.Name = "btnPlayNew";
            this.btnPlayNew.Size = new System.Drawing.Size(380, 139);
            this.btnPlayNew.TabIndex = 1;
            this.btnPlayNew.Text = "Play New Game";
            this.btnPlayNew.UseVisualStyleBackColor = true;
            this.btnPlayNew.Click += new System.EventHandler(this.btnPlayNew_Click);
            // 
            // btnShowScores
            // 
            this.btnShowScores.Location = new System.Drawing.Point(64, 470);
            this.btnShowScores.Name = "btnShowScores";
            this.btnShowScores.Size = new System.Drawing.Size(380, 128);
            this.btnShowScores.TabIndex = 2;
            this.btnShowScores.Text = "Scores";
            this.btnShowScores.UseVisualStyleBackColor = true;
            this.btnShowScores.Click += new System.EventHandler(this.button1_Click);
            // 
            // fmSelectGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 669);
            this.Controls.Add(this.btnShowScores);
            this.Controls.Add(this.btnPlayNew);
            this.Controls.Add(this.btnPlaySaved);
            this.Name = "fmSelectGame";
            this.Text = "fmSelectGame";
            this.Load += new System.EventHandler(this.fmSelectGame_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPlaySaved;
        private System.Windows.Forms.Button btnPlayNew;
        private System.Windows.Forms.Button btnShowScores;
    }
}