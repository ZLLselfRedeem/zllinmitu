using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.Remoting.Contexts;

namespace ThreadMore
{
    public class Printer
    {
        private static object threadLock = new object();
        public  void PrintNumbers()
        {
            //// Use the lock token
            //lock (threadLock)
            //{
            //    Console.WriteLine("-> {0} is executiong PrintNumbers()", Thread.CurrentThread.Name);
            //    Console.WriteLine("Your numbers:");
            //    for (int i = 0; i < 10; i++)
            //    {
            //        // put thread to sleep for a random amount of time
            //        Random r = new Random();
            //        Thread.Sleep(1000 * r.Next(5));
            //        Console.Write("{0},", i);
            //    }
            //    Console.WriteLine();
            //}

            // 以上注释代码等价于下面的代码,使用Lock可以是代码编写更为简洁，而使用Monitor
            // 关键字可以再过程中提供更加多的控制。大部分情况下使用lock关键字已经足够满足要求了。
            Monitor.Enter(threadLock);
            try
            {
                Console.WriteLine("-> {0} is executiong PrintNumbers()", 
                    Thread.CurrentThread.Name);
                Console.WriteLine("Your numbers:");
                for (int i = 0; i < 10; i++)
                {
                    // put thread to sleep for a random amount of time
                    Random r = new Random();
                    Thread.Sleep(1000 * r.Next(5));
                    Console.Write("{0},", i);
                }
                Console.WriteLine();
            }
            finally 
            {
                Monitor.Exit(threadLock);
            }
         
        }
        private static int intVal = 83;
        // 提供了System.Threading.Interlocked类型来进一步简化lock已经Monitor的操作
        public static void InterLockedDem()
        {
            Interlocked.Exchange(ref intVal, 83);
            int newVal = Interlocked.Increment(ref intVal);

            Interlocked.CompareExchange(ref intVal, 99, 83);
        }
        

        //还可以使用[Synchronization]特性来指定特性安全。
        // 注意Synchronization是class水平的特性，可以从该类的定义了解到
        // AttributeUsage(AttributeTargets.Class)
        // 该特性会使的这个类实例对象的所有实例成员都处于线程安全的状态
        // CLR 会把带有[Synchronization]特性的类分配到线程安全的context中，
        // 锁定所有方法的调用，尽管可能这个线程没有使用线程敏感的数据。
        // 所以等价的替代方法来实现线程安全的源代码如下：

    }

    [Synchronization]
        public class PrinterTest : ContextBoundObject
        {
            //  是实例成员。
            public void PrintNumbers() 
            {

            }
        }

    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("***** Background Threads *****\n");
            //Thread[] threads = new Thread[10];
            //for (int i = 0; i < 10; i++)
            //{
            //    threads[i] = new Thread(new ThreadStart(Printer.PrintNumbers));
            //    threads[i].Name = string.Format("Worker thread #{0}", i);
            //}
            //// Now start each one
            //foreach (Thread t in threads)
            //{
            //    t.Start();
            //}
            Console.WriteLine("***** Fun with the CLR Thread Pool *****\n");

            Console.WriteLine("Main thread started. ThreadId = {0}", Thread.CurrentThread.ManagedThreadId);
            Printer p = new Printer();
            WaitCallback workItem = new WaitCallback(PrintTheNumbers);
            // Queue the method ten times
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(workItem, p);
            } 
            Console.WriteLine("All tasks queued");
            Console.ReadLine();
        }

        static void PrintTheNumbers(object state)
        {
            Printer task = (Printer)state;
            task.PrintNumbers();
        }
    }
}
