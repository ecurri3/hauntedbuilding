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
    public partial class fmPlayGame : Form
    {
        private Game.HauntedBuilding hb;
        private Game.Graphic currentGraphic;
        private int state;
        private bool enteringCode; //Is the user entering a pass code?
        private bool helping; //used in Help click event

        //Constructor
        public fmPlayGame()
        {
            InitializeComponent();

            currentGraphic = new Game.Graphic("");
            state = 0;
            enteringCode = false;
            helping = true;

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
            textBox1.Text = graphic.getImage();
            textBox2.Text = graphic.Text;

            currentGraphic.Text = textBox2.Text;
        }

        //Start button click
        private void button1_Click(object sender, EventArgs e)
        {
            //sql
            //if user wanted a new game;
            //change "Johnny" to real account username
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
                default:
                    return;
            }

        }

        //Help button
        private void button3_Click(object sender, EventArgs e)
        {
            if (helping)
            {
                Game.Graphic graphic = hb.getHelp();
                textBox2.Text = graphic.Text;
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
            if (state == 1)
            {
                Game.GameState gs = hb.currentState(); //this returns a GameState Object
                                    //exmaple: use gs.PlayerName to get playerName.
            }
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

                writeGraphic(hb.tryCase(d1, d2, d3));
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
    }
 
}
