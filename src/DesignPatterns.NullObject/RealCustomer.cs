using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.NullObject
{
    public class RealCustomer : AbstractCustomer
    {
        public RealCustomer(string name)
        {
            Name = name;
        }
        public override string GetName()
        {
            return this.Name;
        }

        public override bool IsNil()
        {
            return false;
        }
    }
}
