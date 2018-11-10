using System;
using DesignPattern.AbstractFactory.interfaces;

namespace DesignPattern.AbstractFactory.Shapes
{
    public class Circle:IShape
    {
        public void Draw()
        {
            Console.WriteLine("I am a Circle");
        }
    }
}
