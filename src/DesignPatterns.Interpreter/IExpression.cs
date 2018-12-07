using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Interpreter
{
    public interface IExpression
    {
        bool Interpret(string context);
    }
}
