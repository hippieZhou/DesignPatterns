using System;

namespace DesignPatterns.NullObject
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractCustomer customer1 = CustomerFactory.GetCustomer("Rob");
            AbstractCustomer customer2 = CustomerFactory.GetCustomer("Bob");
            AbstractCustomer customer3 = CustomerFactory.GetCustomer("Julie");
            AbstractCustomer customer4 = CustomerFactory.GetCustomer("Laura");
            Console.WriteLine("Customers");
            Console.WriteLine(customer1.GetName());
            Console.WriteLine(customer2.GetName());
            Console.WriteLine(customer3.GetName());
            Console.WriteLine(customer4.GetName());

            Console.ReadKey();
        }
    }
}
