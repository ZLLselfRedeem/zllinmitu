using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomEnumerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with IEnumerable / IEnumerator *****");
            Garage carLot = new Garage();
            foreach(Car c in carLot)
                Console.WriteLine("{0} is going {1} MPH", c.PetName, c.CurrentSpeed);

            foreach (Car c in carLot.GetTheCars(true)) 
            {
                Console.WriteLine("{0} is going {1} MPH", c.PetName, c.CurrentSpeed);
            }
            Console.ReadLine();
        }
    }
}
