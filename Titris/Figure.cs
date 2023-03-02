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

        internal Result TryMove(Direction dir)
        {
            Hide();
            var clone = Clone();
            Move(clone, dir);

            var result = VerifyPosition(clone);
            if(result == Result.SECCESS)
            {
                Points = clone;
            }

            Draw();
            return result;
        }

        internal Result TryRotate()
        {
            Hide();
            var clone = Clone();
            Rotate(clone);

            var result = VerifyPosition(clone);
            if (result == Result.SECCESS)
            {
                Points = clone;
            }
            Draw();

            return result;
        }

        internal bool IsOnTop()
        {
            return Points[0].Y == 0;
        }

         private Result VerifyPosition(Point[] newPoints)
        {
            foreach (var p in newPoints)
            {
                if (p.Y >= Field.Height)
                    return Result.DOWN_BORDER_STRIKE;
                if (p.X >= Field.Widht || p.X < 0 || p.Y < 0)
                    return Result.BORDER_STRIKE;
                if (Field.CheckStricke(p))
                    return Result.HEAP_STRIKE;
            }
            return Result.SECCESS;
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
