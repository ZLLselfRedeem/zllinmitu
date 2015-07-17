using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;

namespace ThreadsStudy
{  
    class Program
    {
        public static delegate int BinaryOp(int x, int y);
        private static bool isDone = false;
        static void Main(string[] args)
        {
            Console.WriteLine("***** Async Delegate Invocation *****");
            Console.WriteLine("Main() invoked on thread {0}", Thread.CurrentThread.ManagedThreadId);
            BinaryOp b = new BinaryOp(Add);
            IAsyncResult iftAR = b.BeginInvoke(10, 10, new AsyncCallback(AddComplete), "Main() thanks you for adding these numbers.");
            // using the member method or property of IAsyncResult
            // involve in Async process.
            //while (!iftAR.IsCompleted)
            //{
            //    Console.WriteLine("Doing more work in Main()");
            //    Thread.Sleep(1000);
            //}
            //while (!iftAR.AsyncWaitHandle.WaitOne(1000, true))
            //{
            //    Console.WriteLine("Doing more work in Main()");
            //}
            while (!isDone)
            {
                Thread.Sleep(1500);
                Console.WriteLine("Woring more work in Main()");
            }
            // 让第二个线程通知访问线程，当第二个线程的工作完成时。
            // 向BeginInvoke中传入AsyncCallback delegate，在BeginInvoke的异步调用结束时，
            // AsyncCallback委托会访问一个特殊的方法。
            // AsyncCallback委托的原型：     public delegate void AsyncCallback(IAsyncResult ar);
            //int answer = b.EndInvoke(iftAR);
            //Console.WriteLine("10 + 10 is {0}", answer);
            Console.WriteLine("Async work is complete!!");
            Console.ReadLine();
        }

        // 当异步调用的线程完成工作时，会通过AsynCallback委托来调用AddComplete这个方法。
        // 是通过第二个线程来调用这个方法的。
        private static void AddComplete(IAsyncResult itfAR)
        {
            Console.WriteLine("AddComplete() invoked on thread {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Your additon is complete");
            AsyncResult ar = (AsyncResult)itfAR;
            BinaryOp b = (BinaryOp)ar.AsyncDelegate;
            Console.WriteLine("10 + 10 is {0}", b.EndInvoke(itfAR));
            string msg = (string)itfAR.AsyncState;
            Console.WriteLine(msg);
            isDone = true;
        }

        private static void DelegateSync()
        {
            Console.WriteLine("***** Synch Delegate Review *****");
            Console.WriteLine("Main() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
            BinaryOp b = new BinaryOp(Add);
            int answer = b(10, 10);
            Console.WriteLine("Doing more work in Main()");
            Console.WriteLine("10 + 10 is {0}", answer);
            Console.ReadLine();
        }

        static int Add(int x, int y)
        {
            Console.WriteLine("Add() invoked on thread {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            return x + y;
        }
    }
}
