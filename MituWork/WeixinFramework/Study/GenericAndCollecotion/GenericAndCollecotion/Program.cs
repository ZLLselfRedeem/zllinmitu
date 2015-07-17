using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace GenericAndCollecotion
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList al = new ArrayList();
            al.Add("string");
            al.Add('B');
            al.Add(10);
            al.Add(DateTime.Now);
            ArrayList bl = new ArrayList(5);
            al.Remove('B');
            // 从al中删除第一个匹配的对象，如果al中不包含该对象，数组保持不变，不引发异常。
            al.Remove('B');
            al.RemoveAt(0);
            al.RemoveRange(0, 1);
            bl.Add(1);
            bl.Add(11);
            bl.Add(111);
            bl.Insert(4, 1111);
            int[] inttest = (int[])bl.ToArray(typeof(int));
            foreach(int it in inttest)
                Console.WriteLine(it);
            int[] inttest2 = new int[bl.Count];
            bl.CopyTo(inttest2);
            ArrayList cl = new ArrayList();
            cl.Add(1);
            cl.Add("Hello, World!");
            object[] ol = (object[])cl.ToArray(typeof(object));
            // stringp[] os = (string[])cl.ToArray(typeof(string));
            Console.WriteLine("The Capacity of new ArrayList: {0}", al.Capacity);
        }
    }
}
