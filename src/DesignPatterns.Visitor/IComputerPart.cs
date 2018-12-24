using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Visitor
{
    public interface IComputerPart
    {
        void Accept(ComputerPartVisitor computerPartVisitor);
    }
}
