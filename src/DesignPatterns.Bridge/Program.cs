using System;

namespace DesignPatterns.Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape redCircle = new Circle(100, 100, 10, new RedCircle());
            redCircle.Draw();

            Shape greenCircle = new Circle(100, 100, 10, new GreenCircle());
            greenCircle.Draw();

            Console.ReadKey();
        }
    }
}
