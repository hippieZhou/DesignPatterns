using System;
using DesignPattern.AbstractFactory.interfaces;

namespace DesignPattern.AbstractFactory.Shapes
{
    public class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("I am a Square");
        }
    }
}
