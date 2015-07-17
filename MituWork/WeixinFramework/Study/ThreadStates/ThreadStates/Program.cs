using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ThreadStates
{
    class AddParams
    {
        public int a;
        public int b;
        public AddParams(int numa, int numb)
        {
            a = numa;
            b = numb;
        }
    }
    public class Printer
    {
        public void PrintNumbers()
        {
            // Display Thread info.
            Console.WriteLine("-> {0}  is executing PrintNumbers()", Thread.CurrentThread.ManagedThreadId);
            // Print out numbers
            Console.WriteLine("Yours numbers:");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0}, ", i);
                Thread.Sleep(2000);
            }
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Add(object data)
        {
            if (data is AddParams)
            {
                Console.WriteLine("ID of Thread in Add(): {0}", Thread.CurrentThread.ManagedThreadId);
                AddParams ap = (AddParams)data;
                Thread.Sleep(5000);
                Console.WriteLine("{0} + {1} = {2}", ap.a, ap.b, ap.a + ap.b);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("***** The Amazing Thread App *****\n");
            Console.Write("Do you want [1] or [2] threads");
            string threadCount = Console.ReadLine();
             
            // Name the current thread
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "Primary";
            // Display Thread info.
            Console.WriteLine("-> {0}  is executing Main9()", Thread.CurrentThread.Name);
            // Maker worker class.
            AddParams app = new AddParams(10, 10);
            Printer p = new Printer();
            switch (threadCount)
            {
                case "2":
                    Thread backgroundThread = new Thread(new ThreadStart(p.PrintNumbers));
                    Thread backgroundThread2 = new Thread(new ParameterizedThreadStart(Add));
                    backgroundThread.Name = "Secondary";
                    backgroundThread2.Name = "Customer'Thread";
                    backgroundThread.Start();
                    backgroundThread2.Start(app);
                    break;
                case"1":
                    p.PrintNumbers();
                    break;
                default:
                    Console.WriteLine("I don't know what you want... you get 1 thread.");
                    goto case "1";
            }
            MessageBox.Show("I'm busy!", "Work on main thread...");
            Console.ReadLine();
        }

        private static void ThreadTest()
        {
            Console.WriteLine("***** Primary Thread Stats *****\n");
            // Obtain and name the current thread.
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "ThePrimaryThread";

            // Show details of hosting AppDomain/Context
            Console.WriteLine("Name of current AppDomain: {0}", Thread.GetDomain().FriendlyName);
            Console.WriteLine("ID of current Context: {0}", Thread.CurrentContext.ContextID);

            // Print out some stats about this thread.
            Console.WriteLine("Thread Name: {0}", primaryThread.Name);
            Console.WriteLine("Has thread started?: {0}", primaryThread.IsAlive);
            Console.WriteLine("Thread State: {0}", primaryThread.ThreadState);
            Console.WriteLine("Priority Level: {0}", primaryThread.Priority);
            Console.ReadLine();
        }
    }
}
