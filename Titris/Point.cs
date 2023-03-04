using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Titris
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point() {}

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point(Point point)
        {
            X = point.X;
            Y = point.Y;
        }

        public void Draw()
        {
            DrawerProvier.Drawer.DrawPoint(X, Y);
        }

        internal void Move(Direction dir)
        {
            switch (dir)
            {
                case Direction.DOWN:
                    Y += 1;
                    break;
                case Direction.LEFT:
                    X -= 1;
                    break;
                case Direction.RIGHT:
                    X += 1;
                    break;
                case Direction.UP:
                    Y -= 1;
                    break;
            }
        }

        internal void Hide()
        {
            DrawerProvier.Drawer.HidePoint(X, Y);
        }
    }
}
