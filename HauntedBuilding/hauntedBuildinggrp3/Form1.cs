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
        private void textBox1_TextChanged(object sender, EventArgs e){}

        //helper function writes to textboxes
        private void writeGraphic(Game.Graphic graphic)
        {
            textBox1.Text = graphic.getImage();
            textBox2.Text = graphic.Text;

            currentGraphic.Text = textBox2.Text;
        }

        //Start button
        private void button1_Click(object sender, EventArgs e)
        {
            writeGraphic(hb.startGame());

            state = 1;
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
    }
 
}
