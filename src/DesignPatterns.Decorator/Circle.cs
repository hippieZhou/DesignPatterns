using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Decorator
{
    public class Circle:IShape
    {
        public void Draw()
        {
            Console.WriteLine("Shape:Circle");
        }
    }
}
