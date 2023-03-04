using System;
using System.Collections.Generic;
using System.Text;

namespace Titris
{
    internal class ConsoleDrawer : iDrawer
    {
        public void DrawPoint(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write('*');
            Console.SetCursorPosition(0, 0);
        }

        public void HidePoint(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            Console.SetCursorPosition(0, 0);
        }
    }
}

