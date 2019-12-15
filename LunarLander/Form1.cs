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
        private double rsx, rsy; // spectacles location points
        private double rsdx, rsdy; // spectacles displacement 
        private int fuel = 9999999;
        private int ships = 3;
        private int score = 0;
        Rectangle rLander;
        Rectangle rPlatform;
        Rectangle rSpectacle;

        public Form1()
        {
            InitializeComponent();

            initGame();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dy += .5;

            score += 100;

            pictureBox1.Image = imageList1.Images[0];

            moveSpectacle();
            moveShip();
            checkCollide();
            checkLanding();
            showStats();
        } // end timer tick

        private void moveSpectacle()
        {
            Random roller = new Random();

            rsdx = Convert.ToDouble(roller.Next(5) - 2);
            rsdy = Convert.ToDouble(roller.Next(5) - 2);

            rsx += rsdx;
            if (rsx > this.Width - pictureBox3.Width)
            {
                rsx = 0;
            } // end if
            if (rsx < 0)
            {
                rsx = Convert.ToDouble(this.Width - pictureBox3.Width);
            } // end if

            rsy += rsdy;
            if (rsy > this.Height - pictureBox3.Height)
            {
                rsy = 0;
            } // end if 
            if (rsy < 0)
            {
                rsy = Convert.ToDouble(this.Height - pictureBox3.Height);
            } // end if

            pictureBox3.Location = new Point(Convert.ToInt32(rsx), Convert.ToInt32(rsy));
        }

        private void moveShip()
        {
            x += dx;
            if (x > this.Width - pictureBox1.Width)
            {
                x = 0;
            } // end if
            if (x < 0)
            {
                x = Convert.ToDouble(this.Width - pictureBox1.Width);
            } // end if

            y += dy;
            if (y > this.Height - pictureBox1.Height)
            {
                y = 0;
            } // end if 
            if (y < 0)
            {
                y = Convert.ToDouble(this.Height - pictureBox1.Height);
            } // end if

            pictureBox1.Location = new Point(Convert.ToInt32(x), Convert.ToInt32(y));
        } // end moveShip

        private void checkCollide()
        {
            rLander = pictureBox1.Bounds;
            rSpectacle = pictureBox3.Bounds;

            if (rLander.IntersectsWith(rSpectacle))
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
                        }
                        else
                        {
                            MessageBox.Show("Too much vertical velocity!");
                            killShip();
                        } // end vertical if
                    }
                    else
                    {
                        MessageBox.Show("too much horizontal velocity");
                        killShip();
                    } // end horiz if
                    initGame();
                } // end if
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
                    pictureBox1.Image = imageList1.Images[0];
                    dy -= 2;
                    break;
                case Keys.Left:
                    pictureBox1.Image = imageList1.Images[0];
                    dx++;
                    break;
                case Keys.Right:
                    pictureBox1.Image = imageList1.Images[0];
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
            label6.Text = "Spetacles Location: " + pictureBox3.Location.X + ", " +pictureBox3.Location.Y;
            //label7.Text = "";
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
            Random roller = new Random();
            int platX, platY; // platform location points.
            int speX, speY; // spetacle location points.

            dx = Convert.ToDouble(roller.Next(5) - 2);
            dy = Convert.ToDouble(roller.Next(5) - 2);
            //dx = 1;
            //dy = -1;

            x = Convert.ToDouble(roller.Next(this.Width));
            y = Convert.ToDouble(roller.Next(this.Height));
            //x = this.Width;
            //y = this.Height;

            platX = roller.Next(this.Width - pictureBox2.Width);
            platY = roller.Next(this.Height - pictureBox2.Height);
            pictureBox2.Location = new Point(platX, platY);

            rsdx = Convert.ToDouble(roller.Next(5) - 2);
            rsdy = Convert.ToDouble(roller.Next(5) - 2);

            rsx = Convert.ToDouble(roller.Next(this.Width - pictureBox3.Width));
            rsy = Convert.ToDouble(roller.Next(this.Height - pictureBox3.Height));
            speX = roller.Next(this.Width - pictureBox3.Width);
            speY = roller.Next(this.Height - pictureBox3.Height);
            pictureBox3.Location = new Point(speX, speY);

            timer1.Enabled = true;
        } // end initGame
    } // end class
} // end Namespace
