using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Observer
{
    public abstract class Observer
    {
        protected Subject subject;
        public abstract void Update();
    }
}
