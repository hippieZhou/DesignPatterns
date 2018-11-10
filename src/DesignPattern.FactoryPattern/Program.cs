using System;

namespace DesignPattern.FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var  factory = new ShapeFactory();
            IShape shape = factory.GetShape(ShapeType.Rectangle);
            shape.Draw();

            Console.ReadKey();
        }
    }
}
