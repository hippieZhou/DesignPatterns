using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Filter
{
    public class Person
    {
        private string name;
        private string gender;
        private string maritalStatus;

        public Person(string name, string gender, string maritalStatus)
        {
            this.name = name;
            this.gender = gender;
            this.maritalStatus = maritalStatus;
        }

        public string GetName() => name;
        public string GetGender() => gender;
        public string GetMaritalStatus() => maritalStatus;
    }
}
