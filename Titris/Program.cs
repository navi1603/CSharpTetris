using System;

namespace Titris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);

            FigureGenerator generator = new FigureGenerator(20, 0, "*");
            Figure s = generator.GetNewFigure();
        }
    }
}
