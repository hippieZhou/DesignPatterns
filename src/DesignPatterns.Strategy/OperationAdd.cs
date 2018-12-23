using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Strategy
{
    public class OperationAdd : IStrategy
    {
        public int DoOperation(int num1, int num2) => num1 + num2;
    }
}
