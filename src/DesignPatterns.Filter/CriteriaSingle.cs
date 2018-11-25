using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Filter
{
    public class CriteriaSingle : ICriteria
    {
        public IEnumerable<Person> MeetCriteria(IEnumerable<Person> persons)
        {
            List<Person> malePersons = new List<Person>();
            malePersons.AddRange(persons.Where(p => p.GetMaritalStatus() == "SINGLE"));
            return malePersons;
        }
    }
}
