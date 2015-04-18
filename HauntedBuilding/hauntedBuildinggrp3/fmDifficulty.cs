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
    public partial class fmDifficulty : Form
    {
        private string PlayerName;

        public fmDifficulty(string sPlayer)
        {
            PlayerName = sPlayer;

            InitializeComponent();
        }

        private void launchGame(int difficulty)
        {
            fmPlayGame fPG = new fmPlayGame(0, PlayerName, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, difficulty, 0, "", 0);
            
            this.Hide();
            fPG.ShowDialog();
            this.Close();
        }
        private void easy_Click(object sender, EventArgs e)
        {
            launchGame(0);
        }

        private void medium_Click(object sender, EventArgs e)
        {
            launchGame(1);
        }

        private void hard_Click(object sender, EventArgs e)
        {
            launchGame(2);
        }

    }
}
