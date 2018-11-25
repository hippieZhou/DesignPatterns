using System;

namespace DesignPatterns.Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            var shapeMarker = new ShapeMarker();
            shapeMarker.DrawCircle();
            shapeMarker.DrawRectangle();
            shapeMarker.DrawSquare();
            Console.ReadKey();
        }
    }
}
