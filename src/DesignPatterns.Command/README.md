> 命令模式是一种数据驱动型的设计模式，它以命令的形式包裹在对象中，并传递给调用者。

## 介绍

命令模式属于行为型设计模式，它通过将一个请求封装成一个对象，从而使我们可以用不同的请求对客户端进行参数化。

## 类图描述

![](https://img2018.cnblogs.com/blog/749711/201812/749711-20181204220643389-1714376584.png)

## 代码实现

1、创建命令接口

```C#
public interface IOrder
{
    void Execute();
}
```

2、创建一个模拟请求类

```C#
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
```

3、创建命令接口的实现类

```C#
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
```

4、创建命令调用类

```C#
public class Broker
{
    private  List<IOrder> orderList = new List<IOrder>();

    public void TakeOrder(IOrder order)
    {
        orderList.Add(order);
    }

    public void PlaceOrders()
    {
        foreach (var order in orderList)
        {
            order.Execute();
        }
        orderList.Clear();
    }
}
```

5、上层调用

```C#
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
```

## 总结

命令模式通过将实体和行为进行分离，使得对行为的操作不依赖于实体，双方解耦，降低了系统耦合度。
