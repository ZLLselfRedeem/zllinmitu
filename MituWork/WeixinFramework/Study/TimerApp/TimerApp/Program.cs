using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TimerApp
{
    class Program
    {
        static void PrintTime(object state)
        {
            Console.WriteLine("Time is： {0}, Date is: {1}", DateTime.Now.ToLongTimeString(), state.ToString());
        }

        static void Main(string[] args)
        {
            Console.WriteLine("***** Working with Timer type *****\n");

            // Create the delegate for the Timer type.
            // TimerCallback的定义如下：
            // [ComVisible(true)]
            // public delegate void TimerCallback(object state);
            TimerCallback timeCB = new TimerCallback(PrintTime);
            Timer t = new Timer(timeCB, "Hello, QinMing", 0, 2000);
            Console.WriteLine("hit key to terminate...");
            Console.ReadLine(); 
        }
    }
}
