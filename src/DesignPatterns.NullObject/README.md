> 空对象模式取代简单的 NULL 值判断，将空值检查作为一种不做任何事情的行为。

## 介绍

在空对象模式中，我们创建一个指定各种要执行的操作的抽象类和扩展该类的实体类，还创建一个未对该类做任何实现的空对象类，该空对象类将无缝地使用在需要检查空值的地方。

## 类图描述
![](https://img2018.cnblogs.com/blog/749711/201812/749711-20181216174040738-1685193692.jpg)

## 代码实现

1、定义抽象类

```C#
    public abstract class AbstractCustomer
    {
        protected string Name;
        public abstract bool IsNil();
        public abstract string GetName();
    }
```

2、定义实体类

```C#
public class NullCustomer : AbstractCustomer
{
    public override string GetName()
    {
        return "Not Available in Customer Database";
    }

    public override bool IsNil()
    {
        return true;
    }
}

public class RealCustomer : AbstractCustomer
{
    public RealCustomer(string name)
    {
        Name = name;
    }
    public override string GetName()
    {
        return this.Name;
    }

    public override bool IsNil()
    {
        return false;
    }
}
```

3、定义工厂类

```C#
public class CustomerFactory
{
    public static readonly string[] names = { "Rob", "Joe", "Julie" };

    public static AbstractCustomer GetCustomer(string name)
    {
        for (int i = 0; i < names.Length; i++)
        {
            if (names[i] == name)
                return new RealCustomer(names[i]);
        }
        return new NullCustomer();
    }
}
```

4、上层调用

```C#
class Program
{
    static void Main(string[] args)
    {
        AbstractCustomer customer1 = CustomerFactory.GetCustomer("Rob");
        AbstractCustomer customer2 = CustomerFactory.GetCustomer("Bob");
        AbstractCustomer customer3 = CustomerFactory.GetCustomer("Julie");
        AbstractCustomer customer4 = CustomerFactory.GetCustomer("Laura");
        Console.WriteLine("Customers");
        Console.WriteLine(customer1.GetName());
        Console.WriteLine(customer2.GetName());
        Console.WriteLine(customer3.GetName());
        Console.WriteLine(customer4.GetName());

        Console.ReadKey();
    }
}
```

## 总结