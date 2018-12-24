using System;

namespace DesignPatterns.Visitor
{
    public abstract class ComputerPartVisitor
    {
        public abstract void Visit(Computer computer);
        public abstract void Visit(Mouse mouse);
        public abstract void Visit(Keyboard keyboard);
        public abstract void Visit(Monitor monitor);
    }
}