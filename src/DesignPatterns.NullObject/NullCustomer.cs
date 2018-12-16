using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.NullObject
{
    public class NullCustomer : AbstractCustomer
    {
        public override string GetName()
        {
            return "Not Available in Customer Database";
        }

        public override bool IsNil()
        {
            return true;
        }
    }
}
