using System;
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
        private double rsx, rsy, rsx1, rsy1, rsx2, rsy2, rsx3, rsy3, rsx4, rsy4, rsx5, rsy5, rsx6, rsy6, rsx7, rsy7, rsx8, rsy8, rsx9, rsy9; // obstacles location points
        private double rsdx, rsdy, rsdx1, rsdy1, rsdx2, rsdy2, rsdx3, rsdy3, rsdx4, rsdy4, rsdx5, rsdy5, rsdx6, rsdy6, rsdx7, rsdy7, rsdx8, rsdy8, rsdx9, rsdy9; // obstacles displacement 
        private int fuel = 9999999;
        private int ships = 5;
        private int score = 0;
        private int level = 1;
        Rectangle rLander;
        Rectangle rPlatform;
        Rectangle rObstacle;
        Rectangle rObstacle1;
        Rectangle rObstacle2;
        Rectangle rObstacle3;
        Rectangle rObstacle4;
        Rectangle rObstacle5;
        Rectangle rObstacle6;
        Rectangle rObstacle7;
        Rectangle rObstacle8;
        Rectangle rObstacle9;

        PictureBox pictureBox1 = new PictureBox();
        PictureBox pictureBox2 = new PictureBox();
        PictureBox pictureBox3 = new PictureBox();
        PictureBox pictureBox4 = new PictureBox();
        PictureBox pictureBox5 = new PictureBox();
        PictureBox pictureBox6 = new PictureBox();
        PictureBox pictureBox7 = new PictureBox();
        PictureBox pictureBox8 = new PictureBox();
        PictureBox pictureBox9 = new PictureBox();
        PictureBox pictureBox10 = new PictureBox();
        PictureBox pictureBox11 = new PictureBox();
        PictureBox pictureBox12 = new PictureBox();

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
                    moveObstacleOne();
                    break;
                case 3:
                    moveObstacleTwo();
                    break;
                case 4:
                    moveObstacleThree();
                    break;
                case 5:
                    moveObstacleFour();
                    break;
                case 6:
                    moveObstacleFive();
                    break;
                case 7:
                    moveObstacleSix();
                    break;
                case 8:
                    moveObstacleSeven();
                    break;
                case 9:
                    moveObstacleEight();
                    break;
                case 10:
                    moveObstacleNine();
                    break;
                case 11:
                    moveObstacleTen();
                    break;
                case 12:
                    moveObstacleOneWithSpeed();
                    break;
                case 13:
                    moveObstacleOneWithSpeed();
                    break;
                case 14:
                    moveObstacleOneWithSpeed();
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
                    checkCollideFour();
                    break;
                case 6:
                    checkCollideFive();
                    break;
                case 7:
                    checkCollideSix();
                    break;
                case 8:
                    checkCollideSeven();
                    break;
                case 9:
                    checkCollideEight();
                    break;
                case 10:
                    checkCollideNine();
                    break;
                case 11:
                    checkCollideTen();
                    break;
                case 12:
                    checkCollideTen();
                    break;
                case 13:
                    checkCollideTen();
                    break;
                case 14:
                    checkCollideTen();
                    break;
                default:
                    MessageBox.Show("Something have gone wrong. The application will close now.");
                    Application.Exit();
                    break;
            }
            checkLanding();
            showStats();
        } // end timer tick

        private void moveObstacleOne()
        {
            Random roller = new Random();
            
            rsdx = Convert.ToDouble(roller.Next(5) - 2) / 2;
            rsdy = Convert.ToDouble(roller.Next(5) - 2) / 2;

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

        private void moveObstacleTwo()
        {
            Random roller = new Random();
            
            rsdx = Convert.ToDouble(roller.Next(5) - 2) / 2;
            rsdy = Convert.ToDouble(roller.Next(5) - 2) / 2;

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
        }

        private void moveObstacleThree()
        {
            Random roller = new Random();
            
            rsdx = Convert.ToDouble(roller.Next(5) - 2) / 2;
            rsdy = Convert.ToDouble(roller.Next(5) - 2) / 2;

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

        private void moveObstacleFour()
        {
            Random roller = new Random();

            rsdx = Convert.ToDouble(roller.Next(5) - 2) / 2;
            rsdy = Convert.ToDouble(roller.Next(5) - 2) / 2;

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

            rsdx3 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy3 = Convert.ToDouble(roller.Next(5) - 2);

            rsx3 += rsdx3;
            if (rsx3 > panel1.Width - pictureBox6.Width)
            {
                rsx3 = 0;
            } // end if
            if (rsx3 < 0)
            {
                rsx3 = Convert.ToDouble(panel1.Width - pictureBox6.Width);
            } // end if

            rsy3 += rsdy3;
            if (rsy3 > panel1.Height - pictureBox6.Height)
            {
                rsy3 = 0;
            } // end if 
            if (rsy3 < 0)
            {
                rsy3 = Convert.ToDouble(panel1.Height - pictureBox6.Height);
            } // end if

            pictureBox6.Location = new Point(Convert.ToInt32(rsx3), Convert.ToInt32(rsy3));
        }

        private void moveObstacleFive()
        {
            Random roller = new Random();
            
            rsdx = Convert.ToDouble(roller.Next(5) - 2) / 2;
            rsdy = Convert.ToDouble(roller.Next(5) - 2) / 2;

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

            rsdx3 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy3 = Convert.ToDouble(roller.Next(5) - 2);

            rsx3 += rsdx3;
            if (rsx3 > panel1.Width - pictureBox6.Width)
            {
                rsx3 = 0;
            } // end if
            if (rsx3 < 0)
            {
                rsx3 = Convert.ToDouble(panel1.Width - pictureBox6.Width);
            } // end if

            rsy3 += rsdy3;
            if (rsy3 > panel1.Height - pictureBox6.Height)
            {
                rsy3 = 0;
            } // end if 
            if (rsy3 < 0)
            {
                rsy3 = Convert.ToDouble(panel1.Height - pictureBox6.Height);
            } // end if

            pictureBox6.Location = new Point(Convert.ToInt32(rsx3), Convert.ToInt32(rsy3));

            rsdx4 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy4 = Convert.ToDouble(roller.Next(5) - 2);

            rsx4 += rsdx4;
            if (rsx4 > panel1.Width - pictureBox7.Width)
            {
                rsx4 = 0;
            } // end if
            if (rsx4 < 0)
            {
                rsx4 = Convert.ToDouble(panel1.Width - pictureBox7.Width);
            } // end if

            rsy4 += rsdy4;
            if (rsy4 > panel1.Height - pictureBox7.Height)
            {
                rsy4 = 0;
            } // end if 
            if (rsy4 < 0)
            {
                rsy4 = Convert.ToDouble(panel1.Height - pictureBox7.Height);
            } // end if

            pictureBox7.Location = new Point(Convert.ToInt32(rsx4), Convert.ToInt32(rsy4));
        }

        private void moveObstacleSix()
        {
            Random roller = new Random();
            
            rsdx = Convert.ToDouble(roller.Next(5) - 2) / 2;
            rsdy = Convert.ToDouble(roller.Next(5) - 2) / 2;

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

            rsdx3 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy3 = Convert.ToDouble(roller.Next(5) - 2);

            rsx3 += rsdx3;
            if (rsx3 > panel1.Width - pictureBox6.Width)
            {
                rsx3 = 0;
            } // end if
            if (rsx3 < 0)
            {
                rsx3 = Convert.ToDouble(panel1.Width - pictureBox6.Width);
            } // end if

            rsy3 += rsdy3;
            if (rsy3 > panel1.Height - pictureBox6.Height)
            {
                rsy3 = 0;
            } // end if 
            if (rsy3 < 0)
            {
                rsy3 = Convert.ToDouble(panel1.Height - pictureBox6.Height);
            } // end if

            pictureBox6.Location = new Point(Convert.ToInt32(rsx3), Convert.ToInt32(rsy3));

            rsdx4 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy4 = Convert.ToDouble(roller.Next(5) - 2);

            rsx4 += rsdx4;
            if (rsx4 > panel1.Width - pictureBox7.Width)
            {
                rsx4 = 0;
            } // end if
            if (rsx4 < 0)
            {
                rsx4 = Convert.ToDouble(panel1.Width - pictureBox7.Width);
            } // end if

            rsy4 += rsdy4;
            if (rsy4 > panel1.Height - pictureBox7.Height)
            {
                rsy4 = 0;
            } // end if 
            if (rsy4 < 0)
            {
                rsy4 = Convert.ToDouble(panel1.Height - pictureBox7.Height);
            } // end if

            pictureBox7.Location = new Point(Convert.ToInt32(rsx4), Convert.ToInt32(rsy4));

            rsdx5 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy5 = Convert.ToDouble(roller.Next(5) - 2);

            rsx5 += rsdx5;
            if (rsx5 > panel1.Width - pictureBox8.Width)
            {
                rsx5 = 0;
            } // end if
            if (rsx5 < 0)
            {
                rsx5 = Convert.ToDouble(panel1.Width - pictureBox8.Width);
            } // end if

            rsy5 += rsdy5;
            if (rsy5 > panel1.Height - pictureBox8.Height)
            {
                rsy5 = 0;
            } // end if 
            if (rsy5 < 0)
            {
                rsy5 = Convert.ToDouble(panel1.Height - pictureBox8.Height);
            } // end if

            pictureBox8.Location = new Point(Convert.ToInt32(rsx5), Convert.ToInt32(rsy5));
        }

        private void moveObstacleSeven()
        {
            Random roller = new Random();

            rsdx = Convert.ToDouble(roller.Next(5) - 2) / 2;
            rsdy = Convert.ToDouble(roller.Next(5) - 2) / 2;

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

            rsdx3 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy3 = Convert.ToDouble(roller.Next(5) - 2);

            rsx3 += rsdx3;
            if (rsx3 > panel1.Width - pictureBox6.Width)
            {
                rsx3 = 0;
            } // end if
            if (rsx3 < 0)
            {
                rsx3 = Convert.ToDouble(panel1.Width - pictureBox6.Width);
            } // end if

            rsy3 += rsdy3;
            if (rsy3 > panel1.Height - pictureBox6.Height)
            {
                rsy3 = 0;
            } // end if 
            if (rsy3 < 0)
            {
                rsy3 = Convert.ToDouble(panel1.Height - pictureBox6.Height);
            } // end if

            pictureBox6.Location = new Point(Convert.ToInt32(rsx3), Convert.ToInt32(rsy3));

            rsdx4 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy4 = Convert.ToDouble(roller.Next(5) - 2);

            rsx4 += rsdx4;
            if (rsx4 > panel1.Width - pictureBox7.Width)
            {
                rsx4 = 0;
            } // end if
            if (rsx4 < 0)
            {
                rsx4 = Convert.ToDouble(panel1.Width - pictureBox7.Width);
            } // end if

            rsy4 += rsdy4;
            if (rsy4 > panel1.Height - pictureBox7.Height)
            {
                rsy4 = 0;
            } // end if 
            if (rsy4 < 0)
            {
                rsy4 = Convert.ToDouble(panel1.Height - pictureBox7.Height);
            } // end if

            pictureBox7.Location = new Point(Convert.ToInt32(rsx4), Convert.ToInt32(rsy4));

            rsdx5 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy5 = Convert.ToDouble(roller.Next(5) - 2);

            rsx5 += rsdx5;
            if (rsx5 > panel1.Width - pictureBox8.Width)
            {
                rsx5 = 0;
            } // end if
            if (rsx5 < 0)
            {
                rsx5 = Convert.ToDouble(panel1.Width - pictureBox8.Width);
            } // end if

            rsy5 += rsdy5;
            if (rsy5 > panel1.Height - pictureBox8.Height)
            {
                rsy5 = 0;
            } // end if 
            if (rsy5 < 0)
            {
                rsy5 = Convert.ToDouble(panel1.Height - pictureBox8.Height);
            } // end if

            pictureBox8.Location = new Point(Convert.ToInt32(rsx5), Convert.ToInt32(rsy5));

            rsdx6 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy6 = Convert.ToDouble(roller.Next(5) - 2);

            rsx6 += rsdx6;
            if (rsx6 > panel1.Width - pictureBox9.Width)
            {
                rsx6 = 0;
            } // end if
            if (rsx6 < 0)
            {
                rsx6 = Convert.ToDouble(panel1.Width - pictureBox9.Width);
            } // end if

            rsy6 += rsdy6;
            if (rsy6 > panel1.Height - pictureBox9.Height)
            {
                rsy6 = 0;
            } // end if 
            if (rsy6 < 0)
            {
                rsy6 = Convert.ToDouble(panel1.Height - pictureBox9.Height);
            } // end if

            pictureBox9.Location = new Point(Convert.ToInt32(rsx6), Convert.ToInt32(rsy6));
        }

        private void moveObstacleEight()
        {
            Random roller = new Random();

            rsdx = Convert.ToDouble(roller.Next(5) - 2) / 2;
            rsdy = Convert.ToDouble(roller.Next(5) - 2) / 2;

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

            rsdx3 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy3 = Convert.ToDouble(roller.Next(5) - 2);

            rsx3 += rsdx3;
            if (rsx3 > panel1.Width - pictureBox6.Width)
            {
                rsx3 = 0;
            } // end if
            if (rsx3 < 0)
            {
                rsx3 = Convert.ToDouble(panel1.Width - pictureBox6.Width);
            } // end if

            rsy3 += rsdy3;
            if (rsy3 > panel1.Height - pictureBox6.Height)
            {
                rsy3 = 0;
            } // end if 
            if (rsy3 < 0)
            {
                rsy3 = Convert.ToDouble(panel1.Height - pictureBox6.Height);
            } // end if

            pictureBox6.Location = new Point(Convert.ToInt32(rsx3), Convert.ToInt32(rsy3));

            rsdx4 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy4 = Convert.ToDouble(roller.Next(5) - 2);

            rsx4 += rsdx4;
            if (rsx4 > panel1.Width - pictureBox7.Width)
            {
                rsx4 = 0;
            } // end if
            if (rsx4 < 0)
            {
                rsx4 = Convert.ToDouble(panel1.Width - pictureBox7.Width);
            } // end if

            rsy4 += rsdy4;
            if (rsy4 > panel1.Height - pictureBox7.Height)
            {
                rsy4 = 0;
            } // end if 
            if (rsy4 < 0)
            {
                rsy4 = Convert.ToDouble(panel1.Height - pictureBox7.Height);
            } // end if

            pictureBox7.Location = new Point(Convert.ToInt32(rsx4), Convert.ToInt32(rsy4));

            rsdx5 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy5 = Convert.ToDouble(roller.Next(5) - 2);

            rsx5 += rsdx5;
            if (rsx5 > panel1.Width - pictureBox8.Width)
            {
                rsx5 = 0;
            } // end if
            if (rsx5 < 0)
            {
                rsx5 = Convert.ToDouble(panel1.Width - pictureBox8.Width);
            } // end if

            rsy5 += rsdy5;
            if (rsy5 > panel1.Height - pictureBox8.Height)
            {
                rsy5 = 0;
            } // end if 
            if (rsy5 < 0)
            {
                rsy5 = Convert.ToDouble(panel1.Height - pictureBox8.Height);
            } // end if

            pictureBox8.Location = new Point(Convert.ToInt32(rsx5), Convert.ToInt32(rsy5));

            rsdx6 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy6 = Convert.ToDouble(roller.Next(5) - 2);

            rsx6 += rsdx6;
            if (rsx6 > panel1.Width - pictureBox9.Width)
            {
                rsx6 = 0;
            } // end if
            if (rsx6 < 0)
            {
                rsx6 = Convert.ToDouble(panel1.Width - pictureBox9.Width);
            } // end if

            rsy6 += rsdy6;
            if (rsy6 > panel1.Height - pictureBox9.Height)
            {
                rsy6 = 0;
            } // end if 
            if (rsy6 < 0)
            {
                rsy6 = Convert.ToDouble(panel1.Height - pictureBox9.Height);
            } // end if

            pictureBox9.Location = new Point(Convert.ToInt32(rsx6), Convert.ToInt32(rsy6));
            
            rsdx7 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy7 = Convert.ToDouble(roller.Next(5) - 2);

            rsx7 += rsdx7;
            if (rsx7 > panel1.Width - pictureBox10.Width)
            {
                rsx7 = 0;
            } // end if
            if (rsx7 < 0)
            {
                rsx7 = Convert.ToDouble(panel1.Width - pictureBox10.Width);
            } // end if

            rsy7 += rsdy7;
            if (rsy7 > panel1.Height - pictureBox10.Height)
            {
                rsy7 = 0;
            } // end if 
            if (rsy7 < 0)
            {
                rsy7 = Convert.ToDouble(panel1.Height - pictureBox10.Height);
            } // end if

            pictureBox10.Location = new Point(Convert.ToInt32(rsx7), Convert.ToInt32(rsy7));
        }

        private void moveObstacleNine()
        {
            Random roller = new Random();

            rsdx = Convert.ToDouble(roller.Next(5) - 2) / 2;
            rsdy = Convert.ToDouble(roller.Next(5) - 2) / 2;

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

            rsdx3 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy3 = Convert.ToDouble(roller.Next(5) - 2);

            rsx3 += rsdx3;
            if (rsx3 > panel1.Width - pictureBox6.Width)
            {
                rsx3 = 0;
            } // end if
            if (rsx3 < 0)
            {
                rsx3 = Convert.ToDouble(panel1.Width - pictureBox6.Width);
            } // end if

            rsy3 += rsdy3;
            if (rsy3 > panel1.Height - pictureBox6.Height)
            {
                rsy3 = 0;
            } // end if 
            if (rsy3 < 0)
            {
                rsy3 = Convert.ToDouble(panel1.Height - pictureBox6.Height);
            } // end if

            pictureBox6.Location = new Point(Convert.ToInt32(rsx3), Convert.ToInt32(rsy3));

            rsdx4 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy4 = Convert.ToDouble(roller.Next(5) - 2);

            rsx4 += rsdx4;
            if (rsx4 > panel1.Width - pictureBox7.Width)
            {
                rsx4 = 0;
            } // end if
            if (rsx4 < 0)
            {
                rsx4 = Convert.ToDouble(panel1.Width - pictureBox7.Width);
            } // end if

            rsy4 += rsdy4;
            if (rsy4 > panel1.Height - pictureBox7.Height)
            {
                rsy4 = 0;
            } // end if 
            if (rsy4 < 0)
            {
                rsy4 = Convert.ToDouble(panel1.Height - pictureBox7.Height);
            } // end if

            pictureBox7.Location = new Point(Convert.ToInt32(rsx4), Convert.ToInt32(rsy4));

            rsdx5 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy5 = Convert.ToDouble(roller.Next(5) - 2);

            rsx5 += rsdx5;
            if (rsx5 > panel1.Width - pictureBox8.Width)
            {
                rsx5 = 0;
            } // end if
            if (rsx5 < 0)
            {
                rsx5 = Convert.ToDouble(panel1.Width - pictureBox8.Width);
            } // end if

            rsy5 += rsdy5;
            if (rsy5 > panel1.Height - pictureBox8.Height)
            {
                rsy5 = 0;
            } // end if 
            if (rsy5 < 0)
            {
                rsy5 = Convert.ToDouble(panel1.Height - pictureBox8.Height);
            } // end if

            pictureBox8.Location = new Point(Convert.ToInt32(rsx5), Convert.ToInt32(rsy5));
            
            rsdx6 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy6 = Convert.ToDouble(roller.Next(5) - 2);

            rsx6 += rsdx6;
            if (rsx6 > panel1.Width - pictureBox9.Width)
            {
                rsx6 = 0;
            } // end if
            if (rsx6 < 0)
            {
                rsx6 = Convert.ToDouble(panel1.Width - pictureBox9.Width);
            } // end if

            rsy6 += rsdy6;
            if (rsy6 > panel1.Height - pictureBox9.Height)
            {
                rsy6 = 0;
            } // end if 
            if (rsy6 < 0)
            {
                rsy6 = Convert.ToDouble(panel1.Height - pictureBox9.Height);
            } // end if

            pictureBox9.Location = new Point(Convert.ToInt32(rsx6), Convert.ToInt32(rsy6));

            rsdx7 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy7 = Convert.ToDouble(roller.Next(5) - 2);

            rsx7 += rsdx7;
            if (rsx7 > panel1.Width - pictureBox10.Width)
            {
                rsx7 = 0;
            } // end if
            if (rsx7 < 0)
            {
                rsx7 = Convert.ToDouble(panel1.Width - pictureBox10.Width);
            } // end if

            rsy7 += rsdy7;
            if (rsy7 > panel1.Height - pictureBox10.Height)
            {
                rsy7 = 0;
            } // end if 
            if (rsy7 < 0)
            {
                rsy7 = Convert.ToDouble(panel1.Height - pictureBox10.Height);
            } // end if

            pictureBox10.Location = new Point(Convert.ToInt32(rsx7), Convert.ToInt32(rsy7));
        }

        private void moveObstacleTen()
        {
            Random roller = new Random();

            rsdx = Convert.ToDouble(roller.Next(5) - 2) / 2;
            rsdy = Convert.ToDouble(roller.Next(5) - 2) / 2;

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

            rsdx3 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy3 = Convert.ToDouble(roller.Next(5) - 2);

            rsx3 += rsdx3;
            if (rsx3 > panel1.Width - pictureBox6.Width)
            {
                rsx3 = 0;
            } // end if
            if (rsx3 < 0)
            {
                rsx3 = Convert.ToDouble(panel1.Width - pictureBox6.Width);
            } // end if

            rsy3 += rsdy3;
            if (rsy3 > panel1.Height - pictureBox6.Height)
            {
                rsy3 = 0;
            } // end if 
            if (rsy3 < 0)
            {
                rsy3 = Convert.ToDouble(panel1.Height - pictureBox6.Height);
            } // end if

            pictureBox6.Location = new Point(Convert.ToInt32(rsx3), Convert.ToInt32(rsy3));

            rsdx4 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy4 = Convert.ToDouble(roller.Next(5) - 2);

            rsx4 += rsdx4;
            if (rsx4 > panel1.Width - pictureBox7.Width)
            {
                rsx4 = 0;
            } // end if
            if (rsx4 < 0)
            {
                rsx4 = Convert.ToDouble(panel1.Width - pictureBox7.Width);
            } // end if

            rsy4 += rsdy4;
            if (rsy4 > panel1.Height - pictureBox7.Height)
            {
                rsy4 = 0;
            } // end if 
            if (rsy4 < 0)
            {
                rsy4 = Convert.ToDouble(panel1.Height - pictureBox7.Height);
            } // end if

            pictureBox7.Location = new Point(Convert.ToInt32(rsx4), Convert.ToInt32(rsy4));

            rsdx5 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy5 = Convert.ToDouble(roller.Next(5) - 2);

            rsx5 += rsdx5;
            if (rsx5 > panel1.Width - pictureBox8.Width)
            {
                rsx5 = 0;
            } // end if
            if (rsx5 < 0)
            {
                rsx5 = Convert.ToDouble(panel1.Width - pictureBox8.Width);
            } // end if

            rsy5 += rsdy5;
            if (rsy5 > panel1.Height - pictureBox8.Height)
            {
                rsy5 = 0;
            } // end if 
            if (rsy5 < 0)
            {
                rsy5 = Convert.ToDouble(panel1.Height - pictureBox8.Height);
            } // end if

            pictureBox8.Location = new Point(Convert.ToInt32(rsx5), Convert.ToInt32(rsy5));

            rsdx6 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy6 = Convert.ToDouble(roller.Next(5) - 2);

            rsx6 += rsdx6;
            if (rsx6 > panel1.Width - pictureBox9.Width)
            {
                rsx6 = 0;
            } // end if
            if (rsx6 < 0)
            {
                rsx6 = Convert.ToDouble(panel1.Width - pictureBox9.Width);
            } // end if

            rsy6 += rsdy6;
            if (rsy6 > panel1.Height - pictureBox9.Height)
            {
                rsy6 = 0;
            } // end if 
            if (rsy6 < 0)
            {
                rsy6 = Convert.ToDouble(panel1.Height - pictureBox9.Height);
            } // end if

            pictureBox9.Location = new Point(Convert.ToInt32(rsx6), Convert.ToInt32(rsy6));

            rsdx7 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy7 = Convert.ToDouble(roller.Next(5) - 2);

            rsx7 += rsdx7;
            if (rsx7 > panel1.Width - pictureBox10.Width)
            {
                rsx7 = 0;
            } // end if
            if (rsx7 < 0)
            {
                rsx7 = Convert.ToDouble(panel1.Width - pictureBox10.Width);
            } // end if

            rsy7 += rsdy7;
            if (rsy7 > panel1.Height - pictureBox10.Height)
            {
                rsy6 = 0;
            } // end if 
            if (rsy7 < 0)
            {
                rsy7 = Convert.ToDouble(panel1.Height - pictureBox10.Height);
            } // end if

            pictureBox10.Location = new Point(Convert.ToInt32(rsx7), Convert.ToInt32(rsy7));

            rsdx8 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy8 = Convert.ToDouble(roller.Next(5) - 2);

            rsx8 += rsdx8;
            if (rsx8 > panel1.Width - pictureBox11.Width)
            {
                rsx8 = 0;
            } // end if
            if (rsx8 < 0)
            {
                rsx8 = Convert.ToDouble(panel1.Width - pictureBox11.Width);
            } // end if

            rsy8 += rsdy8;
            if (rsy8 > panel1.Height - pictureBox11.Height)
            {
                rsy8 = 0;
            } // end if 
            if (rsy8 < 0)
            {
                rsy8 = Convert.ToDouble(panel1.Height - pictureBox11.Height);
            } // end if

            pictureBox11.Location = new Point(Convert.ToInt32(rsx8), Convert.ToInt32(rsy8));

            rsdx9 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy9 = Convert.ToDouble(roller.Next(5) - 2);

            rsx9 += rsdx9;
            if (rsx9 > panel1.Width - pictureBox12.Width)
            {
                rsx9 = 0;
            } // end if
            if (rsx9 < 0)
            {
                rsx9 = Convert.ToDouble(panel1.Width - pictureBox12.Width);
            } // end if

            rsy9 += rsdy9;
            if (rsy9 > panel1.Height - pictureBox12.Height)
            {
                rsy9 = 0;
            } // end if 
            if (rsy9 < 0)
            {
                rsy9 = Convert.ToDouble(panel1.Height - pictureBox12.Height);
            } // end if

            pictureBox12.Location = new Point(Convert.ToInt32(rsx9), Convert.ToInt32(rsy9));
        }

        private void moveObstacleOneWithSpeed()
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

            rsdx3 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy3 = Convert.ToDouble(roller.Next(5) - 2);

            rsx3 += rsdx3;
            if (rsx3 > panel1.Width - pictureBox6.Width)
            {
                rsx3 = 0;
            } // end if
            if (rsx3 < 0)
            {
                rsx3 = Convert.ToDouble(panel1.Width - pictureBox6.Width);
            } // end if

            rsy3 += rsdy3;
            if (rsy3 > panel1.Height - pictureBox6.Height)
            {
                rsy3 = 0;
            } // end if 
            if (rsy3 < 0)
            {
                rsy3 = Convert.ToDouble(panel1.Height - pictureBox6.Height);
            } // end if

            pictureBox6.Location = new Point(Convert.ToInt32(rsx3), Convert.ToInt32(rsy3));

            rsdx4 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy4 = Convert.ToDouble(roller.Next(5) - 2);

            rsx4 += rsdx4;
            if (rsx4 > panel1.Width - pictureBox7.Width)
            {
                rsx4 = 0;
            } // end if
            if (rsx4 < 0)
            {
                rsx4 = Convert.ToDouble(panel1.Width - pictureBox7.Width);
            } // end if

            rsy4 += rsdy4;
            if (rsy4 > panel1.Height - pictureBox7.Height)
            {
                rsy4 = 0;
            } // end if 
            if (rsy4 < 0)
            {
                rsy4 = Convert.ToDouble(panel1.Height - pictureBox7.Height);
            } // end if

            pictureBox7.Location = new Point(Convert.ToInt32(rsx4), Convert.ToInt32(rsy4));

            rsdx5 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy5 = Convert.ToDouble(roller.Next(5) - 2);

            rsx5 += rsdx5;
            if (rsx5 > panel1.Width - pictureBox8.Width)
            {
                rsx5 = 0;
            } // end if
            if (rsx5 < 0)
            {
                rsx5 = Convert.ToDouble(panel1.Width - pictureBox8.Width);
            } // end if

            rsy5 += rsdy5;
            if (rsy5 > panel1.Height - pictureBox8.Height)
            {
                rsy5 = 0;
            } // end if 
            if (rsy5 < 0)
            {
                rsy5 = Convert.ToDouble(panel1.Height - pictureBox8.Height);
            } // end if

            pictureBox8.Location = new Point(Convert.ToInt32(rsx5), Convert.ToInt32(rsy5));

            rsdx6 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy6 = Convert.ToDouble(roller.Next(5) - 2);

            rsx6 += rsdx6;
            if (rsx6 > panel1.Width - pictureBox9.Width)
            {
                rsx6 = 0;
            } // end if
            if (rsx6 < 0)
            {
                rsx6 = Convert.ToDouble(panel1.Width - pictureBox9.Width);
            } // end if

            rsy6 += rsdy6;
            if (rsy6 > panel1.Height - pictureBox9.Height)
            {
                rsy6 = 0;
            } // end if 
            if (rsy6 < 0)
            {
                rsy6 = Convert.ToDouble(panel1.Height - pictureBox9.Height);
            } // end if

            pictureBox9.Location = new Point(Convert.ToInt32(rsx6), Convert.ToInt32(rsy6));

            rsdx7 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy7 = Convert.ToDouble(roller.Next(5) - 2);

            rsx7 += rsdx7;
            if (rsx7 > panel1.Width - pictureBox10.Width)
            {
                rsx7 = 0;
            } // end if
            if (rsx7 < 0)
            {
                rsx7 = Convert.ToDouble(panel1.Width - pictureBox10.Width);
            } // end if

            rsy7 += rsdy7;
            if (rsy7 > panel1.Height - pictureBox10.Height)
            {
                rsy6 = 0;
            } // end if 
            if (rsy7 < 0)
            {
                rsy7 = Convert.ToDouble(panel1.Height - pictureBox10.Height);
            } // end if

            pictureBox10.Location = new Point(Convert.ToInt32(rsx7), Convert.ToInt32(rsy7));

            rsdx8 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy8 = Convert.ToDouble(roller.Next(5) - 2);

            rsx8 += rsdx8;
            if (rsx8 > panel1.Width - pictureBox11.Width)
            {
                rsx8 = 0;
            } // end if
            if (rsx8 < 0)
            {
                rsx8 = Convert.ToDouble(panel1.Width - pictureBox11.Width);
            } // end if

            rsy8 += rsdy8;
            if (rsy8 > panel1.Height - pictureBox11.Height)
            {
                rsy8 = 0;
            } // end if 
            if (rsy8 < 0)
            {
                rsy8 = Convert.ToDouble(panel1.Height - pictureBox11.Height);
            } // end if

            pictureBox11.Location = new Point(Convert.ToInt32(rsx8), Convert.ToInt32(rsy8));

            rsdx9 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy9 = Convert.ToDouble(roller.Next(5) - 2);

            rsx9 += rsdx9;
            if (rsx9 > panel1.Width - pictureBox12.Width)
            {
                rsx9 = 0;
            } // end if
            if (rsx9 < 0)
            {
                rsx9 = Convert.ToDouble(panel1.Width - pictureBox12.Width);
            } // end if

            rsy9 += rsdy9;
            if (rsy9 > panel1.Height - pictureBox12.Height)
            {
                rsy9 = 0;
            } // end if 
            if (rsy9 < 0)
            {
                rsy9 = Convert.ToDouble(panel1.Height - pictureBox12.Height);
            } // end if

            pictureBox12.Location = new Point(Convert.ToInt32(rsx9), Convert.ToInt32(rsy9));
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
            rObstacle = pictureBox3.Bounds;
            //rSpectacle1 = pictureBox4.Bounds;
            //rSpectacle2 = pictureBox5.Bounds;

            if (rLander.IntersectsWith(rObstacle))
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
            rObstacle = pictureBox3.Bounds;
            rObstacle1 = pictureBox4.Bounds;
            //rSpectacle2 = pictureBox5.Bounds;

            if (rLander.IntersectsWith(rObstacle) || rLander.IntersectsWith(rObstacle1))
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
            rObstacle = pictureBox3.Bounds;
            rObstacle1 = pictureBox4.Bounds;
            rObstacle2 = pictureBox5.Bounds;

            if (rLander.IntersectsWith(rObstacle) || rLander.IntersectsWith(rObstacle1) || rLander.IntersectsWith(rObstacle2))
            {
                timer1.Enabled = false;

                MessageBox.Show("Your ship have been collide with unknown objects!");
                killShip();
                initGame();
            } // end if
        }

        private void checkCollideFour()
        {
            rLander = pictureBox1.Bounds;
            rObstacle = pictureBox3.Bounds;
            rObstacle1 = pictureBox4.Bounds;
            rObstacle2 = pictureBox5.Bounds;
            rObstacle3 = pictureBox6.Bounds;

            if (rLander.IntersectsWith(rObstacle) || rLander.IntersectsWith(rObstacle1) || rLander.IntersectsWith(rObstacle2) || rLander.IntersectsWith(rObstacle3))
            {
                timer1.Enabled = false;

                MessageBox.Show("Your ship have been collide with unknown objects!");
                killShip();
                initGame();
            } // end if
        }

        private void checkCollideFive()
        {
            rLander = pictureBox1.Bounds;
            rObstacle = pictureBox3.Bounds;
            rObstacle1 = pictureBox4.Bounds;
            rObstacle2 = pictureBox5.Bounds;
            rObstacle3 = pictureBox6.Bounds;
            rObstacle4 = pictureBox7.Bounds;

            if (rLander.IntersectsWith(rObstacle) || rLander.IntersectsWith(rObstacle1) || rLander.IntersectsWith(rObstacle2) || rLander.IntersectsWith(rObstacle3) || rLander.IntersectsWith(rObstacle4))
            {
                timer1.Enabled = false;

                MessageBox.Show("Your ship have been collide with unknown objects!");
                killShip();
                initGame();
            } // end if
        }

        private void checkCollideSix()
        {
            rLander = pictureBox1.Bounds;
            rObstacle = pictureBox3.Bounds;
            rObstacle1 = pictureBox4.Bounds;
            rObstacle2 = pictureBox5.Bounds;
            rObstacle3 = pictureBox6.Bounds;
            rObstacle4 = pictureBox7.Bounds;
            rObstacle5 = pictureBox8.Bounds;

            if (rLander.IntersectsWith(rObstacle) || rLander.IntersectsWith(rObstacle1) || rLander.IntersectsWith(rObstacle2) || rLander.IntersectsWith(rObstacle3) || rLander.IntersectsWith(rObstacle4) || rLander.IntersectsWith(rObstacle5))
            {
                timer1.Enabled = false;

                MessageBox.Show("Your ship have been collide with unknown objects!");
                killShip();
                initGame();
            } // end if
        }
        
        private void checkCollideSeven()
        {
            rLander = pictureBox1.Bounds;
            rObstacle = pictureBox3.Bounds;
            rObstacle1 = pictureBox4.Bounds;
            rObstacle2 = pictureBox5.Bounds;
            rObstacle3 = pictureBox6.Bounds;
            rObstacle4 = pictureBox7.Bounds;
            rObstacle5 = pictureBox8.Bounds;
            rObstacle6 = pictureBox9.Bounds;

            if (rLander.IntersectsWith(rObstacle) || rLander.IntersectsWith(rObstacle1) || rLander.IntersectsWith(rObstacle2) || rLander.IntersectsWith(rObstacle3) || rLander.IntersectsWith(rObstacle4) || rLander.IntersectsWith(rObstacle5) || rLander.IntersectsWith(rObstacle6))
            {
                timer1.Enabled = false;

                MessageBox.Show("Your ship have been collide with unknown objects!");
                killShip();
                initGame();
            } // end if
        }
        
        private void checkCollideEight()
        {
            rLander = pictureBox1.Bounds;
            rObstacle = pictureBox3.Bounds;
            rObstacle1 = pictureBox4.Bounds;
            rObstacle2 = pictureBox5.Bounds;
            rObstacle3 = pictureBox6.Bounds;
            rObstacle4 = pictureBox7.Bounds;
            rObstacle5 = pictureBox8.Bounds;
            rObstacle6 = pictureBox9.Bounds;
            rObstacle7 = pictureBox10.Bounds;

            if (rLander.IntersectsWith(rObstacle) || rLander.IntersectsWith(rObstacle1) || rLander.IntersectsWith(rObstacle2) || rLander.IntersectsWith(rObstacle3) || rLander.IntersectsWith(rObstacle4) || rLander.IntersectsWith(rObstacle5) || rLander.IntersectsWith(rObstacle6) || rLander.IntersectsWith(rObstacle7))
            {
                timer1.Enabled = false;

                MessageBox.Show("Your ship have been collide with unknown objects!");
                killShip();
                initGame();
            } // end if
        }

        private void checkCollideNine()
        {
            rLander = pictureBox1.Bounds;
            rObstacle = pictureBox3.Bounds;
            rObstacle1 = pictureBox4.Bounds;
            rObstacle2 = pictureBox5.Bounds;
            rObstacle3 = pictureBox6.Bounds;
            rObstacle4 = pictureBox7.Bounds;
            rObstacle5 = pictureBox8.Bounds;
            rObstacle6 = pictureBox9.Bounds;
            rObstacle7 = pictureBox10.Bounds;
            rObstacle8 = pictureBox11.Bounds;

            if (rLander.IntersectsWith(rObstacle) || rLander.IntersectsWith(rObstacle1) || rLander.IntersectsWith(rObstacle2) || rLander.IntersectsWith(rObstacle3) || rLander.IntersectsWith(rObstacle4) || rLander.IntersectsWith(rObstacle5) || rLander.IntersectsWith(rObstacle6) || rLander.IntersectsWith(rObstacle7) || rLander.IntersectsWith(rObstacle8))
            {
                timer1.Enabled = false;

                MessageBox.Show("Your ship have been collide with unknown objects!");
                killShip();
                initGame();
            } // end if
        }

        private void checkCollideTen()
        {
            rLander = pictureBox1.Bounds;
            rObstacle = pictureBox3.Bounds;
            rObstacle1 = pictureBox4.Bounds;
            rObstacle2 = pictureBox5.Bounds;
            rObstacle3 = pictureBox6.Bounds;
            rObstacle4 = pictureBox7.Bounds;
            rObstacle5 = pictureBox8.Bounds;
            rObstacle6 = pictureBox9.Bounds;
            rObstacle7 = pictureBox10.Bounds;
            rObstacle8 = pictureBox11.Bounds;
            rObstacle9 = pictureBox12.Bounds;

            if (rLander.IntersectsWith(rObstacle) || rLander.IntersectsWith(rObstacle1) || rLander.IntersectsWith(rObstacle2) || rLander.IntersectsWith(rObstacle3) || rLander.IntersectsWith(rObstacle4) || rLander.IntersectsWith(rObstacle5) || rLander.IntersectsWith(rObstacle6) || rLander.IntersectsWith(rObstacle7) || rLander.IntersectsWith(rObstacle8) || rLander.IntersectsWith(rObstacle9))
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
                + "Displacement x: " + rsdx2 + " Displacement y: " + rsdy2 + Environment.NewLine
                + "Spetacles4 Location: " + pictureBox6.Location.X + ", " + pictureBox6.Location.Y + Environment.NewLine
                + "Displacement x: " + rsdx3 + " Displacement y: " + rsdy3 + Environment.NewLine
                + "Spetacles5 Location: " + pictureBox7.Location.X + ", " + pictureBox7.Location.Y + Environment.NewLine
                + "Displacement x: " + rsdx4 + " Displacement y: " + rsdy4 + Environment.NewLine
                + "Spetacles6 Location: " + pictureBox8.Location.X + ", " + pictureBox8.Location.Y + Environment.NewLine
                + "Displacement x: " + rsdx5 + " Displacement y: " + rsdy5 + Environment.NewLine
                + "Spetacles7 Location: " + pictureBox9.Location.X + ", " + pictureBox9.Location.Y + Environment.NewLine
                + "Displacement x: " + rsdx6 + " Displacement y: " + rsdy6 + Environment.NewLine
                + "Spetacles8 Location: " + pictureBox10.Location.X + ", " + pictureBox10.Location.Y + Environment.NewLine
                + "Displacement x: " + rsdx7 + " Displacement y: " + rsdy7 + Environment.NewLine
                + "Spetacles9 Location: " + pictureBox11.Location.X + ", " + pictureBox11.Location.Y + Environment.NewLine
                + "Displacement x: " + rsdx8 + " Displacement y: " + rsdy8 + Environment.NewLine
                + "Spetacles10 Location: " + pictureBox12.Location.X + ", " + pictureBox12.Location.Y + Environment.NewLine
                + "Displacement x: " + rsdx9 + " Displacement y: " + rsdy9;
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
            initLunarRover();
            initPLatform();

            switch (level)
            {
                case 1:
                    initLvlOne();
                    break;
                case 2:
                    initLvlTwo();
                    initObstacle1();
                    break;
                case 3:
                    initLvlThree();
                    initObstacle1();
                    initObstacle2();
                    break;
                case 4:
                    initLvlFour();
                    initObstacle1();
                    initObstacle2();
                    initObstacle3();
                    break;
                case 5:
                    initLvlFive();
                    initObstacle1();
                    initObstacle2();
                    initObstacle3();
                    initObstacle4();
                    break;
                case 6:
                    initLvlSix();
                    initObstacle1();
                    initObstacle2();
                    initObstacle3();
                    initObstacle4();
                    initObstacle5();
                    break;
                case 7:
                    initLvlSeven();
                    initObstacle1();
                    initObstacle2();
                    initObstacle3();
                    initObstacle4();
                    initObstacle5();
                    initObstacle6();
                    break;
                case 8:
                    initLvlEight();
                    initObstacle1();
                    initObstacle2();
                    initObstacle3();
                    initObstacle4();
                    initObstacle5();
                    initObstacle6();
                    initObstacle7();
                    break;
                case 9:
                    initLvlNine();
                    initObstacle1();
                    initObstacle2();
                    initObstacle3();
                    initObstacle4();
                    initObstacle5();
                    initObstacle6();
                    initObstacle7();
                    initObstacle8();
                    break;
                case 10:
                    initLvlTen();
                    initObstacle1();
                    initObstacle2();
                    initObstacle3();
                    initObstacle4();
                    initObstacle5();
                    initObstacle6();
                    initObstacle7();
                    initObstacle8();
                    initObstacle9();
                    break;
                case 11:
                    initLvlEleven();
                    initObstacle1();
                    initObstacle2();
                    initObstacle3();
                    initObstacle4();
                    initObstacle5();
                    initObstacle6();
                    initObstacle7();
                    initObstacle8();
                    initObstacle9();
                    initObstacle10();
                    break;
                case 12:
                    initLvlEleven();
                    initObstacle1();
                    initObstacle2();
                    initObstacle3();
                    initObstacle4();
                    initObstacle5();
                    initObstacle6();
                    initObstacle7();
                    initObstacle8();
                    initObstacle9();
                    initObstacle10();
                    break;
                case 13:
                    initLvlEleven();
                    initObstacle1();
                    initObstacle2();
                    initObstacle3();
                    initObstacle4();
                    initObstacle5();
                    initObstacle6();
                    initObstacle7();
                    initObstacle8();
                    initObstacle9();
                    initObstacle10();
                    break;
                case 14:
                    initLvlTwelve();
                    initObstacle1();
                    initObstacle2();
                    initObstacle3();
                    initObstacle4();
                    initObstacle5();
                    initObstacle6();
                    initObstacle7();
                    initObstacle8();
                    initObstacle9();
                    initObstacle10();
                    break;
                case 15:
                    MessageBox.Show("You have complete all the level. Application will now close");
                    Application.Exit();
                    break;
                default:
                    MessageBox.Show("Something have gone wrong. The application will close now.");
                    Application.Exit();
                    break;
            }
            timer1.Enabled = true;
        } // end initGame

        public void initLunarRover()
        {
            pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pictureBox1.Location = new System.Drawing.Point(206, 50);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(20, 22);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            this.panel1.Controls.Add(pictureBox1);
        }

        public void initPLatform()
        {
            pictureBox2.Location = new System.Drawing.Point(206, 103);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(52, 10);
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            pictureBox2.BackgroundImage = imageList1.Images[1];
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel1.Controls.Add(pictureBox2);
        }

        public void initObstacle1()
        {
            pictureBox3.Location = new System.Drawing.Point(370, 50);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new System.Drawing.Size(20, 22);
            pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 10;
            pictureBox3.TabStop = false;
            pictureBox3.BackgroundImage = imageList1.Images[2];
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel1.Controls.Add(pictureBox3);
        }

        public void initObstacle2()
        {
            pictureBox4.Location = new System.Drawing.Point(370, 50);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new System.Drawing.Size(20, 22);
            pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 10;
            pictureBox4.TabStop = false;
            pictureBox4.BackgroundImage = imageList1.Images[3];
            pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel1.Controls.Add(pictureBox4);
        }

        public void initObstacle3()
        {
            pictureBox5.Location = new System.Drawing.Point(370, 50);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new System.Drawing.Size(20, 22);
            pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 10;
            pictureBox5.TabStop = false;
            pictureBox5.BackgroundImage = imageList1.Images[4];
            pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel1.Controls.Add(pictureBox5);
        }

        public void initObstacle4()
        {
            pictureBox6.Location = new System.Drawing.Point(370, 50);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new System.Drawing.Size(20, 22);
            pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 10;
            pictureBox6.TabStop = false;
            pictureBox6.BackgroundImage = imageList1.Images[5];
            pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel1.Controls.Add(pictureBox6);
        }

        public void initObstacle5()
        {
            pictureBox7.Location = new System.Drawing.Point(370, 50);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new System.Drawing.Size(20, 22);
            pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox7.TabIndex = 10;
            pictureBox7.TabStop = false;
            pictureBox7.BackgroundImage = imageList1.Images[6];
            pictureBox7.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel1.Controls.Add(pictureBox7);
        }

        public void initObstacle6()
        {
            pictureBox8.Location = new System.Drawing.Point(370, 50);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new System.Drawing.Size(20, 22);
            pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox8.TabIndex = 10;
            pictureBox8.TabStop = false;
            pictureBox8.BackgroundImage = imageList1.Images[7];
            pictureBox8.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel1.Controls.Add(pictureBox8);
        }

        public void initObstacle7()
        {
            pictureBox9.Location = new System.Drawing.Point(370, 50);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new System.Drawing.Size(20, 22);
            pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox9.TabIndex = 10;
            pictureBox9.TabStop = false;
            pictureBox9.BackgroundImage = imageList1.Images[8];
            pictureBox9.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel1.Controls.Add(pictureBox9);
        }

        public void initObstacle8()
        {
            pictureBox10.Location = new System.Drawing.Point(370, 50);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new System.Drawing.Size(20, 22);
            pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox10.TabIndex = 10;
            pictureBox10.TabStop = false;
            pictureBox10.BackgroundImage = imageList1.Images[9];
            pictureBox10.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel1.Controls.Add(pictureBox10);
        }

        public void initObstacle9()
        {
            pictureBox11.Location = new System.Drawing.Point(370, 50);
            pictureBox11.Name = "pictureBox11";
            pictureBox11.Size = new System.Drawing.Size(20, 22);
            pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox11.TabIndex = 10;
            pictureBox11.TabStop = false;
            pictureBox11.BackgroundImage = imageList1.Images[10];
            pictureBox11.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel1.Controls.Add(pictureBox11);
        }

        public void initObstacle10()
        {
            pictureBox12.Location = new System.Drawing.Point(370, 50);
            pictureBox12.Name = "pictureBox12";
            pictureBox12.Size = new System.Drawing.Size(20, 22);
            pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox12.TabIndex = 10;
            pictureBox12.TabStop = false;
            pictureBox12.BackgroundImage = imageList1.Images[11];
            pictureBox12.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel1.Controls.Add(pictureBox12);
        }
        
        public void initLvlOne()
        {
            Random roller = new Random();
            int platX, platY; // platform location points.

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
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            pictureBox11.Visible = false;
            pictureBox12.Visible = false;
        }

        public void initLvlTwo()
        {
            Random roller = new Random();
            int platX, platY; // platform location points.
            int speX, speY; // obstacle location points.

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
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            pictureBox11.Visible = false;
            pictureBox12.Visible = false;
        }

        public void initLvlThree()
        {
            Random roller = new Random();
            int platX, platY; // platform location points.
            int speX, speY, speX1, speY1; // obstacle location points.

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
            //pictureBox4.BackgroundImage = imageList1.Images[3];
            //pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.Visible = true;
            pictureBox5.Visible = false;
        }

        public void initLvlFour()
        {
            Random roller = new Random();
            int platX, platY; // platform location points.
            int speX, speY, speX1, speY1, speX2, speY2; // obstacle location points.

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
            //pictureBox4.BackgroundImage = imageList1.Images[3];
            //pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.Visible = true;

            rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            rsx2 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox5.Width));
            rsy2 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox5.Height));
            speX2 = roller.Next(panel1.Width - pictureBox5.Width);
            speY2 = roller.Next(panel1.Height - pictureBox5.Height);
            pictureBox5.Location = new Point(speX2, speY2);
            //pictureBox5.BackgroundImage = imageList1.Images[4];
            //pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox5.Visible = true;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            pictureBox11.Visible = false;
            pictureBox12.Visible = false;
        }

        public void initLvlFive()
        {
            Random roller = new Random();
            int platX, platY; // platform location points.
            int speX, speY, speX1, speY1, speX2, speY2, speX3, speY3; // obstacle location points.

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
            //pictureBox4.BackgroundImage = imageList1.Images[3];
            //pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.Visible = true;

            rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            rsx2 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox5.Width));
            rsy2 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox5.Height));
            speX2 = roller.Next(panel1.Width - pictureBox5.Width);
            speY2 = roller.Next(panel1.Height - pictureBox5.Height);
            pictureBox5.Location = new Point(speX2, speY2);
            //pictureBox5.BackgroundImage = imageList1.Images[4];
            //pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox5.Visible = true;

            rsdx3 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy3 = Convert.ToDouble(roller.Next(5) - 2);

            rsx3 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox6.Width));
            rsy3 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox6.Height));
            speX3 = roller.Next(panel1.Width - pictureBox6.Width);
            speY3 = roller.Next(panel1.Height - pictureBox6.Height);
            pictureBox6.Location = new Point(speX3, speY3);
            //pictureBox6.BackgroundImage = imageList1.Images[5];
            //pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox6.Visible = true;

            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            pictureBox11.Visible = false;
            pictureBox12.Visible = false;
        }

        public void initLvlSix()
        {
            Random roller = new Random();
            int platX, platY; // platform location points.
            int speX, speY, speX1, speY1, speX2, speY2, speX3, speY3, speX4, speY4; // obstacle location points.

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
            //pictureBox4.BackgroundImage = imageList1.Images[3];
            //pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.Visible = true;

            rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            rsx2 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox5.Width));
            rsy2 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox5.Height));
            speX2 = roller.Next(panel1.Width - pictureBox5.Width);
            speY2 = roller.Next(panel1.Height - pictureBox5.Height);
            pictureBox5.Location = new Point(speX2, speY2);
            //pictureBox5.BackgroundImage = imageList1.Images[4];
            //pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox5.Visible = true;

            rsdx3 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy3 = Convert.ToDouble(roller.Next(5) - 2);

            rsx3 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox6.Width));
            rsy3 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox6.Height));
            speX3 = roller.Next(panel1.Width - pictureBox6.Width);
            speY3 = roller.Next(panel1.Height - pictureBox6.Height);
            pictureBox6.Location = new Point(speX3, speY3);
            //pictureBox6.BackgroundImage = imageList1.Images[5];
            //pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox6.Visible = true;

            rsdx4 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy4 = Convert.ToDouble(roller.Next(5) - 2);

            rsx4 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox7.Width));
            rsy4 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox7.Height));
            speX4 = roller.Next(panel1.Width - pictureBox7.Width);
            speY4 = roller.Next(panel1.Height - pictureBox7.Height);
            pictureBox7.Location = new Point(speX4, speY4);
            //pictureBox7.BackgroundImage = imageList1.Images[6];
            //pictureBox7.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox7.Visible = true;

            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            pictureBox11.Visible = false;
            pictureBox12.Visible = false;
        }

        public void initLvlSeven()
        {
            Random roller = new Random();
            int platX, platY; // platform location points.
            int speX, speY, speX1, speY1, speX2, speY2, speX3, speY3, speX4, speY4, speX5, speY5; // obstacle location points.

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
            //pictureBox4.BackgroundImage = imageList1.Images[3];
            //pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.Visible = true;

            rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            rsx2 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox5.Width));
            rsy2 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox5.Height));
            speX2 = roller.Next(panel1.Width - pictureBox5.Width);
            speY2 = roller.Next(panel1.Height - pictureBox5.Height);
            pictureBox5.Location = new Point(speX2, speY2);
            //pictureBox5.BackgroundImage = imageList1.Images[4];
            //pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox5.Visible = true;

            rsdx3 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy3 = Convert.ToDouble(roller.Next(5) - 2);

            rsx3 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox6.Width));
            rsy3 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox6.Height));
            speX3 = roller.Next(panel1.Width - pictureBox6.Width);
            speY3 = roller.Next(panel1.Height - pictureBox6.Height);
            pictureBox6.Location = new Point(speX3, speY3);
            //pictureBox6.BackgroundImage = imageList1.Images[5];
            //pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox6.Visible = true;

            rsdx4 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy4 = Convert.ToDouble(roller.Next(5) - 2);

            rsx4 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox7.Width));
            rsy4 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox7.Height));
            speX4 = roller.Next(panel1.Width - pictureBox7.Width);
            speY4 = roller.Next(panel1.Height - pictureBox7.Height);
            pictureBox7.Location = new Point(speX4, speY4);
            //pictureBox7.BackgroundImage = imageList1.Images[6];
            //pictureBox7.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox7.Visible = true;

            rsdx5 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy5 = Convert.ToDouble(roller.Next(5) - 2);

            rsx5 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox8.Width));
            rsy5 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox8.Height));
            speX5 = roller.Next(panel1.Width - pictureBox8.Width);
            speY5 = roller.Next(panel1.Height - pictureBox8.Height);
            pictureBox8.Location = new Point(speX5, speY5);
            //pictureBox8.BackgroundImage = imageList1.Images[7];
            //pictureBox8.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox8.Visible = true;

            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            pictureBox11.Visible = false;
            pictureBox12.Visible = false;
        }

        public void initLvlEight()
        {
            Random roller = new Random();
            int platX, platY; // platform location points.
            int speX, speY, speX1, speY1, speX2, speY2, speX3, speY3, speX4, speY4, speX5, speY5, speX6, speY6; // obstacle location points.

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
            //pictureBox4.BackgroundImage = imageList1.Images[3];
            //pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.Visible = true;

            rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            rsx2 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox5.Width));
            rsy2 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox5.Height));
            speX2 = roller.Next(panel1.Width - pictureBox5.Width);
            speY2 = roller.Next(panel1.Height - pictureBox5.Height);
            pictureBox5.Location = new Point(speX2, speY2);
            //pictureBox5.BackgroundImage = imageList1.Images[4];
            //pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox5.Visible = true;

            rsdx3 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy3 = Convert.ToDouble(roller.Next(5) - 2);

            rsx3 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox6.Width));
            rsy3 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox6.Height));
            speX3 = roller.Next(panel1.Width - pictureBox6.Width);
            speY3 = roller.Next(panel1.Height - pictureBox6.Height);
            pictureBox6.Location = new Point(speX3, speY3);
            //pictureBox6.BackgroundImage = imageList1.Images[5];
            //pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox6.Visible = true;

            rsdx4 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy4 = Convert.ToDouble(roller.Next(5) - 2);

            rsx4 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox7.Width));
            rsy4 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox7.Height));
            speX4 = roller.Next(panel1.Width - pictureBox7.Width);
            speY4 = roller.Next(panel1.Height - pictureBox7.Height);
            pictureBox7.Location = new Point(speX4, speY4);
            //pictureBox7.BackgroundImage = imageList1.Images[6];
            //pictureBox7.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox7.Visible = true;

            rsdx5 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy5 = Convert.ToDouble(roller.Next(5) - 2);

            rsx5 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox8.Width));
            rsy5 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox8.Height));
            speX5 = roller.Next(panel1.Width - pictureBox8.Width);
            speY5 = roller.Next(panel1.Height - pictureBox8.Height);
            pictureBox8.Location = new Point(speX5, speY5);
            //pictureBox8.BackgroundImage = imageList1.Images[7];
            //pictureBox8.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox8.Visible = true;

            rsdx6 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy6 = Convert.ToDouble(roller.Next(5) - 2);

            rsx6 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox9.Width));
            rsy6 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox9.Height));
            speX6 = roller.Next(panel1.Width - pictureBox9.Width);
            speY6 = roller.Next(panel1.Height - pictureBox9.Height);
            pictureBox9.Location = new Point(speX6, speY6);
            //pictureBox9.BackgroundImage = imageList1.Images[8];
            //pictureBox9.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox9.Visible = true;

            pictureBox10.Visible = false;
            pictureBox11.Visible = false;
            pictureBox12.Visible = false;
        }

        public void initLvlNine()
        {
            Random roller = new Random();
            int platX, platY; // platform location points.
            int speX, speY, speX1, speY1, speX2, speY2, speX3, speY3, speX4, speY4, speX5, speY5, speX6, speY6, speX7, speY7; // obstacle location points.

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
            //pictureBox4.BackgroundImage = imageList1.Images[3];
            //pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.Visible = true;

            rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            rsx2 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox5.Width));
            rsy2 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox5.Height));
            speX2 = roller.Next(panel1.Width - pictureBox5.Width);
            speY2 = roller.Next(panel1.Height - pictureBox5.Height);
            pictureBox5.Location = new Point(speX2, speY2);
            //pictureBox5.BackgroundImage = imageList1.Images[4];
            //pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox5.Visible = true;

            rsdx3 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy3 = Convert.ToDouble(roller.Next(5) - 2);

            rsx3 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox6.Width));
            rsy3 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox6.Height));
            speX3 = roller.Next(panel1.Width - pictureBox6.Width);
            speY3 = roller.Next(panel1.Height - pictureBox6.Height);
            pictureBox6.Location = new Point(speX3, speY3);
            //pictureBox6.BackgroundImage = imageList1.Images[5];
            //pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox6.Visible = true;

            rsdx4 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy4 = Convert.ToDouble(roller.Next(5) - 2);

            rsx4 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox7.Width));
            rsy4 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox7.Height));
            speX4 = roller.Next(panel1.Width - pictureBox7.Width);
            speY4 = roller.Next(panel1.Height - pictureBox7.Height);
            pictureBox7.Location = new Point(speX4, speY4);
            //pictureBox7.BackgroundImage = imageList1.Images[6];
            //pictureBox7.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox7.Visible = true;

            rsdx5 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy5 = Convert.ToDouble(roller.Next(5) - 2);

            rsx5 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox8.Width));
            rsy5 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox8.Height));
            speX5 = roller.Next(panel1.Width - pictureBox8.Width);
            speY5 = roller.Next(panel1.Height - pictureBox8.Height);
            pictureBox8.Location = new Point(speX5, speY5);
            //pictureBox8.BackgroundImage = imageList1.Images[7];
            //pictureBox8.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox8.Visible = true;

            rsdx6 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy6 = Convert.ToDouble(roller.Next(5) - 2);

            rsx6 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox9.Width));
            rsy6 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox9.Height));
            speX6 = roller.Next(panel1.Width - pictureBox9.Width);
            speY6 = roller.Next(panel1.Height - pictureBox9.Height);
            pictureBox9.Location = new Point(speX6, speY6);
            //pictureBox9.BackgroundImage = imageList1.Images[8];
            //pictureBox9.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox9.Visible = true;

            rsdx7 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy7 = Convert.ToDouble(roller.Next(5) - 2);

            rsx7 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox10.Width));
            rsy7 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox10.Height));
            speX7 = roller.Next(panel1.Width - pictureBox10.Width);
            speY7 = roller.Next(panel1.Height - pictureBox10.Height);
            pictureBox10.Location = new Point(speX7, speY7);
            //pictureBox10.BackgroundImage = imageList1.Images[9];
            //pictureBox10.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox10.Visible = true;

            pictureBox11.Visible = false;
            pictureBox12.Visible = false;
        }

        public void initLvlTen()
        {
            Random roller = new Random();
            int platX, platY; // platform location points.
            int speX, speY, speX1, speY1, speX2, speY2, speX3, speY3, speX4, speY4, speX5, speY5, speX6, speY6, speX7, speY7, speX8, speY8; // obstacle location points.

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
            //pictureBox4.BackgroundImage = imageList1.Images[3];
            //pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.Visible = true;

            rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            rsx2 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox5.Width));
            rsy2 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox5.Height));
            speX2 = roller.Next(panel1.Width - pictureBox5.Width);
            speY2 = roller.Next(panel1.Height - pictureBox5.Height);
            pictureBox5.Location = new Point(speX2, speY2);
            //pictureBox5.BackgroundImage = imageList1.Images[4];
            //pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox5.Visible = true;

            rsdx3 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy3 = Convert.ToDouble(roller.Next(5) - 2);

            rsx3 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox6.Width));
            rsy3 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox6.Height));
            speX3 = roller.Next(panel1.Width - pictureBox6.Width);
            speY3 = roller.Next(panel1.Height - pictureBox6.Height);
            pictureBox6.Location = new Point(speX3, speY3);
            //pictureBox6.BackgroundImage = imageList1.Images[5];
            //pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox6.Visible = true;

            rsdx4 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy4 = Convert.ToDouble(roller.Next(5) - 2);

            rsx4 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox7.Width));
            rsy4 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox7.Height));
            speX4 = roller.Next(panel1.Width - pictureBox7.Width);
            speY4 = roller.Next(panel1.Height - pictureBox7.Height);
            pictureBox7.Location = new Point(speX4, speY4);
            //pictureBox7.BackgroundImage = imageList1.Images[6];
            //pictureBox7.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox7.Visible = true;

            rsdx5 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy5 = Convert.ToDouble(roller.Next(5) - 2);

            rsx5 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox8.Width));
            rsy5 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox8.Height));
            speX5 = roller.Next(panel1.Width - pictureBox8.Width);
            speY5 = roller.Next(panel1.Height - pictureBox8.Height);
            pictureBox8.Location = new Point(speX5, speY5);
            //pictureBox8.BackgroundImage = imageList1.Images[7];
            //pictureBox8.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox8.Visible = true;

            rsdx6 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy6 = Convert.ToDouble(roller.Next(5) - 2);

            rsx6 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox9.Width));
            rsy6 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox9.Height));
            speX6 = roller.Next(panel1.Width - pictureBox9.Width);
            speY6 = roller.Next(panel1.Height - pictureBox9.Height);
            pictureBox9.Location = new Point(speX6, speY6);
            //pictureBox9.BackgroundImage = imageList1.Images[8];
            //pictureBox9.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox9.Visible = true;

            rsdx7 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy7 = Convert.ToDouble(roller.Next(5) - 2);

            rsx7 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox10.Width));
            rsy7 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox10.Height));
            speX7 = roller.Next(panel1.Width - pictureBox10.Width);
            speY7 = roller.Next(panel1.Height - pictureBox10.Height);
            pictureBox10.Location = new Point(speX7, speY7);
            //pictureBox10.BackgroundImage = imageList1.Images[9];
            //pictureBox10.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox10.Visible = true;

            rsdx8 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy8 = Convert.ToDouble(roller.Next(5) - 2);

            rsx8 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox11.Width));
            rsy8 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox11.Height));
            speX8 = roller.Next(panel1.Width - pictureBox11.Width);
            speY8 = roller.Next(panel1.Height - pictureBox11.Height);
            pictureBox11.Location = new Point(speX8, speY8);
            //pictureBox11.BackgroundImage = imageList1.Images[10];
            //pictureBox11.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox11.Visible = true;

            pictureBox12.Visible = false;
        }

        public void initLvlEleven()
        {
            Random roller = new Random();
            int platX, platY; // platform location points.
            int speX, speY, speX1, speY1, speX2, speY2, speX3, speY3, speX4, speY4, speX5, speY5, speX6, speY6, speX7, speY7, speX8, speY8, speX9, speY9; // obstacle location points.

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
            //pictureBox4.BackgroundImage = imageList1.Images[3];
            //pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.Visible = true;

            rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            rsx2 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox5.Width));
            rsy2 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox5.Height));
            speX2 = roller.Next(panel1.Width - pictureBox5.Width);
            speY2 = roller.Next(panel1.Height - pictureBox5.Height);
            pictureBox5.Location = new Point(speX2, speY2);
            //pictureBox5.BackgroundImage = imageList1.Images[4];
            //pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox5.Visible = true;

            rsdx3 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy3 = Convert.ToDouble(roller.Next(5) - 2);

            rsx3 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox6.Width));
            rsy3 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox6.Height));
            speX3 = roller.Next(panel1.Width - pictureBox6.Width);
            speY3 = roller.Next(panel1.Height - pictureBox6.Height);
            pictureBox6.Location = new Point(speX3, speY3);
            //pictureBox6.BackgroundImage = imageList1.Images[5];
            //pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox6.Visible = true;

            rsdx4 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy4 = Convert.ToDouble(roller.Next(5) - 2);

            rsx4 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox7.Width));
            rsy4 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox7.Height));
            speX4 = roller.Next(panel1.Width - pictureBox7.Width);
            speY4 = roller.Next(panel1.Height - pictureBox7.Height);
            pictureBox7.Location = new Point(speX4, speY4);
            //pictureBox7.BackgroundImage = imageList1.Images[6];
            //pictureBox7.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox7.Visible = true;

            rsdx5 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy5 = Convert.ToDouble(roller.Next(5) - 2);

            rsx5 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox8.Width));
            rsy5 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox8.Height));
            speX5 = roller.Next(panel1.Width - pictureBox8.Width);
            speY5 = roller.Next(panel1.Height - pictureBox8.Height);
            pictureBox8.Location = new Point(speX5, speY5);
            //pictureBox8.BackgroundImage = imageList1.Images[7];
            //pictureBox8.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox8.Visible = true;

            rsdx6 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy6 = Convert.ToDouble(roller.Next(5) - 2);

            rsx6 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox9.Width));
            rsy6 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox9.Height));
            speX6 = roller.Next(panel1.Width - pictureBox9.Width);
            speY6 = roller.Next(panel1.Height - pictureBox9.Height);
            pictureBox9.Location = new Point(speX6, speY6);
            //pictureBox9.BackgroundImage = imageList1.Images[8];
            //pictureBox9.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox9.Visible = true;

            rsdx7 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy7 = Convert.ToDouble(roller.Next(5) - 2);

            rsx7 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox10.Width));
            rsy7 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox10.Height));
            speX7 = roller.Next(panel1.Width - pictureBox10.Width);
            speY7 = roller.Next(panel1.Height - pictureBox10.Height);
            pictureBox10.Location = new Point(speX7, speY7);
            //pictureBox10.BackgroundImage = imageList1.Images[9];
            //pictureBox10.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox10.Visible = true;

            rsdx8 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy8 = Convert.ToDouble(roller.Next(5) - 2);

            rsx8 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox11.Width));
            rsy8 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox11.Height));
            speX8 = roller.Next(panel1.Width - pictureBox11.Width);
            speY8 = roller.Next(panel1.Height - pictureBox11.Height);
            pictureBox11.Location = new Point(speX8, speY8);
            //pictureBox11.BackgroundImage = imageList1.Images[10];
            //pictureBox11.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox11.Visible = true;

            rsdx9 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy9 = Convert.ToDouble(roller.Next(5) - 2);

            rsx9 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox12.Width));
            rsy9 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox12.Height));
            speX9 = roller.Next(panel1.Width - pictureBox12.Width);
            speY9 = roller.Next(panel1.Height - pictureBox12.Height);
            pictureBox12.Location = new Point(speX9, speY9);
            //pictureBox12.BackgroundImage = imageList1.Images[11];
            //pictureBox12.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox12.Visible = true;
        }

        public void initLvlTwelve()
        {
            Random roller = new Random();
            int platX, platY; // platform location points.
            int speX, speY, speX1, speY1, speX2, speY2, speX3, speY3, speX4, speY4, speX5, speY5, speX6, speY6, speX7, speY7, speX8, speY8, speX9, speY9; // obstacle location points.

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
            //pictureBox4.BackgroundImage = imageList1.Images[3];
            //pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.Visible = true;

            rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            rsx2 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox5.Width));
            rsy2 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox5.Height));
            speX2 = roller.Next(panel1.Width - pictureBox5.Width);
            speY2 = roller.Next(panel1.Height - pictureBox5.Height);
            pictureBox5.Location = new Point(speX2, speY2);
            //pictureBox5.BackgroundImage = imageList1.Images[4];
            //pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox5.Visible = true;

            rsdx3 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy3 = Convert.ToDouble(roller.Next(5) - 2);

            rsx3 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox6.Width));
            rsy3 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox6.Height));
            speX3 = roller.Next(panel1.Width - pictureBox6.Width);
            speY3 = roller.Next(panel1.Height - pictureBox6.Height);
            pictureBox6.Location = new Point(speX3, speY3);
            //pictureBox6.BackgroundImage = imageList1.Images[5];
            //pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox6.Visible = true;

            rsdx4 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy4 = Convert.ToDouble(roller.Next(5) - 2);

            rsx4 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox7.Width));
            rsy4 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox7.Height));
            speX4 = roller.Next(panel1.Width - pictureBox7.Width);
            speY4 = roller.Next(panel1.Height - pictureBox7.Height);
            pictureBox7.Location = new Point(speX4, speY4);
            //pictureBox7.BackgroundImage = imageList1.Images[6];
            //pictureBox7.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox7.Visible = true;

            rsdx5 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy5 = Convert.ToDouble(roller.Next(5) - 2);

            rsx5 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox8.Width));
            rsy5 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox8.Height));
            speX5 = roller.Next(panel1.Width - pictureBox8.Width);
            speY5 = roller.Next(panel1.Height - pictureBox8.Height);
            pictureBox8.Location = new Point(speX5, speY5);
            //pictureBox8.BackgroundImage = imageList1.Images[7];
            //pictureBox8.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox8.Visible = true;

            rsdx6 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy6 = Convert.ToDouble(roller.Next(5) - 2);

            rsx6 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox9.Width));
            rsy6 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox9.Height));
            speX6 = roller.Next(panel1.Width - pictureBox9.Width);
            speY6 = roller.Next(panel1.Height - pictureBox9.Height);
            pictureBox9.Location = new Point(speX6, speY6);
            //pictureBox9.BackgroundImage = imageList1.Images[8];
            //pictureBox9.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox9.Visible = true;

            rsdx7 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy7 = Convert.ToDouble(roller.Next(5) - 2);

            rsx7 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox10.Width));
            rsy7 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox10.Height));
            speX7 = roller.Next(panel1.Width - pictureBox10.Width);
            speY7 = roller.Next(panel1.Height - pictureBox10.Height);
            pictureBox10.Location = new Point(speX7, speY7);
            //pictureBox10.BackgroundImage = imageList1.Images[9];
            //pictureBox10.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox10.Visible = true;

            rsdx8 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy8 = Convert.ToDouble(roller.Next(5) - 2);

            rsx8 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox11.Width));
            rsy8 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox11.Height));
            speX8 = roller.Next(panel1.Width - pictureBox11.Width);
            speY8 = roller.Next(panel1.Height - pictureBox11.Height);
            pictureBox11.Location = new Point(speX8, speY8);
            //pictureBox11.BackgroundImage = imageList1.Images[10];
            //pictureBox11.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox11.Visible = true;

            rsdx9 = Convert.ToDouble(roller.Next(5) - 2);
            rsdy9 = Convert.ToDouble(roller.Next(5) - 2);

            rsx9 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox12.Width));
            rsy9 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox12.Height));
            speX9 = roller.Next(panel1.Width - pictureBox12.Width);
            speY9 = roller.Next(panel1.Height - pictureBox12.Height);
            pictureBox12.Location = new Point(speX9, speY9);
            //pictureBox12.BackgroundImage = imageList1.Images[11];
            //pictureBox12.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox12.Visible = true;
        }

        //public void initLvlThirdteen()
        //{
        //    Random roller = new Random();
        //    int platX, platY; // platform location points.
        //    int speX, speY, speX1, speY1, speX2, speY2; // spetacle location points.

        //    dx = Convert.ToDouble(roller.Next(5) - 2);
        //    dy = Convert.ToDouble(roller.Next(5) - 2);

        //    x = Convert.ToDouble(roller.Next(panel1.Width));
        //    y = Convert.ToDouble(roller.Next(panel1.Height));

        //    platX = roller.Next(panel1.Width - pictureBox2.Width);
        //    platY = roller.Next(panel1.Height - pictureBox2.Height);
        //    pictureBox2.Location = new Point(platX, platY);
        //    pictureBox2.Width = 26;

        //    rsdx = Convert.ToDouble(roller.Next(5) - 2);
        //    rsdy = Convert.ToDouble(roller.Next(5) - 2);

        //    rsx = Convert.ToDouble(roller.Next(panel1.Width - pictureBox3.Width));
        //    rsy = Convert.ToDouble(roller.Next(panel1.Height - pictureBox3.Height));
        //    speX = roller.Next(panel1.Width - pictureBox3.Width);
        //    speY = roller.Next(panel1.Height - pictureBox3.Height);
        //    pictureBox3.Location = new Point(speX, speY);
        //    pictureBox3.Visible = true;

        //    rsdx1 = Convert.ToDouble(roller.Next(5) - 2);
        //    rsdy1 = Convert.ToDouble(roller.Next(5) - 2);

        //    rsx1 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox4.Width));
        //    rsy1 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox4.Height));
        //    speX1 = roller.Next(panel1.Width - pictureBox4.Width);
        //    speY1 = roller.Next(panel1.Height - pictureBox4.Height);
        //    pictureBox4.Location = new Point(speX1, speY1);
        //    //pictureBox4.BackgroundImage = imageList1.Images[3];
        //    //pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
        //    pictureBox4.Visible = true;

        //    rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
        //    rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

        //    rsx2 = Convert.ToDouble(roller.Next(panel1.Width - pictureBox5.Width));
        //    rsy2 = Convert.ToDouble(roller.Next(panel1.Height - pictureBox5.Height));
        //    speX2 = roller.Next(panel1.Width - pictureBox5.Width);
        //    speY2 = roller.Next(panel1.Height - pictureBox5.Height);
        //    pictureBox5.Location = new Point(speX2, speY2);
        //    //pictureBox5.BackgroundImage = imageList1.Images[4];
        //    //pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
        //    pictureBox5.Visible = true;
        //    pictureBox6.Visible = false;
        //    pictureBox7.Visible = false;
        //    pictureBox8.Visible = false;
        //    pictureBox9.Visible = false;
        //    pictureBox10.Visible = false;
        //    pictureBox11.Visible = false;
        //    pictureBox12.Visible = false;
        //}
    } // end class
} // end Namespace
