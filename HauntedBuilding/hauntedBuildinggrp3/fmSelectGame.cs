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
    public partial class fmSelectGame : Form
    {
        private string PlayerName;
        private int PlayerStatus;
        int StartGameStatus;
        int FloorNo;
        int FloorX;
        int FloorY;
        int FirstDgtPass;
        int SecDgtPass;
        int ThirdDgtPass;
        int CaseStatus;
        int HaveCase;
        int HaveNote;
        int HavePhone;
        int HaveAudio;
        public fmSelectGame(string UserName, int UserStatus)
        {
            InitializeComponent();
            PlayerName = UserName;
            PlayerStatus = UserStatus;
        }

        

        private void btnPlaySaved_Click(object sender, EventArgs e)
        {

            StartGameStatus = 1;
            

            fmLogin loginUser = new fmLogin();


            SqlConnection Cnn = new SqlConnection();
            Cnn.ConnectionString = "Data Source=WIN-PC;Initial Catalog=HauntedBuilding;Integrated Security=True";
            SqlCommand oCmd = new SqlCommand();
            //SqlDataReader DR= oCmd.ExecuteReader();
            //oCmd.Connection.ConnectionString="Data Source=WIN-PC; Initial Ctalog=HauntedBuilding; Integrated Security=True"; //oConn is a Module which create a connection to sql
            oCmd.Connection = Cnn;
            oCmd.CommandTimeout = 0;
            oCmd.CommandType = CommandType.StoredProcedure;
            oCmd.CommandText = "spGetPlayerData";
            oCmd.Parameters.Add("@UserName", SqlDbType.NVarChar);
            oCmd.Parameters["@UserName"].Value = PlayerName;
            oCmd.Parameters.Add("@FloorNo", SqlDbType.Int, 4);
            oCmd.Parameters["@FloorNo"].Direction = ParameterDirection.Output;
            oCmd.Parameters.Add("@FloorX", SqlDbType.Int, 4);
            oCmd.Parameters["@FloorX"].Direction = ParameterDirection.Output;
            oCmd.Parameters.Add("@FloorY", SqlDbType.Int, 4);
            oCmd.Parameters["@FloorY"].Direction = ParameterDirection.Output;
            oCmd.Parameters.Add("@FirstDgtPass", SqlDbType.Int, 4);
            oCmd.Parameters["@FirstDgtPass"].Direction = ParameterDirection.Output;
            oCmd.Parameters.Add("@SecDgtPass", SqlDbType.Int, 4);
            oCmd.Parameters["@SecDgtPass"].Direction = ParameterDirection.Output;
            oCmd.Parameters.Add("@ThirdDgtPass", SqlDbType.Int, 4);
            oCmd.Parameters["@ThirdDgtPass"].Direction = ParameterDirection.Output;
            oCmd.Parameters.Add("@CaseStatus", SqlDbType.Int, 4);
            oCmd.Parameters["@CaseStatus"].Direction = ParameterDirection.Output;
            oCmd.Parameters.Add("@HaveCase", SqlDbType.Int, 4);
            oCmd.Parameters["@HaveCase"].Direction = ParameterDirection.Output;
            oCmd.Parameters.Add("@Note", SqlDbType.Int, 4);
            oCmd.Parameters["@Note"].Direction = ParameterDirection.Output;
            oCmd.Parameters.Add("@Phone", SqlDbType.Int, 4);
            oCmd.Parameters["@Phone"].Direction = ParameterDirection.Output;
            oCmd.Parameters.Add("@Audio", SqlDbType.Int, 4);
            oCmd.Parameters["@Audio"].Direction = ParameterDirection.Output;

            SqlDataReader DR;
            try
            {
            Cnn.Open();
            DR = oCmd.ExecuteReader();
            DR.Close();

            FloorNo = Convert.ToInt16(oCmd.Parameters["@FloorNo"].Value);
            FloorX = Convert.ToInt16(oCmd.Parameters["@FloorX"].Value);
            FloorY = Convert.ToInt16(oCmd.Parameters["@FloorY"].Value);
            FirstDgtPass = Convert.ToInt16(oCmd.Parameters["@FirstDgtPass"].Value);
            SecDgtPass = Convert.ToInt16(oCmd.Parameters["@SecDgtPass"].Value);
            ThirdDgtPass = Convert.ToInt16(oCmd.Parameters["@ThirdDgtPass"].Value);
            CaseStatus = Convert.ToInt16(oCmd.Parameters["@CaseStatus"].Value);
            HaveCase = Convert.ToInt16(oCmd.Parameters["@HaveCase"].Value);
            HaveNote = Convert.ToInt16(oCmd.Parameters["@Note"].Value);
            HavePhone = Convert.ToInt16(oCmd.Parameters["@Phone"].Value);
            HaveAudio = Convert.ToInt16(oCmd.Parameters["@Audio"].Value);

            

            fmPlayGame fPG = new fmPlayGame(StartGameStatus, PlayerName, FloorNo, FloorX, FloorY, FirstDgtPass, SecDgtPass, ThirdDgtPass, CaseStatus, HaveCase, HaveNote, HavePhone, HaveAudio);
            this.Hide();
                fPG.ShowDialog();
                this.Close();

            }
            catch (SqlException ex)
            {
                
                MessageBox.Show(ex.Message);
                this.btnPlaySaved.Enabled = false;
            }
            //this.Close();
            //Cnn.Open();
            //DR = oCmd.ExecuteReader();
            //DR.Close();
            //FloorNo = Convert.ToInt16(oCmd.Parameters["@FloorNo"].Value);
            //FloorX = Convert.ToInt16(oCmd.Parameters["@FloorX"].Value);
            //FloorY = Convert.ToInt16(oCmd.Parameters["@FloorY"].Value);
            //FirstDgtPass = Convert.ToInt16(oCmd.Parameters["@FirstDgtPass"].Value);
            //SecDgtPass = Convert.ToInt16(oCmd.Parameters["@SecDgtPass"].Value);
            //ThirdDgtPass = Convert.ToInt16(oCmd.Parameters["@ThirdDgtPass"].Value);
            //CaseStatus = Convert.ToInt16(oCmd.Parameters["@CaseStatus"].Value);
            //HaveCase = Convert.ToInt16(oCmd.Parameters["@HaveCase"].Value);
            //HaveNote = Convert.ToInt16(oCmd.Parameters["@Note"].Value);
            //HavePhone = Convert.ToInt16(oCmd.Parameters["@Phone"].Value);
            //HaveAudio = Convert.ToInt16(oCmd.Parameters["@Audio"].Value);

            //fmPlayGame fPG = new fmPlayGame(StartGameStatus, PlayerName, FloorNo, FloorX, FloorY, FirstDgtPass, SecDgtPass, ThirdDgtPass, CaseStatus, HaveCase, HaveNote, HavePhone, HaveAudio);
            //fPG.ShowDialog();
            
        }

        private void btnPlayNew_Click(object sender, EventArgs e)
        {
            
            StartGameStatus = 0;
            FloorNo=0;
            FloorX=0;
            FloorY=0;
            FirstDgtPass=0;
            SecDgtPass=0;
            ThirdDgtPass=0;
            CaseStatus=0;
            HaveCase=0;
            HaveNote=0;
            HavePhone=0;
            HaveAudio=0;

            fmPlayGame fPG = new fmPlayGame(StartGameStatus, PlayerName, FloorNo, FloorX, FloorY, FirstDgtPass, SecDgtPass, ThirdDgtPass, CaseStatus, HaveCase, HaveNote, HavePhone, HaveAudio);
            this.Hide();
            fPG.ShowDialog();
            this.Close();
        }

        private void fmSelectGame_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.CenterToScreen();

            if (PlayerStatus == 0)
            {
                this.btnPlaySaved.Enabled = false;
            }
        }
    }
}
