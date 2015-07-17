using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ReflectionStudy
{
    class MyClass 
    {
        int x;
        int y;

        public MyClass() 
        {
        }

        public MyClass(int i, int j)
        {
            x = i;
            y = j;
        }

        public int sum() 
        {
            return x + y;
        }

        public bool IsBeween(int i) 
        {
            if (x < i && i < y)
                return true;
            else
                return false;
        }

        public void Set(double a, double b) 
        {
            x = (int)a;
            y = (int)b;
        }

        public void Show() 
        {
            Console.WriteLine("x: {0}, y: {1}", x, y);
        }
    }

    class Program 
    {
        static void Main(string[] args)
        {
            MyClass mc = new MyClass();
            Type tm = mc.GetType();
            Type tm1 = typeof(MyClass);

            // 调用Type.GetType(), 我们不需要编译时的知识，是指这个方法可以接受任何字符串值
            // 当然要知道类型名字的字符串形式

            // 用+ 表示嵌套类型
            Type tmt = Type.GetType("CraLibrary.JamesBondCar+SpyOptions");

            // 第一个字符串参数，逗号前是类型的完全限定名，逗号后是类型所在程序集的油耗名字
            Type tmCar = Type.GetType("CarLibrary.SportsCar, CarLibrary");
            Type tm2 = Type.GetType("ReflectionStudy.MyClass", false, true);

            Type t = typeof(MyClass);
        }
    }
}
