using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.NullObject
{
    public class CustomerFactory
    {
        public static readonly string[] names = { "Rob", "Joe", "Julie" };

        public static AbstractCustomer GetCustomer(string name)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] == name)
                    return new RealCustomer(names[i]);
            }
            return new NullCustomer();
        }
    }
}
