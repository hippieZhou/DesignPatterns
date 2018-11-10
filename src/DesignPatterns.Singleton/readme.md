> 单例模式就是指单例类在一定的生命周期内只能有一个对象实例，单例类的创建必须是本身，并能给使用者提供自身。

## 介绍

在现实世界中，每个生命体都可以被看做是一个单例对象，唯一且具体，具有不可复制性。同样的，在软件开发领域中，有时我们需要保证客户端在当前的客户机上只能运行一个实例这个时候，我们就应该考虑使用单例模式来实现这种业务场景。


## 类图描述

略

## 代码实现

1、懒汉式，线程不安全

```C#
public class SingleObject
{
    private static SingleObject _instance;

    private SingleObject()
    {
    }

    public static SingleObject GetInstance() => _instance ?? (_instance = new SingleObject());

    public void ShowMessage()
    {
        Console.WriteLine("Hello World");
    }
}
```

2、懒汉式，线程安全

```C#
public class SingleObject
{
    private static SingleObject _instance;

    private static readonly object _locker = new object();

    private SingleObject()
    {

    }

    public static SingleObject GetInstance()
    {
        if (_instance == null)
        {
            lock (_locker)
            {
                if (_instance == null)
                {
                    _instance = new SingleObject();
                }
            }
        }

        return _instance;
    }

    public void ShowMessage()
    {
        Console.WriteLine("Hello World");
    }
}
```

3、静态内部类延迟加载

```C#
public class SingleObject
{
    public static SingleObject GetInstance() => Nested.Instance;

    private sealed class Nested
    {
        static Nested()
        {
        }
        internal  static readonly  SingleObject Instance = new SingleObject();
    }
    public void ShowMessage()
    {
        Console.WriteLine("Hello World");
    }
}
```

4、上层调用

```C#
class Program
{
    static void Main(string[] args)
    {

        SingleObject.GetInstance().ShowMessage();
        Console.ReadKey();
    }
}
```

## 总结

对于单例模式，较为好理解，如果需要保持对象的唯一性，则可以考虑使用这种模式进行解决。