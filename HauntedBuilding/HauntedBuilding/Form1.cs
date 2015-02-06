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
    public partial class fmOptions : Form
    {
        public fmOptions()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            fmHelp showfmHelp = new fmHelp();
            showfmHelp.Show();
            
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            fmLogin showfmLogin = new fmLogin();
            showfmLogin.Show();
        }   
        }
}
