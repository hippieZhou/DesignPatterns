using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Iterator
{
    public class NameRepository : Container
    {
        public static string[] names = {"Robert", "John", "Julie", "Lora"};

        public IIterator GetIterator()
        {
            return new NameIterator();
        }

        private class NameIterator : IIterator
        {
            private int index;
            public bool hasNext()
            {
                return index < names.Length;
            }

            public object Next()
            {
                return hasNext() ? names[index++] : null;
            }
        }
    }
}
