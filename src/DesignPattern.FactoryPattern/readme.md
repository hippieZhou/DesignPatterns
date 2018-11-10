> 简单工厂模式，属于创建型模式，它提供了一种创建对象的最佳方式。在工厂模式中，我们创建对象时不会对客户端暴露创建逻辑，而是通过一个统一的接口来指向新创建的对象。

## 介绍

在现实生活中，当我们去 4S 店购车时，我们不用考虑汽车的各个部件是如何生产的，而就可以提走一辆爱车。同样的，在软件开发过程中，当我们需要访问数据时，可以使用这种方法直接获取到数据，而不用考虑数据的底层存储是使用哪种存储方式。

## 类图描述

![](https://img2018.cnblogs.com/blog/749711/201811/749711-20181110133302024-355080471.png)

从上述类图中我们可以发现，**IShape** 为接口类型，定义了所有形状类型所具有的行为，然后具体的类型分别继承该接口并实现相应行为。接着又定义了一个 **ShapeFactory** 来统一所有类型的创建，最后，上层通过调用 ShapeFactory 并转递相应参数来获取具体类型的实例对象。

## 代码实现

1、创建接口 IShape 

```C#
public interface IShape
{
    void Draw();
}
```

2、定义相应形状类并继承 IShape 接口


```C#
public class Circle:IShape
{
    public void Draw()
    {
        Console.WriteLine("I am a Circle");
    }
}

public class Rectangle:IShape
{
    public void Draw()
    {
        Console.WriteLine("I am a Rectangle");
    }
}

public class Square:IShape
{
    public void Draw()
    {
        Console.WriteLine("I am a Square");
    }
}
```

3、创建一个工厂，用于生产指定类型的实体类对象

```C#
public enum ShapeType
{
    Circle,
    Rectangle,
    Square,
}

public class ShapeFactory
{
     public IShape GetShape(ShapeType shapeType)
     {
         IShape shape = null;
         switch (shapeType)
         {
             case ShapeType.Circle:
                 shape = new Circle();
                 break;
             case ShapeType.Rectangle:
                 shape  = new Rectangle();
                 break;
             case ShapeType.Square:
                 shape = new Square();
                 break;
         }
         return shape;
     }
}
```

4、上层调用

```C#
class Program
{
    static void Main(string[] args)
    {
        var  factory = new ShapeFactory();
        IShape shape = factory.GetShape(ShapeType.Rectangle);
        shape.Draw();

        Console.ReadKey();
    }
}
```

## 总结

从上述类图我们可以发现，使用工厂模式可以对复杂对象的创建提供了统一管理。每增加一个类型，都需要增加一个具体类和修改相应的工厂类，对于这一点，在一定程度上会增加系统发杂度。同时对于简单对象的创建，如果也使用这种方式的话就不太合适。