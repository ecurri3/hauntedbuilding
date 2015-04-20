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
    public partial class fmPlayGame : Form
    {
        private Game.HauntedBuilding hb;
        private Game.Graphic currentGraphic;
        private bool enteringCode; //Is the user entering a pass code?
        private bool helping; //used in Help click event
        //Timing the game
        private bool gameStarted; //just used for help(), to avoid a timer bug
        private int hour;
        private int min;
        private int sec;

        //N
       private string DffValue; //For use in saving scores to database

       private int gStatus;
       private string gPlayer;
       private int gFloorNo;
       private int gFloorX;
       private int gFloorY;
       private int gFirstDgt;
       private int gSecDgt;
       private int gThirdDgt;
       private bool gCaseStatus;
       private bool gHaveCase;
       private bool gHaveNote;
       private bool gHavePhone;
       private bool gHaveAudio;
       private int gDifficulty;
       private int gTimeRemain;
       private string gCaseHint;
       private int gScareMeter;
        //N

        //N changed 
        //public fmPlayGame()
        public fmPlayGame(int sStatus, string sPlayer, int sFloorNo, int sFloorX, int sFloorY, int sFirstDgtPass, int sSecDgtPass, int sThirdDgtPass, int sCaseStatus, int sHaveCase, int sHaveNote, int sHavePhone, int sHaveAudio, int sDifficulty, int sTimeRemain, string sCaseHint, int sScareMeter)
        {
            //N
            //public fmPlayGame(int sStatus, string sPlayer, int sFloorNo, int sFloorX, int sFloorY, int sFirstDgtPass, int sSecDgtPass, int sThirdDgtPass, int sCaseStatus, int sHaveCase, int sHaveNote, int sHavePhone, int sHaveAudio )
            //{
            //InitializeComponent();

            //N

            InitializeComponent();
            //N
            gStatus = sStatus;
            gPlayer = sPlayer;
            gFloorNo = sFloorNo;
            gFloorX = sFloorX;
            gFloorY = sFloorY;
            gFirstDgt = sFirstDgtPass;
            gSecDgt = sSecDgtPass;
            gThirdDgt = sThirdDgtPass;
            gCaseStatus = Convert.ToBoolean(sCaseStatus);
            gHaveCase = Convert.ToBoolean(sHaveCase);
            gHaveNote = Convert.ToBoolean(sHaveNote);
            gHavePhone = Convert.ToBoolean(sHavePhone);
            gHaveAudio = Convert.ToBoolean(sHaveAudio);
            gDifficulty = sDifficulty;
            gTimeRemain = sTimeRemain;
            gCaseHint = sCaseHint;
            gScareMeter = sScareMeter;

            //Set DffValue, difficulty as string
            switch (gDifficulty)
            {
                case 0:
                    DffValue = "Easy"; break;
                case 1:
                    DffValue = "Medium"; break;
                case 2:
                    DffValue = "Hard"; break;
                default:
                    DffValue = "Error: DffVal"; break;
            }
            //N
            currentGraphic = new Game.Graphic("");
            enteringCode = false;
            helping = true;
            gameStarted = false;

            //Sets frightened meter max and min
            //Increment by a set amount to increase and decrease how scared player is
            progressBar1.Maximum = 20;
            progressBar1.Minimum = 0;

            //KeyPress event handlers that call appropriate handler
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(Form1_Keypress);

            hb = new Game.HauntedBuilding();
        }

        //ignore this
        private void textBox1_TextChanged(object sender, EventArgs e){}

        //helper function writes to textboxes
        private void writeGraphic(Game.Graphic graphic)
        {
            if(graphic.isImageSet())
                textBox1.Text = graphic.getImage();

            if(graphic.isTextSet())
                textBox2.Text = graphic.Text;

            currentGraphic = graphic;
        }

        //Start button click
        private void button1_Click(object sender, EventArgs e)
        {
            gameScreen.Hide(); //The .gif images
            lbTimer.Visible = true;

            gameStarted = true;
            //sql
            //if user wanted a new game;
            //change "Johnny" to real account username

            //N
            if (gStatus == 0)
            {
                //difficulty as int 0 = easy, 1 = medium, 2 = hard
                /*
                int difficulty;
                if (difficultyBox.Text == "Easy") difficulty = 0;
                else if (difficultyBox.Text == "Medium") difficulty = 1;
                else difficulty = 2;
                */

                resetTime(); //Sets hour,min,sec to default
                progressBar1.Increment(-20);
                writeGraphic(hb.startGame(new Game.GameState(gDifficulty,gPlayer)));

                
            }
            //N


            //N
            if (gStatus == 1)
            {

                sec = gTimeRemain % 60;
                min = gTimeRemain / 60;
                hour = min / 60;
                min %= 60;
                progressBar1.Value = gScareMeter;

                bool[] have = new bool[Game.Constants.NUM_ITEMS];
                have[(int)Game.iName.NOTE] = gHaveNote;
                have[(int)Game.iName.PHONE] = gHavePhone;
                have[(int)Game.iName.AUDIO] = gHaveAudio;
                have[(int)Game.iName.SECRETCASE] = gHaveCase;


                Game.GameState gs = new Game.GameState(gDifficulty, gPlayer, gFloorNo, new Game.PassCode(gFirstDgt, gSecDgt, gThirdDgt),
                                                      new Game.Coordinate(gFloorX, gFloorY), gCaseStatus, have, gCaseHint);
                writeGraphic(hb.startGame(gs));

            }
            //N

            lbTimer.Text = hour.ToString("D2") + ":" + min.ToString("D2") + ":" + sec.ToString("D2"); //start with 5 minutes, may change with difficulty
            timer1.Start();

            playerDisplay.Text = hb.getPlayer().Name;
            pFloorLabel.Text = hb.getPlayer().Floor.Number.ToString();
            pCoordLabel.Text = "(" + hb.getPlayer().Coord.x.ToString() + ", " + hb.getPlayer().Coord.y.ToString() + ")";
            
        }

        //Helper function for ending games.
        private void endGame(String message, bool won)
        {
            if (!won)
            {
                gameScreen.Show();
                gameScreen.Image = Properties.Resources.gameOver;
            }

            hb.endGame();
            timer1.Stop();
            gameStarted = false;
            textBox2.Text = message;
        }

        private void Form1_Keypress(object sender, KeyPressEventArgs e)
        {
            //So the user can enter pass code without casuing the game to play
            if (enteringCode) return;

            if(gameStarted)
                gameScreen.Hide();

            switch (e.KeyChar)
            {
                case 'w': up_Click_1(sender, e);
                    break;
                case 'a': left_Click_1(sender, e);
                    break;
                case 's': down_Click_1(sender, e);
                    break;
                case 'd': right_Click_1(sender, e);
                    break;
                case 'e': pickup_Click_1(sender, e);
                    break;
                case 'r': inspect_Click_1(sender, e);
                    break;
                case '1': inventory_Click_1(sender, e);
                    break;
                case 'x': enterUp_Click(sender, e);
                    break;
                case 'c': enterDown_Click(sender, e);
                    break;
                case 'f': flashlight_Click(sender, e);
                    break;
                case 'q': Enter_Click(sender, e);
                    break;
                default:
                    return;
            }

        }

        //Help button
        private void button3_Click(object sender, EventArgs e)
        {
            if (helping)
            {
                timer1.Stop();
                if(gameStarted) textBox1.Text = "Paused...";
                textBox2.Text = hb.getHelp().Text;
                helping = false;
            }
            else
            {
                if(gameStarted) timer1.Start();
                if(currentGraphic.isImageSet())
                    textBox1.Text = currentGraphic.getImage();

                textBox2.Text = currentGraphic.Text;
                helping = true;
            }

        }

        //When form loads
        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            label3.Text = DateTime.Now.Date.Month.ToString()+"/"+DateTime.Now.Date.Day.ToString()+"/"+DateTime.Now.Date.Year.ToString();
            lbTimer.Visible = false;
            textBox2.Text = hb.getTitle() + System.Environment.NewLine +
                                "Press start to begin.";

            currentGraphic.Text = textBox2.Text;
        }

        private void up_Click_1(object sender, EventArgs e)
        {
            writeGraphic(hb.enterCommand("FORWARD"));

            if(gameStarted)
                pCoordLabel.Text = "(" + hb.getPlayer().Coord.x.ToString() + ", " + hb.getPlayer().Coord.y.ToString() + ")";
        }

        private void down_Click_1(object sender, EventArgs e)
        {
            writeGraphic(hb.enterCommand("BACKWARD"));

            if(gameStarted)
                pCoordLabel.Text = "(" + hb.getPlayer().Coord.x.ToString() + ", " + hb.getPlayer().Coord.y.ToString() + ")";
        }

        private void right_Click_1(object sender, EventArgs e)
        {
             writeGraphic(hb.enterCommand("RIGHT"));

            if(gameStarted)
                pCoordLabel.Text = "(" + hb.getPlayer().Coord.x.ToString() + ", " + hb.getPlayer().Coord.y.ToString() + ")";
        }

        private void left_Click_1(object sender, EventArgs e)
        {
            writeGraphic(hb.enterCommand("LEFT"));

            if(gameStarted)
                pCoordLabel.Text = "(" + hb.getPlayer().Coord.x.ToString() + ", " + hb.getPlayer().Coord.y.ToString() + ")";
        }

        private void pickup_Click_1(object sender, EventArgs e)
        {
            writeGraphic(hb.enterCommand("PICKUP"));

            if (textBox2.Text.Contains("Hourglass"))
            {
                sec += currentGraphic.ExtraFlag; //the extra flag holds the amount of time picked up
                //get overall time in seconds, useful for recalculation
                sec = sec + min * 60 + (hour * 60 * 60);

                if (sec > 59) lbTimer.ForeColor = System.Drawing.Color.Lime;

                min = sec / 60; //recalc num of minutes
                sec %= 60;
                hour = min / 60; //recalc num of hours
                min %= 60;

                lbTimer.Text = hour.ToString("D2") + ":" + min.ToString("D2") + ":" + sec.ToString("D2");
            }
        }

        private void inventory_Click_1(object sender, EventArgs e)
        {
            writeGraphic(hb.enterCommand("INVT"));
        }

        private void inspect_Click_1(object sender, EventArgs e)
        {
            writeGraphic(hb.enterCommand("INSPECT"));
        }

        private void save_Click(object sender, EventArgs e)
        {
           
            //if (state == 1)
            //{
            //    Game.GameState gs = hb.currentState(); //this returns a GameState Object
            //                        //exmaple: use gs.PlayerName to get playerName.
            //}
//N
            if (gameStarted)
            {
                Game.GameState gs = hb.currentState();

                string UserName = gs.playerName;
                int FloorNo = gs.floorNumber;
                int FloorX = gs.coord.x;
                int FloorY = gs.coord.y;
                //int FirstDgtPass = gs.pc.a;
                int FirstDgtPass = gs.pc.code[0];
                int SecondDgtPass = gs.pc.code[1];
                int ThirdDgtPass = gs.pc.code[2];
                bool CaseStatus = gs.caseLocked;
                bool HaveCase = gs.have[(int)Game.iName.SECRETCASE];       //bool HaveSecCase=gs.have[3];
                bool HaveNote = gs.have[(int)Game.iName.NOTE];    
                bool HavePhone = gs.have[(int)Game.iName.PHONE];
                bool HaveAudio = gs.have[(int)Game.iName.AUDIO];

                String CaseHint = gs.caseHint;
                
                int Difficulty=gs.difficulty;
                
                int TimeRemain=hour*3600+min*60+sec;
                int ScareMeter=progressBar1.Value;
                //bool HaveAudio = gs.haveAudio;

                string filename = "HauntedBuilding.mdf";
                string connectionInfo = String.Format(@"Data Source=(LocalDB)\v11.0;
                AttachDbFilename=|DataDirectory|\{0};Integrated Security=True;", filename);

                SqlConnection Cnn = new SqlConnection(connectionInfo);

                //SqlConnection Cnn = new SqlConnection();
                //Cnn.ConnectionString = "Data Source=WIN-PC;Initial Catalog=HauntedBuilding;Integrated Security=True";
                
                SqlCommand oCmd = new SqlCommand();
                //SqlDataReader DR= oCmd.ExecuteReader();
                //oCmd.Connection.ConnectionString="Data Source=WIN-PC; Initial Ctalog=HauntedBuilding; Integrated Security=True"; //oConn is a Module which create a connection to sql
                oCmd.Connection = Cnn;
                oCmd.CommandTimeout = 0;
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.CommandText = "spSaveGame";
                oCmd.Parameters.Add("@UserName", SqlDbType.NVarChar);
                oCmd.Parameters.Add("@FloorNo", SqlDbType.Int);
                oCmd.Parameters.Add("@FloorX", SqlDbType.Int);
                oCmd.Parameters.Add("@FloorY", SqlDbType.Int);
                oCmd.Parameters.Add("@FirstDgtPass", SqlDbType.Int);
                oCmd.Parameters.Add("@SecDgtPass", SqlDbType.Int);
                oCmd.Parameters.Add("@ThirdDgtPass", SqlDbType.Int);
                oCmd.Parameters.Add("@CaseStatus", SqlDbType.Int);
                oCmd.Parameters.Add("@HaveCase", SqlDbType.Int);
                oCmd.Parameters.Add("@Note", SqlDbType.Int);
                oCmd.Parameters.Add("@Phone", SqlDbType.Int);
                oCmd.Parameters.Add("@Audio", SqlDbType.Int);
                oCmd.Parameters.Add("@Difficulty", SqlDbType.Int);
                oCmd.Parameters.Add("@TimeRemain", SqlDbType.Int);
                oCmd.Parameters.Add("@CaseHint", SqlDbType.NVarChar);
                oCmd.Parameters.Add("@ScareMeter", SqlDbType.Int);


                oCmd.Parameters["@UserName"].Value = UserName;
                oCmd.Parameters["@FloorNo"].Value = FloorNo;
                oCmd.Parameters["@FloorX"].Value = FloorX;
                oCmd.Parameters["@FloorY"].Value = FloorY;
                oCmd.Parameters["@FirstDgtPass"].Value = FirstDgtPass;
                oCmd.Parameters["@SecDgtPass"].Value = SecondDgtPass;
                oCmd.Parameters["@ThirdDgtPass"].Value = ThirdDgtPass;
                oCmd.Parameters["@CaseStatus"].Value = CaseStatus;
                oCmd.Parameters["@HaveCase"].Value = HaveCase;
                oCmd.Parameters["@Note"].Value = HaveNote;
                oCmd.Parameters["@Phone"].Value = HavePhone;
                oCmd.Parameters["@Audio"].Value = HaveAudio;
                oCmd.Parameters["@Difficulty"].Value = Difficulty;
                oCmd.Parameters["@TimeRemain"].Value = TimeRemain;
                oCmd.Parameters["@CaseHint"].Value = CaseHint;
                oCmd.Parameters["@ScareMeter"].Value = ScareMeter;

                try
                {
                    Cnn.Open();
                    oCmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Cnn.Close();
                }

            }
            this.Close();
            //N
        }


        private void enterUp_Click(object sender, EventArgs e)
        {
            writeGraphic(hb.enterCommand("ENTER UP"));

            if (gameStarted)
            {
                pFloorLabel.Text = hb.getPlayer().Floor.Number.ToString();
                pCoordLabel.Text = "(" + hb.getPlayer().Coord.x.ToString() + ", " + hb.getPlayer().Coord.y.ToString() + ")";
            }
        }

        private void enterDown_Click(object sender, EventArgs e)
        {
            writeGraphic(hb.enterCommand("ENTER DOWN"));

            if (gameStarted)
            {
                pFloorLabel.Text = hb.getPlayer().Floor.Number.ToString();
                pCoordLabel.Text = "(" + hb.getPlayer().Coord.x.ToString() + ", " + hb.getPlayer().Coord.y.ToString() + ")";
            }
        }

        //Entering a code
        private void button2_Click(object sender, EventArgs e)
        {
            int d1, d2, d3;
            try
            {
                d1 = System.Convert.ToInt32(digit1.Text);
                d2 = System.Convert.ToInt32(digit2.Text);
                d3 = System.Convert.ToInt32(digit3.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter numerical digits only.");
                return;
            }

            //based on the selection textbox
            if (caseRadio.Checked == true)
                writeGraphic(hb.tryUnlock(0, d1, d2, d3)); //0 means case
            else
                writeGraphic(hb.tryUnlock(1, d1, d2, d3));
        }

        //When user clicks on digit textboxes, turn off keypress event handling
        private void clickDigits(object sender, EventArgs e)
        {
            if (gameStarted)
            {
                gameScreen.Show();
                gameScreen.Image = Properties.Resources.enteringCodeImg;
            }
            enteringCode = true;
        }
        //When they click on the game windows, turn on keypress evenexit handling
        private void windowClick(object sender, EventArgs e)
        {
            if (gameStarted)
            {
                gameScreen.Hide();
            }
            enteringCode = false;
        }

        private void fmPlayGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void flashlight_Click(object sender, EventArgs e)
        {
            writeGraphic(hb.enterCommand("FLASHLIGHT"));

            //If monster was revealed, increment scared meter
            if (currentGraphic.Text.Contains("Monster"))
            {
                gameScreen.Show();
                gameScreen.Image = Properties.Resources.monsterEncounter;


                progressBar1.Increment(1);

                //If scared meter is too high, the game is over
                if (gameStarted && progressBar1.Value >= 20)
                    endGame("Game Over!", false);
            }

        }

        private void Enter_Click(object sender, EventArgs e)
        {
            writeGraphic(hb.enterCommand("ENTER DOOR"));

            if (currentGraphic.ExtraFlag == 1)
            {
                endGame("Congratulations you win!", true);
                //N

                string filename = "HauntedBuilding.mdf";
                string connectionInfo = String.Format(@"Data Source=(LocalDB)\v11.0;
                AttachDbFilename=|DataDirectory|\{0};Integrated Security=True;", filename);

                SqlConnection Cnn = new SqlConnection(connectionInfo);

                //SqlConnection Cnn = new SqlConnection();
                //Cnn.ConnectionString = "Data Source=WIN-PC;Initial Catalog=HauntedBuilding;Integrated Security=True";
                
                SqlCommand oCmd = new SqlCommand();

                oCmd.Connection = Cnn;
                oCmd.CommandTimeout = 0;
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.CommandText = "spSaveScore";
                oCmd.Parameters.Add("@UserName", SqlDbType.NVarChar);
                oCmd.Parameters.Add("@DatePlayed", SqlDbType.NVarChar);
                oCmd.Parameters.Add("@Difficulty", SqlDbType.NVarChar);
                oCmd.Parameters.Add("@TimePlayed", SqlDbType.Int);
                oCmd.Parameters.Add("@Score", SqlDbType.Int);
                oCmd.Parameters["@UserName"].Value = gPlayer;
                oCmd.Parameters["@DatePlayed"].Value = DateTime.Now.Date.Month.ToString() + "/" + DateTime.Now.Date.Day.ToString() + "/" + DateTime.Now.Date.Year.ToString();
                oCmd.Parameters["@Difficulty"].Value = DffValue;
                oCmd.Parameters["@TimePlayed"].Value = 3600 * hour + 60 * min + sec;
                oCmd.Parameters["@Score"].Value = "100" + Convert.ToString(3600 * hour + 60 * min + sec); //Not an INT?


                try
                {
                    Cnn.Open();
                    oCmd.ExecuteNonQuery();
                    //this.Close();


                }
                catch (SqlException ex)
                {

                    MessageBox.Show(ex.Message);

                }
                finally
                {
                    Cnn.Close();
                }
           //N
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        //Clears text boxes for secret case/door codes
        //Ease of life functionality
        private void clearCode_Click(object sender, EventArgs e)
        {
            digit1.Text = "";
            digit2.Text = "";
            digit3.Text = "";
        }
        //int hour, min, sec = 0;

        private void resetTime()
        {
            hour = 0;
            min = 5;   //was 1min
            sec = 0;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (--sec < 0)
            {
                if (--min < 0)
                {
                    if (--hour < 0)
                    {
                        endGame("Time is up", false);
                        return;
                    }
                    else min = 59;
                }
                else sec = 59;
            }


            lbTimer.Text = hour.ToString("D2") + ":" + 
                           min.ToString("D2") + ":" + 
                           sec.ToString("D2");

            if ((hour * 60 * 60) + (min * 60) + sec < 60)
                lbTimer.ForeColor = System.Drawing.Color.Red;

        }

        private void lbTimer_Click(object sender, EventArgs e)
        {

        }


        private void pFloorLabel_Click(object sender, EventArgs e)
        {

        }

        private void labelFloor_Click(object sender, EventArgs e)
        {

        }

    }
 
}
