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
    public partial class fmStartGame : Form
    {
        public fmStartGame()
        {
            InitializeComponent();
        }

        private void fmStartGame_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.Text = "";
            btnPlay.TabIndex = 0;
            btnHowToPlay.TabIndex = 1;
            btnExit.TabIndex = 2;
            //btnExit.Text = "E&xit";
            //btnHowToPlay.Text = "&How To Play";
            //btnPlay.Text = "&Play";


        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            //fmPlayGame showfmPlayGame = new fmPlayGame();
            //showfmPlayGame.ShowDialog();
            fmLogin showfmLogin = new fmLogin();
            showfmLogin.Show();
        }

        private void btnHowToPlay_Click(object sender, EventArgs e)
        {
            fmHowToPlay showfmHowToPlay = new fmHowToPlay();
            showfmHowToPlay.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
