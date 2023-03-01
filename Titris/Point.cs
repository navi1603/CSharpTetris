using System;
using System.Collections.Generic;
using System.Text;

namespace Titris
{
    class Point
    {
        public int x;
        public int y;
        public char c;
        private Point point;

        public Point()
        {

        }

        public Point(int x, int y, char c)
        {
            this.x = x;
            this.y = y;
            this.c = c;
        }

        public Point(Point point)
        {
            x = point.x;
            y = point.y;
            c = point.c;
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
            Console.SetCursorPosition(0, 0);
            
        }

        internal void Move(Direction dir)
        {
            switch (dir)
            {
                case Direction.DOWN:
                    y += 1;
                    break;
                case Direction.LEFT:
                    x -= 1;
                    break;
                case Direction.RIGHT:
                    x += 1;
                    break;
            }
        }

        internal void Hide()
        {
            Console.SetCursorPosition (x,y);
            Console.Write(" ");
        }
    }
}
