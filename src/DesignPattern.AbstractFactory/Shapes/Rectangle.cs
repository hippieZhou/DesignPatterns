using System;
using DesignPattern.AbstractFactory.interfaces;

namespace DesignPattern.AbstractFactory.Shapes
{
    public class Rectangle:IShape
    {
        public void Draw()
        {
            Console.WriteLine("I am a Rectangle");
        }
    }
}
