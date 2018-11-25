> 装饰器模式允许向现有对象中添加新功能，同时又不改变其结构。

## 介绍

装饰器模式属于结构型模式，主要功能是能够动态地为一个对象添加额外功能。在保证现有功能的基础上，再添加新功能，可联想到 **WPF** 中的附件属性。

## 类图描述

![](https://img2018.cnblogs.com/blog/749711/201811/749711-20181118195322186-20129641.png)

由上图可知，我们定义了一个基础接口 **IShape** 用于约定对象的基础行为。然后通过定义**ShapeDecorator** 类 来扩展功能，**RedShapleDecorator** 为具体的扩展实现。

## 代码实现

1、定义接口

```C#
public interface IShape
{
    void Draw();
}
```

2、定义对象类型

```C#
public class Circle:IShape
{
    public void Draw()
    {
        Console.WriteLine("Shape:Circle");
    }
}

public class Rectangle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Shape:Rectangle");
    }
}
```

3、定义新的扩展装饰类

```C#
public class ShapeDecorator:IShape
{
    protected IShape decoratedShape;

    public ShapeDecorator(IShape decoratedShape)
    {
        this.decoratedShape = decoratedShape;
    }

    public virtual void Draw()
    {
        decoratedShape.Draw();
    }
}
```

4、定义扩展类的具体实现

```C#
public class RedShapleDecorator : ShapeDecorator
{
    public RedShapleDecorator(IShape decoratedShape) : base(decoratedShape)
    {
    }

    public override void Draw()
    {
        this.decoratedShape.Draw();
        setRedBorder(this.decoratedShape);
    }

    private void setRedBorder(IShape decoratedShape)
    {
        Console.WriteLine("Border Color:Red");
    }
}
```

5、上层调用

```C#
class Program
{
    static void Main(string[] args)
    {
        IShape circle = new Circle();
        IShape redCircle = new RedShapleDecorator(new Circle());

        IShape redRectangle = new RedShapleDecorator(new Rectangle());
        Console.WriteLine("Circle with normal border");
        circle.Draw();

        Console.WriteLine("Circle of red border");
        redCircle.Draw();

        Console.WriteLine("Rectangel of red border");
        redRectangle.Draw();

        Console.ReadKey();
    }
}
```

## 总结

装饰器模式使得对象的核心功能和扩展功能能够各自独立扩展互不影响。但是对于装饰功能较多的情况下不建议采用这种模式。


