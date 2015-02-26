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
            this.up = new System.Windows.Forms.Button();
            this.down = new System.Windows.Forms.Button();
            this.right = new System.Windows.Forms.Button();
            this.left = new System.Windows.Forms.Button();
            this.pickup = new System.Windows.Forms.Button();
            this.inventory = new System.Windows.Forms.Button();
            this.inspect = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.save = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.MenuText;
            this.textBox1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(178, 197);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 237);
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
            this.button3.Location = new System.Drawing.Point(24, 265);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Help";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // up
            // 
            this.up.Location = new System.Drawing.Point(249, 238);
            this.up.Margin = new System.Windows.Forms.Padding(2);
            this.up.Name = "up";
            this.up.Size = new System.Drawing.Size(33, 32);
            this.up.TabIndex = 7;
            this.up.Text = "W";
            this.up.UseVisualStyleBackColor = true;
            this.up.Click += new System.EventHandler(this.up_Click_1);
            // 
            // down
            // 
            this.down.Location = new System.Drawing.Point(249, 274);
            this.down.Margin = new System.Windows.Forms.Padding(2);
            this.down.Name = "down";
            this.down.Size = new System.Drawing.Size(33, 32);
            this.down.TabIndex = 8;
            this.down.Text = "S";
            this.down.UseVisualStyleBackColor = true;
            this.down.Click += new System.EventHandler(this.down_Click_1);
            // 
            // right
            // 
            this.right.Location = new System.Drawing.Point(286, 274);
            this.right.Margin = new System.Windows.Forms.Padding(2);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(33, 32);
            this.right.TabIndex = 9;
            this.right.Text = "D";
            this.right.UseVisualStyleBackColor = true;
            this.right.Click += new System.EventHandler(this.right_Click_1);
            // 
            // left
            // 
            this.left.Location = new System.Drawing.Point(212, 274);
            this.left.Margin = new System.Windows.Forms.Padding(2);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(33, 32);
            this.left.TabIndex = 10;
            this.left.Text = "A";
            this.left.UseVisualStyleBackColor = true;
            this.left.Click += new System.EventHandler(this.left_Click_1);
            // 
            // pickup
            // 
            this.pickup.Location = new System.Drawing.Point(367, 223);
            this.pickup.Margin = new System.Windows.Forms.Padding(2);
            this.pickup.Name = "pickup";
            this.pickup.Size = new System.Drawing.Size(81, 23);
            this.pickup.TabIndex = 11;
            this.pickup.Text = "Pick Up (E)";
            this.pickup.UseVisualStyleBackColor = true;
            this.pickup.Click += new System.EventHandler(this.pickup_Click_1);
            // 
            // inventory
            // 
            this.inventory.Location = new System.Drawing.Point(367, 259);
            this.inventory.Margin = new System.Windows.Forms.Padding(2);
            this.inventory.Name = "inventory";
            this.inventory.Size = new System.Drawing.Size(81, 23);
            this.inventory.TabIndex = 12;
            this.inventory.Text = "Inventory (1)";
            this.inventory.UseVisualStyleBackColor = true;
            this.inventory.Click += new System.EventHandler(this.inventory_Click_1);
            // 
            // inspect
            // 
            this.inspect.Location = new System.Drawing.Point(367, 294);
            this.inspect.Margin = new System.Windows.Forms.Padding(2);
            this.inspect.Name = "inspect";
            this.inspect.Size = new System.Drawing.Size(81, 23);
            this.inspect.TabIndex = 14;
            this.inspect.Text = "Inspect (R)";
            this.inspect.UseVisualStyleBackColor = true;
            this.inspect.Click += new System.EventHandler(this.inspect_Click_1);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.SystemColors.MenuText;
            this.textBox2.Location = new System.Drawing.Point(196, 12);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(252, 197);
            this.textBox2.TabIndex = 16;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(24, 294);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 17;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(174, 302);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(33, 32);
            this.button2.TabIndex = 18;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(321, 302);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(31, 32);
            this.button4.TabIndex = 19;
            this.button4.Text = "C";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // fmPlayGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 346);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.save);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.inspect);
            this.Controls.Add(this.inventory);
            this.Controls.Add(this.pickup);
            this.Controls.Add(this.left);
            this.Controls.Add(this.right);
            this.Controls.Add(this.down);
            this.Controls.Add(this.up);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "fmPlayGame";
            this.Text = "Haunted Building";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button up;
        private System.Windows.Forms.Button down;
        private System.Windows.Forms.Button right;
        private System.Windows.Forms.Button left;
        private System.Windows.Forms.Button pickup;
        private System.Windows.Forms.Button inventory;
        private System.Windows.Forms.Button inspect;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
    }
}

