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
    public partial class fmShowScores : Form
    {
        private string PlayerName;
        public fmShowScores(string UserName)
        {
            InitializeComponent();
            PlayerName = UserName;
        }

        private void fmShowScores_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.CenterToScreen();
            SqlConnection Cnn = new SqlConnection();
            Cnn.ConnectionString = "Data Source=WIN-PC;Initial Catalog=HauntedBuilding;Integrated Security=True";
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = Cnn;
            oCmd.CommandTimeout = 0;
            oCmd.CommandType = CommandType.StoredProcedure;
            oCmd.CommandText = "spSelScores";
            oCmd.Parameters.Add("@UserName", SqlDbType.NVarChar);
            oCmd.Parameters["@UserName"].Value = PlayerName;
            DataTable DT=new DataTable() ;
            SqlDataAdapter DA=new SqlDataAdapter(oCmd);
            DA.Fill(DT);
            DGVScores.DataSource = DT;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
