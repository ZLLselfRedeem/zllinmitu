using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleClassExample
{
    class Car
    {
        // The 'state' of the Car.
        public string petName;
        public int currSpeed;
        public string name;

        public Car() 
        {
            petName = "Chuck";
            currSpeed = 10;
        }

        private Car(string pn) 
        {
            petName = pn;
        }

        public Car(string pn, int cs) 
            : this(pn)
        {
            currSpeed = cs;
        }
        // The functionality of the Car
        public void PrintState() 
        {
            Console.WriteLine("{0} is going {1} MPH.", petName, currSpeed);
            Console.WriteLine("test name: {0}", name);
        }

        public void SpeedUp(int delta) 
        {
            currSpeed += delta;
        }

        public void SetDriveName(string name) 
        {
            this.name = name;
        }
    }
}
