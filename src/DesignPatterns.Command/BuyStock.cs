using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Command
{
    public class BuyStock:IOrder
    {
        private Stock abcStock;

        public BuyStock(Stock abcStock)
        {
            this.abcStock = abcStock;
        }

        public void Execute()
        {
            this.abcStock.Buy();
        }
    }
}
