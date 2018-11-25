using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Facade
{
    public class Rectangle:IShape
    {
        public void Draw() => Console.WriteLine("Rectangle:Draw()");
    }
}
