using System;

namespace Titris
{
    public static class Drawer
    {
        public  const char DEFAULT_SYMBOLE = '*';

        public static void DrawPoint(int x, int y, char c = DEFAULT_SYMBOLE)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
            Console.SetCursorPosition(0, 0);
        }

        public static void HidePoint(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            Console.SetCursorPosition(0, 0);
        }
    }
}