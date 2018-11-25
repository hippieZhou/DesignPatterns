using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Filter
{
    public class CriteriaFemale : ICriteria
    {
        public IEnumerable<Person> MeetCriteria(IEnumerable<Person> persions)
        {
            List<Person> femalePersons = new List<Person>();
            femalePersons.AddRange(persions.Where(p => p.GetGender() == "FEMALE"));
            return femalePersons;
        }
    }
}
