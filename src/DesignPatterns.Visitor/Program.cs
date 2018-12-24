using System;

namespace DesignPatterns.Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            IComputerPart computer = new Computer();
            computer.Accept(new ComputerPartDisplayVisitor());
            Console.ReadKey();
        }
    }
}
