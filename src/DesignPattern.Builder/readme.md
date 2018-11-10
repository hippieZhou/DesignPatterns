> 建造者模式通过将复杂对象逐一拆解成单一的简单对象，然后通过对简单对象的创建，最终构建出一个复杂对象。

## 介绍

在现实世界中，和建造者模式最为相似的是我们到餐厅点餐的流程。在点餐的过程中，我们是不用关系点餐的先后顺序，等我们点完后，点餐系统会自动将我们的所有餐品列表和消费情况全部一次性罗列出来，并且最后都会统一结算。这个过程其实就是建造者模式的应用。

## 类图描述

![](https://img2018.cnblogs.com/blog/749711/201811/749711-20181110194955753-1418840863.png)

通过上述类图，我们可以发现一个复杂对象通过 **MealBuilder** 来进行创建，然后 MealBuilder 在进行细化，通过实例化不同的 **IItem** 类型，来达到创建不同的实例对象并对其进行最终的拼装组合。

## 代码实现

1、定义食物制作和信息接口

```C#
public interface IPacking
{
    string Pack();
}

public interface IItem
{
    string Name();
    IPacking Packing();
    float Price();
}
```
2、定义抽象食物

```C#
public abstract class ColdDrink:IItem
{
    public abstract string Name();

    public IPacking Packing()
    {
        return  new Bottle();
    }

    public abstract float Price();
}

public abstract class Burger:IItem
{
    public abstract string Name();

    public IPacking Packing()
    {
        return  new Wrapper();
    }

    public abstract float Price();
}

```

3、定义具体制作类

```C#
class Bottle:IPacking
{
    public string Pack() => "Bottle";
}

public class Wrapper : IPacking
{
    public string Pack() => "Wrapper";
}
```

4、定义具体食物类

```C#
public class Pepsi : ColdDrink
{
    public override string Name() => "Pepsi";

    public override float Price() => 35.0f;
}

public class Coke : ColdDrink
{
    public override string Name() => "Coke";

    public override float Price() => 30.0f;
}

public class VegBurger:Burger
{
    public override string Name() => "Veg Burger";

    public override float Price() => 25.0f;
}
```

5、定义模拟用户点餐类

```C#
public class MealBuilder
{
    public Meal PrepareVegMeal()
    {
        Meal meal = new Meal();
        meal.AddItem(new VegBurger());
        meal.AddItem(new Coke());
        return meal;
    }

    public Meal PrepareNonMeal()
    {
        Meal meal = new Meal();
        meal.AddItem(new ChickenBurger());
        meal.AddItem(new Pepsi());
        return meal;
    }
}
```

6、上层调用

```C#
class Program
{
    static void Main(string[] args)
    {
        MealBuilder builder = new MealBuilder();

        Meal vegMeal = builder.PrepareVegMeal();
        Console.WriteLine("Veg Meal");
        vegMeal.ShowItems();
        Console.WriteLine($"Total Cost:{vegMeal.GetCost()}");

        Console.WriteLine("-----------------");

        Meal nonVegMeal = builder.PrepareNonMeal();
        Console.WriteLine("Non-Veg Meal");
        nonVegMeal.ShowItems();
        Console.WriteLine($"Total Cost:{nonVegMeal.GetCost()}");

        Console.ReadKey();
    }
}
```

## 总结

建造者模式使用多个简单的对象进行拼装组合，并最终构建出一个复杂对象，它提供了一种创建对象的最佳方式。
