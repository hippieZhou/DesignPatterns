using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Flyweight
{
    public class ShapeFactory
    {
        private static Dictionary<string, IShape> circleMap = new Dictionary<string, IShape>();

        public static IShape GetCircle(string color)
        {
            circleMap.TryGetValue(color, out var circle);

            if (circle != null) return circle;
            circle = new Circle(color);
            circleMap.Add(color, circle);
            Console.WriteLine($"Creating circle of color:{color}");

            return circle;
        }
    }
}
