using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.NullObject
{
    public abstract class AbstractCustomer
    {
        protected string Name;
        public abstract bool IsNil();
        public abstract string GetName();
    }
}
