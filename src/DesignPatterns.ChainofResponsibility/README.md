> 责任链模式通过为请求创建一个 接收者对象的链，对请求的发送者和接收者进行解耦。

## 介绍

责任链属于行为型模式，在这种模式中，通常每个接收者都包含对另一个接收者的引用，如果一个对象不能处理该请求，那么则会继续往下传递，依此类推。可以参考 **C#** 中的事件处理程序就是采用这种思想。

## 类图描述



## 代码实现

1、创建抽象的记录器类

```C#
public abstract class AbstractLogger
{
    public static int INFO = 1;
    public static int DEBUG = 2;
    public static int ERROR = 3;

    protected int level;

    protected AbstractLogger nextLogger;

    public void SetNextLogger(AbstractLogger nextLogger)
    {
        this.nextLogger = nextLogger;
    }

    public void LogMessage(int level, string message)
    {
        if (this.level <= level)
        {
            write(message);
        }

        if (this.nextLogger != null)
        {
            nextLogger.LogMessage(level, message);
        }

    }

    protected abstract void write(string message);
}
```

2、创建扩展了该记录器类的实体类

```C#
public class ConsoleLogger:AbstractLogger
{
    public ConsoleLogger(int level)
    {
        this.level = level;
    }
    protected override void write(string message) => Console.WriteLine($"Standard Console::Logger{message}");
}

public class ErrorLogger:AbstractLogger
{
    public ErrorLogger(int level)
    {
        this.level = level;
    }
    protected override void write(string message) => Console.WriteLine($"Error Console::Logger:{message}");
}

public class FileLogger:AbstractLogger
{
    public FileLogger(int level)
    {
        this.level = level;
    }

    protected override void write(string message) => Console.WriteLine($"File::Logger:{message}");
}
```

3、上层调用

```C#
class Program
{
    private static AbstractLogger GetChainLoggers()
    {
        AbstractLogger errorLogger = new ErrorLogger(AbstractLogger.ERROR);
        AbstractLogger fileLogger = new FileLogger(AbstractLogger.DEBUG);
        AbstractLogger consoleLogger = new ConsoleLogger(AbstractLogger.INFO);

        errorLogger.SetNextLogger(fileLogger);
        fileLogger.SetNextLogger(consoleLogger);

        return errorLogger;
    }

    static void Main(string[] args)
    {
        var loggerChain = GetChainLoggers();

        loggerChain.LogMessage(AbstractLogger.INFO, "This is an information");
        loggerChain.LogMessage(AbstractLogger.DEBUG, "This is an debug level information");
        loggerChain.LogMessage(AbstractLogger.ERROR, "This is an error information");

        Console.ReadKey();
    }
}
```

## 总结

责任链模式多在事件传递中有实际运用，通过链式结构将多个处理类关联起来，简化了上层调用，但是需要注意的是避免出现循环调用。



