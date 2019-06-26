﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Need_For_Speed_Crush
{
    public partial class Form1 : Form
    {
        int gamespeed = 0;
        int score = 0;
        int seconds = 0;
        int immunityCounter = 0;
        bool startFlag = false;
        MovingObjects enemyCars;
        MovingObjects fuelObject;
        MyCar myCar;
        List<PictureBox> enemies = new List<PictureBox>();
        List<PictureBox> middleLines = new List<PictureBox>();
        List<PictureBox> fuels = new List<PictureBox>();
        SoundPlayer soundPlayer = new SoundPlayer(Resource1.soundtrack);
        public Form1()
        {
            InitializeComponent();
            InitializeLists();

            myCar = new MyCar(car);
            enemyCars = new MovingObjects(enemies);
            fuelObject = new MovingObjects(fuels);

            gameOver.Visible = false;
            scoreLabel.Visible = false;

        }

        void InitializeLists()
        {
            enemies.Add(enemy1);
            enemies.Add(enemy2);
            enemies.Add(enemy3);
            fuels.Add(fuel);
            middleLines.Add(pictureBox1);
            middleLines.Add(pictureBox2);
            middleLines.Add(pictureBox3);
            middleLines.Add(pictureBox4);
            middleLines.Add(pictureBox5);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            soundPlayer.PlayLooping();
            PlayAgain.Visible = false;
            fuelLabel.Text = "Fuel Level: " + myCar.fuel.ToString();
            SpeedLabel.Text = "Speed: "+  gamespeed.ToString();
        }


        void checkGame()
        {
            if (myCar.lives == 2)
            {
                heart3.Visible = false;
            }
            else if (myCar.lives == 1)
            {
                heart2.Visible = false;
            }

            if (myCar.lives == 0 || myCar.fuel == 0)
            {
                timer1.Enabled = false;
                gameOver.Visible = true;
                scoreLabel.Text += score;
                scoreLabel.Visible = true;
                heart1.Visible = false;
                gamespeed = 0;
                soundPlayer.Stop();
                PlayAgain.Visible = true;

            }
        }

        void moveLine(int speed)
        {
            foreach(PictureBox line in middleLines)
            {
                if (line.Top >= 500 + line.Height)
                {
                    line.Top = -40;
                }
                else
                {
                    line.Top += speed;
                }
            }
        }
          
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void Label1_Click(object sender, EventArgs e)
        {
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (startFlag)
            {
                moveLine(gamespeed);
                enemyCars.CarMove(gamespeed);
                enemyCars.HeartLost(myCar);
                fuelObject.FuelMove(gamespeed);
                fuelObject.RefilFuel(myCar);
                checkGame();
            }

        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            seconds++;
            score += gamespeed;
            if (gamespeed > 0)
            {
                myCar.FuelLost();
            }

            fuelLabel.Text = "Fuel Level: " + myCar.fuel.ToString();
            SpeedLabel.Text = "Speed: " + gamespeed.ToString();


        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            if (myCar.invincible && myCar.lives > 0)
            {

                immunityCounter++;
                car.Visible = !car.Visible;

                if (immunityCounter == 6)
                {
                    car.Visible = true;
                    immunityCounter = 0;
                    myCar.invincible = false;
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            StartButton.Visible = false;
            startFlag = true;
            gamespeed = 1;
            
        }


        void MoveMyCar(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (gamespeed != 0)
                {
                    if (myCar.position.Left > 20 + pictureBox6.Width)
                        myCar.position.Left += -25;
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                if (gamespeed != 0)
                {
                    if (myCar.position.Right <= 365 - pictureBox7.Width)
                        myCar.position.Left += 25;
                }
            }

            if (e.KeyCode == Keys.Up)
            {
                if (gamespeed < 21)
                {
                    gamespeed++;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (gamespeed > 0)
                {
                    gamespeed--;
                }

            }
        }

        private void StartButton_KeyDown(object sender, KeyEventArgs e)
        {
            MoveMyCar(e);
        }

        private void PlayAgain_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
