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
    public partial class fmHowToPlay : Form
    {
        public fmHowToPlay()
        {
            InitializeComponent();
        }

        private void fmHowToPlay_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.HelpButton = true;
            this.ShowIcon=false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.CenterToScreen();
            rtxtHelp.Text = "You have to escape from a haunted building with multiple floor. There are three elevators on each floor which you can take to get to other floors. There is only on elevator on each floor which take you to the next right floor. Also there is a locked case on each floor that is opened via a password. You need to search each floor to find clues which may help you to find the password. If you could find a password you will get a hint which helps you to choose the right elevator. You  can enter commands such as LEFT, RIGHT, FORWARD, BACKWARD to move across the floor, ENTER to enter an elevator, PICKUP to pick up the items and INVT to display the items you are carrying. ";
        }

        private void btnReturnMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
