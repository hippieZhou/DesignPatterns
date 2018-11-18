using System;

namespace DesignPatterns.Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            IShape circle = new Circle();
            IShape redCircle = new RedShapleDecorator(new Circle());

            IShape redRectangle = new RedShapleDecorator(new Rectangle());
            Console.WriteLine("Circle with normal border");
            circle.Draw();

            Console.WriteLine("Circle of red border");
            redCircle.Draw();

            Console.WriteLine("Rectangel of red border");
            redRectangle.Draw();

            Console.ReadKey();
        }
    }
}
