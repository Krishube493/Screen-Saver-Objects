using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ScreenSaverObjects
{
    public partial class Form1 : Form
    {
        List<Ball> ballList = new List<Ball>();
        SolidBrush ballBrush = new SolidBrush(Color.Red);
        int counter = 0;
        
        public Form1()
        {
            InitializeComponent();
            MakeBall();
        }

        public void MakeBall()
        {
            counter = 0;
            Random randGen = new Random();

            int size = randGen.Next(10, 40);
            int x = randGen.Next(1, this.Width - size);
            int y = randGen.Next(1, this.Height - size);
            int xSpeed = randGen.Next(-5, 6);
            int ySpeed = randGen.Next(-5, 6);
            int r = randGen.Next(0, 256);
            int g = randGen.Next(0, 256);
            int b = randGen.Next(0, 256);
            Color c = Color.FromArgb(r, g, b);

            Ball ball = new Ball(x, y, size, xSpeed, ySpeed, c);
            ballList.Add(ball);
        }

        private void graphicsTimer_Tick(object sender, EventArgs e)
        {
            //move the balls and check wall collisions
            foreach (Ball b in ballList)
            {
                b.Move();
                b.Collision(this);
            }

            //generate new balls on counter
            counter++;

            if (counter == 4)
            {
                MakeBall();
            }

            #region collision of any ball with any other ball
            // this algorithm is not optimal but does give you 
            // an idea of how it may work. 
            //int checkedUpTo = 0;

            //foreach (Ball b1 in ballList)
            //{
            //    checkedUpTo++;

            //    foreach (Ball b2 in ballList.Skip(checkedUpTo))
            //    {
            //        b2.Collision(b1);
            //    }
            //}

            #endregion

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Ball b in ballList)
            {
                ballBrush.Color = b.color;
                e.Graphics.FillEllipse(ballBrush, b.x, b.y, b.size, b.size);
            }
        }
    }
}
