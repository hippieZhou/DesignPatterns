> 在模板模式中，一个抽象类公开定义了执行它的方法的方式或方法

## 介绍

模板模式属于行为型模式，通过将相似的业务行为抽离出来放到抽象类中暴露给上层，然后在自己子类中实现具体的业务行为，通过模板类来约束上层的业务调用。

## 类图描述

![](https://img2018.cnblogs.com/blog/749711/201812/749711-20181223150235666-1907870312.png)

## 代码实现

1、定义抽象基类

```C#
public abstract class Game
{
    public abstract void Initialize();
    public abstract void StartPlay();
    public abstract void EndPlay();

    public void Play()
    {
        Initialize();
        StartPlay();
        EndPlay();
    }
}
```

2、定义业务子类

```C#
public class Cricket : Game
{
    public override void EndPlay()
    {
        Console.WriteLine("Cricket Game Finished");
    }

    public override void Initialize()
    {
        Console.WriteLine("Cricket Game Initialized!Start palying");
    }

    public override void StartPlay()
    {
        Console.WriteLine("Cricket Game Started.Enjoy the game");
    }
}

public class Football : Game
{
    public override void StartPlay()
    {
        Console.WriteLine("Football Game Started.Enjog the game");
    }

    public override void Initialize()
    {
        Console.WriteLine("Football Game Initialized.Start playing.");
    }

    public override void EndPlay()
    {
        Console.WriteLine("Football Game Finished.");
    }
}
```

3、上层调用

```C#
class Program
{
    static void Main(string[] args)
    {
        Game game = new Cricket();
        game.Play();

        game = new Football();
        game.Play();

        Console.ReadKey();
    }
}
```

## 总结 

模板方法类似在建造房子时先将房子的整体框架搭建后，然后具体的建筑细节放到建筑这个地方的时候再具体考虑，延迟的业务的构造。