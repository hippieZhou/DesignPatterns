using System;

namespace DesignPatterns.Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            IImage image = new ProxyImage("test.png");
            image.Display();

            //继续访问时不会创建新对象
            image.Display();
            Console.ReadKey();
        }
    }
}
