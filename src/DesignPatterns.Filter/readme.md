> 过滤器模式通过使用不同的过滤标准来筛选数据，解耦了多个数据源的数据筛选操作。

## 介绍

过滤器模式属于结构型模式，它通过将多个不同的过滤标准结合起来从而达到一个统一的过滤标准，使具体的过滤对上层隔离。

## 类图描述

![](https://img2018.cnblogs.com/blog/749711/201811/749711-20181115180109318-1490176004.png)

由上图可知，**ICriteria** 定义了过滤接口，然后 **CriteriaMale** 、**CriteriaSingle**、**CriteriaFemale** 为具体的底层数据过滤，接着定义 **AndCriteria** 和 **OrCriteria** 为组装数据过滤。最后上层直接调用他们这两个即可。

## 代码实现

1、定义实体类

```C#
public class Person
{
    private string name;
    private string gender;
    private string maritalStatus;

    public Person(string name, string gender, string maritalStatus)
    {
        this.name = name;
        this.gender = gender;
        this.maritalStatus = maritalStatus;
    }

    public string GetName() => name;
    public string GetGender() => gender;
    public string GetMaritalStatus() => maritalStatus;
}
```

1、定义过滤接口

```C#
public interface ICriteria
{
    IEnumerable<Person> MeetCriteria(IEnumerable<Person> persons);
}
```

2、实现过滤接口

```C#
public class CriteriaFemale : ICriteria
{
    public IEnumerable<Person> MeetCriteria(IEnumerable<Person> persions)
    {
        List<Person> femalePersons = new List<Person>();
        femalePersons.AddRange(persions.Where(p => p.GetGender() == "FEMALE"));
        return femalePersons;
    }
}

public class CriteriaMale : ICriteria
{
    public IEnumerable<Person> MeetCriteria(IEnumerable<Person> persions)
    {
        List<Person> malePersons = new List<Person>();
        malePersons.AddRange(persions.Where(p => p.GetGender() == "MALE"));
        return malePersons;
    }
}

public class CriteriaSingle : ICriteria
{
    public IEnumerable<Person> MeetCriteria(IEnumerable<Person> persons)
    {
        List<Person> malePersons = new List<Person>();
        malePersons.AddRange(persons.Where(p => p.GetMaritalStatus() == "SINGLE"));
        return malePersons;
    }
}
```

3、组装过滤器

```C#
public class AndCriteria : ICriteria
{
    private ICriteria criteria;
    private ICriteria otherCriteria;

    public AndCriteria(ICriteria criteria,ICriteria otherCriteria)
    {
        this.criteria = criteria;
        this.otherCriteria = otherCriteria;
    }
    public IEnumerable<Person> MeetCriteria(IEnumerable<Person> persions)
    {
        IEnumerable<Person> firstCriteriaPersons = criteria.MeetCriteria(persions);
        return otherCriteria.MeetCriteria(firstCriteriaPersons);
    }
}

public class OrCriteria : ICriteria
{
    private ICriteria criteria;
    private ICriteria otherCriteria;
    public OrCriteria(ICriteria criteria, ICriteria otherCriteria)
    {
        this.criteria = criteria;
        this.otherCriteria = otherCriteria;
    }

    public IEnumerable<Person> MeetCriteria(IEnumerable<Person> persions)
    {
        List<Person> firstCriteriaItems = criteria.MeetCriteria(persions).ToList();
        IEnumerable<Person> otherCriteriaItems = otherCriteria.MeetCriteria(persions);
        foreach (var person in otherCriteriaItems)
        {
            if (!firstCriteriaItems.Contains(person))
            {
                firstCriteriaItems.Add(person);
            }
        }
        return firstCriteriaItems;
    }
}
```

4、上层调用

```C#
class Program
{
    static void Main(string[] args)
    {
        List<Person> persons = new List<Person>();

        persons.AddRange(new[] {
            new Person("Robert", "MALE", "SINGLE"),
            new Person("John", "MALE", "MARRIED"),
            new Person("Laura", "FEMALE", "MARRIED"),
            new Person("Diana", "FEMALE", "SINGLE"),
            new Person("Mike", "MALE", "SINGLE"),
            new Person("Bobby", "MALE", "SINGLE")
        });

        ICriteria male = new CriteriaMale();
        ICriteria female = new CriteriaFemale();
        ICriteria single = new CriteriaSingle();
        ICriteria singleMale = new AndCriteria(single, male);
        ICriteria singleOrFemale = new OrCriteria(single, female);

        Console.WriteLine("Males:");
        PrintPersons(male.MeetCriteria(persons));

        Console.WriteLine("Females:");
        PrintPersons(female.MeetCriteria(persons));

        Console.WriteLine("Single Males");
        PrintPersons(singleMale.MeetCriteria(persons));

        Console.WriteLine("Single Or Females");
        PrintPersons(singleOrFemale.MeetCriteria(persons));

        Console.ReadKey();
    }

    private static void PrintPersons(IEnumerable<Person> persons)
    {
        foreach (var person in persons)
        {
            Console.WriteLine($"Person [Name:{person.GetName()},Gender:{person.GetGender()},Marital Status:{person.GetMaritalStatus()}]");
        }
    }
}
```

## 总结

在实际开发过程中，如果遇到多个过滤标准的话，可以尝试通过使用过滤器模式来将多个不同的过滤标准组合起来，使上层调用达到统一，底层筛选被隔离。