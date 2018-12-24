using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Visitor
{
    public class Computer : IComputerPart
    {
        readonly IComputerPart[] parts;
        public Computer() => parts = new IComputerPart[] { new Mouse(), new Keyboard(), new Monitor() };

        public void Accept(ComputerPartVisitor computerPartVisitor)
        {
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i].Accept(computerPartVisitor);
            }
            computerPartVisitor.Visit(this);
        }
    }
}
