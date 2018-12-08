> 中介者模式是用来降低多个对象和类之间的通信复杂性。这种模式提供了一个中介类，该类通常处理不同类之间的通信，并支持松耦合，使代码易于维护。

## 前言

中介者模式属于行为者模式，通过一个中介对象来封装一些列的对象交互，使对象之间解耦和，降低系统复杂度。

## 类图描述

![](https://img2018.cnblogs.com/blog/749711/201812/749711-20181208150634991-2038821760.png)

## 代码实现

1、创建中介类

```C#
public class ChatRoom
{
    public static void ShowMessage(User user, string message)
    {
        Console.WriteLine($"{DateTime.Now} [{user.GetName()}]:{message}");
    }
}
```

2、创建实体

```C#
public class User
{
    private string name;
    public User(string name)
    {
        this.name = name;
    }
    internal object GetName()
    {
        return this.name;
    }

    public void SetName(string name)
    {
        this.name = name;
    }

    public void SendMessage(string message)
    {
        ChatRoom.ShowMessage(this, message);
    }
}
```

3、上层调用

```C#
class Program
{
    static void Main(string[] args)
    {
        User robert = new User("Robert");
        User john = new User("john");

        robert.SendMessage("Hi! John!");
        john.SendMessage("Hello! Robert");

        Console.ReadKey();
    }
}
```

## 总结

中介者模式通过为多个对象提供统一的通信方式进而简化对象之间的复杂引用关系，但是这种模式应该适可而止，否则到时候会使中介者过于庞大而难以维护。