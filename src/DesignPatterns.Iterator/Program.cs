using System;

namespace DesignPatterns.Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            var namesRepository = new NameRepository();
            var iter = namesRepository.GetIterator();
            for (;iter.hasNext();)
            {
                Console.WriteLine(iter.Next());
            }
            Console.ReadKey();
        }
    }
}
