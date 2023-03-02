using System;
using System.Collections.Generic;
using System.Text;

namespace Titris
{
    static class Field
    {
        private static int _widht = 40;
        private static int _height = 30;

        public static int Widht
        {
            get
            {
                return _widht;
            }

            set
            {
                _widht = value;
                Console.SetWindowSize(Field.Widht, Field.Height);
                Console.SetBufferSize(Field.Widht, Field.Height);
            }
        }

        public static int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                Console.SetWindowSize(Field.Widht, Field.Height);
                Console.SetBufferSize(Field.Widht, Field.Height);
            }
        }


        private static bool[][] _heap;
        static Field()
        {
            _heap = new bool[Height][];
            for(int i = 0; i < Height; i++)
            {
                _heap[i] = new bool[Widht];
            }
        }

        public static bool CheckStricke(Point p)
        {
            return _heap[p.Y][p.X];
        }
        public static void AddFigure(Figure fig)
        {
            foreach(var p in fig.Points)
            {
                _heap[p.Y][p.X] = true;
            }
        }
    }
}
