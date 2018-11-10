using System;
using DesignPattern.AbstractFactory.interfaces;

namespace DesignPattern.AbstractFactory.Colors
{
    public class Green : IColor
    {
        public void Fill()
        {
            Console.WriteLine("Filled with green");
        }
    }
}
