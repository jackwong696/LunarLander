﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LunarLander
{
    public partial class Form1 : Form
    {
        private double x, y; // ships location points
        private double dx, dy; // ships displacement
        private double rsx, rsy, rsx1, rsy1, rsx2, rsy2; // spectacles location points
        private double rsdx, rsdy, rsdx1, rsdy1, rsdx2, rsdy2; // spectacles displacement 
        private int fuel = 9999999;
        private int ships = 3;
        private int score = 0;
        private int level = 7;
        Rectangle rLander;
        Rectangle rPlatform;
        Rectangle rSpectacle;
        Rectangle rSpectacle1;
        Rectangle rSpectacle2;

        public Form1()
        {
            InitializeComponent();

            initGame();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dy += .5;
            if (level >= 6)
            {
                dy += 0.5;
            }

            score += 100;

            pictureBox1.BackgroundImage = imageList1.Images[0];

            switch (level)
            {
                case 1:
                    break;
                case 2:
                    moveSpectacleOne();
                    break;
                case 3:
                    moveSpectacleTwo();
                    break;
                case 4:
                    moveSpectacleThree();
                    break;
                case 5:
                    moveSpectacleFour();
                    break;
                case 6:
                    moveSpectacleFour();
                    break;
                case 7:
                    moveSpectacleFour();
                    break;
                default:
                    MessageBox.Show("Something have gone wrong. The application will close now.");
                    Application.Exit();
                    break;
            }
            moveShip();
            switch (level)
            {
                case 1:
                    break;
                case 2:
                    checkCollideOne();
                    break;
                case 3:
                    checkCollideTwo();
                    break;
                case 4:
                    checkCollideThree();
                    break;
                case 5:
                    checkCollideThree();
                    break;
                case 6:
                    checkCollideThree();
                    break;
                case 7:
                    checkCollideThree();
                    break;
                default:
                    MessageBox.Show("Something have gone wrong. The application will close now.");
                    Application.Exit();
                    break;
            }
            checkLanding();
            showStats();
        } // end timer tick

        private void moveSpectacleOne()
        {
            Random roller = new Random();

            //int specInterMove;

            //specInterMove = roller.Next(50);

            rsdx = Convert.ToDouble(roller.Next(5) - 2) / 2;
            rsdy = Convert.ToDouble(roller.Next(5) - 2) / 2;

            //for (int i = 0; i < specInterMove; i++)
            //{
            rsx += rsdx;
            if (rsx > panel1.Width - pictureBox3.Width)
            {
                rsx = 0;
            } // end if
            if (rsx < 0)
            {
                rsx = Convert.ToDouble(panel1.Width - pictureBox3.Width);
            } // end if

            rsy += rsdy;
            if (rsy > this.Height - pictureBox3.Height)
            {
                rsy = 0;
            } // end if 
            if (rsy < 0)
            {
                rsy = Convert.ToDouble(panel1.Height - pictureBox3.Height);
            } // end if

            pictureBox3.Location = new Point(Convert.ToInt32(rsx), Convert.ToInt32(rsy));
            //}

            /*rsdx1 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy1 = Convert.ToDouble(roller.Next(5) - 2);

            rsx1 += rsdx1;
            if (rsx1 > panel1.Width - pictureBox4.Width)
            {
                rsx1 = 0;
            } // end if
            if (rsx1 < 0)
            {
                rsx1 = Convert.ToDouble(panel1.Width - pictureBox4.Width);
            } // end if

            rsy1 += rsdy1;
            if (rsy1 > panel1.Height - pictureBox4.Height)
            {
                rsy1 = 0;
            } // end if 
            if (rsy1 < 0)
            {
                rsy1 = Convert.ToDouble(panel1.Height - pictureBox4.Height);
            } // end if

            pictureBox4.Location = new Point(Convert.ToInt32(rsx1), Convert.ToInt32(rsy1));

            rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            rsx2 += rsdx2;
            if (rsx2 > panel1.Width - pictureBox5.Width)
            {
                rsx2 = 0;
            } // end if
            if (rsx2 < 0)
            {
                rsx2 = Convert.ToDouble(panel1.Width - pictureBox5.Width);
            } // end if

            rsy2 += rsdy2;
            if (rsy2 > panel1.Height - pictureBox5.Height)
            {
                rsy2 = 0;
            } // end if 
            if (rsy2 < 0)
            {
                rsy2 = Convert.ToDouble(panel1.Height - pictureBox5.Height);
            } // end if

            pictureBox5.Location = new Point(Convert.ToInt32(rsx2), Convert.ToInt32(rsy2));*/
        }

        private void moveSpectacleTwo()
        {
            Random roller = new Random();

            //int specInterMove;

            //specInterMove = roller.Next(50);

            rsdx = Convert.ToDouble(roller.Next(5) - 2) / 2;
            rsdy = Convert.ToDouble(roller.Next(5) - 2) / 2;

            //for (int i = 0; i < specInterMove; i++)
            //{
            rsx += rsdx;
            if (rsx > panel1.Width - pictureBox3.Width)
            {
                rsx = 0;
            } // end if
            if (rsx < 0)
            {
                rsx = Convert.ToDouble(panel1.Width - pictureBox3.Width);
            } // end if

            rsy += rsdy;
            if (rsy > this.Height - pictureBox3.Height)
            {
                rsy = 0;
            } // end if 
            if (rsy < 0)
            {
                rsy = Convert.ToDouble(panel1.Height - pictureBox3.Height);
            } // end if

            pictureBox3.Location = new Point(Convert.ToInt32(rsx), Convert.ToInt32(rsy));
            //}

            rsdx1 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy1 = Convert.ToDouble(roller.Next(5) - 2);

            rsx1 += rsdx1;
            if (rsx1 > panel1.Width - pictureBox4.Width)
            {
                rsx1 = 0;
            } // end if
            if (rsx1 < 0)
            {
                rsx1 = Convert.ToDouble(panel1.Width - pictureBox4.Width);
            } // end if

            rsy1 += rsdy1;
            if (rsy1 > panel1.Height - pictureBox4.Height)
            {
                rsy1 = 0;
            } // end if 
            if (rsy1 < 0)
            {
                rsy1 = Convert.ToDouble(panel1.Height - pictureBox4.Height);
            } // end if

            pictureBox4.Location = new Point(Convert.ToInt32(rsx1), Convert.ToInt32(rsy1));

            /*rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            rsx2 += rsdx2;
            if (rsx2 > panel1.Width - pictureBox5.Width)
            {
                rsx2 = 0;
            } // end if
            if (rsx2 < 0)
            {
                rsx2 = Convert.ToDouble(panel1.Width - pictureBox5.Width);
            } // end if

            rsy2 += rsdy2;
            if (rsy2 > panel1.Height - pictureBox5.Height)
            {
                rsy2 = 0;
            } // end if 
            if (rsy2 < 0)
            {
                rsy2 = Convert.ToDouble(panel1.Height - pictureBox5.Height);
            } // end if

            pictureBox5.Location = new Point(Convert.ToInt32(rsx2), Convert.ToInt32(rsy2));*/
        }

        private void moveSpectacleThree()
        {
            Random roller = new Random();

            //int specInterMove;

            //specInterMove = roller.Next(50);

            rsdx = Convert.ToDouble(roller.Next(5) - 2) / 2;
            rsdy = Convert.ToDouble(roller.Next(5) - 2) / 2;

            //for (int i = 0; i < specInterMove; i++)
            //{
            rsx += rsdx;
            if (rsx > panel1.Width - pictureBox3.Width)
            {
                rsx = 0;
            } // end if
            if (rsx < 0)
            {
                rsx = Convert.ToDouble(panel1.Width - pictureBox3.Width);
            } // end if

            rsy += rsdy;
            if (rsy > this.Height - pictureBox3.Height)
            {
                rsy = 0;
            } // end if 
            if (rsy < 0)
            {
                rsy = Convert.ToDouble(panel1.Height - pictureBox3.Height);
            } // end if

            pictureBox3.Location = new Point(Convert.ToInt32(rsx), Convert.ToInt32(rsy));
            //}

            rsdx1 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy1 = Convert.ToDouble(roller.Next(5) - 2);

            rsx1 += rsdx1;
            if (rsx1 > panel1.Width - pictureBox4.Width)
            {
                rsx1 = 0;
            } // end if
            if (rsx1 < 0)
            {
                rsx1 = Convert.ToDouble(panel1.Width - pictureBox4.Width);
            } // end if

            rsy1 += rsdy1;
            if (rsy1 > panel1.Height - pictureBox4.Height)
            {
                rsy1 = 0;
            } // end if 
            if (rsy1 < 0)
            {
                rsy1 = Convert.ToDouble(panel1.Height - pictureBox4.Height);
            } // end if

            pictureBox4.Location = new Point(Convert.ToInt32(rsx1), Convert.ToInt32(rsy1));

            rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            rsx2 += rsdx2;
            if (rsx2 > panel1.Width - pictureBox5.Width)
            {
                rsx2 = 0;
            } // end if
            if (rsx2 < 0)
            {
                rsx2 = Convert.ToDouble(panel1.Width - pictureBox5.Width);
            } // end if

            rsy2 += rsdy2;
            if (rsy2 > panel1.Height - pictureBox5.Height)
            {
                rsy2 = 0;
            } // end if 
            if (rsy2 < 0)
            {
                rsy2 = Convert.ToDouble(panel1.Height - pictureBox5.Height);
            } // end if

            pictureBox5.Location = new Point(Convert.ToInt32(rsx2), Convert.ToInt32(rsy2));
        }

        private void moveSpectacleFour()
        {
            Random roller = new Random();

            int specInterMove;

            specInterMove = roller.Next(50);

            rsdx = Convert.ToDouble(roller.Next(5) - 2) / 2;
            rsdy = Convert.ToDouble(roller.Next(5) - 2) / 2;

            for (int i = 0; i < specInterMove; i++)
            {
                rsx += rsdx;
                if (rsx > panel1.Width - pictureBox3.Width)
                {
                    rsx = 0;
                } // end if
                if (rsx < 0)
                {
                    rsx = Convert.ToDouble(panel1.Width - pictureBox3.Width);
                } // end if

                rsy += rsdy;
                if (rsy > this.Height - pictureBox3.Height)
                {
                    rsy = 0;
                } // end if 
                if (rsy < 0)
                {
                    rsy = Convert.ToDouble(panel1.Height - pictureBox3.Height);
                } // end if

                pictureBox3.Location = new Point(Convert.ToInt32(rsx), Convert.ToInt32(rsy));
            }

            rsdx1 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy1 = Convert.ToDouble(roller.Next(5) - 2);

            rsx1 += rsdx1;
            if (rsx1 > panel1.Width - pictureBox4.Width)
            {
                rsx1 = 0;
            } // end if
            if (rsx1 < 0)
            {
                rsx1 = Convert.ToDouble(panel1.Width - pictureBox4.Width);
            } // end if

            rsy1 += rsdy1;
            if (rsy1 > panel1.Height - pictureBox4.Height)
            {
                rsy1 = 0;
            } // end if 
            if (rsy1 < 0)
            {
                rsy1 = Convert.ToDouble(panel1.Height - pictureBox4.Height);
            } // end if

            pictureBox4.Location = new Point(Convert.ToInt32(rsx1), Convert.ToInt32(rsy1));

            rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            rsx2 += rsdx2;
            if (rsx2 > panel1.Width - pictureBox5.Width)
            {
                rsx2 = 0;
            } // end if
            if (rsx2 < 0)
            {
                rsx2 = Convert.ToDouble(panel1.Width - pictureBox5.Width);
            } // end if

            rsy2 += rsdy2;
            if (rsy2 > panel1.Height - pictureBox5.Height)
            {
                rsy2 = 0;
            } // end if 
            if (rsy2 < 0)
            {
                rsy2 = Convert.ToDouble(panel1.Height - pictureBox5.Height);
            } // end if

            pictureBox5.Location = new Point(Convert.ToInt32(rsx2), Convert.ToInt32(rsy2));
        }

        private void moveShip()
        {
            x += dx;
            if (x > panel1.Width - pictureBox1.Width)
            {
                x = 0;
            } // end if
            if (x < 0)
            {
                x = Convert.ToDouble(panel1.Width - pictureBox1.Width);
            } // end if

            y += dy;
            if (y > panel1.Height - pictureBox1.Height)
            {
                y = 0;
            } // end if 
            if (y < 0)
            {
                y = Convert.ToDouble(panel1.Height - pictureBox1.Height);
            } // end if

            pictureBox1.Location = new Point(Convert.ToInt32(x), Convert.ToInt32(y));
        } // end moveShip

        private void checkCollideOne()
        {
            rLander = pictureBox1.Bounds;
            rSpectacle = pictureBox3.Bounds;
            //rSpectacle1 = pictureBox4.Bounds;
            //rSpectacle2 = pictureBox5.Bounds;

            if (rLander.IntersectsWith(rSpectacle))
            {
                timer1.Enabled = false;

                MessageBox.Show("Your ship have been collide with unknown objects!");
                killShip();
                initGame();
            } // end if
        }

        private void checkCollideTwo()
        {
            rLander = pictureBox1.Bounds;
            rSpectacle = pictureBox3.Bounds;
            rSpectacle1 = pictureBox4.Bounds;
            //rSpectacle2 = pictureBox5.Bounds;

            if (rLander.IntersectsWith(rSpectacle) || rLander.IntersectsWith(rSpectacle1))
            {
                timer1.Enabled = false;

                MessageBox.Show("Your ship have been collide with unknown objects!");
                killShip();
                initGame();
            } // end if
        }

        private void checkCollideThree()
        {
            rLander = pictureBox1.Bounds;
            rSpectacle = pictureBox3.Bounds;
            rSpectacle1 = pictureBox4.Bounds;
            rSpectacle2 = pictureBox5.Bounds;

            if (rLander.IntersectsWith(rSpectacle) || rLander.IntersectsWith(rSpectacle1) || rLander.IntersectsWith(rSpectacle2))
            {
                timer1.Enabled = false;

                MessageBox.Show("Your ship have been collide with unknown objects!");
                killShip();
                initGame();
            } // end if
        }

        private void checkLanding()
        {
            rLander = pictureBox1.Bounds;
            rPlatform = pictureBox2.Bounds;

            if (rLander.IntersectsWith(rPlatform))
            {
                timer1.Enabled = false;

                if (Math.Abs(dx) < 1)
                {
                    if (Math.Abs(dy) < 3)
                    {
                        if (Math.Abs(rLander.Bottom - rPlatform.Top) < 3)
                        {
                            MessageBox.Show("Good Landing!");
                            fuel += 30;
                            score += 10000;
                            level += 1;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Too much vertical velocity!");
                        killShip();
                    } // end vertical if
                }
                else
                {
                    MessageBox.Show("Too much horizontal velocity");
                    killShip();
                } // end horiz if
                initGame();
            } // end if
        } // end checkLanding

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            fuel--;

            if (fuel < 0)
            {
                timer1.Enabled = false;
                MessageBox.Show("Out of Fuel!!");
                fuel += 20;
                killShip();
                initGame();
            } // end if

            switch (e.KeyData)
            {
                case Keys.Up:
                    pictureBox1.BackgroundImage = imageList1.Images[0];
                    dy -= 2;
                    break;
                case Keys.Left:
                    pictureBox1.BackgroundImage = imageList1.Images[0];
                    dx++;
                    break;
                case Keys.Right:
                    pictureBox1.BackgroundImage = imageList1.Images[0];
                    dx--;
                    break;
                default:
                    break;
            } // end switch
        } // end keydown

        public void showStats()
        {
            label1.Text = "dx: " + dx;
            label2.Text = "dy: " + dy;
            label3.Text = "Fuel: " + fuel;
            label4.Text = "Ships: " + ships;
            label5.Text = "Score: " + score;
            label9.Text = "Level: " + level;
            label6.Text = "Spetacles1 Location: " + pictureBox3.Location.X + ", " + pictureBox3.Location.Y + Environment.NewLine
                + "Displacement x: " + rsdx + " Displacement y: " + rsdy + Environment.NewLine
                + "Spetacles2 Location: " + pictureBox4.Location.X + ", " + pictureBox4.Location.Y + Environment.NewLine
                + "Displacement x: " + rsdx1 + " Displacement y: " + rsdy1 + Environment.NewLine
                + "Spetacles3 Location: " + pictureBox5.Location.X + ", " + pictureBox5.Location.Y + Environment.NewLine
                + "Displacement x: " + rsdx2 + " Displacement y: " + rsdy2;
            label7.Text = "Platform location: " + pictureBox2.Location.X + ", " + pictureBox2.Location.Y;
            label8.Text = "Ship location: " + pictureBox1.Location.X + ", " + pictureBox1.Location.Y;
            //label6.Text = "Picturebox 1 Bound: " + pictureBox1.Bounds;
            //label7.Text = "Picturebox 2 Bound: " + pictureBox2.Bounds;
            //if (rLander.IntersectsWith(rPlatform))
            //{
            //    label8.Text = "Ship is landed.";
            //}
        } // end showStats

        public void killShip()
        {
            DialogResult answer;
            ships--;

            if (ships <= 0)
            {
                answer = MessageBox.Show("Play Again?", "Game Over", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    ships = 3;
                    fuel = 100;
                    initGame();
                }
                else
                {
                    Application.Exit();
                } // end if
            } // end 'no ships' if
        } // end killShip

        public void initGame()
        {
            switch (level)
            {
                case 1:
                    initLvlOne();
                    break;
                case 2:
                    initLvlTwo();
                    break;
                case 3:
                    initLvlThree();
                    break;
                case 4:
                    initLvlFour();
                    break;
                case 5:
                    initLvlFour();
                    break;
                case 6:
                    initLvlFour();
                    break;
                case 7:
                    initLvlSeven();
                    break;
                default:
                    MessageBox.Show("Something have gone wrong. The application will close now.");
                    Application.Exit();
                    break;
            }
            timer1.Enabled = true;
        } // end initGame

        public void initLvlOne()
        {
            Random roller = new Random();
            int platX, platY; // platform location points.
            //int speX, speY, speX1, speY1, speX2, speY2; // spetacle location points.

            dx = Convert.ToDouble(roller.Next(5) - 2);
            dy = Convert.ToDouble(roller.Next(5) - 2);

            x = Convert.ToDouble(roller.Next(panel1.Width));
            y = Convert.ToDouble(roller.Next(panel1.Height));

            platX = roller.Next(panel1.Width - pictureBox2.Width);
            platY = roller.Next(panel1.Height - pictureBox2.Height);
            pictureBox2.Location = new Point(platX, platY);

            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;

            //rsdx = Convert.ToDouble(roller.Next(5) - 2);
            //rsdy = Convert.ToDouble(roller.Next(5) - 2);

            //rsx = Convert.ToDouble(roller.Next(panel1.Width - pictureBox3.Width));
            //rsy = Convert.ToDouble(roller.Next(panel1.Height - pictureBox3.Height));
            //speX = roller.Next(panel1.Width - pictureBox3.Width);
            //speY = roller.Next(panel1.Height - pictureBox3.Height);
            //pictureBox3.Location = new Point(speX, speY);

            //rsdx1 = Convert.ToDouble(roller.Next(5) - 2);
            //rsdy1 = Convert.ToDouble(roller.Next(5) - 2);

            //rsx1 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox4.Width));
            //rsy1 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox4.Height));
            //speX1 = roller.Next(panel1.Width - pictureBox4.Width);
            //speY1 = roller.Next(panel1.Height - pictureBox4.Height);
            //pictureBox4.Location = new Point(speX1, speY1);

            //rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            //rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            //rsx2 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox5.Width));
            //rsy2 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox5.Height));
            //speX2 = roller.Next(panel1.Width - pictureBox5.Width);
            //speY2 = roller.Next(panel1.Height - pictureBox5.Height);
            //pictureBox5.Location = new Point(speX2, speY2);
        }

        public void initLvlTwo()
        {
            Random roller = new Random();
            int platX, platY; // platform location points.
            int speX, speY, speX1, speY1, speX2, speY2; // spetacle location points.

            dx = Convert.ToDouble(roller.Next(5) - 2);
            dy = Convert.ToDouble(roller.Next(5) - 2);

            x = Convert.ToDouble(roller.Next(panel1.Width));
            y = Convert.ToDouble(roller.Next(panel1.Height));

            platX = roller.Next(panel1.Width - pictureBox2.Width);
            platY = roller.Next(panel1.Height - pictureBox2.Height);
            pictureBox2.Location = new Point(platX, platY);

            rsdx = Convert.ToDouble(roller.Next(5) - 2);
            rsdy = Convert.ToDouble(roller.Next(5) - 2);

            rsx = Convert.ToDouble(roller.Next(panel1.Width - pictureBox3.Width));
            rsy = Convert.ToDouble(roller.Next(panel1.Height - pictureBox3.Height));
            speX = roller.Next(panel1.Width - pictureBox3.Width);
            speY = roller.Next(panel1.Height - pictureBox3.Height);
            pictureBox3.Location = new Point(speX, speY);
            pictureBox3.Visible = true;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;

            //rsdx1 = Convert.ToDouble(roller.Next(5) - 2);
            //rsdy1 = Convert.ToDouble(roller.Next(5) - 2);

            //rsx1 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox4.Width));
            //rsy1 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox4.Height));
            //speX1 = roller.Next(panel1.Width - pictureBox4.Width);
            //speY1 = roller.Next(panel1.Height - pictureBox4.Height);
            //pictureBox4.Location = new Point(speX1, speY1);

            //rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            //rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            //rsx2 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox5.Width));
            //rsy2 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox5.Height));
            //speX2 = roller.Next(panel1.Width - pictureBox5.Width);
            //speY2 = roller.Next(panel1.Height - pictureBox5.Height);
            //pictureBox5.Location = new Point(speX2, speY2);
        }

        public void initLvlThree()
        {
            Random roller = new Random();
            int platX, platY; // platform location points.
            int speX, speY, speX1, speY1, speX2, speY2; // spetacle location points.

            dx = Convert.ToDouble(roller.Next(5) - 2);
            dy = Convert.ToDouble(roller.Next(5) - 2);

            x = Convert.ToDouble(roller.Next(panel1.Width));
            y = Convert.ToDouble(roller.Next(panel1.Height));

            platX = roller.Next(panel1.Width - pictureBox2.Width);
            platY = roller.Next(panel1.Height - pictureBox2.Height);
            pictureBox2.Location = new Point(platX, platY);

            rsdx = Convert.ToDouble(roller.Next(5) - 2);
            rsdy = Convert.ToDouble(roller.Next(5) - 2);

            rsx = Convert.ToDouble(roller.Next(panel1.Width - pictureBox3.Width));
            rsy = Convert.ToDouble(roller.Next(panel1.Height - pictureBox3.Height));
            speX = roller.Next(panel1.Width - pictureBox3.Width);
            speY = roller.Next(panel1.Height - pictureBox3.Height);
            pictureBox3.Location = new Point(speX, speY);
            pictureBox3.Visible = true;

            rsdx1 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy1 = Convert.ToDouble(roller.Next(5) - 2);

            rsx1 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox4.Width));
            rsy1 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox4.Height));
            speX1 = roller.Next(panel1.Width - pictureBox4.Width);
            speY1 = roller.Next(panel1.Height - pictureBox4.Height);
            pictureBox4.Location = new Point(speX1, speY1);
            pictureBox4.Visible = true;
            pictureBox5.Visible = false;

            //rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            //rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            //rsx2 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox5.Width));
            //rsy2 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox5.Height));
            //speX2 = roller.Next(panel1.Width - pictureBox5.Width);
            //speY2 = roller.Next(panel1.Height - pictureBox5.Height);
            //pictureBox5.Location = new Point(speX2, speY2);
        }

        public void initLvlFour()
        {
            Random roller = new Random();
            int platX, platY; // platform location points.
            int speX, speY, speX1, speY1, speX2, speY2; // spetacle location points.

            dx = Convert.ToDouble(roller.Next(5) - 2);
            dy = Convert.ToDouble(roller.Next(5) - 2);

            x = Convert.ToDouble(roller.Next(panel1.Width));
            y = Convert.ToDouble(roller.Next(panel1.Height));

            platX = roller.Next(panel1.Width - pictureBox2.Width);
            platY = roller.Next(panel1.Height - pictureBox2.Height);
            pictureBox2.Location = new Point(platX, platY);

            rsdx = Convert.ToDouble(roller.Next(5) - 2);
            rsdy = Convert.ToDouble(roller.Next(5) - 2);

            rsx = Convert.ToDouble(roller.Next(panel1.Width - pictureBox3.Width));
            rsy = Convert.ToDouble(roller.Next(panel1.Height - pictureBox3.Height));
            speX = roller.Next(panel1.Width - pictureBox3.Width);
            speY = roller.Next(panel1.Height - pictureBox3.Height);
            pictureBox3.Location = new Point(speX, speY);
            pictureBox3.Visible = true;

            rsdx1 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy1 = Convert.ToDouble(roller.Next(5) - 2);

            rsx1 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox4.Width));
            rsy1 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox4.Height));
            speX1 = roller.Next(panel1.Width - pictureBox4.Width);
            speY1 = roller.Next(panel1.Height - pictureBox4.Height);
            pictureBox4.Location = new Point(speX1, speY1);
            pictureBox4.Visible = true;

            rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            rsx2 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox5.Width));
            rsy2 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox5.Height));
            speX2 = roller.Next(panel1.Width - pictureBox5.Width);
            speY2 = roller.Next(panel1.Height - pictureBox5.Height);
            pictureBox5.Location = new Point(speX2, speY2);
            pictureBox5.Visible = true;
        }

        public void initLvlSeven()
        {
            Random roller = new Random();
            int platX, platY; // platform location points.
            int speX, speY, speX1, speY1, speX2, speY2; // spetacle location points.

            dx = Convert.ToDouble(roller.Next(5) - 2);
            dy = Convert.ToDouble(roller.Next(5) - 2);

            x = Convert.ToDouble(roller.Next(panel1.Width));
            y = Convert.ToDouble(roller.Next(panel1.Height));

            platX = roller.Next(panel1.Width - pictureBox2.Width);
            platY = roller.Next(panel1.Height - pictureBox2.Height);
            pictureBox2.Location = new Point(platX, platY);
            pictureBox2.Width = 26;

            rsdx = Convert.ToDouble(roller.Next(5) - 2);
            rsdy = Convert.ToDouble(roller.Next(5) - 2);

            rsx = Convert.ToDouble(roller.Next(panel1.Width - pictureBox3.Width));
            rsy = Convert.ToDouble(roller.Next(panel1.Height - pictureBox3.Height));
            speX = roller.Next(panel1.Width - pictureBox3.Width);
            speY = roller.Next(panel1.Height - pictureBox3.Height);
            pictureBox3.Location = new Point(speX, speY);
            pictureBox3.Visible = true;

            rsdx1 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy1 = Convert.ToDouble(roller.Next(5) - 2);

            rsx1 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox4.Width));
            rsy1 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox4.Height));
            speX1 = roller.Next(panel1.Width - pictureBox4.Width);
            speY1 = roller.Next(panel1.Height - pictureBox4.Height);
            pictureBox4.Location = new Point(speX1, speY1);
            pictureBox4.Visible = true;

            rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            rsx2 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox5.Width));
            rsy2 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox5.Height));
            speX2 = roller.Next(panel1.Width - pictureBox5.Width);
            speY2 = roller.Next(panel1.Height - pictureBox5.Height);
            pictureBox5.Location = new Point(speX2, speY2);
            pictureBox5.Visible = true;
        }
    } // end class
} // end Namespace
