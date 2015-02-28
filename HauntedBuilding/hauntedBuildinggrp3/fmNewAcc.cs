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

namespace hauntedBuildinggrp3
{
    public partial class fmNewAcc : Form
    {
        public fmNewAcc()
        {
            InitializeComponent();
        }

        private void btnCreateAcc_Click(object sender, EventArgs e)
        {
            //if (txtDefUser.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("Please enter your username ");
            //    txtDefUser.Focus();

            //}
            //else if (txtDefPass.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("Please enter your password");
            //    txtDefPass.Focus();
            //}
            //string UserDef;
            //UserDef = txtDefUser.Text;
            
            //int UserStatus;

            //SqlConnection Cnn = new SqlConnection();
            //Cnn.ConnectionString = "Data Source=WIN-PC;Initial Catalog=HauntedBuilding;Integrated Security=True";
            //SqlCommand oCmd = new SqlCommand();

            //oCmd.Connection = Cnn;
            //oCmd.CommandTimeout = 0;
            //oCmd.CommandType = CommandType.StoredProcedure;
            //oCmd.CommandText = "spDefineAcc";
            //oCmd.Parameters.Add("@UserName", SqlDbType.NVarChar);
            //oCmd.Parameters.Add("@Password", SqlDbType.NVarChar);
            //oCmd.Parameters["@UserName"].Value = txtDefUser.Text;
            //oCmd.Parameters["@Password"].Value = txtDefPass.Text;

            //try
            //{
            //    Cnn.Open();
            //    oCmd.ExecuteNonQuery();
            //    MessageBox.Show("welcome " + txtDefUser.Text);
            //    UserStatus = 0;
            //    fmSelectGame ff = new fmSelectGame(UserDef, UserStatus);
            //    this.Hide();
            //    ff.ShowDialog();
            //    this.Close();
                
                
            //}
            //catch (SqlException ex)
            //{

            //    MessageBox.Show(ex.Message);
            //    txtDefUser.Clear();
            //    txtDefPass.Clear();
            //    txtDefUser.Focus();
            //}
           
            
        }

        private void fmNewAcc_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;
            //this.CenterToScreen();
            //txtDefUser.TabIndex = 0;
            //txtDefPass.TabIndex = 1;
            //btnCreateAcc.TabIndex = 2;
        }
    }
}
