> 组合模式通过将多个具有相同属性和行为的对象组装成一个类似树形结构的单一对象。以此来表示各个对象之间的层次关系。

## 前言

组合模式属于结构型模式，通过将多个相似对象组合到一起，从而能够构建出一个树形的 *整体-部分* 的关系。保证了单个对象和组合对象的使用方式是一致的。在现实场景中，类似电脑中文件夹的浏览展示，可以联想到 **组合模式**。

## 类图描述

略

## 代码实现

1、具体实现

```C#
public class Employee
{
    private string name;
    private string dept;
    private int salary;
    private List<Employee> subordinates;
    public Employee(string name,string dept,int sal)
    {
        this.name = name;
        this.dept = dept;
        this.salary = sal;
        subordinates = new List<Employee>();
    }

    public void Add(Employee e) => subordinates.Add(e);
    public void Remove(Employee e) => subordinates.Remove(e);

    public List<Employee> GetSubordinates() => this.subordinates;

    public override string ToString() => $"Employee :[name:{name},dept:{dept},salary:{salary}]";
}
```

2、上层调用

```C#
class Program
{
    static void Main(string[] args)
    {
        Employee CEO = new Employee("John", "CEO", 30000);

        Employee headSales = new Employee("Robert", "Head Sales", 20000);

        Employee headMarketing = new Employee("Michel", "Head Marketing", 20000);

        Employee clerk1 = new Employee("Laura", "Marketing", 10000);
        Employee clerk2 = new Employee("Bob", "Marketing", 10000);

        Employee salesExecutive1 = new Employee("Richard", "Sales", 10000);
        Employee salesExecutive2 = new Employee("Rob", "Sales", 10000);

        CEO.Add(headSales);
        CEO.Add(headMarketing);

        headSales.Add(salesExecutive1);
        headSales.Add(salesExecutive2);

        headMarketing.Add(clerk1);
        headMarketing.Add(clerk2);

        Console.WriteLine(CEO);
        foreach (var headEmployee in CEO.GetSubordinates())
        {
            Console.WriteLine(headEmployee);
            foreach (var employee in headEmployee.GetSubordinates())
            {
                Console.WriteLine(employee);
            }
        }

        Console.ReadKey();
    }
}
```

## 总结

由于组合模式将各个具体具体实现都作为同一个实体类而不是依赖接口，所以违背了 **依赖倒置** 的原则。因此，在具体的使用场景中需要具体分析具体对待。
