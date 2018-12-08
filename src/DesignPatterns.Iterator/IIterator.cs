using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Iterator
{
    public interface IIterator
    {
        bool hasNext();
        object Next();
    }
}
