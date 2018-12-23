> 在策略模式中，一个类的行为或其算法可以在运行时更改。

## 介绍

策略模式属于行为型模式，通过将一系列通用算法封装起来，使它们能够动态替换，而不是通过一大堆条件语句进行选择判断。

## 类图描述

![](https://img2018.cnblogs.com/blog/749711/201812/749711-20181223150208970-402695904.png)

## 代码实现

1、定义策略接口
```C#
public interface IStrategy
{
    int DoOperation(int num1, int num2);
}
```

2、实现策略
```C#
public class OperationAdd : IStrategy
{
    public int DoOperation(int num1, int num2) => num1 + num2;
}

public class OperationMultiply : IStrategy
{
    public int DoOperation(int num1, int num2) => num1 * num2;
}

public class OperationSubstract : IStrategy
{
    public int DoOperation(int num1, int num2) => num1 - num2;
}
```

3、封装策略
```C#
public class Context
{
    private readonly IStrategy _strategy;
    public Context(IStrategy strategy) => _strategy = strategy;

    public int ExecuteStrategy(int num1, int num2) => _strategy.DoOperation(num1, num2);
}
```

4、上层调用
```C#
class Program
{
    static void Main(string[] args)
    {
        Context context = new Context(new OperationAdd());
        Console.WriteLine($"10 + 5 = {context.ExecuteStrategy(10, 5)}");

        context = new Context(new OperationSubstract());
        Console.WriteLine($"10 - 5 = {context.ExecuteStrategy(10, 5)}");

        context = new Context(new OperationMultiply());
        Console.WriteLine($"10 * 5 = {context.ExecuteStrategy(10, 5)}");

        Console.ReadKey();
    }
}
```

## 总结

策略模式的出现是为了解决条件语句判断的难维护，简化了策略选择的代码复杂度。