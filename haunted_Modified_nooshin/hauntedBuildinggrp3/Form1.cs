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
        private Game.Graphic currentGraphic = new Game.Graphic("");
        private int state = 0;
        private bool helping = true; //used in Help click event

        //Constructor
        public fmPlayGame()
        {
            InitializeComponent();
            //KeyPress event handlers that call appropriate handler
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(Form1_Keypress);

            hb = new Game.HauntedBuilding();
        }

        //ignore this
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ;
        }

        //Start button
        private void button1_Click(object sender, EventArgs e)
        {
            //if(state == 0) //first time they click "Start"
            //{
            //    textBox1.Text = hb.getTitle() + System.Environment.NewLine +
            //                    "Press start to begin.";

            //    currentGraphic.setGraphic(textBox1.Text);

                currentGraphic.Text = textBox1.Text;


            //    state = 1;
            //}

            //TODO startGame will need parameters like loading a saved file 
            //call startGame() 
            //If they keep clicking "Start" restart the game
            //else
            {
               Game.Graphic graphic = hb.startGame();
               textBox1.Text = graphic.Text;

               currentGraphic.Text = textBox1.Text;

               state = 2;
            }
                
        }

        private void Form1_Keypress(object sender, KeyPressEventArgs e)
        {
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
                textBox1.Text = graphic.Text;
                helping = false;
            }
            else
            {
                textBox1.Text = currentGraphic.Text;
                helping = true;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = hb.getTitle() + System.Environment.NewLine +
                                "Press start to begin.";

            currentGraphic.Text=textBox1.Text;
        }

        private void up_Click_1(object sender, EventArgs e)
        {
            if (state == 2)
            {
                Game.Graphic graphic = hb.enterCommand("FORWARD");
                textBox1.Text = graphic.Text;

                currentGraphic.Text = textBox1.Text;
            }
        }

        private void down_Click_1(object sender, EventArgs e)
        {
            if (state == 2)
            {
                Game.Graphic graphic = hb.enterCommand("BACKWARD");
                textBox1.Text = graphic.Text;

                currentGraphic.Text = textBox1.Text;
            }
        }

        private void right_Click_1(object sender, EventArgs e)
        {
            if (state == 2)
            {
                Game.Graphic graphic = hb.enterCommand("RIGHT");
                textBox1.Text = graphic.Text;

                currentGraphic.Text = textBox1.Text;
            }
        }

        private void left_Click_1(object sender, EventArgs e)
        {
            if (state == 2)
            {
                Game.Graphic graphic = hb.enterCommand("LEFT");
                textBox1.Text = graphic.Text;

                currentGraphic.Text = textBox1.Text;
            }
        }

        private void pickup_Click_1(object sender, EventArgs e)
        {
            if (state == 2)
            {
                Game.Graphic graphic = hb.enterCommand("PICKUP");
                textBox1.Text = graphic.Text;

                currentGraphic.Text = textBox1.Text;
            }

        }

        private void inventory_Click_1(object sender, EventArgs e)
        {
            if (state == 2)
            {
                Game.Graphic graphic = hb.enterCommand("INVT");
                textBox1.Text = graphic.Text;

                currentGraphic.Text = textBox1.Text;
            }
        }

        private void inspect_Click_1(object sender, EventArgs e)
        {
            if (state == 2)
            {
                Game.Graphic graphic = hb.enterCommand("INSPECT");
                textBox1.Text = graphic.Text;

                currentGraphic.Text = textBox1.Text;
            }
        }
    }
 
}
