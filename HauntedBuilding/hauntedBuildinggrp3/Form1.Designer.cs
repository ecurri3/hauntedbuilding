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
            this.digit1 = new System.Windows.Forms.TextBox();
            this.digit3 = new System.Windows.Forms.TextBox();
            this.digit2 = new System.Windows.Forms.TextBox();
            this.tryCase = new System.Windows.Forms.Button();
            this.flashlight = new System.Windows.Forms.Button();
            this.tryWhat = new System.Windows.Forms.ListBox();
            this.Enter = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.MenuText;
            this.textBox1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(18, 28);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(474, 290);
            this.textBox1.TabIndex = 0;
            this.textBox1.Click += new System.EventHandler(this.windowClick);
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
            // up
            // 
            this.up.Location = new System.Drawing.Point(548, 331);
            this.up.Name = "up";
            this.up.Size = new System.Drawing.Size(50, 49);
            this.up.TabIndex = 7;
            this.up.Text = "W";
            this.up.UseVisualStyleBackColor = true;
            this.up.Click += new System.EventHandler(this.up_Click_1);
            // 
            // down
            // 
            this.down.Location = new System.Drawing.Point(548, 386);
            this.down.Name = "down";
            this.down.Size = new System.Drawing.Size(50, 49);
            this.down.TabIndex = 8;
            this.down.Text = "S";
            this.down.UseVisualStyleBackColor = true;
            this.down.Click += new System.EventHandler(this.down_Click_1);
            // 
            // right
            // 
            this.right.Location = new System.Drawing.Point(603, 386);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(50, 49);
            this.right.TabIndex = 9;
            this.right.Text = "D";
            this.right.UseVisualStyleBackColor = true;
            this.right.Click += new System.EventHandler(this.right_Click_1);
            // 
            // left
            // 
            this.left.Location = new System.Drawing.Point(492, 386);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(50, 49);
            this.left.TabIndex = 10;
            this.left.Text = "A";
            this.left.UseVisualStyleBackColor = true;
            this.left.Click += new System.EventHandler(this.left_Click_1);
            // 
            // pickup
            // 
            this.pickup.Location = new System.Drawing.Point(682, 386);
            this.pickup.Name = "pickup";
            this.pickup.Size = new System.Drawing.Size(122, 35);
            this.pickup.TabIndex = 11;
            this.pickup.Text = "Pick Up (E)";
            this.pickup.UseVisualStyleBackColor = true;
            this.pickup.Click += new System.EventHandler(this.pickup_Click_1);
            // 
            // inventory
            // 
            this.inventory.Location = new System.Drawing.Point(682, 428);
            this.inventory.Name = "inventory";
            this.inventory.Size = new System.Drawing.Size(122, 35);
            this.inventory.TabIndex = 12;
            this.inventory.Text = "Inventory (1)";
            this.inventory.UseVisualStyleBackColor = true;
            this.inventory.Click += new System.EventHandler(this.inventory_Click_1);
            // 
            // inspect
            // 
            this.inspect.Location = new System.Drawing.Point(682, 469);
            this.inspect.Name = "inspect";
            this.inspect.Size = new System.Drawing.Size(122, 35);
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
            this.textBox2.Location = new System.Drawing.Point(532, 18);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(286, 292);
            this.textBox2.TabIndex = 16;
            this.textBox2.Click += new System.EventHandler(this.windowClick);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(36, 452);
            this.save.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(112, 35);
            this.save.TabIndex = 17;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(459, 449);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 49);
            this.button2.TabIndex = 18;
            this.button2.Text = "Up (X)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.enterUp_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(573, 449);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(102, 49);
            this.button4.TabIndex = 19;
            this.button4.Text = "Down (C)";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.enterDown_Click);
            // 
            // digit1
            // 
            this.digit1.Location = new System.Drawing.Point(268, 365);
            this.digit1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.digit1.MaxLength = 1;
            this.digit1.Name = "digit1";
            this.digit1.Size = new System.Drawing.Size(34, 26);
            this.digit1.TabIndex = 18;
            this.digit1.Click += new System.EventHandler(this.clickDigits);
            // 
            // digit3
            // 
            this.digit3.Location = new System.Drawing.Point(358, 365);
            this.digit3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.digit3.MaxLength = 1;
            this.digit3.Name = "digit3";
            this.digit3.Size = new System.Drawing.Size(34, 26);
            this.digit3.TabIndex = 19;
            this.digit3.Click += new System.EventHandler(this.clickDigits);
            // 
            // digit2
            // 
            this.digit2.Location = new System.Drawing.Point(314, 365);
            this.digit2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.digit2.MaxLength = 1;
            this.digit2.Name = "digit2";
            this.digit2.Size = new System.Drawing.Size(34, 26);
            this.digit2.TabIndex = 20;
            this.digit2.Click += new System.EventHandler(this.clickDigits);
            // 
            // tryCase
            // 
            this.tryCase.Location = new System.Drawing.Point(268, 408);
            this.tryCase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tryCase.Name = "tryCase";
            this.tryCase.Size = new System.Drawing.Size(126, 35);
            this.tryCase.TabIndex = 21;
            this.tryCase.Text = "Send";
            this.tryCase.UseVisualStyleBackColor = true;
            this.tryCase.Click += new System.EventHandler(this.button2_Click);
            // 
            // flashlight
            // 
            this.flashlight.Location = new System.Drawing.Point(682, 345);
            this.flashlight.Name = "flashlight";
            this.flashlight.Size = new System.Drawing.Size(126, 35);
            this.flashlight.TabIndex = 22;
            this.flashlight.Text = "Flashlight (F)";
            this.flashlight.UseVisualStyleBackColor = true;
            this.flashlight.Click += new System.EventHandler(this.flashlight_Click);
            // 
            // tryWhat
            // 
            this.tryWhat.FormattingEnabled = true;
            this.tryWhat.ItemHeight = 20;
            this.tryWhat.Items.AddRange(new object[] {
            "Case",
            "Door"});
            this.tryWhat.Location = new System.Drawing.Point(190, 365);
            this.tryWhat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tryWhat.Name = "tryWhat";
            this.tryWhat.Size = new System.Drawing.Size(67, 44);
            this.tryWhat.TabIndex = 23;
            // 
            // Enter
            // 
            this.Enter.Location = new System.Drawing.Point(682, 508);
            this.Enter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(122, 35);
            this.Enter.TabIndex = 24;
            this.Enter.Text = "Enter (Q)";
            this.Enter.UseVisualStyleBackColor = true;
            this.Enter.Click += new System.EventHandler(this.Enter_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(459, 563);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(216, 36);
            this.progressBar1.TabIndex = 25;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(500, 532);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "Frightened Meter";
            // 
            // fmPlayGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 635);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.Enter);
            this.Controls.Add(this.tryWhat);
            this.Controls.Add(this.flashlight);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tryCase);
            this.Controls.Add(this.digit2);
            this.Controls.Add(this.digit3);
            this.Controls.Add(this.digit1);
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
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "fmPlayGame";
            this.Text = "Haunted Building";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fmPlayGame_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.windowClick);
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
        private System.Windows.Forms.TextBox digit1;
        private System.Windows.Forms.TextBox digit3;
        private System.Windows.Forms.TextBox digit2;
        private System.Windows.Forms.Button tryCase;
        private System.Windows.Forms.Button flashlight;
        private System.Windows.Forms.ListBox tryWhat;
        private System.Windows.Forms.Button Enter;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
    }
}

