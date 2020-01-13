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
        public Form1()
        {
            InitializeComponent();

            initGame();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GlobalVar.dy += .5;
            if (GlobalVar.level >= 6)
            {
                GlobalVar.dy += 0.5;
            }

            GlobalVar.score += 100;

            // check if addon exist, if not exist create addon
            if (GlobalVar.addOnExist == false)
            {
                createAddOn();
                GlobalVar.addOnExist = true;
            }
            // check addon collide
            if (GlobalVar.addOnItem == 0)
            {
                checkAddOnCollide(GlobalVar.fuelPic);
            }
            else
            {
                checkAddOnCollide(GlobalVar.shipPic);
            }

            // move obstacles
            switch (GlobalVar.level)
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
            // check obstacles collition
            switch (GlobalVar.level)
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

        private void createAddOn()
        {
            Random roller = new Random();
            int fuelOrShip = roller.Next(100);

            // 0 = fuel
            // 1 = ship
            if (fuelOrShip > 2)
            {
                GlobalVar.addOnItem = 0;
                initFuelAddOn();
                moveAddOn(GlobalVar.fuelPic);
            }
            else
            {
                GlobalVar.addOnItem = 1;
                initShipAddOn();
                moveAddOn(GlobalVar.shipPic);
            }
        }
        private void moveAddOn(PictureBox addOnPic)
        {
            Random roller = new Random();

            GlobalVar.aodx = Convert.ToDouble(roller.Next(5) - 2) / 2;
            GlobalVar.aody = Convert.ToDouble(roller.Next(5) - 2) / 2;

            GlobalVar.aox += GlobalVar.aodx;
            if (GlobalVar.aox > panel1.Width - addOnPic.Width)
            {
                GlobalVar.aox = 0;
            } // end if
            if (GlobalVar.aox < 0)
            {
                GlobalVar.aox = Convert.ToDouble(panel1.Width - addOnPic.Width);
            } // end if

            GlobalVar.aoy += GlobalVar.aody;
            if (GlobalVar.aoy > this.Height - addOnPic.Height)
            {
                GlobalVar.aoy = 0;
            } // end if 
            if (GlobalVar.aoy < 0)
            {
                GlobalVar.aoy = Convert.ToDouble(panel1.Height - addOnPic.Height);
            } // end if

            addOnPic.Location = new Point(Convert.ToInt32(GlobalVar.aox), Convert.ToInt32(GlobalVar.aoy));
        }
        private void checkAddOnCollide(PictureBox addOnPic)
        {
            GlobalVar.rLander = GlobalVar.pictureBox1.Bounds;
            if (addOnPic.Name == "fuelPic")
            {
                GlobalVar.rFuelAddOn = addOnPic.Bounds;

                if (GlobalVar.rLander.IntersectsWith(GlobalVar.rFuelAddOn))
                {
                    GlobalVar.GetPlayerSound("Addon.wav");
                    GlobalVar.player.Play();
                    this.panel1.Controls.Remove(addOnPic);
                    GlobalVar.fuel += 1000;
                    GlobalVar.addOnExist = false;
                    //GlobalVar.player.Stop();
                } // end if
            }
            else
            {
                GlobalVar.rShipAddOn = addOnPic.Bounds;

                if (GlobalVar.rLander.IntersectsWith(GlobalVar.rShipAddOn))
                {
                    GlobalVar.GetPlayerSound("Addon.wav");
                    GlobalVar.player.Play();
                    this.panel1.Controls.Remove(addOnPic);
                    GlobalVar.ships += 1;
                    GlobalVar.addOnExist = false;
                    //GlobalVar.player.Stop();
                } // end if
            }
        }

        private void moveObstacleOne()
        {
            Random roller = new Random();

            GlobalVar.rsdx = Convert.ToDouble(roller.Next(5) - 2) / 2;
            GlobalVar.rsdy = Convert.ToDouble(roller.Next(5) - 2) / 2;

            GlobalVar.rsx += GlobalVar.rsdx;
            if (GlobalVar.rsx > panel1.Width - GlobalVar.pictureBox3.Width)
            {
                GlobalVar.rsx = 0;
            } // end if
            if (GlobalVar.rsx < 0)
            {
                GlobalVar.rsx = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox3.Width);
            } // end if

            GlobalVar.rsy += GlobalVar.rsdy;
            if (GlobalVar.rsy > this.Height - GlobalVar.pictureBox3.Height)
            {
                GlobalVar.rsy = 0;
            } // end if 
            if (GlobalVar.rsy < 0)
            {
                GlobalVar.rsy = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox3.Height);
            } // end if

            GlobalVar.pictureBox3.Location = new Point(Convert.ToInt32(GlobalVar.rsx), Convert.ToInt32(GlobalVar.rsy));
        }
        private void moveObstacleTwo()
        {
            Random roller = new Random();

            GlobalVar.rsdx = Convert.ToDouble(roller.Next(5) - 2) / 2;
            GlobalVar.rsdy = Convert.ToDouble(roller.Next(5) - 2) / 2;

            GlobalVar.rsx += GlobalVar.rsdx;
            if (GlobalVar.rsx > panel1.Width - GlobalVar.pictureBox3.Width)
            {
                GlobalVar.rsx = 0;
            } // end if
            if (GlobalVar.rsx < 0)
            {
                GlobalVar.rsx = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox3.Width);
            } // end if

            GlobalVar.rsy += GlobalVar.rsdy;
            if (GlobalVar.rsy > this.Height - GlobalVar.pictureBox3.Height)
            {
                GlobalVar.rsy = 0;
            } // end if 
            if (GlobalVar.rsy < 0)
            {
                GlobalVar.rsy = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox3.Height);
            } // end if

            GlobalVar.pictureBox3.Location = new Point(Convert.ToInt32(GlobalVar.rsx), Convert.ToInt32(GlobalVar.rsy));

            GlobalVar.rsdx1 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy1 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx1 += GlobalVar.rsdx1;
            if (GlobalVar.rsx1 > panel1.Width - GlobalVar.pictureBox4.Width)
            {
                GlobalVar.rsx1 = 0;
            } // end if
            if (GlobalVar.rsx1 < 0)
            {
                GlobalVar.rsx1 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox4.Width);
            } // end if

            GlobalVar.rsy1 += GlobalVar.rsdy1;
            if (GlobalVar.rsy1 > panel1.Height - GlobalVar.pictureBox4.Height)
            {
                GlobalVar.rsy1 = 0;
            } // end if 
            if (GlobalVar.rsy1 < 0)
            {
                GlobalVar.rsy1 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox4.Height);
            } // end if

            GlobalVar.pictureBox4.Location = new Point(Convert.ToInt32(GlobalVar.rsx1), Convert.ToInt32(GlobalVar.rsy1));
        }
        private void moveObstacleThree()
        {
            Random roller = new Random();

            GlobalVar.rsdx = Convert.ToDouble(roller.Next(5) - 2) / 2;
            GlobalVar.rsdy = Convert.ToDouble(roller.Next(5) - 2) / 2;

            GlobalVar.rsx += GlobalVar.rsdx;
            if (GlobalVar.rsx > panel1.Width - GlobalVar.pictureBox3.Width)
            {
                GlobalVar.rsx = 0;
            } // end if
            if (GlobalVar.rsx < 0)
            {
                GlobalVar.rsx = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox3.Width);
            } // end if

            GlobalVar.rsy += GlobalVar.rsdy;
            if (GlobalVar.rsy > this.Height - GlobalVar.pictureBox3.Height)
            {
                GlobalVar.rsy = 0;
            } // end if 
            if (GlobalVar.rsy < 0)
            {
                GlobalVar.rsy = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox3.Height);
            } // end if

            GlobalVar.pictureBox3.Location = new Point(Convert.ToInt32(GlobalVar.rsx), Convert.ToInt32(GlobalVar.rsy));

            GlobalVar.rsdx1 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy1 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx1 += GlobalVar.rsdx1;
            if (GlobalVar.rsx1 > panel1.Width - GlobalVar.pictureBox4.Width)
            {
                GlobalVar.rsx1 = 0;
            } // end if
            if (GlobalVar.rsx1 < 0)
            {
                GlobalVar.rsx1 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox4.Width);
            } // end if

            GlobalVar.rsy1 += GlobalVar.rsdy1;
            if (GlobalVar.rsy1 > panel1.Height - GlobalVar.pictureBox4.Height)
            {
                GlobalVar.rsy1 = 0;
            } // end if 
            if (GlobalVar.rsy1 < 0)
            {
                GlobalVar.rsy1 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox4.Height);
            } // end if

            GlobalVar.pictureBox4.Location = new Point(Convert.ToInt32(GlobalVar.rsx1), Convert.ToInt32(GlobalVar.rsy1));

            GlobalVar.rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx2 += GlobalVar.rsdx2;
            if (GlobalVar.rsx2 > panel1.Width - GlobalVar.pictureBox5.Width)
            {
                GlobalVar.rsx2 = 0;
            } // end if
            if (GlobalVar.rsx2 < 0)
            {
                GlobalVar.rsx2 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox5.Width);
            } // end if

            GlobalVar.rsy2 += GlobalVar.rsdy2;
            if (GlobalVar.rsy2 > panel1.Height - GlobalVar.pictureBox5.Height)
            {
                GlobalVar.rsy2 = 0;
            } // end if 
            if (GlobalVar.rsy2 < 0)
            {
                GlobalVar.rsy2 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox5.Height);
            } // end if

            GlobalVar.pictureBox5.Location = new Point(Convert.ToInt32(GlobalVar.rsx2), Convert.ToInt32(GlobalVar.rsy2));
        }
        private void moveObstacleFour()
        {
            Random roller = new Random();

            GlobalVar.rsdx = Convert.ToDouble(roller.Next(5) - 2) / 2;
            GlobalVar.rsdy = Convert.ToDouble(roller.Next(5) - 2) / 2;

            GlobalVar.rsx += GlobalVar.rsdx;
            if (GlobalVar.rsx > panel1.Width - GlobalVar.pictureBox3.Width)
            {
                GlobalVar.rsx = 0;
            } // end if
            if (GlobalVar.rsx < 0)
            {
                GlobalVar.rsx = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox3.Width);
            } // end if

            GlobalVar.rsy += GlobalVar.rsdy;
            if (GlobalVar.rsy > this.Height - GlobalVar.pictureBox3.Height)
            {
                GlobalVar.rsy = 0;
            } // end if 
            if (GlobalVar.rsy < 0)
            {
                GlobalVar.rsy = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox3.Height);
            } // end if

            GlobalVar.pictureBox3.Location = new Point(Convert.ToInt32(GlobalVar.rsx), Convert.ToInt32(GlobalVar.rsy));

            GlobalVar.rsdx1 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy1 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx1 += GlobalVar.rsdx1;
            if (GlobalVar.rsx1 > panel1.Width - GlobalVar.pictureBox4.Width)
            {
                GlobalVar.rsx1 = 0;
            } // end if
            if (GlobalVar.rsx1 < 0)
            {
                GlobalVar.rsx1 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox4.Width);
            } // end if

            GlobalVar.rsy1 += GlobalVar.rsdy1;
            if (GlobalVar.rsy1 > panel1.Height - GlobalVar.pictureBox4.Height)
            {
                GlobalVar.rsy1 = 0;
            } // end if 
            if (GlobalVar.rsy1 < 0)
            {
                GlobalVar.rsy1 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox4.Height);
            } // end if

            GlobalVar.pictureBox4.Location = new Point(Convert.ToInt32(GlobalVar.rsx1), Convert.ToInt32(GlobalVar.rsy1));

            GlobalVar.rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx2 += GlobalVar.rsdx2;
            if (GlobalVar.rsx2 > panel1.Width - GlobalVar.pictureBox5.Width)
            {
                GlobalVar.rsx2 = 0;
            } // end if
            if (GlobalVar.rsx2 < 0)
            {
                GlobalVar.rsx2 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox5.Width);
            } // end if

            GlobalVar.rsy2 += GlobalVar.rsdy2;
            if (GlobalVar.rsy2 > panel1.Height - GlobalVar.pictureBox5.Height)
            {
                GlobalVar.rsy2 = 0;
            } // end if 
            if (GlobalVar.rsy2 < 0)
            {
                GlobalVar.rsy2 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox5.Height);
            } // end if

            GlobalVar.pictureBox5.Location = new Point(Convert.ToInt32(GlobalVar.rsx2), Convert.ToInt32(GlobalVar.rsy2));

            GlobalVar.rsdx3 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy3 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx3 += GlobalVar.rsdx3;
            if (GlobalVar.rsx3 > panel1.Width - GlobalVar.pictureBox6.Width)
            {
                GlobalVar.rsx3 = 0;
            } // end if
            if (GlobalVar.rsx3 < 0)
            {
                GlobalVar.rsx3 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox6.Width);
            } // end if

            GlobalVar.rsy3 += GlobalVar.rsdy3;
            if (GlobalVar.rsy3 > panel1.Height - GlobalVar.pictureBox6.Height)
            {
                GlobalVar.rsy3 = 0;
            } // end if 
            if (GlobalVar.rsy3 < 0)
            {
                GlobalVar.rsy3 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox6.Height);
            } // end if

            GlobalVar.pictureBox6.Location = new Point(Convert.ToInt32(GlobalVar.rsx3), Convert.ToInt32(GlobalVar.rsy3));
        }
        private void moveObstacleFive()
        {
            Random roller = new Random();

            GlobalVar.rsdx = Convert.ToDouble(roller.Next(5) - 2) / 2;
            GlobalVar.rsdy = Convert.ToDouble(roller.Next(5) - 2) / 2;

            GlobalVar.rsx += GlobalVar.rsdx;
            if (GlobalVar.rsx > panel1.Width - GlobalVar.pictureBox3.Width)
            {
                GlobalVar.rsx = 0;
            } // end if
            if (GlobalVar.rsx < 0)
            {
                GlobalVar.rsx = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox3.Width);
            } // end if

            GlobalVar.rsy += GlobalVar.rsdy;
            if (GlobalVar.rsy > this.Height - GlobalVar.pictureBox3.Height)
            {
                GlobalVar.rsy = 0;
            } // end if 
            if (GlobalVar.rsy < 0)
            {
                GlobalVar.rsy = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox3.Height);
            } // end if

            GlobalVar.pictureBox3.Location = new Point(Convert.ToInt32(GlobalVar.rsx), Convert.ToInt32(GlobalVar.rsy));

            GlobalVar.rsdx1 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy1 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx1 += GlobalVar.rsdx1;
            if (GlobalVar.rsx1 > panel1.Width - GlobalVar.pictureBox4.Width)
            {
                GlobalVar.rsx1 = 0;
            } // end if
            if (GlobalVar.rsx1 < 0)
            {
                GlobalVar.rsx1 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox4.Width);
            } // end if

            GlobalVar.rsy1 += GlobalVar.rsdy1;
            if (GlobalVar.rsy1 > panel1.Height - GlobalVar.pictureBox4.Height)
            {
                GlobalVar.rsy1 = 0;
            } // end if 
            if (GlobalVar.rsy1 < 0)
            {
                GlobalVar.rsy1 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox4.Height);
            } // end if

            GlobalVar.pictureBox4.Location = new Point(Convert.ToInt32(GlobalVar.rsx1), Convert.ToInt32(GlobalVar.rsy1));

            GlobalVar.rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx2 += GlobalVar.rsdx2;
            if (GlobalVar.rsx2 > panel1.Width - GlobalVar.pictureBox5.Width)
            {
                GlobalVar.rsx2 = 0;
            } // end if
            if (GlobalVar.rsx2 < 0)
            {
                GlobalVar.rsx2 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox5.Width);
            } // end if

            GlobalVar.rsy2 += GlobalVar.rsdy2;
            if (GlobalVar.rsy2 > panel1.Height - GlobalVar.pictureBox5.Height)
            {
                GlobalVar.rsy2 = 0;
            } // end if 
            if (GlobalVar.rsy2 < 0)
            {
                GlobalVar.rsy2 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox5.Height);
            } // end if

            GlobalVar.pictureBox5.Location = new Point(Convert.ToInt32(GlobalVar.rsx2), Convert.ToInt32(GlobalVar.rsy2));

            GlobalVar.rsdx3 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy3 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx3 += GlobalVar.rsdx3;
            if (GlobalVar.rsx3 > panel1.Width - GlobalVar.pictureBox6.Width)
            {
                GlobalVar.rsx3 = 0;
            } // end if
            if (GlobalVar.rsx3 < 0)
            {
                GlobalVar.rsx3 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox6.Width);
            } // end if

            GlobalVar.rsy3 += GlobalVar.rsdy3;
            if (GlobalVar.rsy3 > panel1.Height - GlobalVar.pictureBox6.Height)
            {
                GlobalVar.rsy3 = 0;
            } // end if 
            if (GlobalVar.rsy3 < 0)
            {
                GlobalVar.rsy3 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox6.Height);
            } // end if

            GlobalVar.pictureBox6.Location = new Point(Convert.ToInt32(GlobalVar.rsx3), Convert.ToInt32(GlobalVar.rsy3));

            GlobalVar.rsdx4 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy4 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx4 += GlobalVar.rsdx4;
            if (GlobalVar.rsx4 > panel1.Width - GlobalVar.pictureBox7.Width)
            {
                GlobalVar.rsx4 = 0;
            } // end if
            if (GlobalVar.rsx4 < 0)
            {
                GlobalVar.rsx4 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox7.Width);
            } // end if

            GlobalVar.rsy4 += GlobalVar.rsdy4;
            if (GlobalVar.rsy4 > panel1.Height - GlobalVar.pictureBox7.Height)
            {
                GlobalVar.rsy4 = 0;
            } // end if 
            if (GlobalVar.rsy4 < 0)
            {
                GlobalVar.rsy4 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox7.Height);
            } // end if

            GlobalVar.pictureBox7.Location = new Point(Convert.ToInt32(GlobalVar.rsx4), Convert.ToInt32(GlobalVar.rsy4));
        }
        private void moveObstacleSix()
        {
            Random roller = new Random();

            GlobalVar.rsdx = Convert.ToDouble(roller.Next(5) - 2) / 2;
            GlobalVar.rsdy = Convert.ToDouble(roller.Next(5) - 2) / 2;

            GlobalVar.rsx += GlobalVar.rsdx;
            if (GlobalVar.rsx > panel1.Width - GlobalVar.pictureBox3.Width)
            {
                GlobalVar.rsx = 0;
            } // end if
            if (GlobalVar.rsx < 0)
            {
                GlobalVar.rsx = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox3.Width);
            } // end if

            GlobalVar.rsy += GlobalVar.rsdy;
            if (GlobalVar.rsy > this.Height - GlobalVar.pictureBox3.Height)
            {
                GlobalVar.rsy = 0;
            } // end if 
            if (GlobalVar.rsy < 0)
            {
                GlobalVar.rsy = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox3.Height);
            } // end if

            GlobalVar.pictureBox3.Location = new Point(Convert.ToInt32(GlobalVar.rsx), Convert.ToInt32(GlobalVar.rsy));

            GlobalVar.rsdx1 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy1 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx1 += GlobalVar.rsdx1;
            if (GlobalVar.rsx1 > panel1.Width - GlobalVar.pictureBox4.Width)
            {
                GlobalVar.rsx1 = 0;
            } // end if
            if (GlobalVar.rsx1 < 0)
            {
                GlobalVar.rsx1 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox4.Width);
            } // end if

            GlobalVar.rsy1 += GlobalVar.rsdy1;
            if (GlobalVar.rsy1 > panel1.Height - GlobalVar.pictureBox4.Height)
            {
                GlobalVar.rsy1 = 0;
            } // end if 
            if (GlobalVar.rsy1 < 0)
            {
                GlobalVar.rsy1 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox4.Height);
            } // end if

            GlobalVar.pictureBox4.Location = new Point(Convert.ToInt32(GlobalVar.rsx1), Convert.ToInt32(GlobalVar.rsy1));

            GlobalVar.rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx2 += GlobalVar.rsdx2;
            if (GlobalVar.rsx2 > panel1.Width - GlobalVar.pictureBox5.Width)
            {
                GlobalVar.rsx2 = 0;
            } // end if
            if (GlobalVar.rsx2 < 0)
            {
                GlobalVar.rsx2 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox5.Width);
            } // end if

            GlobalVar.rsy2 += GlobalVar.rsdy2;
            if (GlobalVar.rsy2 > panel1.Height - GlobalVar.pictureBox5.Height)
            {
                GlobalVar.rsy2 = 0;
            } // end if 
            if (GlobalVar.rsy2 < 0)
            {
                GlobalVar.rsy2 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox5.Height);
            } // end if

            GlobalVar.pictureBox5.Location = new Point(Convert.ToInt32(GlobalVar.rsx2), Convert.ToInt32(GlobalVar.rsy2));

            GlobalVar.rsdx3 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy3 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx3 += GlobalVar.rsdx3;
            if (GlobalVar.rsx3 > panel1.Width - GlobalVar.pictureBox6.Width)
            {
                GlobalVar.rsx3 = 0;
            } // end if
            if (GlobalVar.rsx3 < 0)
            {
                GlobalVar.rsx3 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox6.Width);
            } // end if

            GlobalVar.rsy3 += GlobalVar.rsdy3;
            if (GlobalVar.rsy3 > panel1.Height - GlobalVar.pictureBox6.Height)
            {
                GlobalVar.rsy3 = 0;
            } // end if 
            if (GlobalVar.rsy3 < 0)
            {
                GlobalVar.rsy3 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox6.Height);
            } // end if

            GlobalVar.pictureBox6.Location = new Point(Convert.ToInt32(GlobalVar.rsx3), Convert.ToInt32(GlobalVar.rsy3));

            GlobalVar.rsdx4 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy4 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx4 += GlobalVar.rsdx4;
            if (GlobalVar.rsx4 > panel1.Width - GlobalVar.pictureBox7.Width)
            {
                GlobalVar.rsx4 = 0;
            } // end if
            if (GlobalVar.rsx4 < 0)
            {
                GlobalVar.rsx4 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox7.Width);
            } // end if

            GlobalVar.rsy4 += GlobalVar.rsdy4;
            if (GlobalVar.rsy4 > panel1.Height - GlobalVar.pictureBox7.Height)
            {
                GlobalVar.rsy4 = 0;
            } // end if 
            if (GlobalVar.rsy4 < 0)
            {
                GlobalVar.rsy4 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox7.Height);
            } // end if

            GlobalVar.pictureBox7.Location = new Point(Convert.ToInt32(GlobalVar.rsx4), Convert.ToInt32(GlobalVar.rsy4));

            GlobalVar.rsdx5 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy5 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx5 += GlobalVar.rsdx5;
            if (GlobalVar.rsx5 > panel1.Width - GlobalVar.pictureBox8.Width)
            {
                GlobalVar.rsx5 = 0;
            } // end if
            if (GlobalVar.rsx5 < 0)
            {
                GlobalVar.rsx5 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox8.Width);
            } // end if

            GlobalVar.rsy5 += GlobalVar.rsdy5;
            if (GlobalVar.rsy5 > panel1.Height - GlobalVar.pictureBox8.Height)
            {
                GlobalVar.rsy5 = 0;
            } // end if 
            if (GlobalVar.rsy5 < 0)
            {
                GlobalVar.rsy5 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox8.Height);
            } // end if

            GlobalVar.pictureBox8.Location = new Point(Convert.ToInt32(GlobalVar.rsx5), Convert.ToInt32(GlobalVar.rsy5));
        }
        private void moveObstacleSeven()
        {
            Random roller = new Random();

            GlobalVar.rsdx = Convert.ToDouble(roller.Next(5) - 2) / 2;
            GlobalVar.rsdy = Convert.ToDouble(roller.Next(5) - 2) / 2;

            GlobalVar.rsx += GlobalVar.rsdx;
            if (GlobalVar.rsx > panel1.Width - GlobalVar.pictureBox3.Width)
            {
                GlobalVar.rsx = 0;
            } // end if
            if (GlobalVar.rsx < 0)
            {
                GlobalVar.rsx = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox3.Width);
            } // end if

            GlobalVar.rsy += GlobalVar.rsdy;
            if (GlobalVar.rsy > this.Height - GlobalVar.pictureBox3.Height)
            {
                GlobalVar.rsy = 0;
            } // end if 
            if (GlobalVar.rsy < 0)
            {
                GlobalVar.rsy = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox3.Height);
            } // end if

            GlobalVar.pictureBox3.Location = new Point(Convert.ToInt32(GlobalVar.rsx), Convert.ToInt32(GlobalVar.rsy));

            GlobalVar.rsdx1 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy1 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx1 += GlobalVar.rsdx1;
            if (GlobalVar.rsx1 > panel1.Width - GlobalVar.pictureBox4.Width)
            {
                GlobalVar.rsx1 = 0;
            } // end if
            if (GlobalVar.rsx1 < 0)
            {
                GlobalVar.rsx1 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox4.Width);
            } // end if

            GlobalVar.rsy1 += GlobalVar.rsdy1;
            if (GlobalVar.rsy1 > panel1.Height - GlobalVar.pictureBox4.Height)
            {
                GlobalVar.rsy1 = 0;
            } // end if 
            if (GlobalVar.rsy1 < 0)
            {
                GlobalVar.rsy1 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox4.Height);
            } // end if

            GlobalVar.pictureBox4.Location = new Point(Convert.ToInt32(GlobalVar.rsx1), Convert.ToInt32(GlobalVar.rsy1));

            GlobalVar.rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx2 += GlobalVar.rsdx2;
            if (GlobalVar.rsx2 > panel1.Width - GlobalVar.pictureBox5.Width)
            {
                GlobalVar.rsx2 = 0;
            } // end if
            if (GlobalVar.rsx2 < 0)
            {
                GlobalVar.rsx2 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox5.Width);
            } // end if

            GlobalVar.rsy2 += GlobalVar.rsdy2;
            if (GlobalVar.rsy2 > panel1.Height - GlobalVar.pictureBox5.Height)
            {
                GlobalVar.rsy2 = 0;
            } // end if 
            if (GlobalVar.rsy2 < 0)
            {
                GlobalVar.rsy2 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox5.Height);
            } // end if

            GlobalVar.pictureBox5.Location = new Point(Convert.ToInt32(GlobalVar.rsx2), Convert.ToInt32(GlobalVar.rsy2));

            GlobalVar.rsdx3 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy3 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx3 += GlobalVar.rsdx3;
            if (GlobalVar.rsx3 > panel1.Width - GlobalVar.pictureBox6.Width)
            {
                GlobalVar.rsx3 = 0;
            } // end if
            if (GlobalVar.rsx3 < 0)
            {
                GlobalVar.rsx3 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox6.Width);
            } // end if

            GlobalVar.rsy3 += GlobalVar.rsdy3;
            if (GlobalVar.rsy3 > panel1.Height - GlobalVar.pictureBox6.Height)
            {
                GlobalVar.rsy3 = 0;
            } // end if 
            if (GlobalVar.rsy3 < 0)
            {
                GlobalVar.rsy3 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox6.Height);
            } // end if

            GlobalVar.pictureBox6.Location = new Point(Convert.ToInt32(GlobalVar.rsx3), Convert.ToInt32(GlobalVar.rsy3));

            GlobalVar.rsdx4 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy4 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx4 += GlobalVar.rsdx4;
            if (GlobalVar.rsx4 > panel1.Width - GlobalVar.pictureBox7.Width)
            {
                GlobalVar.rsx4 = 0;
            } // end if
            if (GlobalVar.rsx4 < 0)
            {
                GlobalVar.rsx4 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox7.Width);
            } // end if

            GlobalVar.rsy4 += GlobalVar.rsdy4;
            if (GlobalVar.rsy4 > panel1.Height - GlobalVar.pictureBox7.Height)
            {
                GlobalVar.rsy4 = 0;
            } // end if 
            if (GlobalVar.rsy4 < 0)
            {
                GlobalVar.rsy4 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox7.Height);
            } // end if

            GlobalVar.pictureBox7.Location = new Point(Convert.ToInt32(GlobalVar.rsx4), Convert.ToInt32(GlobalVar.rsy4));

            GlobalVar.rsdx5 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy5 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx5 += GlobalVar.rsdx5;
            if (GlobalVar.rsx5 > panel1.Width - GlobalVar.pictureBox8.Width)
            {
                GlobalVar.rsx5 = 0;
            } // end if
            if (GlobalVar.rsx5 < 0)
            {
                GlobalVar.rsx5 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox8.Width);
            } // end if

            GlobalVar.rsy5 += GlobalVar.rsdy5;
            if (GlobalVar.rsy5 > panel1.Height - GlobalVar.pictureBox8.Height)
            {
                GlobalVar.rsy5 = 0;
            } // end if 
            if (GlobalVar.rsy5 < 0)
            {
                GlobalVar.rsy5 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox8.Height);
            } // end if

            GlobalVar.pictureBox8.Location = new Point(Convert.ToInt32(GlobalVar.rsx5), Convert.ToInt32(GlobalVar.rsy5));

            GlobalVar.rsdx6 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy6 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx6 += GlobalVar.rsdx6;
            if (GlobalVar.rsx6 > panel1.Width - GlobalVar.pictureBox9.Width)
            {
                GlobalVar.rsx6 = 0;
            } // end if
            if (GlobalVar.rsx6 < 0)
            {
                GlobalVar.rsx6 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox9.Width);
            } // end if

            GlobalVar.rsy6 += GlobalVar.rsdy6;
            if (GlobalVar.rsy6 > panel1.Height - GlobalVar.pictureBox9.Height)
            {
                GlobalVar.rsy6 = 0;
            } // end if 
            if (GlobalVar.rsy6 < 0)
            {
                GlobalVar.rsy6 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox9.Height);
            } // end if

            GlobalVar.pictureBox9.Location = new Point(Convert.ToInt32(GlobalVar.rsx6), Convert.ToInt32(GlobalVar.rsy6));
        }
        private void moveObstacleEight()
        {
            Random roller = new Random();

            GlobalVar.rsdx = Convert.ToDouble(roller.Next(5) - 2) / 2;
            GlobalVar.rsdy = Convert.ToDouble(roller.Next(5) - 2) / 2;

            GlobalVar.rsx += GlobalVar.rsdx;
            if (GlobalVar.rsx > panel1.Width - GlobalVar.pictureBox3.Width)
            {
                GlobalVar.rsx = 0;
            } // end if
            if (GlobalVar.rsx < 0)
            {
                GlobalVar.rsx = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox3.Width);
            } // end if

            GlobalVar.rsy += GlobalVar.rsdy;
            if (GlobalVar.rsy > this.Height - GlobalVar.pictureBox3.Height)
            {
                GlobalVar.rsy = 0;
            } // end if 
            if (GlobalVar.rsy < 0)
            {
                GlobalVar.rsy = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox3.Height);
            } // end if

            GlobalVar.pictureBox3.Location = new Point(Convert.ToInt32(GlobalVar.rsx), Convert.ToInt32(GlobalVar.rsy));

            GlobalVar.rsdx1 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy1 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx1 += GlobalVar.rsdx1;
            if (GlobalVar.rsx1 > panel1.Width - GlobalVar.pictureBox4.Width)
            {
                GlobalVar.rsx1 = 0;
            } // end if
            if (GlobalVar.rsx1 < 0)
            {
                GlobalVar.rsx1 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox4.Width);
            } // end if

            GlobalVar.rsy1 += GlobalVar.rsdy1;
            if (GlobalVar.rsy1 > panel1.Height - GlobalVar.pictureBox4.Height)
            {
                GlobalVar.rsy1 = 0;
            } // end if 
            if (GlobalVar.rsy1 < 0)
            {
                GlobalVar.rsy1 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox4.Height);
            } // end if

            GlobalVar.pictureBox4.Location = new Point(Convert.ToInt32(GlobalVar.rsx1), Convert.ToInt32(GlobalVar.rsy1));

            GlobalVar.rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx2 += GlobalVar.rsdx2;
            if (GlobalVar.rsx2 > panel1.Width - GlobalVar.pictureBox5.Width)
            {
                GlobalVar.rsx2 = 0;
            } // end if
            if (GlobalVar.rsx2 < 0)
            {
                GlobalVar.rsx2 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox5.Width);
            } // end if

            GlobalVar.rsy2 += GlobalVar.rsdy2;
            if (GlobalVar.rsy2 > panel1.Height - GlobalVar.pictureBox5.Height)
            {
                GlobalVar.rsy2 = 0;
            } // end if 
            if (GlobalVar.rsy2 < 0)
            {
                GlobalVar.rsy2 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox5.Height);
            } // end if

            GlobalVar.pictureBox5.Location = new Point(Convert.ToInt32(GlobalVar.rsx2), Convert.ToInt32(GlobalVar.rsy2));

            GlobalVar.rsdx3 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy3 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx3 += GlobalVar.rsdx3;
            if (GlobalVar.rsx3 > panel1.Width - GlobalVar.pictureBox6.Width)
            {
                GlobalVar.rsx3 = 0;
            } // end if
            if (GlobalVar.rsx3 < 0)
            {
                GlobalVar.rsx3 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox6.Width);
            } // end if

            GlobalVar.rsy3 += GlobalVar.rsdy3;
            if (GlobalVar.rsy3 > panel1.Height - GlobalVar.pictureBox6.Height)
            {
                GlobalVar.rsy3 = 0;
            } // end if 
            if (GlobalVar.rsy3 < 0)
            {
                GlobalVar.rsy3 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox6.Height);
            } // end if

            GlobalVar.pictureBox6.Location = new Point(Convert.ToInt32(GlobalVar.rsx3), Convert.ToInt32(GlobalVar.rsy3));

            GlobalVar.rsdx4 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy4 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx4 += GlobalVar.rsdx4;
            if (GlobalVar.rsx4 > panel1.Width - GlobalVar.pictureBox7.Width)
            {
                GlobalVar.rsx4 = 0;
            } // end if
            if (GlobalVar.rsx4 < 0)
            {
                GlobalVar.rsx4 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox7.Width);
            } // end if

            GlobalVar.rsy4 += GlobalVar.rsdy4;
            if (GlobalVar.rsy4 > panel1.Height - GlobalVar.pictureBox7.Height)
            {
                GlobalVar.rsy4 = 0;
            } // end if 
            if (GlobalVar.rsy4 < 0)
            {
                GlobalVar.rsy4 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox7.Height);
            } // end if

            GlobalVar.pictureBox7.Location = new Point(Convert.ToInt32(GlobalVar.rsx4), Convert.ToInt32(GlobalVar.rsy4));

            GlobalVar.rsdx5 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy5 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx5 += GlobalVar.rsdx5;
            if (GlobalVar.rsx5 > panel1.Width - GlobalVar.pictureBox8.Width)
            {
                GlobalVar.rsx5 = 0;
            } // end if
            if (GlobalVar.rsx5 < 0)
            {
                GlobalVar.rsx5 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox8.Width);
            } // end if

            GlobalVar.rsy5 += GlobalVar.rsdy5;
            if (GlobalVar.rsy5 > panel1.Height - GlobalVar.pictureBox8.Height)
            {
                GlobalVar.rsy5 = 0;
            } // end if 
            if (GlobalVar.rsy5 < 0)
            {
                GlobalVar.rsy5 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox8.Height);
            } // end if

            GlobalVar.pictureBox8.Location = new Point(Convert.ToInt32(GlobalVar.rsx5), Convert.ToInt32(GlobalVar.rsy5));

            GlobalVar.rsdx6 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy6 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx6 += GlobalVar.rsdx6;
            if (GlobalVar.rsx6 > panel1.Width - GlobalVar.pictureBox9.Width)
            {
                GlobalVar.rsx6 = 0;
            } // end if
            if (GlobalVar.rsx6 < 0)
            {
                GlobalVar.rsx6 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox9.Width);
            } // end if

            GlobalVar.rsy6 += GlobalVar.rsdy6;
            if (GlobalVar.rsy6 > panel1.Height - GlobalVar.pictureBox9.Height)
            {
                GlobalVar.rsy6 = 0;
            } // end if 
            if (GlobalVar.rsy6 < 0)
            {
                GlobalVar.rsy6 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox9.Height);
            } // end if

            GlobalVar.pictureBox9.Location = new Point(Convert.ToInt32(GlobalVar.rsx6), Convert.ToInt32(GlobalVar.rsy6));

            GlobalVar.rsdx7 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy7 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx7 += GlobalVar.rsdx7;
            if (GlobalVar.rsx7 > panel1.Width - GlobalVar.pictureBox10.Width)
            {
                GlobalVar.rsx7 = 0;
            } // end if
            if (GlobalVar.rsx7 < 0)
            {
                GlobalVar.rsx7 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox10.Width);
            } // end if

            GlobalVar.rsy7 += GlobalVar.rsdy7;
            if (GlobalVar.rsy7 > panel1.Height - GlobalVar.pictureBox10.Height)
            {
                GlobalVar.rsy7 = 0;
            } // end if 
            if (GlobalVar.rsy7 < 0)
            {
                GlobalVar.rsy7 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox10.Height);
            } // end if

            GlobalVar.pictureBox10.Location = new Point(Convert.ToInt32(GlobalVar.rsx7), Convert.ToInt32(GlobalVar.rsy7));
        }
        private void moveObstacleNine()
        {
            Random roller = new Random();

            GlobalVar.rsdx = Convert.ToDouble(roller.Next(5) - 2) / 2;
            GlobalVar.rsdy = Convert.ToDouble(roller.Next(5) - 2) / 2;

            GlobalVar.rsx += GlobalVar.rsdx;
            if (GlobalVar.rsx > panel1.Width - GlobalVar.pictureBox3.Width)
            {
                GlobalVar.rsx = 0;
            } // end if
            if (GlobalVar.rsx < 0)
            {
                GlobalVar.rsx = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox3.Width);
            } // end if

            GlobalVar.rsy += GlobalVar.rsdy;
            if (GlobalVar.rsy > this.Height - GlobalVar.pictureBox3.Height)
            {
                GlobalVar.rsy = 0;
            } // end if 
            if (GlobalVar.rsy < 0)
            {
                GlobalVar.rsy = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox3.Height);
            } // end if

            GlobalVar.pictureBox3.Location = new Point(Convert.ToInt32(GlobalVar.rsx), Convert.ToInt32(GlobalVar.rsy));

            GlobalVar.rsdx1 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy1 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx1 += GlobalVar.rsdx1;
            if (GlobalVar.rsx1 > panel1.Width - GlobalVar.pictureBox4.Width)
            {
                GlobalVar.rsx1 = 0;
            } // end if
            if (GlobalVar.rsx1 < 0)
            {
                GlobalVar.rsx1 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox4.Width);
            } // end if

            GlobalVar.rsy1 += GlobalVar.rsdy1;
            if (GlobalVar.rsy1 > panel1.Height - GlobalVar.pictureBox4.Height)
            {
                GlobalVar.rsy1 = 0;
            } // end if 
            if (GlobalVar.rsy1 < 0)
            {
                GlobalVar.rsy1 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox4.Height);
            } // end if

            GlobalVar.pictureBox4.Location = new Point(Convert.ToInt32(GlobalVar.rsx1), Convert.ToInt32(GlobalVar.rsy1));

            GlobalVar.rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx2 += GlobalVar.rsdx2;
            if (GlobalVar.rsx2 > panel1.Width - GlobalVar.pictureBox5.Width)
            {
                GlobalVar.rsx2 = 0;
            } // end if
            if (GlobalVar.rsx2 < 0)
            {
                GlobalVar.rsx2 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox5.Width);
            } // end if

            GlobalVar.rsy2 += GlobalVar.rsdy2;
            if (GlobalVar.rsy2 > panel1.Height - GlobalVar.pictureBox5.Height)
            {
                GlobalVar.rsy2 = 0;
            } // end if 
            if (GlobalVar.rsy2 < 0)
            {
                GlobalVar.rsy2 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox5.Height);
            } // end if

            GlobalVar.pictureBox5.Location = new Point(Convert.ToInt32(GlobalVar.rsx2), Convert.ToInt32(GlobalVar.rsy2));

            GlobalVar.rsdx3 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy3 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx3 += GlobalVar.rsdx3;
            if (GlobalVar.rsx3 > panel1.Width - GlobalVar.pictureBox6.Width)
            {
                GlobalVar.rsx3 = 0;
            } // end if
            if (GlobalVar.rsx3 < 0)
            {
                GlobalVar.rsx3 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox6.Width);
            } // end if

            GlobalVar.rsy3 += GlobalVar.rsdy3;
            if (GlobalVar.rsy3 > panel1.Height - GlobalVar.pictureBox6.Height)
            {
                GlobalVar.rsy3 = 0;
            } // end if 
            if (GlobalVar.rsy3 < 0)
            {
                GlobalVar.rsy3 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox6.Height);
            } // end if

            GlobalVar.pictureBox6.Location = new Point(Convert.ToInt32(GlobalVar.rsx3), Convert.ToInt32(GlobalVar.rsy3));

            GlobalVar.rsdx4 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy4 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx4 += GlobalVar.rsdx4;
            if (GlobalVar.rsx4 > panel1.Width - GlobalVar.pictureBox7.Width)
            {
                GlobalVar.rsx4 = 0;
            } // end if
            if (GlobalVar.rsx4 < 0)
            {
                GlobalVar.rsx4 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox7.Width);
            } // end if

            GlobalVar.rsy4 += GlobalVar.rsdy4;
            if (GlobalVar.rsy4 > panel1.Height - GlobalVar.pictureBox7.Height)
            {
                GlobalVar.rsy4 = 0;
            } // end if 
            if (GlobalVar.rsy4 < 0)
            {
                GlobalVar.rsy4 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox7.Height);
            } // end if

            GlobalVar.pictureBox7.Location = new Point(Convert.ToInt32(GlobalVar.rsx4), Convert.ToInt32(GlobalVar.rsy4));

            GlobalVar.rsdx5 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy5 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx5 += GlobalVar.rsdx5;
            if (GlobalVar.rsx5 > panel1.Width - GlobalVar.pictureBox8.Width)
            {
                GlobalVar.rsx5 = 0;
            } // end if
            if (GlobalVar.rsx5 < 0)
            {
                GlobalVar.rsx5 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox8.Width);
            } // end if

            GlobalVar.rsy5 += GlobalVar.rsdy5;
            if (GlobalVar.rsy5 > panel1.Height - GlobalVar.pictureBox8.Height)
            {
                GlobalVar.rsy5 = 0;
            } // end if 
            if (GlobalVar.rsy5 < 0)
            {
                GlobalVar.rsy5 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox8.Height);
            } // end if

            GlobalVar.pictureBox8.Location = new Point(Convert.ToInt32(GlobalVar.rsx5), Convert.ToInt32(GlobalVar.rsy5));

            GlobalVar.rsdx6 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy6 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx6 += GlobalVar.rsdx6;
            if (GlobalVar.rsx6 > panel1.Width - GlobalVar.pictureBox9.Width)
            {
                GlobalVar.rsx6 = 0;
            } // end if
            if (GlobalVar.rsx6 < 0)
            {
                GlobalVar.rsx6 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox9.Width);
            } // end if

            GlobalVar.rsy6 += GlobalVar.rsdy6;
            if (GlobalVar.rsy6 > panel1.Height - GlobalVar.pictureBox9.Height)
            {
                GlobalVar.rsy6 = 0;
            } // end if 
            if (GlobalVar.rsy6 < 0)
            {
                GlobalVar.rsy6 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox9.Height);
            } // end if

            GlobalVar.pictureBox9.Location = new Point(Convert.ToInt32(GlobalVar.rsx6), Convert.ToInt32(GlobalVar.rsy6));

            GlobalVar.rsdx7 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy7 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx7 += GlobalVar.rsdx7;
            if (GlobalVar.rsx7 > panel1.Width - GlobalVar.pictureBox10.Width)
            {
                GlobalVar.rsx7 = 0;
            } // end if
            if (GlobalVar.rsx7 < 0)
            {
                GlobalVar.rsx7 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox10.Width);
            } // end if

            GlobalVar.rsy7 += GlobalVar.rsdy7;
            if (GlobalVar.rsy7 > panel1.Height - GlobalVar.pictureBox10.Height)
            {
                GlobalVar.rsy7 = 0;
            } // end if 
            if (GlobalVar.rsy7 < 0)
            {
                GlobalVar.rsy7 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox10.Height);
            } // end if

            GlobalVar.pictureBox10.Location = new Point(Convert.ToInt32(GlobalVar.rsx7), Convert.ToInt32(GlobalVar.rsy7));
        }
        private void moveObstacleTen()
        {
            Random roller = new Random();

            GlobalVar.rsdx = Convert.ToDouble(roller.Next(5) - 2) / 2;
            GlobalVar.rsdy = Convert.ToDouble(roller.Next(5) - 2) / 2;

            GlobalVar.rsx += GlobalVar.rsdx;
            if (GlobalVar.rsx > panel1.Width - GlobalVar.pictureBox3.Width)
            {
                GlobalVar.rsx = 0;
            } // end if
            if (GlobalVar.rsx < 0)
            {
                GlobalVar.rsx = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox3.Width);
            } // end if

            GlobalVar.rsy += GlobalVar.rsdy;
            if (GlobalVar.rsy > this.Height - GlobalVar.pictureBox3.Height)
            {
                GlobalVar.rsy = 0;
            } // end if 
            if (GlobalVar.rsy < 0)
            {
                GlobalVar.rsy = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox3.Height);
            } // end if

            GlobalVar.pictureBox3.Location = new Point(Convert.ToInt32(GlobalVar.rsx), Convert.ToInt32(GlobalVar.rsy));

            GlobalVar.rsdx1 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy1 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx1 += GlobalVar.rsdx1;
            if (GlobalVar.rsx1 > panel1.Width - GlobalVar.pictureBox4.Width)
            {
                GlobalVar.rsx1 = 0;
            } // end if
            if (GlobalVar.rsx1 < 0)
            {
                GlobalVar.rsx1 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox4.Width);
            } // end if

            GlobalVar.rsy1 += GlobalVar.rsdy1;
            if (GlobalVar.rsy1 > panel1.Height - GlobalVar.pictureBox4.Height)
            {
                GlobalVar.rsy1 = 0;
            } // end if 
            if (GlobalVar.rsy1 < 0)
            {
                GlobalVar.rsy1 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox4.Height);
            } // end if

            GlobalVar.pictureBox4.Location = new Point(Convert.ToInt32(GlobalVar.rsx1), Convert.ToInt32(GlobalVar.rsy1));

            GlobalVar.rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx2 += GlobalVar.rsdx2;
            if (GlobalVar.rsx2 > panel1.Width - GlobalVar.pictureBox5.Width)
            {
                GlobalVar.rsx2 = 0;
            } // end if
            if (GlobalVar.rsx2 < 0)
            {
                GlobalVar.rsx2 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox5.Width);
            } // end if

            GlobalVar.rsy2 += GlobalVar.rsdy2;
            if (GlobalVar.rsy2 > panel1.Height - GlobalVar.pictureBox5.Height)
            {
                GlobalVar.rsy2 = 0;
            } // end if 
            if (GlobalVar.rsy2 < 0)
            {
                GlobalVar.rsy2 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox5.Height);
            } // end if

            GlobalVar.pictureBox5.Location = new Point(Convert.ToInt32(GlobalVar.rsx2), Convert.ToInt32(GlobalVar.rsy2));

            GlobalVar.rsdx3 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy3 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx3 += GlobalVar.rsdx3;
            if (GlobalVar.rsx3 > panel1.Width - GlobalVar.pictureBox6.Width)
            {
                GlobalVar.rsx3 = 0;
            } // end if
            if (GlobalVar.rsx3 < 0)
            {
                GlobalVar.rsx3 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox6.Width);
            } // end if

            GlobalVar.rsy3 += GlobalVar.rsdy3;
            if (GlobalVar.rsy3 > panel1.Height - GlobalVar.pictureBox6.Height)
            {
                GlobalVar.rsy3 = 0;
            } // end if 
            if (GlobalVar.rsy3 < 0)
            {
                GlobalVar.rsy3 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox6.Height);
            } // end if

            GlobalVar.pictureBox6.Location = new Point(Convert.ToInt32(GlobalVar.rsx3), Convert.ToInt32(GlobalVar.rsy3));

            GlobalVar.rsdx4 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy4 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx4 += GlobalVar.rsdx4;
            if (GlobalVar.rsx4 > panel1.Width - GlobalVar.pictureBox7.Width)
            {
                GlobalVar.rsx4 = 0;
            } // end if
            if (GlobalVar.rsx4 < 0)
            {
                GlobalVar.rsx4 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox7.Width);
            } // end if

            GlobalVar.rsy4 += GlobalVar.rsdy4;
            if (GlobalVar.rsy4 > panel1.Height - GlobalVar.pictureBox7.Height)
            {
                GlobalVar.rsy4 = 0;
            } // end if 
            if (GlobalVar.rsy4 < 0)
            {
                GlobalVar.rsy4 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox7.Height);
            } // end if

            GlobalVar.pictureBox7.Location = new Point(Convert.ToInt32(GlobalVar.rsx4), Convert.ToInt32(GlobalVar.rsy4));

            GlobalVar.rsdx5 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy5 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx5 += GlobalVar.rsdx5;
            if (GlobalVar.rsx5 > panel1.Width - GlobalVar.pictureBox8.Width)
            {
                GlobalVar.rsx5 = 0;
            } // end if
            if (GlobalVar.rsx5 < 0)
            {
                GlobalVar.rsx5 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox8.Width);
            } // end if

            GlobalVar.rsy5 += GlobalVar.rsdy5;
            if (GlobalVar.rsy5 > panel1.Height - GlobalVar.pictureBox8.Height)
            {
                GlobalVar.rsy5 = 0;
            } // end if 
            if (GlobalVar.rsy5 < 0)
            {
                GlobalVar.rsy5 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox8.Height);
            } // end if

            GlobalVar.pictureBox8.Location = new Point(Convert.ToInt32(GlobalVar.rsx5), Convert.ToInt32(GlobalVar.rsy5));

            GlobalVar.rsdx6 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy6 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx6 += GlobalVar.rsdx6;
            if (GlobalVar.rsx6 > panel1.Width - GlobalVar.pictureBox9.Width)
            {
                GlobalVar.rsx6 = 0;
            } // end if
            if (GlobalVar.rsx6 < 0)
            {
                GlobalVar.rsx6 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox9.Width);
            } // end if

            GlobalVar.rsy6 += GlobalVar.rsdy6;
            if (GlobalVar.rsy6 > panel1.Height - GlobalVar.pictureBox9.Height)
            {
                GlobalVar.rsy6 = 0;
            } // end if 
            if (GlobalVar.rsy6 < 0)
            {
                GlobalVar.rsy6 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox9.Height);
            } // end if

            GlobalVar.pictureBox9.Location = new Point(Convert.ToInt32(GlobalVar.rsx6), Convert.ToInt32(GlobalVar.rsy6));

            GlobalVar.rsdx7 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy7 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx7 += GlobalVar.rsdx7;
            if (GlobalVar.rsx7 > panel1.Width - GlobalVar.pictureBox10.Width)
            {
                GlobalVar.rsx7 = 0;
            } // end if
            if (GlobalVar.rsx7 < 0)
            {
                GlobalVar.rsx7 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox10.Width);
            } // end if

            GlobalVar.rsy7 += GlobalVar.rsdy7;
            if (GlobalVar.rsy7 > panel1.Height - GlobalVar.pictureBox10.Height)
            {
                GlobalVar.rsy6 = 0;
            } // end if 
            if (GlobalVar.rsy7 < 0)
            {
                GlobalVar.rsy7 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox10.Height);
            } // end if

            GlobalVar.pictureBox10.Location = new Point(Convert.ToInt32(GlobalVar.rsx7), Convert.ToInt32(GlobalVar.rsy7));

            GlobalVar.rsdx8 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy8 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx8 += GlobalVar.rsdx8;
            if (GlobalVar.rsx8 > panel1.Width - GlobalVar.pictureBox11.Width)
            {
                GlobalVar.rsx8 = 0;
            } // end if
            if (GlobalVar.rsx8 < 0)
            {
                GlobalVar.rsx8 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox11.Width);
            } // end if

            GlobalVar.rsy8 += GlobalVar.rsdy8;
            if (GlobalVar.rsy8 > panel1.Height - GlobalVar.pictureBox11.Height)
            {
                GlobalVar.rsy8 = 0;
            } // end if 
            if (GlobalVar.rsy8 < 0)
            {
                GlobalVar.rsy8 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox11.Height);
            } // end if

            GlobalVar.pictureBox11.Location = new Point(Convert.ToInt32(GlobalVar.rsx8), Convert.ToInt32(GlobalVar.rsy8));

            GlobalVar.rsdx9 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy9 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx9 += GlobalVar.rsdx9;
            if (GlobalVar.rsx9 > panel1.Width - GlobalVar.pictureBox12.Width)
            {
                GlobalVar.rsx9 = 0;
            } // end if
            if (GlobalVar.rsx9 < 0)
            {
                GlobalVar.rsx9 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox12.Width);
            } // end if

            GlobalVar.rsy9 += GlobalVar.rsdy9;
            if (GlobalVar.rsy9 > panel1.Height - GlobalVar.pictureBox12.Height)
            {
                GlobalVar.rsy9 = 0;
            } // end if 
            if (GlobalVar.rsy9 < 0)
            {
                GlobalVar.rsy9 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox12.Height);
            } // end if

            GlobalVar.pictureBox12.Location = new Point(Convert.ToInt32(GlobalVar.rsx9), Convert.ToInt32(GlobalVar.rsy9));
        }
        private void moveObstacleOneWithSpeed()
        {
            Random roller = new Random();

            int specInterMove;

            specInterMove = roller.Next(50);

            GlobalVar.rsdx = Convert.ToDouble(roller.Next(5) - 2) / 2;
            GlobalVar.rsdy = Convert.ToDouble(roller.Next(5) - 2) / 2;

            for (int i = 0; i < specInterMove; i++)
            {
                GlobalVar.rsx += GlobalVar.rsdx;
                if (GlobalVar.rsx > panel1.Width - GlobalVar.pictureBox3.Width)
                {
                    GlobalVar.rsx = 0;
                } // end if
                if (GlobalVar.rsx < 0)
                {
                    GlobalVar.rsx = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox3.Width);
                } // end if

                GlobalVar.rsy += GlobalVar.rsdy;
                if (GlobalVar.rsy > this.Height - GlobalVar.pictureBox3.Height)
                {
                    GlobalVar.rsy = 0;
                } // end if 
                if (GlobalVar.rsy < 0)
                {
                    GlobalVar.rsy = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox3.Height);
                } // end if

                GlobalVar.pictureBox3.Location = new Point(Convert.ToInt32(GlobalVar.rsx), Convert.ToInt32(GlobalVar.rsy));
            }

            GlobalVar.rsdx1 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy1 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx1 += GlobalVar.rsdx1;
            if (GlobalVar.rsx1 > panel1.Width - GlobalVar.pictureBox4.Width)
            {
                GlobalVar.rsx1 = 0;
            } // end if
            if (GlobalVar.rsx1 < 0)
            {
                GlobalVar.rsx1 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox4.Width);
            } // end if

            GlobalVar.rsy1 += GlobalVar.rsdy1;
            if (GlobalVar.rsy1 > panel1.Height - GlobalVar.pictureBox4.Height)
            {
                GlobalVar.rsy1 = 0;
            } // end if 
            if (GlobalVar.rsy1 < 0)
            {
                GlobalVar.rsy1 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox4.Height);
            } // end if

            GlobalVar.pictureBox4.Location = new Point(Convert.ToInt32(GlobalVar.rsx1), Convert.ToInt32(GlobalVar.rsy1));

            GlobalVar.rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx2 += GlobalVar.rsdx2;
            if (GlobalVar.rsx2 > panel1.Width - GlobalVar.pictureBox5.Width)
            {
                GlobalVar.rsx2 = 0;
            } // end if
            if (GlobalVar.rsx2 < 0)
            {
                GlobalVar.rsx2 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox5.Width);
            } // end if

            GlobalVar.rsy2 += GlobalVar.rsdy2;
            if (GlobalVar.rsy2 > panel1.Height - GlobalVar.pictureBox5.Height)
            {
                GlobalVar.rsy2 = 0;
            } // end if 
            if (GlobalVar.rsy2 < 0)
            {
                GlobalVar.rsy2 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox5.Height);
            } // end if

            GlobalVar.pictureBox5.Location = new Point(Convert.ToInt32(GlobalVar.rsx2), Convert.ToInt32(GlobalVar.rsy2));

            GlobalVar.rsdx3 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy3 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx3 += GlobalVar.rsdx3;
            if (GlobalVar.rsx3 > panel1.Width - GlobalVar.pictureBox6.Width)
            {
                GlobalVar.rsx3 = 0;
            } // end if
            if (GlobalVar.rsx3 < 0)
            {
                GlobalVar.rsx3 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox6.Width);
            } // end if

            GlobalVar.rsy3 += GlobalVar.rsdy3;
            if (GlobalVar.rsy3 > panel1.Height - GlobalVar.pictureBox6.Height)
            {
                GlobalVar.rsy3 = 0;
            } // end if 
            if (GlobalVar.rsy3 < 0)
            {
                GlobalVar.rsy3 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox6.Height);
            } // end if

            GlobalVar.pictureBox6.Location = new Point(Convert.ToInt32(GlobalVar.rsx3), Convert.ToInt32(GlobalVar.rsy3));

            GlobalVar.rsdx4 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy4 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx4 += GlobalVar.rsdx4;
            if (GlobalVar.rsx4 > panel1.Width - GlobalVar.pictureBox7.Width)
            {
                GlobalVar.rsx4 = 0;
            } // end if
            if (GlobalVar.rsx4 < 0)
            {
                GlobalVar.rsx4 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox7.Width);
            } // end if

            GlobalVar.rsy4 += GlobalVar.rsdy4;
            if (GlobalVar.rsy4 > panel1.Height - GlobalVar.pictureBox7.Height)
            {
                GlobalVar.rsy4 = 0;
            } // end if 
            if (GlobalVar.rsy4 < 0)
            {
                GlobalVar.rsy4 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox7.Height);
            } // end if

            GlobalVar.pictureBox7.Location = new Point(Convert.ToInt32(GlobalVar.rsx4), Convert.ToInt32(GlobalVar.rsy4));

            GlobalVar.rsdx5 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy5 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx5 += GlobalVar.rsdx5;
            if (GlobalVar.rsx5 > panel1.Width - GlobalVar.pictureBox8.Width)
            {
                GlobalVar.rsx5 = 0;
            } // end if
            if (GlobalVar.rsx5 < 0)
            {
                GlobalVar.rsx5 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox8.Width);
            } // end if

            GlobalVar.rsy5 += GlobalVar.rsdy5;
            if (GlobalVar.rsy5 > panel1.Height - GlobalVar.pictureBox8.Height)
            {
                GlobalVar.rsy5 = 0;
            } // end if 
            if (GlobalVar.rsy5 < 0)
            {
                GlobalVar.rsy5 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox8.Height);
            } // end if

            GlobalVar.pictureBox8.Location = new Point(Convert.ToInt32(GlobalVar.rsx5), Convert.ToInt32(GlobalVar.rsy5));

            GlobalVar.rsdx6 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy6 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx6 += GlobalVar.rsdx6;
            if (GlobalVar.rsx6 > panel1.Width - GlobalVar.pictureBox9.Width)
            {
                GlobalVar.rsx6 = 0;
            } // end if
            if (GlobalVar.rsx6 < 0)
            {
                GlobalVar.rsx6 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox9.Width);
            } // end if

            GlobalVar.rsy6 += GlobalVar.rsdy6;
            if (GlobalVar.rsy6 > panel1.Height - GlobalVar.pictureBox9.Height)
            {
                GlobalVar.rsy6 = 0;
            } // end if 
            if (GlobalVar.rsy6 < 0)
            {
                GlobalVar.rsy6 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox9.Height);
            } // end if

            GlobalVar.pictureBox9.Location = new Point(Convert.ToInt32(GlobalVar.rsx6), Convert.ToInt32(GlobalVar.rsy6));

            GlobalVar.rsdx7 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy7 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx7 += GlobalVar.rsdx7;
            if (GlobalVar.rsx7 > panel1.Width - GlobalVar.pictureBox10.Width)
            {
                GlobalVar.rsx7 = 0;
            } // end if
            if (GlobalVar.rsx7 < 0)
            {
                GlobalVar.rsx7 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox10.Width);
            } // end if

            GlobalVar.rsy7 += GlobalVar.rsdy7;
            if (GlobalVar.rsy7 > panel1.Height - GlobalVar.pictureBox10.Height)
            {
                GlobalVar.rsy6 = 0;
            } // end if 
            if (GlobalVar.rsy7 < 0)
            {
                GlobalVar.rsy7 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox10.Height);
            } // end if

            GlobalVar.pictureBox10.Location = new Point(Convert.ToInt32(GlobalVar.rsx7), Convert.ToInt32(GlobalVar.rsy7));

            GlobalVar.rsdx8 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy8 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx8 += GlobalVar.rsdx8;
            if (GlobalVar.rsx8 > panel1.Width - GlobalVar.pictureBox11.Width)
            {
                GlobalVar.rsx8 = 0;
            } // end if
            if (GlobalVar.rsx8 < 0)
            {
                GlobalVar.rsx8 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox11.Width);
            } // end if

            GlobalVar.rsy8 += GlobalVar.rsdy8;
            if (GlobalVar.rsy8 > panel1.Height - GlobalVar.pictureBox11.Height)
            {
                GlobalVar.rsy8 = 0;
            } // end if 
            if (GlobalVar.rsy8 < 0)
            {
                GlobalVar.rsy8 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox11.Height);
            } // end if

            GlobalVar.pictureBox11.Location = new Point(Convert.ToInt32(GlobalVar.rsx8), Convert.ToInt32(GlobalVar.rsy8));

            GlobalVar.rsdx9 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy9 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx9 += GlobalVar.rsdx9;
            if (GlobalVar.rsx9 > panel1.Width - GlobalVar.pictureBox12.Width)
            {
                GlobalVar.rsx9 = 0;
            } // end if
            if (GlobalVar.rsx9 < 0)
            {
                GlobalVar.rsx9 = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox12.Width);
            } // end if

            GlobalVar.rsy9 += GlobalVar.rsdy9;
            if (GlobalVar.rsy9 > panel1.Height - GlobalVar.pictureBox12.Height)
            {
                GlobalVar.rsy9 = 0;
            } // end if 
            if (GlobalVar.rsy9 < 0)
            {
                GlobalVar.rsy9 = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox12.Height);
            } // end if

            GlobalVar.pictureBox12.Location = new Point(Convert.ToInt32(GlobalVar.rsx9), Convert.ToInt32(GlobalVar.rsy9));
        }

        private void moveShip()
        {
            GlobalVar.x += GlobalVar.dx;
            //x += dx;
            if (GlobalVar.x > panel1.Width - GlobalVar.pictureBox1.Width)
            {
                GlobalVar.x = 0;
            } // end if
            if (GlobalVar.x < 0)
            {
                GlobalVar.x = Convert.ToDouble(panel1.Width - GlobalVar.pictureBox1.Width);
            } // end if

            GlobalVar.y += GlobalVar.dy;
            if (GlobalVar.y > panel1.Height - GlobalVar.pictureBox1.Height)
            {
                GlobalVar.y = 0;
            } // end if 
            if (GlobalVar.y < 0)
            {
                GlobalVar.y = Convert.ToDouble(panel1.Height - GlobalVar.pictureBox1.Height);
            } // end if

            GlobalVar.pictureBox1.Location = new Point(Convert.ToInt32(GlobalVar.x), Convert.ToInt32(GlobalVar.y));
        } // end moveShip

        private void checkCollideOne()
        {
            GlobalVar.rLander = GlobalVar.pictureBox1.Bounds;
            GlobalVar.rObstacle = GlobalVar.pictureBox3.Bounds;
            //rSpectacle1 = GlobalVar.pictureBox4.Bounds;
            //rSpectacle2 = GlobalVar.pictureBox5.Bounds;

            if (GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle))
            {
                timer1.Enabled = false;

                GlobalVar.pictureBox1.BackgroundImage = imageList1.Images[6];
                GlobalVar.GetPlayerSound("Explosion.wav");
                GlobalVar.player.Play();
                MessageBox.Show("Your ship have been collide with unknown objects!");
                GlobalVar.player.Stop();
                killShip();
                initGame();
            } // end if
        }
        private void checkCollideTwo()
        {
            GlobalVar.rLander = GlobalVar.pictureBox1.Bounds;
            GlobalVar.rObstacle = GlobalVar.pictureBox3.Bounds;
            GlobalVar.rObstacle1 = GlobalVar.pictureBox4.Bounds;
            //rSpectacle2 = GlobalVar.pictureBox5.Bounds;

            if (GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle1))
            {
                timer1.Enabled = false;

                GlobalVar.pictureBox1.BackgroundImage = imageList1.Images[6];
                GlobalVar.GetPlayerSound("Explosion.wav");
                GlobalVar.player.Play();
                MessageBox.Show("Your ship have been collide with unknown objects!");
                GlobalVar.player.Stop();
                killShip();
                initGame();
            } // end if
        }
        private void checkCollideThree()
        {
            GlobalVar.rLander = GlobalVar.pictureBox1.Bounds;
            GlobalVar.rObstacle = GlobalVar.pictureBox3.Bounds;
            GlobalVar.rObstacle1 = GlobalVar.pictureBox4.Bounds;
            GlobalVar.rObstacle2 = GlobalVar.pictureBox5.Bounds;

            if (GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle1) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle2))
            {
                timer1.Enabled = false;

                GlobalVar.pictureBox1.BackgroundImage = imageList1.Images[6];
                GlobalVar.GetPlayerSound("Explosion.wav");
                GlobalVar.player.Play();
                MessageBox.Show("Your ship have been collide with unknown objects!");
                GlobalVar.player.Stop();
                killShip();
                initGame();
            } // end if
        }
        private void checkCollideFour()
        {
            GlobalVar.rLander = GlobalVar.pictureBox1.Bounds;
            GlobalVar.rObstacle = GlobalVar.pictureBox3.Bounds;
            GlobalVar.rObstacle1 = GlobalVar.pictureBox4.Bounds;
            GlobalVar.rObstacle2 = GlobalVar.pictureBox5.Bounds;
            GlobalVar.rObstacle3 = GlobalVar.pictureBox6.Bounds;

            if (GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle1) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle2) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle3))
            {
                timer1.Enabled = false;

                GlobalVar.pictureBox1.BackgroundImage = imageList1.Images[6];
                GlobalVar.GetPlayerSound("Explosion.wav");
                GlobalVar.player.Play();
                MessageBox.Show("Your ship have been collide with unknown objects!");
                GlobalVar.player.Stop();
                killShip();
                initGame();
            } // end if
        }
        private void checkCollideFive()
        {
            GlobalVar.rLander = GlobalVar.pictureBox1.Bounds;
            GlobalVar.rObstacle = GlobalVar.pictureBox3.Bounds;
            GlobalVar.rObstacle1 = GlobalVar.pictureBox4.Bounds;
            GlobalVar.rObstacle2 = GlobalVar.pictureBox5.Bounds;
            GlobalVar.rObstacle3 = GlobalVar.pictureBox6.Bounds;
            GlobalVar.rObstacle4 = GlobalVar.pictureBox7.Bounds;

            if (GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle1) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle2) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle3) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle4))
            {
                timer1.Enabled = false;

                GlobalVar.pictureBox1.BackgroundImage = imageList1.Images[6];
                GlobalVar.GetPlayerSound("Explosion.wav");
                GlobalVar.player.Play();
                MessageBox.Show("Your ship have been collide with unknown objects!");
                GlobalVar.player.Stop();
                killShip();
                initGame();
            } // end if
        }
        private void checkCollideSix()
        {
            GlobalVar.rLander = GlobalVar.pictureBox1.Bounds;
            GlobalVar.rObstacle = GlobalVar.pictureBox3.Bounds;
            GlobalVar.rObstacle1 = GlobalVar.pictureBox4.Bounds;
            GlobalVar.rObstacle2 = GlobalVar.pictureBox5.Bounds;
            GlobalVar.rObstacle3 = GlobalVar.pictureBox6.Bounds;
            GlobalVar.rObstacle4 = GlobalVar.pictureBox7.Bounds;
            GlobalVar.rObstacle5 = GlobalVar.pictureBox8.Bounds;

            if (GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle1) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle2) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle3) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle4) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle5))
            {
                timer1.Enabled = false;

                GlobalVar.pictureBox1.BackgroundImage = imageList1.Images[6];
                GlobalVar.GetPlayerSound("Explosion.wav");
                GlobalVar.player.Play();
                MessageBox.Show("Your ship have been collide with unknown objects!");
                GlobalVar.player.Stop();
                killShip();
                initGame();
            } // end if
        }
        private void checkCollideSeven()
        {
            GlobalVar.rLander = GlobalVar.pictureBox1.Bounds;
            GlobalVar.rObstacle = GlobalVar.pictureBox3.Bounds;
            GlobalVar.rObstacle1 = GlobalVar.pictureBox4.Bounds;
            GlobalVar.rObstacle2 = GlobalVar.pictureBox5.Bounds;
            GlobalVar.rObstacle3 = GlobalVar.pictureBox6.Bounds;
            GlobalVar.rObstacle4 = GlobalVar.pictureBox7.Bounds;
            GlobalVar.rObstacle5 = GlobalVar.pictureBox8.Bounds;
            GlobalVar.rObstacle6 = GlobalVar.pictureBox9.Bounds;

            if (GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle1) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle2) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle3) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle4) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle5) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle6))
            {
                timer1.Enabled = false;

                GlobalVar.pictureBox1.BackgroundImage = imageList1.Images[6];
                GlobalVar.GetPlayerSound("Explosion.wav");
                GlobalVar.player.Play();
                MessageBox.Show("Your ship have been collide with unknown objects!");
                GlobalVar.player.Stop();
                killShip();
                initGame();
            } // end if
        }
        private void checkCollideEight()
        {
            GlobalVar.rLander = GlobalVar.pictureBox1.Bounds;
            GlobalVar.rObstacle = GlobalVar.pictureBox3.Bounds;
            GlobalVar.rObstacle1 = GlobalVar.pictureBox4.Bounds;
            GlobalVar.rObstacle2 = GlobalVar.pictureBox5.Bounds;
            GlobalVar.rObstacle3 = GlobalVar.pictureBox6.Bounds;
            GlobalVar.rObstacle4 = GlobalVar.pictureBox7.Bounds;
            GlobalVar.rObstacle5 = GlobalVar.pictureBox8.Bounds;
            GlobalVar.rObstacle6 = GlobalVar.pictureBox9.Bounds;
            GlobalVar.rObstacle7 = GlobalVar.pictureBox10.Bounds;

            if (GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle1) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle2) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle3) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle4) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle5) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle6) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle7))
            {
                timer1.Enabled = false;

                GlobalVar.pictureBox1.BackgroundImage = imageList1.Images[6];
                GlobalVar.GetPlayerSound("Explosion.wav");
                GlobalVar.player.Play();
                MessageBox.Show("Your ship have been collide with unknown objects!");
                GlobalVar.player.Stop();
                killShip();
                initGame();
            } // end if
        }
        private void checkCollideNine()
        {
            GlobalVar.rLander = GlobalVar.pictureBox1.Bounds;
            GlobalVar.rObstacle = GlobalVar.pictureBox3.Bounds;
            GlobalVar.rObstacle1 = GlobalVar.pictureBox4.Bounds;
            GlobalVar.rObstacle2 = GlobalVar.pictureBox5.Bounds;
            GlobalVar.rObstacle3 = GlobalVar.pictureBox6.Bounds;
            GlobalVar.rObstacle4 = GlobalVar.pictureBox7.Bounds;
            GlobalVar.rObstacle5 = GlobalVar.pictureBox8.Bounds;
            GlobalVar.rObstacle6 = GlobalVar.pictureBox9.Bounds;
            GlobalVar.rObstacle7 = GlobalVar.pictureBox10.Bounds;
            GlobalVar.rObstacle8 = GlobalVar.pictureBox11.Bounds;

            if (GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle1) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle2) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle3) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle4) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle5) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle6) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle7) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle8))
            {
                timer1.Enabled = false;

                GlobalVar.pictureBox1.BackgroundImage = imageList1.Images[6];
                GlobalVar.GetPlayerSound("Explosion.wav");
                GlobalVar.player.Play();
                MessageBox.Show("Your ship have been collide with unknown objects!");
                GlobalVar.player.Stop();
                killShip();
                initGame();
            } // end if
        }
        private void checkCollideTen()
        {
            GlobalVar.rLander = GlobalVar.pictureBox1.Bounds;
            GlobalVar.rObstacle = GlobalVar.pictureBox3.Bounds;
            GlobalVar.rObstacle1 = GlobalVar.pictureBox4.Bounds;
            GlobalVar.rObstacle2 = GlobalVar.pictureBox5.Bounds;
            GlobalVar.rObstacle3 = GlobalVar.pictureBox6.Bounds;
            GlobalVar.rObstacle4 = GlobalVar.pictureBox7.Bounds;
            GlobalVar.rObstacle5 = GlobalVar.pictureBox8.Bounds;
            GlobalVar.rObstacle6 = GlobalVar.pictureBox9.Bounds;
            GlobalVar.rObstacle7 = GlobalVar.pictureBox10.Bounds;
            GlobalVar.rObstacle8 = GlobalVar.pictureBox11.Bounds;
            GlobalVar.rObstacle9 = GlobalVar.pictureBox12.Bounds;

            if (GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle1) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle2) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle3) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle4) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle5) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle6) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle7) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle8) || GlobalVar.rLander.IntersectsWith(GlobalVar.rObstacle9))
            {
                timer1.Enabled = false;

                GlobalVar.pictureBox1.BackgroundImage = imageList1.Images[6];
                GlobalVar.GetPlayerSound("Explosion.wav");
                GlobalVar.player.Play();
                MessageBox.Show("Your ship have been collide with unknown objects!");
                GlobalVar.player.Stop();
                killShip();
                initGame();
            } // end if
        }

        private void checkLanding()
        {
            GlobalVar.rLander = GlobalVar.pictureBox1.Bounds;
            GlobalVar.rPlatform = GlobalVar.pictureBox2.Bounds;

            if (GlobalVar.rLander.IntersectsWith(GlobalVar.rPlatform))
            {
                timer1.Enabled = false;

                if (Math.Abs(GlobalVar.dx) < 1)
                {
                    if (Math.Abs(GlobalVar.dy) < 3)
                    {
                        //if (Math.Abs(GlobalVar.rLander.Bottom - GlobalVar.rPlatform.Top) < 3)
                        //{
                        GlobalVar.GetPlayerSound("TaDa.wav");
                        GlobalVar.player.Play();
                        MessageBox.Show("Good Landing!");
                        GlobalVar.player.Stop();
                        GlobalVar.fuel += 30;
                        GlobalVar.score += 10000;
                        GlobalVar.level += 1;
                        //}
                    }
                    else
                    {
                        GlobalVar.pictureBox1.BackgroundImage = imageList1.Images[6];
                        GlobalVar.GetPlayerSound("Explosion.wav");
                        GlobalVar.player.Play();
                        MessageBox.Show("Too much vertical velocity!");
                        GlobalVar.player.Stop();
                        killShip();
                    } // end vertical if
                }
                else
                {
                    GlobalVar.pictureBox1.BackgroundImage = imageList1.Images[6];
                    GlobalVar.GetPlayerSound("Explosion.wav");
                    GlobalVar.player.Play();
                    MessageBox.Show("Too much horizontal velocity");
                    GlobalVar.player.Stop();
                    killShip();
                } // end horiz if
                initGame();
            } // end if
        } // end checkLanding

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            GlobalVar.fuel--;

            if (GlobalVar.fuel < 0)
            {
                timer1.Enabled = false;
                MessageBox.Show("Out of Fuel!!");
                GlobalVar.fuel += 20;
                killShip();
                initGame();
            } // end if

            switch (e.KeyData)
            {
                case Keys.Up:
                    GlobalVar.pictureBox1.BackgroundImage = imageList1.Images[0];
                    GlobalVar.dy -= 2;
                    break;
                case Keys.Left:
                    GlobalVar.pictureBox1.BackgroundImage = imageList1.Images[0];
                    GlobalVar.dx++;
                    break;
                case Keys.Right:
                    GlobalVar.pictureBox1.BackgroundImage = imageList1.Images[0];
                    GlobalVar.dx--;
                    break;
                default:
                    break;
            } // end switch
        } // end keydown

        public void showStats()
        {
            label1.Text = "dx: " + GlobalVar.dx;
            label2.Text = "dy: " + GlobalVar.dy;
            label3.Text = "Fuel: " + GlobalVar.fuel;
            label4.Text = "Ships: " + GlobalVar.ships;
            label5.Text = "Score: " + GlobalVar.score;
            label9.Text = "Level: " + GlobalVar.level;
            label6.Text = "Spetacles1 Location: " + GlobalVar.pictureBox3.Location.X + ", " + GlobalVar.pictureBox3.Location.Y + Environment.NewLine
                + "Displacement x: " + GlobalVar.rsdx + " Displacement y: " + GlobalVar.rsdy + Environment.NewLine
                + "Spetacles2 Location: " + GlobalVar.pictureBox4.Location.X + ", " + GlobalVar.pictureBox4.Location.Y + Environment.NewLine
                + "Displacement x: " + GlobalVar.rsdx1 + " Displacement y: " + GlobalVar.rsdy1 + Environment.NewLine
                + "Spetacles3 Location: " + GlobalVar.pictureBox5.Location.X + ", " + GlobalVar.pictureBox5.Location.Y + Environment.NewLine
                + "Displacement x: " + GlobalVar.rsdx2 + " Displacement y: " + GlobalVar.rsdy2 + Environment.NewLine
                + "Spetacles4 Location: " + GlobalVar.pictureBox6.Location.X + ", " + GlobalVar.pictureBox6.Location.Y + Environment.NewLine
                + "Displacement x: " + GlobalVar.rsdx3 + " Displacement y: " + GlobalVar.rsdy3 + Environment.NewLine
                + "Spetacles5 Location: " + GlobalVar.pictureBox7.Location.X + ", " + GlobalVar.pictureBox7.Location.Y + Environment.NewLine
                + "Displacement x: " + GlobalVar.rsdx4 + " Displacement y: " + GlobalVar.rsdy4 + Environment.NewLine
                + "Spetacles6 Location: " + GlobalVar.pictureBox8.Location.X + ", " + GlobalVar.pictureBox8.Location.Y + Environment.NewLine
                + "Displacement x: " + GlobalVar.rsdx5 + " Displacement y: " + GlobalVar.rsdy5 + Environment.NewLine
                + "Spetacles7 Location: " + GlobalVar.pictureBox9.Location.X + ", " + GlobalVar.pictureBox9.Location.Y + Environment.NewLine
                + "Displacement x: " + GlobalVar.rsdx6 + " Displacement y: " + GlobalVar.rsdy6 + Environment.NewLine
                + "Spetacles8 Location: " + GlobalVar.pictureBox10.Location.X + ", " + GlobalVar.pictureBox10.Location.Y + Environment.NewLine
                + "Displacement x: " + GlobalVar.rsdx7 + " Displacement y: " + GlobalVar.rsdy7 + Environment.NewLine
                + "Spetacles9 Location: " + GlobalVar.pictureBox11.Location.X + ", " + GlobalVar.pictureBox11.Location.Y + Environment.NewLine
                + "Displacement x: " + GlobalVar.rsdx8 + " Displacement y: " + GlobalVar.rsdy8 + Environment.NewLine
                + "Spetacles10 Location: " + GlobalVar.pictureBox12.Location.X + ", " + GlobalVar.pictureBox12.Location.Y + Environment.NewLine
                + "Displacement x: " + GlobalVar.rsdx9 + " Displacement y: " + GlobalVar.rsdy9;
            label7.Text = "Platform location: " + GlobalVar.pictureBox2.Location.X + ", " + GlobalVar.pictureBox2.Location.Y;
            label8.Text = "Ship location: " + GlobalVar.pictureBox1.Location.X + ", " + GlobalVar.pictureBox1.Location.Y;
            //label6.Text = "Picturebox 1 Bound: " + GlobalVar.pictureBox1.Bounds;
            //label7.Text = "Picturebox 2 Bound: " + GlobalVar.pictureBox2.Bounds;
            //if (GlobalVar.rLander.IntersectsWith(GlobalVar.rPlatform))
            //{
            //    label8.Text = "Ship is landed.";
            //}
        } // end showStats

        public void killShip()
        {
            DialogResult answer;
            GlobalVar.ships--;

            if (GlobalVar.ships <= 0)
            {
                answer = MessageBox.Show("Play Again?", "Game Over", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    GlobalVar.ships = 3;
                    GlobalVar.fuel = 100;
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
            DialogResult answer;
            initLunarRover();
            initPLatform();

            switch (GlobalVar.level)
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
                    answer = MessageBox.Show("You have complete all the level. Do you want to play again?", "Game Over", MessageBoxButtons.YesNo);
                    if (answer == DialogResult.Yes)
                    {
                        GlobalVar.level = 1;
                        initGame();
                    }
                    else
                    {
                        Application.Exit();
                    } // end if
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
            GlobalVar.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            GlobalVar.pictureBox1.Location = new System.Drawing.Point(206, 50);
            GlobalVar.pictureBox1.Name = "GlobalVar.pictureBox1";
            GlobalVar.pictureBox1.Size = new System.Drawing.Size(20, 22);
            GlobalVar.pictureBox1.TabIndex = 0;
            GlobalVar.pictureBox1.TabStop = false;
            GlobalVar.pictureBox1.BackgroundImage = imageList1.Images[0];
            this.panel1.Controls.Add(GlobalVar.pictureBox1);
        }

        public void initPLatform()
        {
            GlobalVar.pictureBox2.Location = new System.Drawing.Point(206, 103);
            GlobalVar.pictureBox2.Name = "GlobalVar.pictureBox2";
            GlobalVar.pictureBox2.Size = new System.Drawing.Size(52, 10);
            GlobalVar.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            GlobalVar.pictureBox2.TabIndex = 1;
            GlobalVar.pictureBox2.TabStop = false;
            GlobalVar.pictureBox2.BackgroundImage = imageList1.Images[1];
            GlobalVar.pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel1.Controls.Add(GlobalVar.pictureBox2);
        }

        public void initFuelAddOn()
        {
            GlobalVar.fuelPic.Location = new System.Drawing.Point(206, 103);
            GlobalVar.fuelPic.Name = "fuelPic";
            GlobalVar.fuelPic.Size = new System.Drawing.Size(20, 22);
            GlobalVar.fuelPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            GlobalVar.fuelPic.TabIndex = 1;
            GlobalVar.fuelPic.TabStop = false;
            GlobalVar.fuelPic.BackgroundImage = imageList1.Images[4];
            GlobalVar.fuelPic.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel1.Controls.Add(GlobalVar.fuelPic);

            Random roller = new Random();

            GlobalVar.aox = Convert.ToDouble(roller.Next(panel1.Width));
            GlobalVar.aoy = Convert.ToDouble(roller.Next(panel1.Height));
            GlobalVar.fuelPic.Location = new Point(Convert.ToInt32(GlobalVar.aox), Convert.ToInt32(GlobalVar.aoy));
        }

        public void initShipAddOn()
        {
            GlobalVar.shipPic.Location = new System.Drawing.Point(206, 103);
            GlobalVar.shipPic.Name = "shipPic";
            GlobalVar.shipPic.Size = new System.Drawing.Size(20, 22);
            GlobalVar.shipPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            GlobalVar.shipPic.TabIndex = 1;
            GlobalVar.shipPic.TabStop = false;
            GlobalVar.shipPic.BackgroundImage = imageList1.Images[5];
            GlobalVar.shipPic.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel1.Controls.Add(GlobalVar.shipPic);

            Random roller = new Random();

            GlobalVar.aox = Convert.ToDouble(roller.Next(panel1.Width));
            GlobalVar.aoy = Convert.ToDouble(roller.Next(panel1.Height));
            GlobalVar.shipPic.Location = new Point(Convert.ToInt32(GlobalVar.aox), Convert.ToInt32(GlobalVar.aoy));
        }

        public void initObstacle1()
        {
            GlobalVar.pictureBox3.Location = new System.Drawing.Point(370, 50);
            GlobalVar.pictureBox3.Name = "GlobalVar.pictureBox3";
            GlobalVar.pictureBox3.Size = new System.Drawing.Size(20, 22);
            GlobalVar.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            GlobalVar.pictureBox3.TabIndex = 10;
            GlobalVar.pictureBox3.TabStop = false;
            GlobalVar.pictureBox3.BackgroundImage = imageList1.Images[2];
            GlobalVar.pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel1.Controls.Add(GlobalVar.pictureBox3);
        }
        public void initObstacle2()
        {
            GlobalVar.pictureBox4.Location = new System.Drawing.Point(370, 50);
            GlobalVar.pictureBox4.Name = "GlobalVar.pictureBox4";
            GlobalVar.pictureBox4.Size = new System.Drawing.Size(20, 22);
            GlobalVar.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            GlobalVar.pictureBox4.TabIndex = 10;
            GlobalVar.pictureBox4.TabStop = false;
            GlobalVar.pictureBox4.BackgroundImage = imageList1.Images[2];
            GlobalVar.pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel1.Controls.Add(GlobalVar.pictureBox4);
        }
        public void initObstacle3()
        {
            GlobalVar.pictureBox5.Location = new System.Drawing.Point(370, 50);
            GlobalVar.pictureBox5.Name = "GlobalVar.pictureBox5";
            GlobalVar.pictureBox5.Size = new System.Drawing.Size(20, 22);
            GlobalVar.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            GlobalVar.pictureBox5.TabIndex = 10;
            GlobalVar.pictureBox5.TabStop = false;
            GlobalVar.pictureBox5.BackgroundImage = imageList1.Images[2];
            GlobalVar.pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel1.Controls.Add(GlobalVar.pictureBox5);
        }
        public void initObstacle4()
        {
            GlobalVar.pictureBox6.Location = new System.Drawing.Point(370, 50);
            GlobalVar.pictureBox6.Name = "GlobalVar.pictureBox6";
            GlobalVar.pictureBox6.Size = new System.Drawing.Size(20, 22);
            GlobalVar.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            GlobalVar.pictureBox6.TabIndex = 10;
            GlobalVar.pictureBox6.TabStop = false;
            GlobalVar.pictureBox6.BackgroundImage = imageList1.Images[2];
            GlobalVar.pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel1.Controls.Add(GlobalVar.pictureBox6);
        }
        public void initObstacle5()
        {
            GlobalVar.pictureBox7.Location = new System.Drawing.Point(370, 50);
            GlobalVar.pictureBox7.Name = "GlobalVar.pictureBox7";
            GlobalVar.pictureBox7.Size = new System.Drawing.Size(20, 22);
            GlobalVar.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            GlobalVar.pictureBox7.TabIndex = 10;
            GlobalVar.pictureBox7.TabStop = false;
            GlobalVar.pictureBox7.BackgroundImage = imageList1.Images[2];
            GlobalVar.pictureBox7.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel1.Controls.Add(GlobalVar.pictureBox7);
        }
        public void initObstacle6()
        {
            GlobalVar.pictureBox8.Location = new System.Drawing.Point(370, 50);
            GlobalVar.pictureBox8.Name = "GlobalVar.pictureBox8";
            GlobalVar.pictureBox8.Size = new System.Drawing.Size(20, 22);
            GlobalVar.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            GlobalVar.pictureBox8.TabIndex = 10;
            GlobalVar.pictureBox8.TabStop = false;
            GlobalVar.pictureBox8.BackgroundImage = imageList1.Images[2];
            GlobalVar.pictureBox8.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel1.Controls.Add(GlobalVar.pictureBox8);
        }
        public void initObstacle7()
        {
            GlobalVar.pictureBox9.Location = new System.Drawing.Point(370, 50);
            GlobalVar.pictureBox9.Name = "GlobalVar.pictureBox9";
            GlobalVar.pictureBox9.Size = new System.Drawing.Size(20, 22);
            GlobalVar.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            GlobalVar.pictureBox9.TabIndex = 10;
            GlobalVar.pictureBox9.TabStop = false;
            GlobalVar.pictureBox9.BackgroundImage = imageList1.Images[2];
            GlobalVar.pictureBox9.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel1.Controls.Add(GlobalVar.pictureBox9);
        }
        public void initObstacle8()
        {
            GlobalVar.pictureBox10.Location = new System.Drawing.Point(370, 50);
            GlobalVar.pictureBox10.Name = "GlobalVar.pictureBox10";
            GlobalVar.pictureBox10.Size = new System.Drawing.Size(20, 22);
            GlobalVar.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            GlobalVar.pictureBox10.TabIndex = 10;
            GlobalVar.pictureBox10.TabStop = false;
            GlobalVar.pictureBox10.BackgroundImage = imageList1.Images[2];
            GlobalVar.pictureBox10.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel1.Controls.Add(GlobalVar.pictureBox10);
        }
        public void initObstacle9()
        {
            GlobalVar.pictureBox11.Location = new System.Drawing.Point(370, 50);
            GlobalVar.pictureBox11.Name = "GlobalVar.pictureBox11";
            GlobalVar.pictureBox11.Size = new System.Drawing.Size(20, 22);
            GlobalVar.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            GlobalVar.pictureBox11.TabIndex = 10;
            GlobalVar.pictureBox11.TabStop = false;
            GlobalVar.pictureBox11.BackgroundImage = imageList1.Images[2];
            GlobalVar.pictureBox11.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel1.Controls.Add(GlobalVar.pictureBox11);
        }
        public void initObstacle10()
        {
            GlobalVar.pictureBox12.Location = new System.Drawing.Point(370, 50);
            GlobalVar.pictureBox12.Name = "GlobalVar.pictureBox12";
            GlobalVar.pictureBox12.Size = new System.Drawing.Size(20, 22);
            GlobalVar.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            GlobalVar.pictureBox12.TabIndex = 10;
            GlobalVar.pictureBox12.TabStop = false;
            GlobalVar.pictureBox12.BackgroundImage = imageList1.Images[2];
            GlobalVar.pictureBox12.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel1.Controls.Add(GlobalVar.pictureBox12);
        }

        public void initLvlOne()
        {
            Random roller = new Random();
            int platX, platY; // platform location points.

            GlobalVar.dx = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.dy = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.x = Convert.ToDouble(roller.Next(panel1.Width));
            GlobalVar.y = Convert.ToDouble(roller.Next(panel1.Height));

            platX = roller.Next(panel1.Width - GlobalVar.pictureBox2.Width);
            platY = roller.Next(panel1.Height - GlobalVar.pictureBox2.Height);
            GlobalVar.pictureBox2.Location = new Point(platX, platY);

            GlobalVar.pictureBox3.Visible = false;
            GlobalVar.pictureBox4.Visible = false;
            GlobalVar.pictureBox5.Visible = false;
            GlobalVar.pictureBox6.Visible = false;
            GlobalVar.pictureBox7.Visible = false;
            GlobalVar.pictureBox8.Visible = false;
            GlobalVar.pictureBox9.Visible = false;
            GlobalVar.pictureBox10.Visible = false;
            GlobalVar.pictureBox11.Visible = false;
            GlobalVar.pictureBox12.Visible = false;
        }
        public void initLvlTwo()
        {
            Random roller = new Random();
            int platX, platY; // platform location points.
            int speX, speY; // obstacle location points.

            GlobalVar.dx = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.dy = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.x = Convert.ToDouble(roller.Next(panel1.Width));
            GlobalVar.y = Convert.ToDouble(roller.Next(panel1.Height));

            platX = roller.Next(panel1.Width - GlobalVar.pictureBox2.Width);
            platY = roller.Next(panel1.Height - GlobalVar.pictureBox2.Height);
            GlobalVar.pictureBox2.Location = new Point(platX, platY);

            GlobalVar.rsdx = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox3.Width));
            GlobalVar.rsy = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox3.Height));
            speX = roller.Next(panel1.Width - GlobalVar.pictureBox3.Width);
            speY = roller.Next(panel1.Height - GlobalVar.pictureBox3.Height);
            GlobalVar.pictureBox3.Location = new Point(speX, speY);
            GlobalVar.pictureBox3.Visible = true;
            GlobalVar.pictureBox4.Visible = false;
            GlobalVar.pictureBox5.Visible = false;
            GlobalVar.pictureBox6.Visible = false;
            GlobalVar.pictureBox7.Visible = false;
            GlobalVar.pictureBox8.Visible = false;
            GlobalVar.pictureBox9.Visible = false;
            GlobalVar.pictureBox10.Visible = false;
            GlobalVar.pictureBox11.Visible = false;
            GlobalVar.pictureBox12.Visible = false;
        }
        public void initLvlThree()
        {
            Random roller = new Random();
            int platX, platY; // platform location points.
            int speX, speY, speX1, speY1; // obstacle location points.

            GlobalVar.dx = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.dy = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.x = Convert.ToDouble(roller.Next(panel1.Width));
            GlobalVar.y = Convert.ToDouble(roller.Next(panel1.Height));

            platX = roller.Next(panel1.Width - GlobalVar.pictureBox2.Width);
            platY = roller.Next(panel1.Height - GlobalVar.pictureBox2.Height);
            GlobalVar.pictureBox2.Location = new Point(platX, platY);

            GlobalVar.rsdx = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox3.Width));
            GlobalVar.rsy = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox3.Height));
            speX = roller.Next(panel1.Width - GlobalVar.pictureBox3.Width);
            speY = roller.Next(panel1.Height - GlobalVar.pictureBox3.Height);
            GlobalVar.pictureBox3.Location = new Point(speX, speY);
            GlobalVar.pictureBox3.Visible = true;

            GlobalVar.rsdx1 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy1 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx1 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox4.Width));
            GlobalVar.rsy1 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox4.Height));
            speX1 = roller.Next(panel1.Width - GlobalVar.pictureBox4.Width);
            speY1 = roller.Next(panel1.Height - GlobalVar.pictureBox4.Height);
            GlobalVar.pictureBox4.Location = new Point(speX1, speY1);
            //GlobalVar.pictureBox4.BackgroundImage = imageList1.Images[3];
            //GlobalVar.pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox4.Visible = true;
            GlobalVar.pictureBox5.Visible = false;
        }
        public void initLvlFour()
        {
            Random roller = new Random();
            int platX, platY; // platform location points.
            int speX, speY, speX1, speY1, speX2, speY2; // obstacle location points.

            GlobalVar.dx = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.dy = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.x = Convert.ToDouble(roller.Next(panel1.Width));
            GlobalVar.y = Convert.ToDouble(roller.Next(panel1.Height));

            platX = roller.Next(panel1.Width - GlobalVar.pictureBox2.Width);
            platY = roller.Next(panel1.Height - GlobalVar.pictureBox2.Height);
            GlobalVar.pictureBox2.Location = new Point(platX, platY);

            GlobalVar.rsdx = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox3.Width));
            GlobalVar.rsy = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox3.Height));
            speX = roller.Next(panel1.Width - GlobalVar.pictureBox3.Width);
            speY = roller.Next(panel1.Height - GlobalVar.pictureBox3.Height);
            GlobalVar.pictureBox3.Location = new Point(speX, speY);
            GlobalVar.pictureBox3.Visible = true;

            GlobalVar.rsdx1 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy1 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx1 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox4.Width));
            GlobalVar.rsy1 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox4.Height));
            speX1 = roller.Next(panel1.Width - GlobalVar.pictureBox4.Width);
            speY1 = roller.Next(panel1.Height - GlobalVar.pictureBox4.Height);
            GlobalVar.pictureBox4.Location = new Point(speX1, speY1);
            //GlobalVar.pictureBox4.BackgroundImage = imageList1.Images[3];
            //GlobalVar.pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox4.Visible = true;

            GlobalVar.rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx2 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox5.Width));
            GlobalVar.rsy2 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox5.Height));
            speX2 = roller.Next(panel1.Width - GlobalVar.pictureBox5.Width);
            speY2 = roller.Next(panel1.Height - GlobalVar.pictureBox5.Height);
            GlobalVar.pictureBox5.Location = new Point(speX2, speY2);
            //GlobalVar.pictureBox5.BackgroundImage = imageList1.Images[4];
            //GlobalVar.pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox5.Visible = true;
            GlobalVar.pictureBox6.Visible = false;
            GlobalVar.pictureBox7.Visible = false;
            GlobalVar.pictureBox8.Visible = false;
            GlobalVar.pictureBox9.Visible = false;
            GlobalVar.pictureBox10.Visible = false;
            GlobalVar.pictureBox11.Visible = false;
            GlobalVar.pictureBox12.Visible = false;
        }
        public void initLvlFive()
        {
            Random roller = new Random();
            int platX, platY; // platform location points.
            int speX, speY, speX1, speY1, speX2, speY2, speX3, speY3; // obstacle location points.

            GlobalVar.dx = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.dy = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.x = Convert.ToDouble(roller.Next(panel1.Width));
            GlobalVar.y = Convert.ToDouble(roller.Next(panel1.Height));

            platX = roller.Next(panel1.Width - GlobalVar.pictureBox2.Width);
            platY = roller.Next(panel1.Height - GlobalVar.pictureBox2.Height);
            GlobalVar.pictureBox2.Location = new Point(platX, platY);

            GlobalVar.rsdx = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox3.Width));
            GlobalVar.rsy = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox3.Height));
            speX = roller.Next(panel1.Width - GlobalVar.pictureBox3.Width);
            speY = roller.Next(panel1.Height - GlobalVar.pictureBox3.Height);
            GlobalVar.pictureBox3.Location = new Point(speX, speY);
            GlobalVar.pictureBox3.Visible = true;

            GlobalVar.rsdx1 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy1 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx1 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox4.Width));
            GlobalVar.rsy1 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox4.Height));
            speX1 = roller.Next(panel1.Width - GlobalVar.pictureBox4.Width);
            speY1 = roller.Next(panel1.Height - GlobalVar.pictureBox4.Height);
            GlobalVar.pictureBox4.Location = new Point(speX1, speY1);
            //GlobalVar.pictureBox4.BackgroundImage = imageList1.Images[3];
            //GlobalVar.pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox4.Visible = true;

            GlobalVar.rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx2 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox5.Width));
            GlobalVar.rsy2 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox5.Height));
            speX2 = roller.Next(panel1.Width - GlobalVar.pictureBox5.Width);
            speY2 = roller.Next(panel1.Height - GlobalVar.pictureBox5.Height);
            GlobalVar.pictureBox5.Location = new Point(speX2, speY2);
            //GlobalVar.pictureBox5.BackgroundImage = imageList1.Images[4];
            //GlobalVar.pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox5.Visible = true;

            GlobalVar.rsdx3 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy3 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx3 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox6.Width));
            GlobalVar.rsy3 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox6.Height));
            speX3 = roller.Next(panel1.Width - GlobalVar.pictureBox6.Width);
            speY3 = roller.Next(panel1.Height - GlobalVar.pictureBox6.Height);
            GlobalVar.pictureBox6.Location = new Point(speX3, speY3);
            //GlobalVar.pictureBox6.BackgroundImage = imageList1.Images[5];
            //GlobalVar.pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox6.Visible = true;

            GlobalVar.pictureBox7.Visible = false;
            GlobalVar.pictureBox8.Visible = false;
            GlobalVar.pictureBox9.Visible = false;
            GlobalVar.pictureBox10.Visible = false;
            GlobalVar.pictureBox11.Visible = false;
            GlobalVar.pictureBox12.Visible = false;
        }
        public void initLvlSix()
        {
            Random roller = new Random();
            int platX, platY; // platform location points.
            int speX, speY, speX1, speY1, speX2, speY2, speX3, speY3, speX4, speY4; // obstacle location points.

            GlobalVar.dx = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.dy = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.x = Convert.ToDouble(roller.Next(panel1.Width));
            GlobalVar.y = Convert.ToDouble(roller.Next(panel1.Height));

            platX = roller.Next(panel1.Width - GlobalVar.pictureBox2.Width);
            platY = roller.Next(panel1.Height - GlobalVar.pictureBox2.Height);
            GlobalVar.pictureBox2.Location = new Point(platX, platY);

            GlobalVar.rsdx = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox3.Width));
            GlobalVar.rsy = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox3.Height));
            speX = roller.Next(panel1.Width - GlobalVar.pictureBox3.Width);
            speY = roller.Next(panel1.Height - GlobalVar.pictureBox3.Height);
            GlobalVar.pictureBox3.Location = new Point(speX, speY);
            GlobalVar.pictureBox3.Visible = true;

            GlobalVar.rsdx1 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy1 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx1 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox4.Width));
            GlobalVar.rsy1 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox4.Height));
            speX1 = roller.Next(panel1.Width - GlobalVar.pictureBox4.Width);
            speY1 = roller.Next(panel1.Height - GlobalVar.pictureBox4.Height);
            GlobalVar.pictureBox4.Location = new Point(speX1, speY1);
            //GlobalVar.pictureBox4.BackgroundImage = imageList1.Images[3];
            //GlobalVar.pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox4.Visible = true;

            GlobalVar.rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx2 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox5.Width));
            GlobalVar.rsy2 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox5.Height));
            speX2 = roller.Next(panel1.Width - GlobalVar.pictureBox5.Width);
            speY2 = roller.Next(panel1.Height - GlobalVar.pictureBox5.Height);
            GlobalVar.pictureBox5.Location = new Point(speX2, speY2);
            //GlobalVar.pictureBox5.BackgroundImage = imageList1.Images[4];
            //GlobalVar.pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox5.Visible = true;

            GlobalVar.rsdx3 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy3 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx3 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox6.Width));
            GlobalVar.rsy3 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox6.Height));
            speX3 = roller.Next(panel1.Width - GlobalVar.pictureBox6.Width);
            speY3 = roller.Next(panel1.Height - GlobalVar.pictureBox6.Height);
            GlobalVar.pictureBox6.Location = new Point(speX3, speY3);
            //GlobalVar.pictureBox6.BackgroundImage = imageList1.Images[5];
            //GlobalVar.pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox6.Visible = true;

            GlobalVar.rsdx4 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy4 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx4 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox7.Width));
            GlobalVar.rsy4 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox7.Height));
            speX4 = roller.Next(panel1.Width - GlobalVar.pictureBox7.Width);
            speY4 = roller.Next(panel1.Height - GlobalVar.pictureBox7.Height);
            GlobalVar.pictureBox7.Location = new Point(speX4, speY4);
            //GlobalVar.pictureBox7.BackgroundImage = imageList1.Images[6];
            //GlobalVar.pictureBox7.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox7.Visible = true;

            GlobalVar.pictureBox8.Visible = false;
            GlobalVar.pictureBox9.Visible = false;
            GlobalVar.pictureBox10.Visible = false;
            GlobalVar.pictureBox11.Visible = false;
            GlobalVar.pictureBox12.Visible = false;
        }
        public void initLvlSeven()
        {
            Random roller = new Random();
            int platX, platY; // platform location points.
            int speX, speY, speX1, speY1, speX2, speY2, speX3, speY3, speX4, speY4, speX5, speY5; // obstacle location points.

            GlobalVar.dx = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.dy = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.x = Convert.ToDouble(roller.Next(panel1.Width));
            GlobalVar.y = Convert.ToDouble(roller.Next(panel1.Height));

            platX = roller.Next(panel1.Width - GlobalVar.pictureBox2.Width);
            platY = roller.Next(panel1.Height - GlobalVar.pictureBox2.Height);
            GlobalVar.pictureBox2.Location = new Point(platX, platY);

            GlobalVar.rsdx = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox3.Width));
            GlobalVar.rsy = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox3.Height));
            speX = roller.Next(panel1.Width - GlobalVar.pictureBox3.Width);
            speY = roller.Next(panel1.Height - GlobalVar.pictureBox3.Height);
            GlobalVar.pictureBox3.Location = new Point(speX, speY);
            GlobalVar.pictureBox3.Visible = true;

            GlobalVar.rsdx1 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy1 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx1 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox4.Width));
            GlobalVar.rsy1 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox4.Height));
            speX1 = roller.Next(panel1.Width - GlobalVar.pictureBox4.Width);
            speY1 = roller.Next(panel1.Height - GlobalVar.pictureBox4.Height);
            GlobalVar.pictureBox4.Location = new Point(speX1, speY1);
            //GlobalVar.pictureBox4.BackgroundImage = imageList1.Images[3];
            //GlobalVar.pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox4.Visible = true;

            GlobalVar.rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx2 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox5.Width));
            GlobalVar.rsy2 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox5.Height));
            speX2 = roller.Next(panel1.Width - GlobalVar.pictureBox5.Width);
            speY2 = roller.Next(panel1.Height - GlobalVar.pictureBox5.Height);
            GlobalVar.pictureBox5.Location = new Point(speX2, speY2);
            //GlobalVar.pictureBox5.BackgroundImage = imageList1.Images[4];
            //GlobalVar.pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox5.Visible = true;

            GlobalVar.rsdx3 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy3 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx3 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox6.Width));
            GlobalVar.rsy3 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox6.Height));
            speX3 = roller.Next(panel1.Width - GlobalVar.pictureBox6.Width);
            speY3 = roller.Next(panel1.Height - GlobalVar.pictureBox6.Height);
            GlobalVar.pictureBox6.Location = new Point(speX3, speY3);
            //GlobalVar.pictureBox6.BackgroundImage = imageList1.Images[5];
            //GlobalVar.pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox6.Visible = true;

            GlobalVar.rsdx4 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy4 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx4 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox7.Width));
            GlobalVar.rsy4 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox7.Height));
            speX4 = roller.Next(panel1.Width - GlobalVar.pictureBox7.Width);
            speY4 = roller.Next(panel1.Height - GlobalVar.pictureBox7.Height);
            GlobalVar.pictureBox7.Location = new Point(speX4, speY4);
            //GlobalVar.pictureBox7.BackgroundImage = imageList1.Images[6];
            //GlobalVar.pictureBox7.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox7.Visible = true;

            GlobalVar.rsdx5 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy5 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx5 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox8.Width));
            GlobalVar.rsy5 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox8.Height));
            speX5 = roller.Next(panel1.Width - GlobalVar.pictureBox8.Width);
            speY5 = roller.Next(panel1.Height - GlobalVar.pictureBox8.Height);
            GlobalVar.pictureBox8.Location = new Point(speX5, speY5);
            //GlobalVar.pictureBox8.BackgroundImage = imageList1.Images[7];
            //GlobalVar.pictureBox8.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox8.Visible = true;

            GlobalVar.pictureBox9.Visible = false;
            GlobalVar.pictureBox10.Visible = false;
            GlobalVar.pictureBox11.Visible = false;
            GlobalVar.pictureBox12.Visible = false;
        }
        public void initLvlEight()
        {
            Random roller = new Random();
            int platX, platY; // platform location points.
            int speX, speY, speX1, speY1, speX2, speY2, speX3, speY3, speX4, speY4, speX5, speY5, speX6, speY6; // obstacle location points.

            GlobalVar.dx = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.dy = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.x = Convert.ToDouble(roller.Next(panel1.Width));
            GlobalVar.y = Convert.ToDouble(roller.Next(panel1.Height));

            platX = roller.Next(panel1.Width - GlobalVar.pictureBox2.Width);
            platY = roller.Next(panel1.Height - GlobalVar.pictureBox2.Height);
            GlobalVar.pictureBox2.Location = new Point(platX, platY);

            GlobalVar.rsdx = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox3.Width));
            GlobalVar.rsy = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox3.Height));
            speX = roller.Next(panel1.Width - GlobalVar.pictureBox3.Width);
            speY = roller.Next(panel1.Height - GlobalVar.pictureBox3.Height);
            GlobalVar.pictureBox3.Location = new Point(speX, speY);
            GlobalVar.pictureBox3.Visible = true;

            GlobalVar.rsdx1 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy1 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx1 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox4.Width));
            GlobalVar.rsy1 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox4.Height));
            speX1 = roller.Next(panel1.Width - GlobalVar.pictureBox4.Width);
            speY1 = roller.Next(panel1.Height - GlobalVar.pictureBox4.Height);
            GlobalVar.pictureBox4.Location = new Point(speX1, speY1);
            //GlobalVar.pictureBox4.BackgroundImage = imageList1.Images[3];
            //GlobalVar.pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox4.Visible = true;

            GlobalVar.rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx2 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox5.Width));
            GlobalVar.rsy2 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox5.Height));
            speX2 = roller.Next(panel1.Width - GlobalVar.pictureBox5.Width);
            speY2 = roller.Next(panel1.Height - GlobalVar.pictureBox5.Height);
            GlobalVar.pictureBox5.Location = new Point(speX2, speY2);
            //GlobalVar.pictureBox5.BackgroundImage = imageList1.Images[4];
            //GlobalVar.pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox5.Visible = true;

            GlobalVar.rsdx3 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy3 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx3 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox6.Width));
            GlobalVar.rsy3 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox6.Height));
            speX3 = roller.Next(panel1.Width - GlobalVar.pictureBox6.Width);
            speY3 = roller.Next(panel1.Height - GlobalVar.pictureBox6.Height);
            GlobalVar.pictureBox6.Location = new Point(speX3, speY3);
            //GlobalVar.pictureBox6.BackgroundImage = imageList1.Images[5];
            //GlobalVar.pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox6.Visible = true;

            GlobalVar.rsdx4 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy4 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx4 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox7.Width));
            GlobalVar.rsy4 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox7.Height));
            speX4 = roller.Next(panel1.Width - GlobalVar.pictureBox7.Width);
            speY4 = roller.Next(panel1.Height - GlobalVar.pictureBox7.Height);
            GlobalVar.pictureBox7.Location = new Point(speX4, speY4);
            //GlobalVar.pictureBox7.BackgroundImage = imageList1.Images[6];
            //GlobalVar.pictureBox7.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox7.Visible = true;

            GlobalVar.rsdx5 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy5 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx5 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox8.Width));
            GlobalVar.rsy5 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox8.Height));
            speX5 = roller.Next(panel1.Width - GlobalVar.pictureBox8.Width);
            speY5 = roller.Next(panel1.Height - GlobalVar.pictureBox8.Height);
            GlobalVar.pictureBox8.Location = new Point(speX5, speY5);
            //GlobalVar.pictureBox8.BackgroundImage = imageList1.Images[7];
            //GlobalVar.pictureBox8.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox8.Visible = true;

            GlobalVar.rsdx6 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy6 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx6 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox9.Width));
            GlobalVar.rsy6 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox9.Height));
            speX6 = roller.Next(panel1.Width - GlobalVar.pictureBox9.Width);
            speY6 = roller.Next(panel1.Height - GlobalVar.pictureBox9.Height);
            GlobalVar.pictureBox9.Location = new Point(speX6, speY6);
            //GlobalVar.pictureBox9.BackgroundImage = imageList1.Images[8];
            //GlobalVar.pictureBox9.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox9.Visible = true;

            GlobalVar.pictureBox10.Visible = false;
            GlobalVar.pictureBox11.Visible = false;
            GlobalVar.pictureBox12.Visible = false;
        }
        public void initLvlNine()
        {
            Random roller = new Random();
            int platX, platY; // platform location points.
            int speX, speY, speX1, speY1, speX2, speY2, speX3, speY3, speX4, speY4, speX5, speY5, speX6, speY6, speX7, speY7; // obstacle location points.

            GlobalVar.dx = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.dy = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.x = Convert.ToDouble(roller.Next(panel1.Width));
            GlobalVar.y = Convert.ToDouble(roller.Next(panel1.Height));

            platX = roller.Next(panel1.Width - GlobalVar.pictureBox2.Width);
            platY = roller.Next(panel1.Height - GlobalVar.pictureBox2.Height);
            GlobalVar.pictureBox2.Location = new Point(platX, platY);

            GlobalVar.rsdx = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox3.Width));
            GlobalVar.rsy = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox3.Height));
            speX = roller.Next(panel1.Width - GlobalVar.pictureBox3.Width);
            speY = roller.Next(panel1.Height - GlobalVar.pictureBox3.Height);
            GlobalVar.pictureBox3.Location = new Point(speX, speY);
            GlobalVar.pictureBox3.Visible = true;

            GlobalVar.rsdx1 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy1 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx1 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox4.Width));
            GlobalVar.rsy1 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox4.Height));
            speX1 = roller.Next(panel1.Width - GlobalVar.pictureBox4.Width);
            speY1 = roller.Next(panel1.Height - GlobalVar.pictureBox4.Height);
            GlobalVar.pictureBox4.Location = new Point(speX1, speY1);
            //GlobalVar.pictureBox4.BackgroundImage = imageList1.Images[3];
            //GlobalVar.pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox4.Visible = true;

            GlobalVar.rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx2 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox5.Width));
            GlobalVar.rsy2 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox5.Height));
            speX2 = roller.Next(panel1.Width - GlobalVar.pictureBox5.Width);
            speY2 = roller.Next(panel1.Height - GlobalVar.pictureBox5.Height);
            GlobalVar.pictureBox5.Location = new Point(speX2, speY2);
            //GlobalVar.pictureBox5.BackgroundImage = imageList1.Images[4];
            //GlobalVar.pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox5.Visible = true;

            GlobalVar.rsdx3 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy3 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx3 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox6.Width));
            GlobalVar.rsy3 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox6.Height));
            speX3 = roller.Next(panel1.Width - GlobalVar.pictureBox6.Width);
            speY3 = roller.Next(panel1.Height - GlobalVar.pictureBox6.Height);
            GlobalVar.pictureBox6.Location = new Point(speX3, speY3);
            //GlobalVar.pictureBox6.BackgroundImage = imageList1.Images[5];
            //GlobalVar.pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox6.Visible = true;

            GlobalVar.rsdx4 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy4 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx4 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox7.Width));
            GlobalVar.rsy4 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox7.Height));
            speX4 = roller.Next(panel1.Width - GlobalVar.pictureBox7.Width);
            speY4 = roller.Next(panel1.Height - GlobalVar.pictureBox7.Height);
            GlobalVar.pictureBox7.Location = new Point(speX4, speY4);
            //GlobalVar.pictureBox7.BackgroundImage = imageList1.Images[6];
            //GlobalVar.pictureBox7.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox7.Visible = true;

            GlobalVar.rsdx5 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy5 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx5 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox8.Width));
            GlobalVar.rsy5 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox8.Height));
            speX5 = roller.Next(panel1.Width - GlobalVar.pictureBox8.Width);
            speY5 = roller.Next(panel1.Height - GlobalVar.pictureBox8.Height);
            GlobalVar.pictureBox8.Location = new Point(speX5, speY5);
            //GlobalVar.pictureBox8.BackgroundImage = imageList1.Images[7];
            //GlobalVar.pictureBox8.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox8.Visible = true;

            GlobalVar.rsdx6 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy6 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx6 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox9.Width));
            GlobalVar.rsy6 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox9.Height));
            speX6 = roller.Next(panel1.Width - GlobalVar.pictureBox9.Width);
            speY6 = roller.Next(panel1.Height - GlobalVar.pictureBox9.Height);
            GlobalVar.pictureBox9.Location = new Point(speX6, speY6);
            //GlobalVar.pictureBox9.BackgroundImage = imageList1.Images[8];
            //GlobalVar.pictureBox9.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox9.Visible = true;

            GlobalVar.rsdx7 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy7 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx7 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox10.Width));
            GlobalVar.rsy7 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox10.Height));
            speX7 = roller.Next(panel1.Width - GlobalVar.pictureBox10.Width);
            speY7 = roller.Next(panel1.Height - GlobalVar.pictureBox10.Height);
            GlobalVar.pictureBox10.Location = new Point(speX7, speY7);
            //GlobalVar.pictureBox10.BackgroundImage = imageList1.Images[9];
            //GlobalVar.pictureBox10.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox10.Visible = true;

            GlobalVar.pictureBox11.Visible = false;
            GlobalVar.pictureBox12.Visible = false;
        }
        public void initLvlTen()
        {
            Random roller = new Random();
            int platX, platY; // platform location points.
            int speX, speY, speX1, speY1, speX2, speY2, speX3, speY3, speX4, speY4, speX5, speY5, speX6, speY6, speX7, speY7, speX8, speY8; // obstacle location points.

            GlobalVar.dx = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.dy = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.x = Convert.ToDouble(roller.Next(panel1.Width));
            GlobalVar.y = Convert.ToDouble(roller.Next(panel1.Height));

            platX = roller.Next(panel1.Width - GlobalVar.pictureBox2.Width);
            platY = roller.Next(panel1.Height - GlobalVar.pictureBox2.Height);
            GlobalVar.pictureBox2.Location = new Point(platX, platY);

            GlobalVar.rsdx = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox3.Width));
            GlobalVar.rsy = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox3.Height));
            speX = roller.Next(panel1.Width - GlobalVar.pictureBox3.Width);
            speY = roller.Next(panel1.Height - GlobalVar.pictureBox3.Height);
            GlobalVar.pictureBox3.Location = new Point(speX, speY);
            GlobalVar.pictureBox3.Visible = true;

            GlobalVar.rsdx1 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy1 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx1 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox4.Width));
            GlobalVar.rsy1 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox4.Height));
            speX1 = roller.Next(panel1.Width - GlobalVar.pictureBox4.Width);
            speY1 = roller.Next(panel1.Height - GlobalVar.pictureBox4.Height);
            GlobalVar.pictureBox4.Location = new Point(speX1, speY1);
            //GlobalVar.pictureBox4.BackgroundImage = imageList1.Images[3];
            //GlobalVar.pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox4.Visible = true;

            GlobalVar.rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx2 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox5.Width));
            GlobalVar.rsy2 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox5.Height));
            speX2 = roller.Next(panel1.Width - GlobalVar.pictureBox5.Width);
            speY2 = roller.Next(panel1.Height - GlobalVar.pictureBox5.Height);
            GlobalVar.pictureBox5.Location = new Point(speX2, speY2);
            //GlobalVar.pictureBox5.BackgroundImage = imageList1.Images[4];
            //GlobalVar.pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox5.Visible = true;

            GlobalVar.rsdx3 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy3 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx3 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox6.Width));
            GlobalVar.rsy3 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox6.Height));
            speX3 = roller.Next(panel1.Width - GlobalVar.pictureBox6.Width);
            speY3 = roller.Next(panel1.Height - GlobalVar.pictureBox6.Height);
            GlobalVar.pictureBox6.Location = new Point(speX3, speY3);
            //GlobalVar.pictureBox6.BackgroundImage = imageList1.Images[5];
            //GlobalVar.pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox6.Visible = true;

            GlobalVar.rsdx4 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy4 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx4 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox7.Width));
            GlobalVar.rsy4 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox7.Height));
            speX4 = roller.Next(panel1.Width - GlobalVar.pictureBox7.Width);
            speY4 = roller.Next(panel1.Height - GlobalVar.pictureBox7.Height);
            GlobalVar.pictureBox7.Location = new Point(speX4, speY4);
            //GlobalVar.pictureBox7.BackgroundImage = imageList1.Images[6];
            //GlobalVar.pictureBox7.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox7.Visible = true;

            GlobalVar.rsdx5 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy5 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx5 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox8.Width));
            GlobalVar.rsy5 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox8.Height));
            speX5 = roller.Next(panel1.Width - GlobalVar.pictureBox8.Width);
            speY5 = roller.Next(panel1.Height - GlobalVar.pictureBox8.Height);
            GlobalVar.pictureBox8.Location = new Point(speX5, speY5);
            //GlobalVar.pictureBox8.BackgroundImage = imageList1.Images[7];
            //GlobalVar.pictureBox8.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox8.Visible = true;

            GlobalVar.rsdx6 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy6 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx6 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox9.Width));
            GlobalVar.rsy6 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox9.Height));
            speX6 = roller.Next(panel1.Width - GlobalVar.pictureBox9.Width);
            speY6 = roller.Next(panel1.Height - GlobalVar.pictureBox9.Height);
            GlobalVar.pictureBox9.Location = new Point(speX6, speY6);
            //GlobalVar.pictureBox9.BackgroundImage = imageList1.Images[8];
            //GlobalVar.pictureBox9.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox9.Visible = true;

            GlobalVar.rsdx7 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy7 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx7 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox10.Width));
            GlobalVar.rsy7 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox10.Height));
            speX7 = roller.Next(panel1.Width - GlobalVar.pictureBox10.Width);
            speY7 = roller.Next(panel1.Height - GlobalVar.pictureBox10.Height);
            GlobalVar.pictureBox10.Location = new Point(speX7, speY7);
            //GlobalVar.pictureBox10.BackgroundImage = imageList1.Images[9];
            //GlobalVar.pictureBox10.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox10.Visible = true;

            GlobalVar.rsdx8 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy8 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx8 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox11.Width));
            GlobalVar.rsy8 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox11.Height));
            speX8 = roller.Next(panel1.Width - GlobalVar.pictureBox11.Width);
            speY8 = roller.Next(panel1.Height - GlobalVar.pictureBox11.Height);
            GlobalVar.pictureBox11.Location = new Point(speX8, speY8);
            //GlobalVar.pictureBox11.BackgroundImage = imageList1.Images[10];
            //GlobalVar.pictureBox11.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox11.Visible = true;

            GlobalVar.pictureBox12.Visible = false;
        }
        public void initLvlEleven()
        {
            Random roller = new Random();
            int platX, platY; // platform location points.
            int speX, speY, speX1, speY1, speX2, speY2, speX3, speY3, speX4, speY4, speX5, speY5, speX6, speY6, speX7, speY7, speX8, speY8, speX9, speY9; // obstacle location points.

            GlobalVar.dx = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.dy = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.x = Convert.ToDouble(roller.Next(panel1.Width));
            GlobalVar.y = Convert.ToDouble(roller.Next(panel1.Height));

            platX = roller.Next(panel1.Width - GlobalVar.pictureBox2.Width);
            platY = roller.Next(panel1.Height - GlobalVar.pictureBox2.Height);
            GlobalVar.pictureBox2.Location = new Point(platX, platY);

            GlobalVar.rsdx = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox3.Width));
            GlobalVar.rsy = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox3.Height));
            speX = roller.Next(panel1.Width - GlobalVar.pictureBox3.Width);
            speY = roller.Next(panel1.Height - GlobalVar.pictureBox3.Height);
            GlobalVar.pictureBox3.Location = new Point(speX, speY);
            GlobalVar.pictureBox3.Visible = true;

            GlobalVar.rsdx1 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy1 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx1 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox4.Width));
            GlobalVar.rsy1 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox4.Height));
            speX1 = roller.Next(panel1.Width - GlobalVar.pictureBox4.Width);
            speY1 = roller.Next(panel1.Height - GlobalVar.pictureBox4.Height);
            GlobalVar.pictureBox4.Location = new Point(speX1, speY1);
            //GlobalVar.pictureBox4.BackgroundImage = imageList1.Images[3];
            //GlobalVar.pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox4.Visible = true;

            GlobalVar.rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx2 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox5.Width));
            GlobalVar.rsy2 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox5.Height));
            speX2 = roller.Next(panel1.Width - GlobalVar.pictureBox5.Width);
            speY2 = roller.Next(panel1.Height - GlobalVar.pictureBox5.Height);
            GlobalVar.pictureBox5.Location = new Point(speX2, speY2);
            //GlobalVar.pictureBox5.BackgroundImage = imageList1.Images[4];
            //GlobalVar.pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox5.Visible = true;

            GlobalVar.rsdx3 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy3 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx3 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox6.Width));
            GlobalVar.rsy3 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox6.Height));
            speX3 = roller.Next(panel1.Width - GlobalVar.pictureBox6.Width);
            speY3 = roller.Next(panel1.Height - GlobalVar.pictureBox6.Height);
            GlobalVar.pictureBox6.Location = new Point(speX3, speY3);
            //GlobalVar.pictureBox6.BackgroundImage = imageList1.Images[5];
            //GlobalVar.pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox6.Visible = true;

            GlobalVar.rsdx4 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy4 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx4 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox7.Width));
            GlobalVar.rsy4 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox7.Height));
            speX4 = roller.Next(panel1.Width - GlobalVar.pictureBox7.Width);
            speY4 = roller.Next(panel1.Height - GlobalVar.pictureBox7.Height);
            GlobalVar.pictureBox7.Location = new Point(speX4, speY4);
            //GlobalVar.pictureBox7.BackgroundImage = imageList1.Images[6];
            //GlobalVar.pictureBox7.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox7.Visible = true;

            GlobalVar.rsdx5 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy5 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx5 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox8.Width));
            GlobalVar.rsy5 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox8.Height));
            speX5 = roller.Next(panel1.Width - GlobalVar.pictureBox8.Width);
            speY5 = roller.Next(panel1.Height - GlobalVar.pictureBox8.Height);
            GlobalVar.pictureBox8.Location = new Point(speX5, speY5);
            //GlobalVar.pictureBox8.BackgroundImage = imageList1.Images[7];
            //GlobalVar.pictureBox8.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox8.Visible = true;

            GlobalVar.rsdx6 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy6 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx6 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox9.Width));
            GlobalVar.rsy6 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox9.Height));
            speX6 = roller.Next(panel1.Width - GlobalVar.pictureBox9.Width);
            speY6 = roller.Next(panel1.Height - GlobalVar.pictureBox9.Height);
            GlobalVar.pictureBox9.Location = new Point(speX6, speY6);
            //GlobalVar.pictureBox9.BackgroundImage = imageList1.Images[8];
            //GlobalVar.pictureBox9.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox9.Visible = true;

            GlobalVar.rsdx7 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy7 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx7 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox10.Width));
            GlobalVar.rsy7 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox10.Height));
            speX7 = roller.Next(panel1.Width - GlobalVar.pictureBox10.Width);
            speY7 = roller.Next(panel1.Height - GlobalVar.pictureBox10.Height);
            GlobalVar.pictureBox10.Location = new Point(speX7, speY7);
            //GlobalVar.pictureBox10.BackgroundImage = imageList1.Images[9];
            //GlobalVar.pictureBox10.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox10.Visible = true;

            GlobalVar.rsdx8 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy8 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx8 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox11.Width));
            GlobalVar.rsy8 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox11.Height));
            speX8 = roller.Next(panel1.Width - GlobalVar.pictureBox11.Width);
            speY8 = roller.Next(panel1.Height - GlobalVar.pictureBox11.Height);
            GlobalVar.pictureBox11.Location = new Point(speX8, speY8);
            //GlobalVar.pictureBox11.BackgroundImage = imageList1.Images[10];
            //GlobalVar.pictureBox11.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox11.Visible = true;

            GlobalVar.rsdx9 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy9 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx9 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox12.Width));
            GlobalVar.rsy9 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox12.Height));
            speX9 = roller.Next(panel1.Width - GlobalVar.pictureBox12.Width);
            speY9 = roller.Next(panel1.Height - GlobalVar.pictureBox12.Height);
            GlobalVar.pictureBox12.Location = new Point(speX9, speY9);
            //GlobalVar.pictureBox12.BackgroundImage = imageList1.Images[11];
            //GlobalVar.pictureBox12.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox12.Visible = true;
        }
        public void initLvlTwelve()
        {
            Random roller = new Random();
            int platX, platY; // platform location points.
            int speX, speY, speX1, speY1, speX2, speY2, speX3, speY3, speX4, speY4, speX5, speY5, speX6, speY6, speX7, speY7, speX8, speY8, speX9, speY9; // obstacle location points.

            GlobalVar.dx = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.dy = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.x = Convert.ToDouble(roller.Next(panel1.Width));
            GlobalVar.y = Convert.ToDouble(roller.Next(panel1.Height));

            platX = roller.Next(panel1.Width - GlobalVar.pictureBox2.Width);
            platY = roller.Next(panel1.Height - GlobalVar.pictureBox2.Height);
            GlobalVar.pictureBox2.Location = new Point(platX, platY);
            GlobalVar.pictureBox2.Width = 26;

            GlobalVar.rsdx = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox3.Width));
            GlobalVar.rsy = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox3.Height));
            speX = roller.Next(panel1.Width - GlobalVar.pictureBox3.Width);
            speY = roller.Next(panel1.Height - GlobalVar.pictureBox3.Height);
            GlobalVar.pictureBox3.Location = new Point(speX, speY);
            GlobalVar.pictureBox3.Visible = true;

            GlobalVar.rsdx1 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy1 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx1 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox4.Width));
            GlobalVar.rsy1 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox4.Height));
            speX1 = roller.Next(panel1.Width - GlobalVar.pictureBox4.Width);
            speY1 = roller.Next(panel1.Height - GlobalVar.pictureBox4.Height);
            GlobalVar.pictureBox4.Location = new Point(speX1, speY1);
            //GlobalVar.pictureBox4.BackgroundImage = imageList1.Images[3];
            //GlobalVar.pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox4.Visible = true;

            GlobalVar.rsdx2 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy2 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx2 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox5.Width));
            GlobalVar.rsy2 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox5.Height));
            speX2 = roller.Next(panel1.Width - GlobalVar.pictureBox5.Width);
            speY2 = roller.Next(panel1.Height - GlobalVar.pictureBox5.Height);
            GlobalVar.pictureBox5.Location = new Point(speX2, speY2);
            //GlobalVar.pictureBox5.BackgroundImage = imageList1.Images[4];
            //GlobalVar.pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox5.Visible = true;

            GlobalVar.rsdx3 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy3 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx3 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox6.Width));
            GlobalVar.rsy3 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox6.Height));
            speX3 = roller.Next(panel1.Width - GlobalVar.pictureBox6.Width);
            speY3 = roller.Next(panel1.Height - GlobalVar.pictureBox6.Height);
            GlobalVar.pictureBox6.Location = new Point(speX3, speY3);
            //GlobalVar.pictureBox6.BackgroundImage = imageList1.Images[5];
            //GlobalVar.pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox6.Visible = true;

            GlobalVar.rsdx4 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy4 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx4 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox7.Width));
            GlobalVar.rsy4 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox7.Height));
            speX4 = roller.Next(panel1.Width - GlobalVar.pictureBox7.Width);
            speY4 = roller.Next(panel1.Height - GlobalVar.pictureBox7.Height);
            GlobalVar.pictureBox7.Location = new Point(speX4, speY4);
            //GlobalVar.pictureBox7.BackgroundImage = imageList1.Images[6];
            //GlobalVar.pictureBox7.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox7.Visible = true;

            GlobalVar.rsdx5 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy5 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx5 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox8.Width));
            GlobalVar.rsy5 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox8.Height));
            speX5 = roller.Next(panel1.Width - GlobalVar.pictureBox8.Width);
            speY5 = roller.Next(panel1.Height - GlobalVar.pictureBox8.Height);
            GlobalVar.pictureBox8.Location = new Point(speX5, speY5);
            //GlobalVar.pictureBox8.BackgroundImage = imageList1.Images[7];
            //GlobalVar.pictureBox8.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox8.Visible = true;

            GlobalVar.rsdx6 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy6 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx6 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox9.Width));
            GlobalVar.rsy6 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox9.Height));
            speX6 = roller.Next(panel1.Width - GlobalVar.pictureBox9.Width);
            speY6 = roller.Next(panel1.Height - GlobalVar.pictureBox9.Height);
            GlobalVar.pictureBox9.Location = new Point(speX6, speY6);
            //GlobalVar.pictureBox9.BackgroundImage = imageList1.Images[8];
            //GlobalVar.pictureBox9.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox9.Visible = true;

            GlobalVar.rsdx7 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy7 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx7 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox10.Width));
            GlobalVar.rsy7 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox10.Height));
            speX7 = roller.Next(panel1.Width - GlobalVar.pictureBox10.Width);
            speY7 = roller.Next(panel1.Height - GlobalVar.pictureBox10.Height);
            GlobalVar.pictureBox10.Location = new Point(speX7, speY7);
            //GlobalVar.pictureBox10.BackgroundImage = imageList1.Images[9];
            //GlobalVar.pictureBox10.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox10.Visible = true;

            GlobalVar.rsdx8 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy8 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx8 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox11.Width));
            GlobalVar.rsy8 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox11.Height));
            speX8 = roller.Next(panel1.Width - GlobalVar.pictureBox11.Width);
            speY8 = roller.Next(panel1.Height - GlobalVar.pictureBox11.Height);
            GlobalVar.pictureBox11.Location = new Point(speX8, speY8);
            //GlobalVar.pictureBox11.BackgroundImage = imageList1.Images[10];
            //GlobalVar.pictureBox11.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox11.Visible = true;

            GlobalVar.rsdx9 = Convert.ToDouble(roller.Next(5) - 2);
            GlobalVar.rsdy9 = Convert.ToDouble(roller.Next(5) - 2);

            GlobalVar.rsx9 = Convert.ToDouble(roller.Next(panel1.Width - GlobalVar.pictureBox12.Width));
            GlobalVar.rsy9 = Convert.ToDouble(roller.Next(panel1.Height - GlobalVar.pictureBox12.Height));
            speX9 = roller.Next(panel1.Width - GlobalVar.pictureBox12.Width);
            speY9 = roller.Next(panel1.Height - GlobalVar.pictureBox12.Height);
            GlobalVar.pictureBox12.Location = new Point(speX9, speY9);
            //GlobalVar.pictureBox12.BackgroundImage = imageList1.Images[11];
            //GlobalVar.pictureBox12.BackgroundImageLayout = ImageLayout.Stretch;
            GlobalVar.pictureBox12.Visible = true;
        }

    } // end class
} // end Namespace
