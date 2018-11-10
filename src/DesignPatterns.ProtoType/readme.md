> 所谓原型模式是指为创建重复对象提供一种新的可能。

## 介绍

当面对系统资源紧缺的情况下，如果我们在重新创建一个新的完全一样的对象从某种意义上来讲是资源的浪费，因为在新对象的创建过程中，是会有系统资源的消耗，而为了尽可能的节省系统资源，我们有必要寻找一种新的方式来创建重复对象。

## 类图描述

![](https://img2018.cnblogs.com/blog/749711/201811/749711-20181110212623378-1391325987.png)

由于**Shape** 抽象类继承了 **ICloneable** 接口，所以通过上图我们可以发现，所有具体的类型都继承 **Shape** 抽象类，并实现 **Clone()** 方法即可。

## 代码实现

1、定义具有抽象基类

```C#
public abstract class Shape : ICloneable
{
    private string id;
    protected string type;
    public abstract void Draw();

    public string GetId() => id;
    public string GetType() => type;

    public void SetId(string id) => this.id = id;

    public new object MemberwiseClone() => base.MemberwiseClone();
    public abstract object Clone();
}
```

2、定义具体类型

```C#
public class Circle:Shape
{
    public Circle() => type = "Circle";
    public override void Draw()
    {
        Console.WriteLine("I am a Circle");
    }
    public override object Clone()
    {
        Circle obj = new Circle();
        obj.type = type;
        obj.SetId(this.GetId());
        return obj;
    }
}

public class Rectangle:Shape
{
    public Rectangle() => type = "Rectangle";
    public override void Draw()
    {

        Console.WriteLine("I am a Rectangle");
    }
    public override object Clone()
    {
        Rectangle obj = new Rectangle();
        obj.type = type;
        obj.SetId(this.GetId());
        return obj;

    }
}

public class Square:Shape
{
    public Square() => type = "Square";
    public override void Draw()
    {
        Console.WriteLine("I am a Square");
    }
    public override object Clone()
    {
        Square obj = new Square();
        obj.type = type;
        obj.SetId(this.GetId());
        return obj;
    }
}
```

3、创建种子数据

```C#
public class ShapeCache
{
    private  static  HashSet<Shape> shapeMap = new HashSet<Shape>();

    public static Shape GetShape(string shapeId)
    {
        var cachedShape = shapeMap.FirstOrDefault(p => p.GetId() == shapeId);
        return (Shape) cachedShape?.Clone();
    }

    public static void LoadCache()
    {
        Circle circle = new Circle();
        circle.SetId("1");
        shapeMap.Add(circle);


        Square square = new Square();
        square.SetId("2");
        shapeMap.Add(square);

        Rectangle rectangle = new Rectangle();
        rectangle.SetId("3");
        shapeMap.Add(rectangle);
    }
}
```

4、上层调用

```C#
class Program
{
    static void Main(string[] args)
    {
        ShapeCache.LoadCache();

        Shape clonedShape1 = (Shape) ShapeCache.GetShape("1");
        Console.WriteLine(clonedShape1.GetType());
        clonedShape1.Draw();

        Shape clonedShape2 = (Shape)ShapeCache.GetShape("2");
        Console.WriteLine(clonedShape2.GetType());
        clonedShape2.Draw();

        Shape clonedShape3 = (Shape)ShapeCache.GetShape("3");
        Console.WriteLine(clonedShape3.GetType());
        clonedShape3.Draw();

        Console.ReadKey();
    }
}
```

## 总结

在 *C#* 中实现原型模式的关键是需要定义一个继承 **ICloneable** 接口的抽象类，并在子类中重写相应的 **Clone()**	方法即可。