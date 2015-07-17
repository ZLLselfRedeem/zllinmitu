using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace TimerAndCallback
{
    class Program
    {
        private static object threadLock = new object();
        static void PrintTime(object state)
        {
            lock (threadLock)
            {
                Console.WriteLine("PrintTime thread started. ThreadId = {0}",
                    Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("Time is {0}, the Host is {1}",
                    DateTime.Now.ToLongTimeString(), state.ToString());

                Console.Write("Your numbers: ");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write("{0}, ", i);
                    Thread.Sleep(10);
                }
                Console.WriteLine("\n");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with the CLR Thread Pool *****\n");
            Console.WriteLine("Main thread started. ThreadId = {0}", 
                Thread.CurrentThread.ManagedThreadId);
            WaitCallback workItem = new WaitCallback(PrintTime);
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(workItem, "zllinzju2015");
            }
            Console.ReadLine();
        }

        private static void TimerTest()
        {
            TimerCallback tcb = new TimerCallback(PrintTime);
            Timer tTest = new Timer(tcb, "ZJUIN2015", 4000, 2000);
        }
        
    }
}
