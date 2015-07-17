using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringBuid
{
    [Flags]
    public enum Color 
    {
        Red = 0, 
        Yellow = 1,
        White = 2,
        Black = 4
    }

    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("123456789");
            sb.Length = 3;
            Console.WriteLine(sb.ToString());

            sb.Length = 30;
            Console.WriteLine(sb.ToString() + ",结尾");
            Console.WriteLine(sb.Length);

            StringBuilder sb2 = new StringBuilder();
            Console.Write("Capacity:" + sb2.Capacity);
            Console.WriteLine("\t Length:" + sb2.Length);
            sb2.Length = 5;
            Console.WriteLine(sb2.ToString() + "Test");
            sb2.Append('1', 18);
            Console.Write("Capacity:" + sb2.Capacity);
            Console.WriteLine("\t Length:" + sb2.Length);

            sb2.Append('1', 35);
            Console.Write("Capacity:" + sb2.Capacity);
            Console.WriteLine("\t Length:" + sb2.Length);

            // Length是可以根据自己的需要进行设置的，但是Capacity必须要比Length大。
            // sb2.Capacity = 4;

            sb2.Remove(0, sb2.Length);
            sb2.Capacity = 1;
            sb2.Append('a', 2);
            Console.Write("Capacity:" + sb2.Capacity);
            Console.WriteLine("\t Length:" + sb2.Length);
            sb2.Append('b', 3);
            Console.Write("Capacity:" + sb2.Capacity);
            Console.WriteLine("\t Length:" + sb2.Length);

            Color test = (Color)3;
            Console.WriteLine(test.ToString());
        }
    }
}
