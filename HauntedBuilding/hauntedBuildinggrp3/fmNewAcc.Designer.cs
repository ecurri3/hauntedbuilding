namespace hauntedBuildinggrp3
{
    partial class fmNewAcc
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
            this.txtDefUser = new System.Windows.Forms.TextBox();
            this.txtDefPass = new System.Windows.Forms.TextBox();
            this.btnCreateAcc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDefUser
            // 
            this.txtDefUser.Location = new System.Drawing.Point(236, 145);
            this.txtDefUser.Name = "txtDefUser";
            this.txtDefUser.Size = new System.Drawing.Size(230, 31);
            this.txtDefUser.TabIndex = 0;
            // 
            // txtDefPass
            // 
            this.txtDefPass.Location = new System.Drawing.Point(236, 231);
            this.txtDefPass.Name = "txtDefPass";
            this.txtDefPass.PasswordChar = '*';
            this.txtDefPass.Size = new System.Drawing.Size(230, 31);
            this.txtDefPass.TabIndex = 1;
            // 
            // btnCreateAcc
            // 
            this.btnCreateAcc.Location = new System.Drawing.Point(213, 345);
            this.btnCreateAcc.Name = "btnCreateAcc";
            this.btnCreateAcc.Size = new System.Drawing.Size(260, 89);
            this.btnCreateAcc.TabIndex = 2;
            this.btnCreateAcc.Text = "Create";
            this.btnCreateAcc.UseVisualStyleBackColor = true;
            this.btnCreateAcc.Click += new System.EventHandler(this.btnCreateAcc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // fmNewAcc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 580);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCreateAcc);
            this.Controls.Add(this.txtDefPass);
            this.Controls.Add(this.txtDefUser);
            this.Name = "fmNewAcc";
            this.Text = "Create New Account";
            this.Load += new System.EventHandler(this.fmNewAcc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDefUser;
        private System.Windows.Forms.TextBox txtDefPass;
        private System.Windows.Forms.Button btnCreateAcc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}