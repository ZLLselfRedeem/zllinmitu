using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleClassExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Class Types *****\n");
            // Allocate and configure a Car object.
            Car myCar = new Car();
            myCar.currSpeed = 10;
            myCar.petName = "Herry";

            for (int i = 0; i <= 10; ++i)
            {
                myCar.SpeedUp(5);
                myCar.PrintState();
            }

            Car chuck = new Car();
            chuck.PrintState();

            Car daisy = new Car("Daisy", 75);
            daisy.PrintState();

            Console.WriteLine("Test:");
            // Car Jon = new Car("Jon");
            myCar.SetDriveName("Hello");
            myCar.PrintState();

            Console.ReadLine();
        }
    }
}
