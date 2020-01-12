using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LunarLander
{
    class GlobalVar
    {
        private static double _x, _y; // ships location points
        private static double _dx, _dy; // ships displacement
        private static double _rsx, _rsy, _rsx1, _rsy1, _rsx2, _rsy2, _rsx3, _rsy3, _rsx4, _rsy4, _rsx5, _rsy5, _rsx6, _rsy6, _rsx7, _rsy7, _rsx8, _rsy8, _rsx9, _rsy9; // obstacles location points
        private static double _rsdx, _rsdy, _rsdx1, _rsdy1, _rsdx2, _rsdy2, _rsdx3, _rsdy3, _rsdx4, _rsdy4, _rsdx5, _rsdy5, _rsdx6, _rsdy6, _rsdx7, _rsdy7, _rsdx8, _rsdy8, _rsdx9, _rsdy9; // obstacles displacement
        private static double _aox, _aoy; // addon points
        private static double _aodx, _aody; // addon displacement 
        private static int _fuel = 9999999;
        private static int _ships = 5;
        private static int _score = 0;
        private static int _level = 1;
        private static bool _addOnExist = false;
        private static int _addOnItem;

        private static Rectangle _rLander;
        private static Rectangle _rPlatform;
        private static Rectangle _rObstacle;
        private static Rectangle _rObstacle1;
        private static Rectangle _rObstacle2;
        private static Rectangle _rObstacle3;
        private static Rectangle _rObstacle4;
        private static Rectangle _rObstacle5;
        private static Rectangle _rObstacle6;
        private static Rectangle _rObstacle7;
        private static Rectangle _rObstacle8;
        private static Rectangle _rObstacle9;

        private static PictureBox _pictureBox1 = new PictureBox();
        private static PictureBox _pictureBox2 = new PictureBox();
        private static PictureBox _pictureBox3 = new PictureBox();
        private static PictureBox _pictureBox4 = new PictureBox();
        private static PictureBox _pictureBox5 = new PictureBox();
        private static PictureBox _pictureBox6 = new PictureBox();
        private static PictureBox _pictureBox7 = new PictureBox();
        private static PictureBox _pictureBox8 = new PictureBox();
        private static PictureBox _pictureBox9 = new PictureBox();
        private static PictureBox _pictureBox10 = new PictureBox();
        private static PictureBox _pictureBox11 = new PictureBox();
        private static PictureBox _pictureBox12 = new PictureBox();

        private static Rectangle _rFuelAddOn;
        private static Rectangle _rShipAddOn;

        private static PictureBox _fuelPic = new PictureBox();
        private static PictureBox _shipPic = new PictureBox();
        
        public static double x
        {
            get { return _x; }
            set { _x = value; }
        }
        public static double y
        {
            get { return _y; }
            set { _y = value; }
        }

        public static double dx
        {
            get { return _dx; }
            set { _dx = value; }
        }
        public static double dy
        {
            get { return _dy; }
            set { _dy = value; }
        }

        public static double rsx
        {
            get { return _rsx; }
            set { _rsx = value; }
        }
        public static double rsy
        {
            get { return _rsy; }
            set { _rsy = value; }
        }
        public static double rsx1
        {
            get { return _rsx1; }
            set { _rsx1 = value; }
        }
        public static double rsy1
        {
            get { return _rsy1; }
            set { _rsy1 = value; }
        }
        public static double rsx2
        {
            get { return _rsx2; }
            set { _rsx2 = value; }
        }
        public static double rsy2
        {
            get { return _rsy2; }
            set { _rsy2 = value; }
        }
        public static double rsx3
        {
            get { return _rsx3; }
            set { _rsx3 = value; }
        }
        public static double rsy3
        {
            get { return _rsy3; }
            set { _rsy3 = value; }
        }
        public static double rsx4
        {
            get { return _rsx4; }
            set { _rsx4 = value; }
        }
        public static double rsy4
        {
            get { return _rsy4; }
            set { _rsy4 = value; }
        }
        public static double rsx5
        {
            get { return _rsx5; }
            set { _rsx5 = value; }
        }
        public static double rsy5
        {
            get { return _rsy5; }
            set { _rsy5 = value; }
        }
        public static double rsx6
        {
            get { return _rsx6; }
            set { _rsx6 = value; }
        }
        public static double rsy6
        {
            get { return _rsy6; }
            set { _rsy6 = value; }
        }
        public static double rsx7
        {
            get { return _rsx7; }
            set { _rsx7 = value; }
        }
        public static double rsy7
        {
            get { return _rsy7; }
            set { _rsy7 = value; }
        }
        public static double rsx8
        {
            get { return _rsx8; }
            set { _rsx8 = value; }
        }
        public static double rsy8
        {
            get { return _rsy8; }
            set { _rsy8 = value; }
        }
        public static double rsx9
        {
            get { return _rsx9; }
            set { _rsx9 = value; }
        }
        public static double rsy9
        {
            get { return _rsy9; }
            set { _rsy9 = value; }
        }

        public static double rsdx
        {
            get { return _rsdx; }
            set { _rsdx = value; }
        }
        public static double rsdy
        {
            get { return _rsdy; }
            set { _rsdy = value; }
        }
        public static double rsdx1
        {
            get { return _rsdx1; }
            set { _rsdx1 = value; }
        }
        public static double rsdy1
        {
            get { return _rsdy1; }
            set { _rsdy1 = value; }
        }
        public static double rsdx2
        {
            get { return _rsdx2; }
            set { _rsdx2 = value; }
        }
        public static double rsdy2
        {
            get { return _rsdy2; }
            set { _rsdy2 = value; }
        }
        public static double rsdx3
        {
            get { return _rsdx3; }
            set { _rsdx3 = value; }
        }
        public static double rsdy3
        {
            get { return _rsdy3; }
            set { _rsdy3 = value; }
        }
        public static double rsdx4
        {
            get { return _rsdx4; }
            set { _rsdx4 = value; }
        }
        public static double rsdy4
        {
            get { return _rsdy4; }
            set { _rsdy4 = value; }
        }
        public static double rsdx5
        {
            get { return _rsdx5; }
            set { _rsdx5 = value; }
        }
        public static double rsdy5
        {
            get { return _rsdy5; }
            set { _rsdy5 = value; }
        }
        public static double rsdx6
        {
            get { return _rsdx6; }
            set { _rsdx6 = value; }
        }
        public static double rsdy6
        {
            get { return _rsdy6; }
            set { _rsdy6 = value; }
        }
        public static double rsdx7
        {
            get { return _rsdx7; }
            set { _rsdx7 = value; }
        }
        public static double rsdy7
        {
            get { return _rsdy7; }
            set { _rsdy7 = value; }
        }
        public static double rsdx8
        {
            get { return _rsdx8; }
            set { _rsdx8 = value; }
        }
        public static double rsdy8
        {
            get { return _rsdy8; }
            set { _rsdy8 = value; }
        }
        public static double rsdx9
        {
            get { return _rsdx9; }
            set { _rsdx9 = value; }
        }
        public static double rsdy9
        {
            get { return _rsdy9; }
            set { _rsdy9 = value; }
        }

        public static int fuel
        {
            get { return _fuel; }
            set { _fuel = value; }
        }

        public static int ships
        {
            get { return _ships; }
            set { _ships = value; }
        }

        public static int score
        {
            get { return _score; }
            set { _score = value; }
        }

        public static int level
        {
            get { return _level; }
            set { _level = value; }
        }

        public static Rectangle rLander
        {
            get { return _rLander; }
            set { _rLander = value; }
        }
        public static Rectangle rPlatform
        {
            get { return _rPlatform; }
            set { _rPlatform = value; }
        }
        public static Rectangle rObstacle
        {
            get { return _rObstacle; }
            set { _rObstacle = value; }
        }
        public static Rectangle rObstacle1
        {
            get { return _rObstacle1; }
            set { _rObstacle1 = value; }
        }
        public static Rectangle rObstacle2
        {
            get { return _rObstacle2; }
            set { _rObstacle2 = value; }
        }
        public static Rectangle rObstacle3
        {
            get { return _rObstacle3; }
            set { _rObstacle3 = value; }
        }
        public static Rectangle rObstacle4
        {
            get { return _rObstacle4; }
            set { _rObstacle4 = value; }
        }
        public static Rectangle rObstacle5
        {
            get { return _rObstacle5; }
            set { _rObstacle5 = value; }
        }
        public static Rectangle rObstacle6
        {
            get { return _rObstacle6; }
            set { _rObstacle6 = value; }
        }
        public static Rectangle rObstacle7
        {
            get { return _rObstacle7; }
            set { _rObstacle7 = value; }
        }
        public static Rectangle rObstacle8
        {
            get { return _rObstacle8; }
            set { _rObstacle8 = value; }
        }
        public static Rectangle rObstacle9
        {
            get { return _rObstacle9; }
            set { _rObstacle9 = value; }
        }

        public static PictureBox pictureBox1
        {
            get { return _pictureBox1; }
            set { _pictureBox1 = value; }
        }
        public static PictureBox pictureBox2
        {
            get { return _pictureBox2; }
            set { _pictureBox2 = value; }
        }
        public static PictureBox pictureBox3
        {
            get { return _pictureBox3; }
            set { _pictureBox3 = value; }
        }
        public static PictureBox pictureBox4
        {
            get { return _pictureBox4; }
            set { _pictureBox4 = value; }
        }
        public static PictureBox pictureBox5
        {
            get { return _pictureBox5; }
            set { _pictureBox5 = value; }
        }
        public static PictureBox pictureBox6
        {
            get { return _pictureBox6; }
            set { _pictureBox6 = value; }
        }
        public static PictureBox pictureBox7
        {
            get { return _pictureBox7; }
            set { _pictureBox7 = value; }
        }
        public static PictureBox pictureBox8
        {
            get { return _pictureBox8; }
            set { _pictureBox8 = value; }
        }
        public static PictureBox pictureBox9
        {
            get { return _pictureBox9; }
            set { _pictureBox9 = value; }
        }
        public static PictureBox pictureBox10
        {
            get { return _pictureBox10; }
            set { _pictureBox10 = value; }
        }
        public static PictureBox pictureBox11
        {
            get { return _pictureBox11; }
            set { _pictureBox11 = value; }
        }
        public static PictureBox pictureBox12
        {
            get { return _pictureBox12; }
            set { _pictureBox12 = value; }
        }

        public static double aox
        {
            get { return _aox; }
            set { _aox = value; }
        }
        public static double aoy
        {
            get { return _aoy; }
            set { _aoy = value; }
        }
        public static double aodx
        {
            get { return _aodx; }
            set { _aodx = value; }
        }
        public static double aody
        {
            get { return _aody; }
            set { _aody = value; }
        }

        public static Rectangle rFuelAddOn
        {
            get { return _rFuelAddOn; }
            set { _rFuelAddOn = value; }
        }
        public static Rectangle rShipAddOn
        {
            get { return _rShipAddOn; }
            set { _rShipAddOn = value; }
        }

        public static PictureBox fuelPic
        {
            get { return _fuelPic; }
            set { _fuelPic = value; }
        }
        public static PictureBox shipPic
        {
            get { return _shipPic; }
            set { _shipPic = value; }
        }

        public static bool addOnExist
        {
            get { return _addOnExist; }
            set { _addOnExist = value; }
        }

        public static int addOnItem
        {
            get { return _addOnItem; }
            set { _addOnItem = value; }
        }

    }
}
