using System;
using DesignPattern.AbstractFactory.interfaces;

namespace DesignPattern.AbstractFactory.Colors
{
    class Red:IColor
    {
        public void Fill()
        {
            Console.WriteLine("Filled with red");
        }
    }
}
