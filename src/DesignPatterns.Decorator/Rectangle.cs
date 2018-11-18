using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Decorator
{
    public class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Shape:Rectangle");
        }
    }
}
