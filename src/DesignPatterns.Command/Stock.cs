using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Command
{
    public class Stock
    {
        private string name = "ABC";
        private int quantity = 10;

        public void Buy()
        {
            Console.WriteLine($"Stock [name:{name} Quantity:{quantity}] bought");
        }

        public void Sell()
        {
            Console.WriteLine($"Stock [Name:{name} Quantity:{quantity}] sold");
        }
    }
}
