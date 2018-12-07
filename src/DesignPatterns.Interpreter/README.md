> 解释器模式通过实现一个表达式接口，从而能够以指定方式解析指定内容

## 介绍

解释器模式属于行为型模式，通过这种设计模式，我们可以定义一种特定的解释器来解释特定的业务场景，可以类比不同的编程语言的编译器需要设计不同的解释器来编译执行。

## 类图描述

![](https://img2018.cnblogs.com/blog/749711/201812/749711-20181207220241317-1608370167.png)

## 代码实现

1、定义表达式接口

```C#
public interface IExpression
{
    bool Interpret(string context);
}
```

2、创建接口实体

```C#
public class TerminalExpression : IExpression
{
    private string data;

    public TerminalExpression(string data)
    {
        this.data = data;
    }
    public bool Interpret(string context)
    {
        return context.Contains(data);
    }
}

public class AndExpression : IExpression
{
    private IExpression expr1 = null;
    private IExpression expr2 = null;
    public AndExpression(IExpression expr1, IExpression expr2)
    {
        this.expr1 = expr1;
        this.expr2 = expr2;
    }

    public bool Interpret(string context)
    {
        return expr1.Interpret(context) && expr2.Interpret(context);
    }
}

public class OrExpression : IExpression
{
    private IExpression expr1 = null;
    private IExpression expr2 = null;
    public OrExpression(IExpression expr1,IExpression expr2)
    {
        this.expr1 = expr1;
        this.expr2 = expr2;
    }
    public bool Interpret(string context)
    {
        return expr1.Interpret(context) || expr2.Interpret(context);
    }
}
```

3、创建规则，上层调用

```C#
class Program
{
    static IExpression GetMaleExpression()
    {
        IExpression robert = new TerminalExpression("Robert");
        IExpression john = new TerminalExpression("John");
        return new OrExpression(robert, john);
    }
    static IExpression GetMarriedWomanExpression()
    {
        IExpression julie = new TerminalExpression("Julie");
        IExpression married = new TerminalExpression("Married");
        return new AndExpression(julie, married);
    }

    static void Main(string[] args)
    {
        IExpression isMale = GetMaleExpression();
        IExpression isMarriedWoman = GetMarriedWomanExpression();

        Console.WriteLine($"John is male? {isMale.Interpret("John")}");
        Console.WriteLine($"Julie is a married women? {isMarriedWoman.Interpret("Married Julie")}");
        Console.ReadKey();
    }
}
```

## 总结

解释器模式可利用的场景比较少，在遇到规则类的业务场景时可以考虑采用这种方式。