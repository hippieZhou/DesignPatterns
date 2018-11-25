> 外观模式通过创建新的对象访问接口，从而隐藏对象内部发复复杂性

## 介绍

外观模式属于创建型模式，通过定义的外观器，从而简化了具体对象的内部复杂性。这种模式通过在复杂系统和上层调用之间添加了一层，这一层对上提供简单接口，对下执行复杂操作。

## 类图描述

![](https://img2018.cnblogs.com/blog/749711/201811/749711-20181125181113360-1759505360.png)

通过上图我们可以发现，**IShape** 为行为接口，然后 **Rectangle** **Square** **Circle** 为具体的对象实体类型， **ShapeMarker** 为我们定义的外观器，通过它，我们能间接访问复杂对象。

## 代码实现

1、定义对象接口

```C#
public interface IShape
{
    void Draw();
}
```

2、定义实体对象类型

```C#
public class Circle:IShape
{
    public void Draw() => Console.WriteLine("Circle:Draw()");
}
public class Rectangle:IShape
{
    public void Draw() => Console.WriteLine("Rectangle:Draw()");
}
public class Square:IShape
{
    public void Draw() => Console.WriteLine("Square:Draw()");
}
```

3、定义外观类

```C#
public class ShapeMarker
{
    private IShape circle;
    private IShape rectangle;
    private IShape square;

    public ShapeMarker()
    {
        circle = new Circle();
        rectangle = new Rectangle();
        square = new Square();
    }

    public void DrawCircle() => circle.Draw();
    public void DrawRectangle() => rectangle.Draw();
    public void DrawSquare() => square.Draw();
}
```

4、上层调用

```C#
class Program
{
    static void Main(string[] args)
    {
        var shapeMarker = new ShapeMarker();
        shapeMarker.DrawCircle();
        shapeMarker.DrawRectangle();
        shapeMarker.DrawSquare();
        Console.ReadKey();
    }
}
```

## 总结

外观模式不符合开闭原则，如果外观类执行的操作过于复杂的话，则不建议使用这种模式。