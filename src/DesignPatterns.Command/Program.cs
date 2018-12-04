using System;

namespace DesignPatterns.Command
{
    class Program
    {
        static void Main(string[] args)
        {
            var abcStock = new Stock();
            var buyStockOrder = new BuyStock(abcStock);
            var sellStock = new SellStock(abcStock);

            var broker = new Broker();
            broker.TakeOrder(buyStockOrder);
            broker.TakeOrder(sellStock);
            broker.PlaceOrders();

            Console.ReadKey();
        }
    }
}
