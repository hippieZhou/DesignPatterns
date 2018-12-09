using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Observer
{
    public class OctalObserver:Observer
    {
        public OctalObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.Attach(this);
        }

        public override void Update()
        {
            Console.WriteLine($"Octal string:{subject.GetState()}");

        }
    }
}
