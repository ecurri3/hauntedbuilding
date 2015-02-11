﻿using System;
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

        //TODO Enter button & error check
        private void button2_Click(object sender, EventArgs e)
        {
            if (state == 2)
            {
                Game.Graphic graphic = hb.enterCommand(listBox1.Text);
                textBox1.Text = graphic.Text;

                currentGraphic.Text = textBox1.Text;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = hb.getTitle() + System.Environment.NewLine +
                                "Press start to begin.";

            currentGraphic.Text=textBox1.Text;
        }
    }
 
}