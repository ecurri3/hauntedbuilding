namespace hauntedBuildinggrp3
{
    partial class fmHowToPlay
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
            this.rtxtHelp = new System.Windows.Forms.RichTextBox();
            this.btnCloseHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtxtHelp
            // 
            this.rtxtHelp.Location = new System.Drawing.Point(56, 54);
            this.rtxtHelp.Name = "rtxtHelp";
            this.rtxtHelp.Size = new System.Drawing.Size(559, 585);
            this.rtxtHelp.TabIndex = 0;
            this.rtxtHelp.Text = "";
            // 
            // btnCloseHelp
            // 
            this.btnCloseHelp.Location = new System.Drawing.Point(712, 281);
            this.btnCloseHelp.Name = "btnCloseHelp";
            this.btnCloseHelp.Size = new System.Drawing.Size(195, 94);
            this.btnCloseHelp.TabIndex = 1;
            this.btnCloseHelp.Text = "Close";
            this.btnCloseHelp.UseVisualStyleBackColor = true;
            this.btnCloseHelp.Click += new System.EventHandler(this.btnReturnMenu_Click);
            // 
            // fmHowToPlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 697);
            this.Controls.Add(this.btnCloseHelp);
            this.Controls.Add(this.rtxtHelp);
            this.Name = "fmHowToPlay";
            this.Text = "fmHowToPlay";
            this.Load += new System.EventHandler(this.fmHowToPlay_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtHelp;
        private System.Windows.Forms.Button btnCloseHelp;
    }
}