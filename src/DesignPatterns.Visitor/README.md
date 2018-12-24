> 访问者模式通过使用一个访问者类，是主业务改变执行算法

## 介绍

访问者模式属于行为型模式，通过依据不同的访问者来动态调整访问方式，将数据结构和数据操作进行分离，符合单一职责原则，扩展性较好。

## 类图描述

![](https://img2018.cnblogs.com/blog/749711/201812/749711-20181224212413200-1001170291.png)

## 代码实现

1、定义组件接口

```C#
public interface IComputerPart
{
    void Accept(ComputerPartVisitor computerPartVisitor);
}
```

2、定义访问者

```C#
public class Keyboard : IComputerPart
{
    public void Accept(ComputerPartVisitor computerPartVisitor)
    {
        computerPartVisitor.Visit(this);
    }
}

public class Monitor : IComputerPart
{
    public void Accept(ComputerPartVisitor computerPartVisitor)
    {
        computerPartVisitor.Visit(this);
    }
}

public class Mouse : IComputerPart
{
    public void Accept(ComputerPartVisitor computerPartVisitor)
    {
        computerPartVisitor.Visit(this);
    }
}

public class Computer : IComputerPart
{
    readonly IComputerPart[] parts;
    public Computer() => parts = new IComputerPart[] { new Mouse(), new Keyboard(), new Monitor() };

    public void Accept(ComputerPartVisitor computerPartVisitor)
    {
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i].Accept(computerPartVisitor);
        }
        computerPartVisitor.Visit(this);
    }
}
```

3、定义抽象访问者

```C#
public abstract class ComputerPartVisitor
{
    public abstract void Visit(Computer computer);
    public abstract void Visit(Mouse mouse);
    public abstract void Visit(Keyboard keyboard);
    public abstract void Visit(Monitor monitor);
}
```

4、实现访问者

```C#
public class ComputerPartDisplayVisitor : ComputerPartVisitor
{
    public override void Visit(Computer computer)
    {
        Console.WriteLine("Displaying computer");
    }

    public override void Visit(Mouse mouse)
    {
        Console.WriteLine("Displaying mouse");
    }

    public override void Visit(Keyboard keyboard)
    {
        Console.WriteLine("Displaying keyboard");
    }

    public override void Visit(Monitor monitor)
    {
        Console.WriteLine("Displaying monitor");
    }
}
```

5、上层调用

```C#
class Program
{
    static void Main(string[] args)
    {
        IComputerPart computer = new Computer();
        computer.Accept(new ComputerPartDisplayVisitor());
        Console.ReadKey();
    }
}
```

## 总结

访问者模式对访问功能进行统一管理，通过再被访问者的类中加几个对外提供接待访问者的接口，从而改变具体访问者的执行方式。
