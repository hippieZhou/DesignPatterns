using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Visitor
{
    public class Monitor : IComputerPart
    {
        public void Accept(ComputerPartVisitor computerPartVisitor)
        {
            computerPartVisitor.Visit(this);
        }
    }
}
