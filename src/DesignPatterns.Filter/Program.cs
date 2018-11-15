using System;
using System.Collections.Generic;

namespace DesignPatterns.Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            persons.AddRange(new[] {
                new Person("Robert", "MALE", "SINGLE"),
                new Person("John", "MALE", "MARRIED"),
                new Person("Laura", "FEMALE", "MARRIED"),
                new Person("Diana", "FEMALE", "SINGLE"),
                new Person("Mike", "MALE", "SINGLE"),
                new Person("Bobby", "MALE", "SINGLE")
            });

            ICriteria male = new CriteriaMale();
            ICriteria female = new CriteriaFemale();
            ICriteria single = new CriteriaSingle();
            ICriteria singleMale = new AndCriteria(single, male);
            ICriteria singleOrFemale = new OrCriteria(single, female);

            Console.WriteLine("Males:");
            PrintPersons(male.MeetCriteria(persons));

            Console.WriteLine("Females:");
            PrintPersons(female.MeetCriteria(persons));

            Console.WriteLine("Single Males");
            PrintPersons(singleMale.MeetCriteria(persons));

            Console.WriteLine("Single Or Females");
            PrintPersons(singleOrFemale.MeetCriteria(persons));

            Console.ReadKey();
        }

        private static void PrintPersons(IEnumerable<Person> persons)
        {
            foreach (var person in persons)
            {
                Console.WriteLine($"Person [Name:{person.GetName()},Gender:{person.GetGender()},Marital Status:{person.GetMaritalStatus()}]");
            }
        }
    }
}
