using System;

namespace DesignPatterns.ProtoType
{
    class Program
    {
        static void Main(string[] args)
        {
            ShapeCache.LoadCache();

            Shape clonedShape1 = (Shape) ShapeCache.GetShape("1");
            Console.WriteLine(clonedShape1.GetType());
            clonedShape1.Draw();

            Shape clonedShape2 = (Shape)ShapeCache.GetShape("2");
            Console.WriteLine(clonedShape2.GetType());
            clonedShape2.Draw();

            Shape clonedShape3 = (Shape)ShapeCache.GetShape("3");
            Console.WriteLine(clonedShape3.GetType());
            clonedShape3.Draw();

            Console.ReadKey();
        }
    }
}
