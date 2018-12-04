using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.ChainofResponsibility
{
    public class ErrorLogger:AbstractLogger
    {
        public ErrorLogger(int level)
        {
            this.level = level;
        }
        protected override void write(string message) => Console.WriteLine($"Error Console::Logger:{message}");
    }
}
