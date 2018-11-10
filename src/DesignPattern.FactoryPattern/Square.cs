using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.FactoryPattern
{
    public class Square:IShape
    {
        public void Draw()
        {
            Console.WriteLine("I am a Square");
        }
    }
}
