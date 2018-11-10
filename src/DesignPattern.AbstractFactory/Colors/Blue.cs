using System;
using DesignPattern.AbstractFactory.interfaces;

namespace DesignPattern.AbstractFactory.Colors
{
    public class Blue:IColor
    {
        public void Fill()
        {
            Console.WriteLine("Filled with blue");
        }
    }
}
