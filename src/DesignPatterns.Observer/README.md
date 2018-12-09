> 当对象之间存在一对多的关系时，若需要进行对象之间的通知，则可使用观察者模式

## 介绍

观察者模式属于行为型模式，当一个对象的状态发生改变时，若我们想通知其他对象，此时可通过观察者模式来进行解决。

## 类图描述

![](https://img2018.cnblogs.com/blog/749711/201812/749711-20181209222402877-220092438.png)

## 代码实现

1、定义抽象观察者

```C#
public abstract class Observer
{
    protected Subject subject;
    public abstract void Update();
}
```

2、定义观察者管理类

```C#
public class Subject
{
    private List<Observer> observers = new List<Observer>();

    private int state;
    public int GetState() => this.state;

    public void SetState(int state)
    {
        this.state = state;
        NitifyAllObservers();
    }

    public void Attach(Observer observer)
    {
        observers.Add(observer);
    }

    private void NitifyAllObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update();
        }
    }
}
```

3、定义具体观察者

```C#
public class BinaryObserver : Observer
{
    public BinaryObserver(Subject subject)
    {
        this.subject = subject;
        this.subject.Attach(this);
    }

    public override void Update()
    {
        Console.WriteLine($"Binary string:{subject.GetState()}");
    }
}

public class HexaObserver:Observer
{
    public HexaObserver(Subject subject)
    {
        this.subject = subject;
        this.subject.Attach(this);
    }

    public override void Update()
    {
        Console.WriteLine($"Hex string:{subject.GetState()}");
    }
}

public class OctalObserver:Observer
{
    public OctalObserver(Subject subject)
    {
        this.subject = subject;
        this.subject.Attach(this);
    }

    public override void Update()
    {
        Console.WriteLine($"Octal string:{subject.GetState()}");

    }
}
```

4、上层调用

```C#
class Program
{
    static void Main(string[] args)
    {
        Subject subject = new Subject();

        new HexaObserver(subject);
        new OctalObserver(subject);
        new BinaryObserver(subject);
        Console.WriteLine("First state change:15");
        subject.SetState(15);
        Console.WriteLine("Second state change:10");
        subject.SetState(10);

        Console.ReadKey();
    }
}
```

## 总结

观察者模式通过一种集合方式将所有观察者管理起来，并最终循环遍历通知所有对象。
