using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Filter
{
    public class AndCriteria : ICriteria
    {
        private ICriteria criteria;
        private ICriteria otherCriteria;

        public AndCriteria(ICriteria criteria,ICriteria otherCriteria)
        {
            this.criteria = criteria;
            this.otherCriteria = otherCriteria;
        }
        public IEnumerable<Person> MeetCriteria(IEnumerable<Person> persions)
        {
            IEnumerable<Person> firstCriteriaPersons = criteria.MeetCriteria(persions);
            return otherCriteria.MeetCriteria(firstCriteriaPersons);
        }
    }
}
