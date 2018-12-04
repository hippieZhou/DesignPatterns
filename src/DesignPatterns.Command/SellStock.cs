using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Command
{
    public class SellStock:IOrder
    {
        private Stock abcStock;

        public SellStock(Stock abcStock)
        {
            this.abcStock = abcStock;
        }

        public void Execute()
        {
            abcStock.Sell();
        }
    }
}
