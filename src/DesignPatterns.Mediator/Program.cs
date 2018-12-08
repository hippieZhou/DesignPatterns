using System;

namespace DesignPatterns.Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            User robert = new User("Robert");
            User john = new User("john");

            robert.SendMessage("Hi! John!");
            john.SendMessage("Hello! Robert");

            Console.ReadKey();
        }
    }
}
