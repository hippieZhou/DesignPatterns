> 抽象工厂是基于简单工厂发展而来的，通过抽象工厂，我们可以创建多种类型的工厂，并且依据具体业务需求而在具体工厂里面进行任意拼装组合。

## 介绍

在现实世界中，汽车制作行业有各种各样的工厂，每个工厂都需要具有生产轮胎、汽车引擎等部件的能力，但是针对具体的工厂，每个部件的生产又各不相同，所有在软件开发过程中，当我们为客户端制作各种各样的皮肤时，就可以参考这种设计模式。

## 类图描述

![](https://img2018.cnblogs.com/blog/749711/201811/749711-20181110165736897-1166188478.png)

从上图我们可以发现，我们通过定义一个抽象工厂 **AbstractFactory** 来约束具体每种工厂所具备的能力，然后通过定义 **IShape** 和 **IColor** 来约束具体每个部件所具备的行为。接着，对相应接口进行继承并实现相应行为从而达到能生产具体某种类型的对象。最后，上层公共调用工厂管理类来获取具体的产品对象，而对其内部构成不用关心。

## 代码实现

1、定义部件接口

```C#
public interface IColor
{
    void Fill();
}

public interface IShape
{
    void Draw();
}
```

2、定义各种类型的部件元素

```C#
public class Blue:IColor
{
    public void Fill()
    {
        Console.WriteLine("Filled with blue");
    }
}

public class Green : IColor
{
    public void Fill()
    {
        Console.WriteLine("Filled with green");
    }
}

class Red:IColor
{
    public void Fill()
    {
        Console.WriteLine("Filled with red");
    }
}

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

public class Square : IShape
{
    public void Draw()
    {
        Console.WriteLine("I am a Square");
    }
}
```

3、定义抽象工厂

```C#
public abstract class AbstractFactory
{
    public abstract IColor GetColor(ColorType colorType);

    public abstract IShape GetShape(ShapeType shapeType);
}
```

3、定义具体工厂

```C#
public class ColorFactory:AbstractFactory
{
    public override IColor GetColor(ColorType colorType)
    {
        IColor color = null;
        switch (colorType)
        {
            case ColorType.Blue:
                color= new Blue();
                break;
            case ColorType.Green:
                color =new Green();
                break;
            case ColorType.Red:
                color = new Red();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(colorType), colorType, null);
        }

        return color;
    }

    public override IShape GetShape(ShapeType shapeType)
    {
        return null;
    }
}

public class ShapeFactory:AbstractFactory
{
    public override IColor GetColor(ColorType colorType)
    {
        return null;
    }

    public override IShape GetShape(ShapeType shapeType)
    {
        IShape shape = null;
        switch (shapeType)
        {
            case ShapeType.Circle:
                shape = new Circle();
                break;
            case ShapeType.Rectangle:
                shape = new Rectangle();
                break;
            case ShapeType.Square:
                shape = new Square();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(shapeType), shapeType, null);
        }
        return shape;
    }
}
```


4、定义工厂管理类

```C#
public class FactoryProducer
{
    public static Factories.AbstractFactory GetFactory(ProducerType producerType)
    {
        switch (producerType)
        {
            case ProducerType.Shape:
                return new ShapeFactory();
            case ProducerType.Color:
                return new ColorFactory();
            default:
                throw new ArgumentOutOfRangeException(nameof(producerType), producerType, null);
        }
    }
}
```

5、上层调用

```C#
class Program
{
    static void Main(string[] args)
    {
        Factories.AbstractFactory shapeFactory = FactoryProducer.GetFactory(ProducerType.Shape);
        IShape shape = shapeFactory.GetShape(ShapeType.Circle);
        shape.Draw();

        Factories.AbstractFactory colorFactory = FactoryProducer.GetFactory(ProducerType.Color);
        IColor color = colorFactory.GetColor(ColorType.Red);
        color.Fill();

        Console.ReadKey();
    }
}
```

## 总结

当一个产品集合中的多个部件可以任意组合时，使用抽象工厂较为合适，这使得每一层的类型创建较为具体，关注点较为统一。