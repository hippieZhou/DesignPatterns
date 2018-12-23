using System;

namespace DesignPatterns.Template
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Cricket();
            game.Play();

            game = new Football();
            game.Play();

            Console.ReadKey();
        }
    }
}
