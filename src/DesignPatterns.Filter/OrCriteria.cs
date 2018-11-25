using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Filter
{
    public class OrCriteria : ICriteria
    {
        private ICriteria criteria;
        private ICriteria otherCriteria;
        public OrCriteria(ICriteria criteria, ICriteria otherCriteria)
        {
            this.criteria = criteria;
            this.otherCriteria = otherCriteria;
        }

        public IEnumerable<Person> MeetCriteria(IEnumerable<Person> persions)
        {
            List<Person> firstCriteriaItems = criteria.MeetCriteria(persions).ToList();
            IEnumerable<Person> otherCriteriaItems = otherCriteria.MeetCriteria(persions);
            foreach (var person in otherCriteriaItems)
            {
                if (!firstCriteriaItems.Contains(person))
                {
                    firstCriteriaItems.Add(person);
                }
            }
            return firstCriteriaItems;
        }
    }
}
