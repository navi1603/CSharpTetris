using System;

namespace Titris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);

            FigureGenerator generator = new FigureGenerator(20, 0, '*');
            Figure currentFigare = generator.GetNewFigure();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    HandleKey(currentFigare, key);
                }
            }
        }

        private static void HandleKey(Figure currentFigare, ConsoleKeyInfo key)
        {
            switch(key.Key){
                case ConsoleKey.LeftArrow:
                    currentFigare.TryMove(Direction.LEFT);
                    break;
                case ConsoleKey.RightArrow:
                    currentFigare.TryMove(Direction.RIGHT);
                    break;
                case ConsoleKey.DownArrow:
                    currentFigare.TryMove(Direction.DOWN);
                    break;
;                case ConsoleKey.Backspace:
                    currentFigare.Hide();
                    currentFigare.Rotate();
                    currentFigare.Draw();
                    break;
            }
        }
    }
}
