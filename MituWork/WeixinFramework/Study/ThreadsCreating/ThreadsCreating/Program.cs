using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ThreadsCreating
{
    class Limitation
    {
        public Limitation(int la, int iv)
        {
            lAbove = la;
            interval = iv;
        }

        public int LAbove 
        {
            get { return lAbove; } 
        }

        public int Interval 
        {
            get { return interval; }
        }
        private int lAbove;
        private int interval;
    }
    class Program
    {
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("***** The Amazing Threading App *****\n");
            Console.Write("Do you want [1] or [2] threads?\n");
            string threadChance = Console.ReadLine();
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "Primary";
            Limitation lm = new Limitation(8, 1400);

            Console.WriteLine("-> {0} is executing Main()", Thread.CurrentThread.Name);
            switch (threadChance)
            {
                case "2":
                    // ThreadStart threadStart = new ThreadStart(TestThreads);
                    ParameterizedThreadStart threadStart = new ParameterizedThreadStart(TestThreads);
                    Thread scdTread = new Thread(threadStart);
                    scdTread.Name = "Secondary";
                    scdTread.Start(lm);
                    break;
                case "1":
                    TestThreads(lm);
                    break;
                default:
                    Console.WriteLine("I don't know you want... you get 1 thread.");
                    goto case "1";
                
            }
            MessageBox.Show("I'm busy!", "Work on main thread...");
            waitHandle.WaitOne();
            Console.WriteLine("Other thread is done!");
            Console.ReadLine();
        }

        static void TestThreads(object obj)
        {
            Limitation lm = (Limitation)obj;
            Console.WriteLine("-> {0} is executing TestThreads()", Thread.CurrentThread.Name);
            Console.Write("Your Numbers: ");
            for (int i = 0; i < lm.LAbove; i++)
            {
                Console.Write("{0},", i);
                Thread.Sleep(lm.Interval);
            }
            Console.WriteLine();
            waitHandle.Set();
        }
    }
}
