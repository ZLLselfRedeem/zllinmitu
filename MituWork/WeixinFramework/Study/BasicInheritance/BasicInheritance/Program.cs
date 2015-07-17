using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicInheritance
{
    class Car 
    {
        public readonly int maxSpeed;
        private int currSpeed;

        public Car(int max) 
        {
            maxSpeed = max;
        }

        public Car() 
        {
            maxSpeed = 55;
        }

        public int Speed
        {
            get 
            {
                return currSpeed; 
            }
            set 
            {
                currSpeed = value;
                if (currSpeed > maxSpeed)
                {
                    currSpeed = maxSpeed;
                }
            }
        }
    }
    sealed class MiniVan : Car 
    {
        public void TestMethod()
        {
            Speed = 10;
            // currSpeed = 10;
        }
    }

    //class DeluxeMiniVan : MiniVan 
    //{

    //}

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Basic Inheritance *****\n");
            Car myCar = new Car(80);
            myCar.Speed = 50;
            Console.WriteLine("My car is going to {0} MPH", myCar.Speed);

            MiniVan myVan = new MiniVan();
            myVan.Speed = 10;
            Console.WriteLine("My van is going {0} MPH", myVan.Speed);
            // myVan.currSpeed = 55;
            Console.ReadLine();
        }
    }
}
