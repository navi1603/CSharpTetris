using System;
using System.Collections.Generic;
using System.Text;

namespace Titris
{
    abstract class Figure
    {
        const int LENGHT = 4;
        public Point[] Points = new Point[LENGHT];

        public void Draw()
        {
            foreach (Point p in Points)
            {
                p.Draw();
            }
        }

        public void Hide()
        {
            foreach(Point p in Points)
            {
                p.Hide();
            }
        }

        public abstract void Rotate(Point [] plist);

        internal void TryMove(Direction dir)
        {
            Hide();
            var clone = Clone();
            Move(clone, dir);
            if (VerifyPosition(clone))
            {
                Points = clone;
            }

            Draw();
        }

        internal void TryRotate()
        {
            Hide();
            var clone = Clone();
            Rotate(clone);
            if (VerifyPosition(clone))
            {
                Points = clone;
            }
            Draw();
        }

        private bool VerifyPosition(Point[] plist)
        {
            foreach(var p in plist)
            {
                if (p.X < 0 || p.Y < 0 || p.X >= Field.Widht || p.Y >= Field.Height)
                    return false;
            }
            return true;
        }

        private void Move(Point[] plist, Direction dir)
        {
            foreach(var p in plist)
            {
                p.Move(dir);
            }
        }

        private Point[] Clone()
        {
            var newPoints = new Point[LENGHT];
            for(int i = 0; i < LENGHT; i++)
            {
                newPoints[i] = new Point (Points[i]);
            }
            return newPoints;
        }
    }
}
