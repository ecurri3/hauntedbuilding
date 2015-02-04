using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hauntedBuildinggrp3
{
    public partial class Form1 : Form
    {
        HauntedBuilding hb;
        private int state = 0;
        public Form1()
        {
            InitializeComponent();
            hb = new HauntedBuilding();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(state == 0)
            {
                textBox1.Text = hb.getTitle();
                textBox1.AppendText("Press start to begin.");
            }
            else
            {

                hb.startGame();
            }
                
        }
    }
 
}
