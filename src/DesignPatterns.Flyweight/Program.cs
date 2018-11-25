using System;

namespace DesignPatterns.Flyweight
{
    class Program
    {
        private static string[] colors = new[] {"Red", "Green", "Blue", "White", "Black"};
        private static Random random = new Random();

        static void Main(string[] args)
        {
            for (int i = 0; i < 20; i++)
            {
                Circle circle = (Circle) ShapeFactory.GetCircle(GetRandomColor());
                circle.SetX(GetRandomX());
                circle.SetY(GetRandomY());
                circle.SetRadius(100);
                circle.Draw();
            }

            Console.ReadKey();
        }

        private static string GetRandomColor()
        {
            return colors[random.Next(0, colors.Length)];
        }

        private static int GetRandomX()
        {
            return random.Next(0, colors.Length) * 100;
        }

        private static int GetRandomY()
        {
            return random.Next(0, colors.Length) * 100;
        }
    }
}
