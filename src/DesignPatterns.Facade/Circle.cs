using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Facade
{
    public class Circle:IShape
    {
        public void Draw() => Console.WriteLine("Circle:Draw()");
    }
}
