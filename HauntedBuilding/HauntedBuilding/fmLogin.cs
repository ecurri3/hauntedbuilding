using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HauntedBuilding
{   
    public partial class fmLogin : Form
    {
        public fmLogin()
        {
            InitializeComponent();
        }

        private void fmLogin_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle= FormBorderStyle.FixedDialog;
            this.CenterToScreen();
            txtPass.MaxLength=20;
            txtUser.TabIndex = 0;
            txtPass.TabIndex = 1;
            btnLogin.TabIndex = 2;
            lklbNewAcc.TabIndex = 3;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim().Length==0)
	     {
		 MessageBox.Show("Please enter your username ");
                txtUser.Focus();

	     }
            else if (txtPass.Text.Trim().Length==0)
	    {
                MessageBox.Show("Please enter your password");
                txtPass.Focus();
	    }

            SqlCommand oCmd=new SqlCommand();
            SqlDataReader DR=new SqlDataReader();
            oCmd.Connection=oConn; //oConn is a Module which create a connection to sql
            oCmd.CommandTimeout = 0;
            oCmd.CommandType= CommandType.StoredProcedure;
            oCmd.CommandText = "spLogin";
            oCmd.Parameters.Add("@UserName", SqlDbType.NVarChar);
            oCmd.Parameters.Add("@Password", SqlDbType.NVarChar);
            oCmd.Parameters["@UserName"].Value = txtUser.Text;
            oCmd.Parameters["@Password"].Value = txtPass.Text;

        //    Try
        //    {
        //    DR = oCmd.ExecuteReader();
        //    if (DR.Read == True) 
        //    {
        //        DR.Close();
               
        //        This.Close();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Username or password not valid");
        //        DR.Close();
        //        txtPass.Clear();
        //        txtPass.Focus();
        //    }
        //    }
        //Catch (SqlException ex)
        //    {
        //    MessageBox.show(ex.Message);
        //    txtUser.Clear();
        //    txtPass.Clear();
        //    txtUser.Focus();
            
        
        //    } 

        }

        private void lklbNewAcc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fmNewAcc showfmCreateAcc = new fmNewAcc();
            showfmCreateAcc.ShowDialog();
        }
    }
}
?;