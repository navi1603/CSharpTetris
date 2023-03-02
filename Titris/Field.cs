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
    }
}
