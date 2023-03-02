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
        public char C { get; set; }

        public Point() {}

        public Point(int x, int y, char c)
        {
            X = x;
            Y = y;
            C = c;
        }

        public Point(Point point)
        {
            X = point.X;
            Y = point.Y;
            C = point.C;
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(C);
            Console.SetCursorPosition(0, 0);
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
            }
        }

        internal void Hide()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }
    }
}
