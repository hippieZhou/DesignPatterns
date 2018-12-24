using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Visitor
{
    public class ComputerPartDisplayVisitor : ComputerPartVisitor
    {
        public override void Visit(Computer computer)
        {
            Console.WriteLine("Displaying computer");
        }

        public override void Visit(Mouse mouse)
        {
            Console.WriteLine("Displaying mouse");
        }

        public override void Visit(Keyboard keyboard)
        {
            Console.WriteLine("Displaying keyboard");
        }

        public override void Visit(Monitor monitor)
        {
            Console.WriteLine("Displaying monitor");
        }
    }
}
