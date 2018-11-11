> 使用桥接模式可以将类型的抽象和具体实现进行分离，两者通过桥接模式进行关联，从而达到解耦

## 介绍

桥接模式属于结构型模式。在现实世界中，我们装修房子时，布线的工人和安装空调的工人之间可以同时工作，不用互相依赖。而对于屋主人来讲也不用关系他们具体时怎么工作的，只需要等他们完成即可。在软件开发中，当我们面对一个业务中两个独立的子业务时，使用桥接模式是一个不错的选择。

## 类图描述

![](https://img2018.cnblogs.com/blog/749711/201811/749711-20181111155745078-358952050.png)

由上图我们可以看到，我们定义了一个抽象类 **Shape** 来继承 **IDrawAPI** 接口，然后定义两种绘制方式 **GreenCircle** 和 **RedCircle** ,最后上层通过将具体绘制传递给 **Circle** 即可。

## 代码实现

1、定义绘制接口

```C#
    public interface IDrawAPI
    {
        void DrawCircle(int radius, int x, int y);
    }
```

2、定义具体绘制类

```C#
public class RedCircle:IDrawAPI
{
    public void DrawCircle(int radius, int x, int y)
    {
        Console.WriteLine($"Drawing Circle[color:red,radius:{radius},x:{x},y:{y}]");
    }
}

public class GreenCircle:IDrawAPI
{
    public void DrawCircle(int radius, int x, int y)
    {
        Console.WriteLine($"Drawing Circle[color:green,radius:{radius},x:{x},y:{y}]");
    }
}
```

3、定义抽象形状类

```C#
public abstract class Shape
{
    protected IDrawAPI drawAPI;

    protected Shape(IDrawAPI drawAPI) => this.drawAPI = drawAPI;

    public abstract void Draw();
}
```

4、定义具体形状类

```C#
public class Circle:Shape
{
    private int x, y, radius;
    public Circle(int x,int y,int radius,IDrawAPI drawAPI) : base(drawAPI)
    {
        this.x = x;
        this.y = y;
        this.radius = radius;
    }

    public override void Draw()
    {
        drawAPI.DrawCircle(radius, x, y);
    }
}
```

5、上层调用

```C#
class Program
{
    static void Main(string[] args)
    {
        Shape redCircle = new Circle(100, 100, 10, new RedCircle());
        redCircle.Draw();

        Shape greenCircle = new Circle(100, 100, 10, new GreenCircle());
        greenCircle.Draw();

        Console.ReadKey();
    }
}
```

## 总结

桥接模式将抽象和实现进行了分离，让它们能独立变化，使得具体的实现细节不用暴露给上层。
