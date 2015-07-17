using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqOverCustomObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Sytem.Gc");
            Console.WriteLine("Estimated bytes on heap: {0}", GC.GetTotalMemory(false));
            Console.WriteLine("This OS has {0} object generatiins.\n", (GC.MaxGeneration + 1));

            List<int> li = new List<int>();
            Console.WriteLine("Generation of li: {0}", GC.GetGeneration(li));
            //.NET垃圾回收器的功能是代替我们管理内存，在一些非常罕见的环境下，通过编程使用GC.Collect()
            //强制垃圾回收可能会有好处。其中两种情况需要与回收进程进行交互。
            //  1. 应用程序将要进入一段代码，后者不希望被可能的；垃圾回收中断
            //  2.应用程序刚刚分配了非常多的对象，你想尽可能多地删除已分配的内存。
            // 如果你确定让垃圾回收器马上检查不可访问对象可能有好处，就可以显式触发一次垃圾回收
                //GC.Collect();
                GC.Collect(0, GCCollectionMode.Forced);
            //挂起当前线程直到所有可终结的对象都被终结
            //通常在调用GC.Collect()后直接调用
            GC.WaitForPendingFinalizers();
            // 在底层GC.WaitForPendingFinalizers()会在回收过程中挂起调用的线程。

            object[] tonsOfObjects = new object[50000];
            for (int i = 0; i < 50000; i++) 
            {
                tonsOfObjects[i] = new object();
            }

            if (tonsOfObjects[9000] != null) 
            {
                Console.WriteLine("Generation of tonsOfObjects[9000] is {0}", GC.GetGeneration(tonsOfObjects[9000]));
            }
            else
                Console.WriteLine("tonsOfObject[9000] is no longer alive.");

            Console.WriteLine("\n Gen 0 has been swept {0} times", GC.CollectionCount(0));
            
            Console.WriteLine("\n Gen 1 has been swept {0} times", GC.CollectionCount(1));
            
            Console.WriteLine("\n Gen 2 has been swept {0} times", GC.CollectionCount(2));
        }
    }
}
