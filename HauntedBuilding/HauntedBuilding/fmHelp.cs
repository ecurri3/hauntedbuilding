using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HauntedBuilding
{
    public partial class fmHelp : Form
    {
        public fmHelp()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtHelp_TextChanged(object sender, EventArgs e)
        {

        }

        private void fmHelp_Load(object sender, EventArgs e)
        {
            txtHelp.Text = "You have to escape from a haunted building with multiple floor. There are three elevators on each floor which you can take to get to other floors. There is only on elevator on each floor which take you to the next right floor. Also there is a locked case on each floor that is opened via a password. You need to search each floor to find clues which may help you to find the password. If you could find a password you will get a hint which helps you to choose the right elevator. You  can enter commands such as LEFT, RIGHT, FORWARD, BACKWARD to move across the floor, ENTER to enter an elevator, PICKUP to pick up the items and INVT to display the items you are carrying. ";
        }
    }
}
