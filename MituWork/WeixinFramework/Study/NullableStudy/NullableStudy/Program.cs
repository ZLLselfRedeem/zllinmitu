using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NullableStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            // Nullable<int> i = new Nullable<int>();
            //int? i = null;
            //Console.WriteLine(i == null);

            // Nullable<T>该结构有两个构造函数，一个是默认的，一个是要获取一个参数。
            // struct的默认构造函数永远存在，但是可以创建另外的构造函数，
            // 但是隐式的构造函数不会被删除或者重定义
            Nullable<int> value = new Nullable<int>();
            Nullable<int> testValue = new Nullable<int>(5);
            Console.WriteLine("Instance with value:");
            Display(testValue);

            Console.WriteLine("Instance without value:");
            Display(value);
            TestBoxed();
        }
        static void TestBoxed()
        {
            Nullable<int> iValue = new Nullable<int>(5);
            // 等价于Nullable<int> iValues = 5; 存在着从T到Nullable<T>隐式的类型转换
            // 从Nullable<T>到T的转换需要显示指明。
            Console.WriteLine("获取不为null的可用类型的类型为： {0}", iValue.GetType());
            int i = (int)iValue;
            Object obj = iValue;//装箱过程
            Console.WriteLine("获得装箱后obj的类型为: {0}", obj.GetType());
            i = (int)obj;
            int? iNull = (Nullable<int>)obj;

            int? iInit = new int?(); // Nullable<int> iInit = new Nullable<int>();
            // 对于一个为null的类型调用方法时会出现异常，所以一般对引用类型的调用方法前
            // 要进行非null的判断，但是对于Nullable<T>类型为null时，可以调用HasValue特性
            // 这是一个特列。
            //Console.WriteLine("获取不为null的可用类型的类型为： {0}", iValue.GetType());
            Console.WriteLine("iInit is null: {0}", iInit.HasValue);
            obj = iInit;
            iNull = (Nullable<int>)obj;
            //i = (int)obj;
            Console.WriteLine(iNull.HasValue);
        }
        static void Display(Nullable<int> x) 
        {
            Console.WriteLine("HasValue: {0}", x.HasValue);
            if (x.HasValue)
            {
                Console.WriteLine("Value: {0}", x.Value);
                Console.WriteLine("Explicti conversion: {0}", (int)x);
            }

            Console.WriteLine("GetValueOrdDefault(): {0}", x.GetValueOrDefault());
            Console.WriteLine("GetValueOrDefaullt(10): {0}", x.GetValueOrDefault(10));

            Console.WriteLine("ToString(): \"{0}\"", x.ToString());
            Console.WriteLine("GetHashCode(): {0}", x.GetHashCode());
        }
    }
}
