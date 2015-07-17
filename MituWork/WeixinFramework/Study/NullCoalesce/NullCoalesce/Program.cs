using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NullCoalesce
{
    class NullCoalesce 
    {
        internal static int? GetNullableInt() 
        {
            return null;
        }

        internal static string GetStringValue() 
        {
            return null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int? x = null;
            // 一个可空类型的变量x 赋值给不可空类型的变量y
            // 因为x可能为null 如果直接赋值，会产生变异错误
            //int y = x; Error！
            int y = x ?? -1;
            // ??可以用于变量，也可以用于方法返回值
            int i = NullCoalesce.GetNullableInt() ?? default(int);
            Console.WriteLine(i);
            // ?? 还可以用于引用类型
            string s = NullCoalesce.GetStringValue();
            Console.WriteLine(s ?? "Unspeecified");
        }
    }
}
