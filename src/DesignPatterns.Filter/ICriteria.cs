using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Filter
{
    public interface ICriteria
    {
        IEnumerable<Person> MeetCriteria(IEnumerable<Person> persons);
    }
}
