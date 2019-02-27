using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenSaverObjects
{
    public class Ball
    {
        public int x, y, size, xSpeed, ySpeed;
        public Color color;

        public Ball(int _x, int _y, int _size, int _xSpeed, int _ySpeed, Color _color)
        {
            x = _x;
            y = _y;
            size = _size;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
            color = _color;
        }

        public void Move()
        {
            x += xSpeed;
            y += ySpeed;
        }

        public void Collision(Form f)
        {
            // change left/right direction on wall hit
            if (x < 0 || x > f.Width - size)
            {
                xSpeed *= -1;
            }

            // change up/down direction on wall hit
            if (y < 0 || y > f.Height - size)
            {
                ySpeed *= -1;
            }
        }

        public void Collision(Ball b)
        {
            // received ball
            Rectangle ball1 = new Rectangle(b.x, b.y, b.size, b.size);

            // this ball
            Rectangle ball2 = new Rectangle(x, y, size, size);

            if (ball1.IntersectsWith(ball2))
            {
                //change direction of received ball
                b.xSpeed *= -1;
                b.ySpeed *= -1;

                //change direction of this ball
                xSpeed *= -1;
                ySpeed *= -1;
            }
        }
    }
}
