> 备忘录模式通过保存一个对象的某个状态，以便在需要的时候恢复该对象。

## 介绍

备忘录模式属于行为型模式，它通过在不破坏封装性的前提下，捕获一个对象的内部状态，并在该对象之外保存这个状态。

## 类图描述

![](https://img2018.cnblogs.com/blog/749711/201812/749711-20181209215631032-1040571313.png)

## 代码实现

1、创建实体类

```C#
public class Memento
{
    private string state;
    public Memento(string state)
    {
        this.state = state;
    }

    public string GetState() => state;
}
```

2、创建状态处理类

```C#
public class Originator
{
    private string state;
    public void SetState(string state)
    {
        this.state = state;
    }

    public string GetState()
    {
        return state;
    }

    public Memento SaveStateToMemento()
    {
        return new Memento(this.state);
    }

    public void GetStateFromMemento(Memento memento)
    {
        state = memento.GetState();
    }
}
```

3、创建储存集合

```C#
public class CareTaker
{
    private List<Memento> mementoList = new List<Memento>();

    public void Add(Memento state)
    {
        mementoList.Add(state);
    }

    public Memento Get(int index)
    {
        return mementoList[index];
    }
}
```

4、上层调用

```C#
class Program
{
    static void Main(string[] args)
    {
        Originator originator = new Originator();
        CareTaker careTaker = new CareTaker();
        originator.SetState("State #1");
        originator.SetState("State #2");
        careTaker.Add(originator.SaveStateToMemento());
        originator.SetState("State #3");
        careTaker.Add(originator.SaveStateToMemento());
        originator.SetState("State #4");

        Console.WriteLine($"Current State:{originator.GetState()}");
        originator.GetStateFromMemento(careTaker.Get(0));
        Console.WriteLine($"First saved State:{originator.GetState()}");
        originator.GetStateFromMemento(careTaker.Get(1));
        Console.WriteLine($"Second saved State:{originator.GetState()}");

        Console.ReadKey();
    }
}
```

## 总结

备忘录模式常用于数据的可回退操作，这样能解决一些义务处理的误操作。为了节省内存，可使用 原型模式+备忘录模式 的方式。