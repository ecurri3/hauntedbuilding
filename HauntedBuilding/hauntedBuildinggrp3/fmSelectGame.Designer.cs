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
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPlaySaved
            // 
            this.btnPlaySaved.BackgroundImage = global::hauntedBuildinggrp3.Properties.Resources.gycomp;
            this.btnPlaySaved.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlaySaved.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPlaySaved.Location = new System.Drawing.Point(68, 62);
            this.btnPlaySaved.Name = "btnPlaySaved";
            this.btnPlaySaved.Size = new System.Drawing.Size(377, 125);
            this.btnPlaySaved.TabIndex = 0;
            this.btnPlaySaved.Text = "Continue Saved Game";
            this.btnPlaySaved.UseVisualStyleBackColor = true;
            this.btnPlaySaved.Click += new System.EventHandler(this.btnPlaySaved_Click);
            // 
            // btnPlayNew
            // 
            this.btnPlayNew.BackgroundImage = global::hauntedBuildinggrp3.Properties.Resources.gycomp;
            this.btnPlayNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayNew.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPlayNew.Location = new System.Drawing.Point(68, 213);
            this.btnPlayNew.Name = "btnPlayNew";
            this.btnPlayNew.Size = new System.Drawing.Size(377, 125);
            this.btnPlayNew.TabIndex = 1;
            this.btnPlayNew.Text = "Play New Game";
            this.btnPlayNew.UseVisualStyleBackColor = true;
            this.btnPlayNew.Click += new System.EventHandler(this.btnPlayNew_Click);
            // 
            // btnShowScores
            // 
            this.btnShowScores.BackgroundImage = global::hauntedBuildinggrp3.Properties.Resources.gycomp;
            this.btnShowScores.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowScores.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnShowScores.Location = new System.Drawing.Point(68, 369);
            this.btnShowScores.Name = "btnShowScores";
            this.btnShowScores.Size = new System.Drawing.Size(377, 125);
            this.btnShowScores.TabIndex = 2;
            this.btnShowScores.Text = "Scores";
            this.btnShowScores.UseVisualStyleBackColor = true;
            this.btnShowScores.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::hauntedBuildinggrp3.Properties.Resources.gycomp;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(68, 522);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(377, 125);
            this.button1.TabIndex = 3;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // fmSelectGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::hauntedBuildinggrp3.Properties.Resources.gycomp;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(513, 709);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnShowScores);
            this.Controls.Add(this.btnPlayNew);
            this.Controls.Add(this.btnPlaySaved);
            this.Name = "fmSelectGame";
            this.Load += new System.EventHandler(this.fmSelectGame_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPlaySaved;
        private System.Windows.Forms.Button btnPlayNew;
        private System.Windows.Forms.Button btnShowScores;
        private System.Windows.Forms.Button button1;
    }
}