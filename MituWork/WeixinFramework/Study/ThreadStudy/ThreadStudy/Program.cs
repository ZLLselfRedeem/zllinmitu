using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ThreadStudy
{
    public delegate int BinaryOp(int x, int y);
    public class Printer
    {
        private static object threadLock = new object();
        public static void PrintNumbers()
        {
            // Use the lock token
            lock (threadLock)
            {
                Console.WriteLine("-> {0} is executiong PrintNumbers()", Thread.CurrentThread.Name);
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
        }
    }

    class AddParams
    {
        public int a, b;

        public AddParams(int numa, int numb)
        {
            a = numa;
            b = numb;
        }
    }

    class Program
    {
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);
        private static bool isDone = false;
        static void Add(object data)
        {
            if (data is AddParams)
            {
                Console.WriteLine("ID of thread in Add(): {0}", Thread.CurrentThread.Name);
                AddParams ap = (AddParams)data;
                Console.WriteLine("{0} + {1} = {2}", ap.a, ap.b, ap.a + ap.b);
                // Tell ohter thread we are done. 
                Thread.Sleep(5000);
                waitHandle.Set();

            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("***** Background Threads *****\n");
            //Thread bgroudThread = new Thread(new ThreadStart(Printer.PrintNumbers));
            //bgroudThread.IsBackground = true;
            //bgroudThread.Start();
            Thread[] threads = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(new ThreadStart(Printer.PrintNumbers));
                threads[i].Name = string.Format("Worker thread #{0}", i);
            }
            // Now start each one
            foreach (Thread t in threads)
            {
                t.Start();
            }
            Console.ReadLine();
        }

        private static void CreateThread()
        {
            Console.WriteLine("***** The Amazing Thread App *****\n");
            // Name the current thread
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "Primary";
            Console.WriteLine("-> {0} is executing Main()", Thread.CurrentThread.Name);
            Thread t = new Thread(new ParameterizedThreadStart(Add));
            AddParams ap = new AddParams(10, 10);
            t.Start(ap);
            waitHandle.WaitOne();

            Console.WriteLine("Now it's Ok!");
            //switch (threadCount)
            //{
            //    case "2":
            //        // Now Make the thread.
            //        Thread backgroudThread = new Thread(new ThreadStart(Printer.PrintNumbers));
            //        backgroudThread.Name = "Secondary";
            //        backgroudThread.Start();
            //        break;
            //    case "1":
            //        Printer.PrintNumbers();
            //        break;
            //    default:
            //        Console.WriteLine("I don't know what you want... you get 1 thread");
            //        goto case "1";
            //}
            //MessageBox.Show("I'm busuy!", "Work on main thread...");
            Console.ReadLine();
        }

        private static void TestAsy()
        {
            Console.WriteLine("***** AsyncCallbackDelegate Example *****");
            Console.WriteLine("Main() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);

            BinaryOp b = new BinaryOp(Add);
            IAsyncResult itfAR = b.BeginInvoke(10, 10, new AsyncCallback(AddComplete),
                "Main() thanks you for adding these numbers");
            // Assume other work is performed here...
            while (!isDone)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Working...");
            }
            Console.ReadLine();
        }

         //the static AddComplete() method will be invoked by the AsyncCallback delegate
         //when the Add() method has completed.
        static void AddComplete(IAsyncResult itfAR)
        {
            Console.WriteLine("AddComplete() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Your additon is complete");
            AsyncResult ar = (AsyncResult)itfAR;
            BinaryOp b = (BinaryOp)ar.AsyncDelegate;
            Console.WriteLine("10 + 10 is {0}.", b.EndInvoke(itfAR));
            string msg = (string)itfAR.AsyncState;
            Console.WriteLine(msg);
            isDone = true;
        }

        private static void AsyncTest()
        {
            Console.WriteLine("***** Async Delegate Review");
            // Print out the ID of the executing thread.
            Console.WriteLine("Main() invoked on thread {0}", Thread.CurrentThread.ManagedThreadId);

            // Invoke Add() in a secondary thread.
            BinaryOp b = new BinaryOp(Add);
            IAsyncResult iftAR = b.BeginInvoke(10, 10, null, null);

            // Do other work on primary thread..
            // This call takes far less than five seconds
            // because of async
            while (!iftAR.AsyncWaitHandle.WaitOne(1000,true))
            {
                Console.WriteLine("Doing more word in Main()!");
            }
            // Obtain the result of the Add();
            // Now we are waiting again for other thread to compelte
            int answer = b.EndInvoke(iftAR);
            Console.WriteLine("10 + 10 is {0}", answer);
            Console.ReadLine();
        }

        private static void SyncTest()
        {
            Console.WriteLine("***** Sync Delegate Review");
            // Print out the ID of the executing thread.
            Console.WriteLine("Main() invoked on thread {0}", Thread.CurrentThread.ManagedThreadId);

            // Invoke Add() in a synchronous manner.
            BinaryOp b = new BinaryOp(Add);
            int answer = b(10, 10);

            // These lines will not execute until the Add() method has completed
            Console.WriteLine("Doing more wordk in Main()!");
            Console.WriteLine("10 + 10 is {0}", answer);
            Console.ReadLine();
        }

        static int Add(int x, int y)
        {
            // Print out the Id of the executing thread.
            Console.WriteLine("Add() invoked on thread {0}",
                Thread.CurrentThread.ManagedThreadId);
            // Pause to simulate a lengthy operation
            Thread.Sleep(5000);
            return x + y; 
        }
        static void ExtractExexutingThread()
        {
            // Get the thread currently executing this method
            Thread currThread = Thread.CurrentThread;
        }

        static void ExtractAppDomainHostingThread()
        {
            // obtain the AppDomain hosting the current thread
            AppDomain ad = Thread.GetDomain();
        }

        static void ExtractCurrentThreadContext()
        {
            // obtain the context under which the current thread is operating
            Context ctx = Thread.CurrentContext;
        }
    }
}
