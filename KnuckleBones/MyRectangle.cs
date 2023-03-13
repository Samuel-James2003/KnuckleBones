using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnuckleBones
{
    class MyRectangle
    {
        private PictureBox PlayerBox;
        private Pen pen;

        public MyRectangle(PictureBox pictureBox, Color color, int penWidth)
        {
            PlayerBox = pictureBox;
            pen = new Pen(color, penWidth);
        }

        public void Draw(int rows, int columns, int startX, int startY, int rectangleWidth, int rectangleHeight)
        {
            using (var graphics = Graphics.FromImage(PlayerBox.Image))
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        int x = startX + j * rectangleWidth;
                        int y = startY + i * rectangleHeight;
                        graphics.DrawLine(pen, x, y, x + rectangleWidth, y);
                        graphics.DrawLine(pen, x + rectangleWidth, y, x + rectangleWidth, y + rectangleHeight);
                        graphics.DrawLine(pen, x + rectangleWidth, y + rectangleHeight, x, y + rectangleHeight);
                        graphics.DrawLine(pen, x, y + rectangleHeight, x, y);
                    }
                }
            }
            PlayerBox.Refresh();
        }
    }
}
