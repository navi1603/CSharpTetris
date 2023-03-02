using System;

namespace Titris
{
    class Program
    {
        static FigureGenerator generator;
        static void Main(string[] args)
        {
            Console.SetWindowSize(Field.Widht, Field.Height);
            Console.SetBufferSize(Field.Widht, Field.Height);

            generator = new FigureGenerator(Field.Widht / 2, 0, Drawer.DEFAULT_SYMBOLE);
            Figure currentFigare = generator.GetNewFigure();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    var result = HandleKey(currentFigare, key);
                    ProcessResult(result, ref currentFigare);
                }
            }
        }

        private static bool ProcessResult(Result result, ref Figure currentFigare)
        {
            if(result == Result.HEAP_STRIKE || result == Result.DOWN_BORDER_STRIKE)
            {
                Field.AddFigure(currentFigare);
                Field.TryDeleteLines();
                currentFigare = generator.GetNewFigure();
                return true;
            }
            else
            {
                return false;
            }
        }

        private static Result HandleKey(Figure f, ConsoleKeyInfo key)
        {
            switch(key.Key){
                case ConsoleKey.LeftArrow:
                    return f.TryMove(Direction.LEFT);
                case ConsoleKey.RightArrow:
                    return f.TryMove(Direction.RIGHT);
                case ConsoleKey.DownArrow:
                    return f.TryMove(Direction.DOWN);
;                case ConsoleKey.Spacebar:
                    return f.TryRotate();
            }
            return Result.SECCESS;
        }
    }
}
