using System;
using System.Timers;
using System.Threading;

namespace Titris
{
    class Program
    {
        const int TIMER_INTERVAL = 500;
        static System.Timers.Timer timer;
        static private Object _lockObject = new object();

        static Figure currentFigare;
        static FigureGenerator generator;
        static void Main(string[] args)
        {
            Console.SetWindowSize(Field.Widht, Field.Height);
            Console.SetBufferSize(Field.Widht, Field.Height);

            IIDrawer drawer = new ConsoleDrawer();
            Test(drawer);

            generator = new FigureGenerator(Field.Widht / 2, 0, Drawer.DEFAULT_SYMBOLE);
            currentFigare = generator.GetNewFigure();
            SetTimer();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    Monitor.Enter(_lockObject);
                    var result = HandleKey(currentFigare, key);
                    ProcessResult(result, ref currentFigare);
                    Monitor.Exit(_lockObject);
                }
            }
        }

        private static void Test(IIDrawer drawer)
        {
            drawer.DrawPoint(5,6);
        }

        private static void SetTimer()
        {
            timer = new System.Timers.Timer(TIMER_INTERVAL);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Monitor.Enter(_lockObject);
            var result = currentFigare.TryMove(Direction.DOWN);
            ProcessResult(result, ref currentFigare);
            Monitor.Exit(_lockObject);

        }

        private static bool ProcessResult(Result result, ref Figure currentFigare)
        {
            if(result == Result.HEAP_STRIKE || result == Result.DOWN_BORDER_STRIKE)
            {
                Field.AddFigure(currentFigare);
                Field.TryDeleteLines();

                if (currentFigare.IsOnTop())
                {
                    WriteGameOver();
                    timer.Elapsed -= OnTimedEvent;
                    return true;
                }
                else
                {
                    currentFigare = generator.GetNewFigure();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private static void WriteGameOver()
        {
            Console.SetCursorPosition(Field.Widht / 2 - 8, Field.Height / 2);
            Console.WriteLine("G A M E  O V E R");
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
