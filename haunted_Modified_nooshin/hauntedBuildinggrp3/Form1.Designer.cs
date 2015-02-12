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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.up = new System.Windows.Forms.Button();
            this.down = new System.Windows.Forms.Button();
            this.right = new System.Windows.Forms.Button();
            this.left = new System.Windows.Forms.Button();
            this.pickup = new System.Windows.Forms.Button();
            this.inventory = new System.Windows.Forms.Button();
            this.inspect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.MenuText;
            this.textBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(18, 18);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(674, 301);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 365);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 15;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(36, 408);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 35);
            this.button3.TabIndex = 5;
            this.button3.Text = "Help";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            // 
            // up
            // 
            this.up.Location = new System.Drawing.Point(425, 334);
            this.up.Name = "up";
            this.up.Size = new System.Drawing.Size(50, 50);
            this.up.TabIndex = 7;
            this.up.Text = "U";
            this.up.UseVisualStyleBackColor = true;
            this.up.Click += new System.EventHandler(this.up_Click_1);
            // 
            // down
            // 
            this.down.Location = new System.Drawing.Point(425, 446);
            this.down.Name = "down";
            this.down.Size = new System.Drawing.Size(50, 50);
            this.down.TabIndex = 8;
            this.down.Text = "D";
            this.down.UseVisualStyleBackColor = true;
            this.down.Click += new System.EventHandler(this.down_Click_1);
            // 
            // right
            // 
            this.right.Location = new System.Drawing.Point(471, 390);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(50, 50);
            this.right.TabIndex = 9;
            this.right.Text = "R";
            this.right.UseVisualStyleBackColor = true;
            this.right.Click += new System.EventHandler(this.right_Click_1);
            // 
            // left
            // 
            this.left.Location = new System.Drawing.Point(380, 390);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(50, 50);
            this.left.TabIndex = 10;
            this.left.Text = "L";
            this.left.UseVisualStyleBackColor = true;
            this.left.Click += new System.EventHandler(this.left_Click_1);
            // 
            // pickup
            // 
            this.pickup.Location = new System.Drawing.Point(600, 334);
            this.pickup.Name = "pickup";
            this.pickup.Size = new System.Drawing.Size(100, 35);
            this.pickup.TabIndex = 11;
            this.pickup.Text = "Pick Up";
            this.pickup.UseVisualStyleBackColor = true;
            this.pickup.Click += new System.EventHandler(this.pickup_Click_1);
            // 
            // inventory
            // 
            this.inventory.Location = new System.Drawing.Point(600, 390);
            this.inventory.Name = "inventory";
            this.inventory.Size = new System.Drawing.Size(100, 35);
            this.inventory.TabIndex = 12;
            this.inventory.Text = "Inventory";
            this.inventory.UseVisualStyleBackColor = true;
            this.inventory.Click += new System.EventHandler(this.inventory_Click_1);
            // 
            // inspect
            // 
            this.inspect.Location = new System.Drawing.Point(600, 446);
            this.inspect.Name = "inspect";
            this.inspect.Size = new System.Drawing.Size(100, 35);
            this.inspect.TabIndex = 14;
            this.inspect.Text = "Inspect";
            this.inspect.UseVisualStyleBackColor = true;
            this.inspect.Click += new System.EventHandler(this.inspect_Click_1);
            // 
            // fmPlayGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 533);
            this.Controls.Add(this.inspect);
            this.Controls.Add(this.inventory);
            this.Controls.Add(this.pickup);
            this.Controls.Add(this.left);
            this.Controls.Add(this.right);
            this.Controls.Add(this.down);
            this.Controls.Add(this.up);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "fmPlayGame";
            this.Text = "Play";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button up;
        private System.Windows.Forms.Button down;
        private System.Windows.Forms.Button right;
        private System.Windows.Forms.Button left;
        private System.Windows.Forms.Button pickup;
        private System.Windows.Forms.Button inventory;
        private System.Windows.Forms.Button inspect;
    }
}

