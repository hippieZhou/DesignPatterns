using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Singleton
{
    /// <summary>
    /// 懒汉式，线程不安全
    /// </summary>
    //public class SingleObject
    //{
    //    private static SingleObject _instance;

    //    private SingleObject()
    //    {
    //    }

    //    public static SingleObject GetInstance() => _instance ?? (_instance = new SingleObject());

    //    public void ShowMessage()
    //    {
    //        Console.WriteLine("Hello World");
    //    }
    //}


    //public class SingleObject
    //{
    //    private static SingleObject _instance;

    //    private static readonly object _locker = new object();

    //    private SingleObject()
    //    {

    //    }

    //    public static SingleObject GetInstance()
    //    {
    //        if (_instance == null)
    //        {
    //            lock (_locker)
    //            {
    //                if (_instance == null)
    //                {
    //                    _instance = new SingleObject();
    //                }
    //            }
    //        }

    //        return _instance;
    //    }

    //    public void ShowMessage()
    //    {
    //        Console.WriteLine("Hello World");
    //    }
    //}

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
}
