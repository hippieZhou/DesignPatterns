using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Facade
{
    public class Square:IShape
    {
        public void Draw() => Console.WriteLine("Square:Draw()");
    }
}
