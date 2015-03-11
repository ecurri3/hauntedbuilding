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
        private int state;
        private bool enteringCode; //Is the user entering a pass code?
        private bool helping; //used in Help click event

        //N
        //private int gStatus;
        //private string gPlayer;
        //private int gFloorNo;
        //private int gFloorX;
        //private int gFloorY;
        //private int gFirstDgt;
        //private int gSecDgt;
        //private int gThirdDgt;
        //private bool gCaseStatus;
        //private bool gHaveCase;
        //private bool gHaveNote;
        //private bool gHavePhone;
        //private bool gHaveAudio;

        public fmPlayGame()
        {
            //N
            //public fmPlayGame(int sStatus, string sPlayer, int sFloorNo, int sFloorX, int sFloorY, int sFirstDgtPass, int sSecDgtPass, int sThirdDgtPass, int sCaseStatus, int sHaveCase, int sHaveNote, int sHavePhone, int sHaveAudio )
            //{
            //InitializeComponent();
            //gStatus = sStatus;
            //gPlayer = sPlayer;
            //gFloorNo = sFloorNo;
            //gFloorX = sFloorX;
            //gFloorY = sFloorY;
            //gFirstDgt = sFirstDgtPass;
            //gSecDgt = sSecDgtPass;
            //gThirdDgt = sThirdDgtPass;
            //gCaseStatus = Convert.ToBoolean(sCaseStatus);
            //gHaveCase = Convert.ToBoolean(sHaveCase);
            //gHaveNote = Convert.ToBoolean(sHaveNote);
            //gHavePhone = Convert.ToBoolean(sHavePhone);
            //gHaveAudio = Convert.ToBoolean(sHaveAudio);
            //N
            InitializeComponent();
            currentGraphic = new Game.Graphic("");
            state = 0;
            enteringCode = false;
            helping = true;

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

            textBox2.Text = graphic.Text;

            currentGraphic.Text = textBox2.Text;
        }

        //Start button click
        private void button1_Click(object sender, EventArgs e)
        {
            lbTimer.Visible = true;
            lbTimer.Text = "";
            timer1.Start();
            //sql
            //if user wanted a new game;
            //change "Johnny" to real account username

            //N
            //if (gStatus==0)
            //{
            //    writeGraphic(hb.startGame(new Game.GameState(gPlayer.ToString())));  
            //}
            //N


            writeGraphic(hb.startGame(new Game.GameState("Johnny")));
           

            //else
            //get SQL data for user name store as variables in GameState object
            //Init. a GameState and fill in the fields
            //pass to hb.startGame(myGameState);

            //Example Test
            /* testing, seems to work fine
               Game.GameState gs = new Game.GameState("Mark",3, new Game.PassCode(3,3,3),
                                                       new Game.Coordinate(4,4),false,true,true,true,true);
                writeGraphic(hb.startGame(gs));
             */

            //N
            //if (gStatus==1)
            //{
            //  bool[] have = new bool[Constants.NUM_ITEMS];
            //  have[(int)iName.NOTE] = ghaveNote;
            //  have[(int)iName.PHONE] = ghavePhone;
            //  have[(int)iName.AUDIO] = ghaveAudio;
            //  have[(int)iName.SECRETCASE] = ghaveCase;

            //    Game.GameState gs = new Game.GameState(gPlayer, gFloorNo, new Game.PassCode(gFirstDgt, gSecDgt, gThirdDgt),
            //                                          new Game.Coordinate(gFloorX, gFloorY), gCaseStatus, have);
            //    writeGraphic(hb.startGame(gs));
            //}
            //N

            progressBar1.Increment(-20);
            state = 1;
        }

        private void Form1_Keypress(object sender, KeyPressEventArgs e)
        {
            //So the user can enter pass code without casuing the game to play
            if (enteringCode) return;

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
                textBox2.Text = hb.getHelp().Text;
                helping = false;
            }
            else
            {
                textBox2.Text = currentGraphic.Text;
                helping = true;
            }

        }

        //When form loads
        private void Form1_Load(object sender, EventArgs e)
        {
            lbTimer.Visible = false;
            textBox2.Text = hb.getTitle() + System.Environment.NewLine +
                                "Press start to begin.";

            currentGraphic.Text = textBox2.Text;
        }

        private void up_Click_1(object sender, EventArgs e)
        {
            if (state == 1)
                writeGraphic(hb.enterCommand("FORWARD"));
        }

        private void down_Click_1(object sender, EventArgs e)
        {
            if (state == 1)
                writeGraphic(hb.enterCommand("BACKWARD"));
        }

        private void right_Click_1(object sender, EventArgs e)
        {
            if (state == 1)
                writeGraphic(hb.enterCommand("RIGHT"));
        }

        private void left_Click_1(object sender, EventArgs e)
        {
            if (state == 1)
                writeGraphic(hb.enterCommand("LEFT"));
        }

        private void pickup_Click_1(object sender, EventArgs e)
        {
            if (state == 1)
                writeGraphic(hb.enterCommand("PICKUP"));
        }

        private void inventory_Click_1(object sender, EventArgs e)
        {
            if (state == 1)
                writeGraphic(hb.enterCommand("INVT"));
        }

        private void inspect_Click_1(object sender, EventArgs e)
        {
            if (state == 1)
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
            //if (state == 1)
            //{
            //    Game.GameState gs = hb.currentState();

            //    string UserName = gs.playerName;
            //    int FloorNo = gs.floorNumber;
            //    int FloorX = gs.coord.x;
            //    int FloorY = gs.coord.y;
            //    int FirstDgtPass = gs.pc.a;
            //    int SecondDgtPass = gs.pc.b;
            //    int ThirdDgtPass = gs.pc.c;
            //    bool CaseStatus = gs.caseLocked;
            //    bool HaveCase = gs.haveCase;
            //    bool HaveNote = gs.haveNote;
            //    bool HavePhone = gs.havePhone;
            //    bool HaveAudio = gs.haveAudio;
                

            //    SqlConnection Cnn = new SqlConnection();
            //    Cnn.ConnectionString = "Data Source=WIN-PC;Initial Catalog=HauntedBuilding;Integrated Security=True";
            //    SqlCommand oCmd = new SqlCommand();
            //    //SqlDataReader DR= oCmd.ExecuteReader();
            //    //oCmd.Connection.ConnectionString="Data Source=WIN-PC; Initial Ctalog=HauntedBuilding; Integrated Security=True"; //oConn is a Module which create a connection to sql
            //    oCmd.Connection = Cnn;
            //    oCmd.CommandTimeout = 0;
            //    oCmd.CommandType = CommandType.StoredProcedure;
            //    oCmd.CommandText = "spSaveGame";
            //    oCmd.Parameters.Add("@UserName", SqlDbType.NVarChar);
            //    oCmd.Parameters.Add("@FloorNo", SqlDbType.Int);
            //    oCmd.Parameters.Add("@FloorX", SqlDbType.Int);
            //    oCmd.Parameters.Add("@FloorY", SqlDbType.Int);
            //    oCmd.Parameters.Add("@FirstDgtPass", SqlDbType.Int);
            //    oCmd.Parameters.Add("@SecDgtPass", SqlDbType.Int);
            //    oCmd.Parameters.Add("@ThirdDgtPass", SqlDbType.Int);
            //    oCmd.Parameters.Add("@CaseStatus", SqlDbType.Int);
            //    oCmd.Parameters.Add("@HaveCase", SqlDbType.Int);
            //    oCmd.Parameters.Add("@Note", SqlDbType.Int);
            //    oCmd.Parameters.Add("@Phone", SqlDbType.Int);
            //    oCmd.Parameters.Add("@Audio", SqlDbType.Int);

            //    oCmd.Parameters["@UserName"].Value = UserName;
            //    oCmd.Parameters["@FloorNo"].Value = FloorNo;
            //    oCmd.Parameters["@FloorX"].Value = FloorX;
            //    oCmd.Parameters["@FloorY"].Value = FloorY;
            //    oCmd.Parameters["@FirstDgtPass"].Value = FirstDgtPass;
            //    oCmd.Parameters["@SecDgtPass"].Value = SecondDgtPass;
            //    oCmd.Parameters["@ThirdDgtPass"].Value = ThirdDgtPass;
            //    oCmd.Parameters["@CaseStatus"].Value = CaseStatus;
            //    oCmd.Parameters["@HaveCase"].Value = HaveCase;
            //    oCmd.Parameters["@Note"].Value = HaveNote;
            //    oCmd.Parameters["@Phone"].Value = HavePhone;
            //    oCmd.Parameters["@Audio"].Value = HaveAudio;


            //    try
            //    {
            //        Cnn.Open();
            //        oCmd.ExecuteNonQuery();
                    
            //    }
            //    catch (SqlException ex)
            //    {

            //        MessageBox.Show(ex.Message);
            //    }
            //}
            //this.Close();
            //N
        }


        private void enterUp_Click(object sender, EventArgs e)
        {
            if (state == 1)
                writeGraphic(hb.enterCommand("ENTER UP"));
        }

        private void enterDown_Click(object sender, EventArgs e)
        {
            if (state == 1)
                writeGraphic(hb.enterCommand("ENTER DOWN"));
        }

        //TryCase
        private void button2_Click(object sender, EventArgs e)
        {
            if (state == 1)
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
                if (tryWhat.Text == "Case")
                    writeGraphic(hb.tryUnlock(0, d1, d2, d3)); //0 means case tryunlock
                else
                    writeGraphic(hb.tryUnlock(1, d1, d2, d3));
            }
        }

        //When user clicks on digit textboxes, turn off keypress event handling
        private void clickDigits(object sender, EventArgs e)
        {
            enteringCode = true;
        }
        //When they click on the game windows, turn on keypress event handling
        private void windowClick(object sender, EventArgs e)
        {
            enteringCode = false;
        }

        private void fmPlayGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void flashlight_Click(object sender, EventArgs e)
        {
            if (state == 1)
                writeGraphic(hb.enterCommand("FLASHLIGHT"));

            //If monster was revealed, increment scared meter
            if (currentGraphic.Text == "Monster!")
                progressBar1.Increment(5);

            //If scared meter is too high, the game is over
            if (progressBar1.Value >= 20)
            {
                state = 0;
                textBox1.Text = "Game Over!";
            }
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            if (state == 1)
                writeGraphic(hb.enterCommand("ENTER DOOR"));

            //TODO better way of detecting the player successfully entered the door
            //The game ends
            if (textBox2.Text.Contains("win"))
                state = 0;
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
        int hour, min, sec = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTimer.Text = hour + ":" + min + ":" + sec.ToString();
            sec++;
            if (sec > 60)
            {
                min++;
                sec = 0;
            }
            else
            {
                sec++;
            }
            if (min > 60)
            {
                hour++;
                min = 0;
            }
        }
    }
 
}
