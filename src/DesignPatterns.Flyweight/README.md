> 享元模式主要通过共享对象的方式来减少对象的创建。

## 介绍

在复杂系统中，频繁创建对象是一件很耗资源的操作，为了节约系统有限的资源，我们有必要通过某种技术来减少对象的创建。在 **AspNetCore** 大量使用了 **依赖注入** 技术从而达到对象的集中式管理。

## 类图描述

![](https://img2018.cnblogs.com/blog/749711/201811/749711-20181125201311525-318165081.png)

由上图可知，通过定义一个 **IShape** 接口来约束实体类行为，**Circle** 为具体的实体类，**ShapeFactory** 为享元工厂，用于统一所有实体类的初始化操作。

## 代码实现

1、定义行为接口

```C#
public interface IShape
{
    void Draw();
}
```

2、定义对象实体

```C#
public class Circle:IShape
{
    private string color;
    private int x;
    private int y;
    private int radius;
    public Circle(string color)
    {
        this.color = color;
    }

    public void SetX(int x) => this.x = x;
    public void SetY(int y) => this.y = y;
    public void SetRadius(int radius) => this.radius = radius;
    public void Draw() => Console.WriteLine($"Circle:Draw()[Color:{color},x={x},y={y},radius:{radius}]");
}
```

3、定义享元工厂

```C#
public class ShapeFactory
{
    private static Dictionary<string, IShape> circleMap = new Dictionary<string, IShape>();

    public static IShape GetCircle(string color)
    {
        circleMap.TryGetValue(color, out var circle);

        if (circle != null) return circle;
        circle = new Circle(color);
        circleMap.Add(color, circle);
        Console.WriteLine($"Creating circle of color:{color}");

        return circle;
    }
}
```

4、上层调用

```C#
class Program
{
    private static string[] colors = new[] {"Red", "Green", "Blue", "White", "Black"};
    private static Random random = new Random();

    static void Main(string[] args)
    {
        for (int i = 0; i < 20; i++)
        {
            Circle circle = (Circle) ShapeFactory.GetCircle(GetRandomColor());
            circle.SetX(GetRandomX());
            circle.SetY(GetRandomY());
            circle.SetRadius(100);
            circle.Draw();
        }

        Console.ReadKey();
    }

    private static string GetRandomColor()
    {
        return colors[random.Next(0, colors.Length)];
    }

    private static int GetRandomX()
    {
        return random.Next(0, colors.Length) * 100;
    }

    private static int GetRandomY()
    {
        return random.Next(0, colors.Length) * 100;
    }
}
```

## 总结 

如果系统中需要大量初始化相似对象，系统资源使用紧张，此时使用享元模式较为合适，但是需要注意的是要合理区分内部操作和外部操作，否则很容易引起线程安全的问题。