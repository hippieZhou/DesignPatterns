using System;

namespace DesignPatterns.ChainofResponsibility
{
    public class FileLogger:AbstractLogger
    {
        public FileLogger(int level)
        {
            this.level = level;
        }

        protected override void write(string message) => Console.WriteLine($"File::Logger:{message}");
    }
}
