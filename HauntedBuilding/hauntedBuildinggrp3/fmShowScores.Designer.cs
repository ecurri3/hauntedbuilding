namespace hauntedBuildinggrp3
{
    partial class fmShowScores
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
            this.DGVScores = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGVScores)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVScores
            // 
            this.DGVScores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVScores.Location = new System.Drawing.Point(0, -1);
            this.DGVScores.Name = "DGVScores";
            this.DGVScores.RowTemplate.Height = 33;
            this.DGVScores.Size = new System.Drawing.Size(986, 620);
            this.DGVScores.TabIndex = 0;
            this.DGVScores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // fmShowScores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 618);
            this.Controls.Add(this.DGVScores);
            this.Name = "fmShowScores";
            this.Text = "Scores";
            this.Load += new System.EventHandler(this.fmShowScores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVScores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVScores;
    }
}