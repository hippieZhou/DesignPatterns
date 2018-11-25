using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Filter
{
    public class CriteriaMale : ICriteria
    {
        public IEnumerable<Person> MeetCriteria(IEnumerable<Person> persions)
        {
            List<Person> malePersons = new List<Person>();
            malePersons.AddRange(persions.Where(p => p.GetGender() == "MALE"));
            return malePersons;
        }
    }
}
