> 迭代器模式在 **.Net** 中使用很广泛，其循环遍历对于的集合已经实现了迭代器模式

## 介绍

迭代器模式属于行为型模式，它通过提供一种方法来顺序访问集合对象中的每个元素，而又不用暴露其内部表示。

## 类图描述

![](https://img2018.cnblogs.com/blog/749711/201812/749711-20181208121555756-2054581541.png)

## 代码实现

1、创建接口

```C#
public interface IIterator
{
    bool hasNext();
    object Next();
}

public interface Container
{
    IIterator GetIterator();
}
```

2、创建可遍历的实体类

```C#
public class NameRepository : Container
{
    public static string[] names = {"Robert", "John", "Julie", "Lora"};

    public IIterator GetIterator()
    {
        return new NameIterator();
    }

    private class NameIterator : IIterator
    {
        private int index;
        public bool hasNext()
        {
            return index < names.Length;
        }

        public object Next()
        {
            return hasNext() ? names[index++] : null;
        }
    }
}
```

3、上层调用

```C#
class Program
{
    static void Main(string[] args)
    {
        var namesRepository = new NameRepository();
        var iter = namesRepository.GetIterator();
        for (;iter.hasNext();)
        {
            Console.WriteLine(iter.Next());
        }
        Console.ReadKey();
    }
}
```

## 总结

迭代器模式常用于对聚合对象的遍历。这种模式分离了集合对象的遍历行为。如果一个对象需要使用遍历的同时又不想暴露内部，这个时候则可以考虑使用这种设计模式。
 