> 通过创建现有对象的对象，以便向外界通过访问接口，这种模式我们称之为代理模式

## 介绍

代理模式属于结构型模式，通过在对象与对象之间添加一个代理中间层来到达对目标对象的间接访问。

## 类图描述

![](https://img2018.cnblogs.com/blog/749711/201812/749711-20181202202514770-1107887188.png)

由上图可知，我们通过定义一个基本接口来约束业务行为，然后定义具体的业务实现该接口，最后通过定义一个代理类来协调上层和具体业务实体之间的访问，从而使上层也能访问到下层对象。

## 代码实现

1、创建接口

```C#
public interface IImage
{
    void Display();
}
```

2、实现接口

```C#
public class RealImage : IImage
{
    private string fileName;
    public RealImage(string fileName)
    {
        this.fileName = fileName;
        LoadFromDisk();
    }

    public void Display() => Console.WriteLine($"Displaying:{fileName}");
    private void LoadFromDisk() => Console.WriteLine($"Loading:{fileName}");
}
```

3、定义代理类

```C#
public class ProxyImage : IImage
{
    private RealImage realImage;
    private string fileName;
    public ProxyImage(string fileName)
    {
        this.fileName = fileName;
    }

    public void Display()
    {
        if (realImage == null)
        {
            realImage = new RealImage(fileName);
        }
        realImage.Display();
    }
}
```

4、上层调用

```C#
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
```

## 总结

当上层访问下次对象时，由于业务的需要，我们需要对下层对象进行一个处理，这个时候可以考虑使用代理模式来解决，这个模式带来的好处是保证了现有底层对象不变的情况下进行了访问控制。