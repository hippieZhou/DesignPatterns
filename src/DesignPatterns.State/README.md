> 在状态模式中，类的行为时基于它的状态改变而改变。

## 介绍

状态模式属于行为型模式，通过运行对象在内部状态发生改变时改变它的行为，主要解决的问题是对象的行为严重依赖于它的状态。

## 类图描述

![](https://img2018.cnblogs.com/blog/749711/201812/749711-20181216173932122-1928364443.png)

## 代码实现

1、定义状态上下文

```C#
    public class Context
    {
        private static IState state;

        public void SetState(IState state) => Context.state = state;

        public IState GetState() => state;
    }
```

2、定义行为接口

```C#
public interface IState
{
    void DoAction(Context context);
}
```

3、定义行为

```C#
public class StartState : IState
{
    public void DoAction(Context context)
    {
        Console.WriteLine("Player is in start state");
        context.SetState(this);
    }

    public override string ToString()
    {
        return "Start State";
    }
}

public class StopState : IState
{
    public void DoAction(Context context)
    {
        Console.WriteLine("Player is in stop state");
        context.SetState(this);
    }

    public override string ToString()
    {
        return "Stop State";
    }
}
```

4、上层调用

```C#
class Program
{
    static void Main(string[] args)
    {
        Context context = new Context();
        IState startState = new StartState();
        startState.DoAction(context);

        Console.WriteLine(context.GetState().ToString());

        IState stopState = new StopState();
        stopState.DoAction(context);
        Console.WriteLine(context.GetState().ToString());

        Console.ReadKey();
    }
}
```

## 总结

状态模式封装了转换规则，将每种状态与对应的的行为进行关联，这样可以使多个环境对象共享一个状态对象，从而减少系统中对象的个数。