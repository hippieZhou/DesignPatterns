using System;

namespace DesignPatterns.Singleton
{
    class Program
    {
        static void Main(string[] args)
        {

            SingleObject.GetInstance().ShowMessage();
            Console.ReadKey();
        }
    }
}
