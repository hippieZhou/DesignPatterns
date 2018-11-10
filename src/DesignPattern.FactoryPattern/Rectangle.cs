using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.FactoryPattern
{
    public class Rectangle:IShape
    {
        public void Draw()
        {
            Console.WriteLine("I am a Rectangle");
        }
    }
}
