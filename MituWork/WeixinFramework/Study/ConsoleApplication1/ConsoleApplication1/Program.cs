using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Garage carLot = new Garage();
            IEnumerator i = carLot.GetEnumerator();
            
            // Car myCar = (Car)i.Current;  // 枚举尚未开始，请调用MoveNext()
            //bool flag = i.MoveNext();
            //Car myCar = (Car)i.Current;
            //Console.WriteLine("{0} is going {1} MPH", myCar.PetName, myCar.CurrentSpeed);
            for(bool flag = i.MoveNext(); flag == true; flag = i.MoveNext())
            {
                Car myCar = (Car)i.Current;
                Console.WriteLine("CustomForMethod : {0} is going {1} MPH", myCar.PetName, myCar.CurrentSpeed);
            }
            
            // i.Reset();不会对下一次的foreach造成影响，应该是在使用foreach方法的第一步是调用Reset()进行设置，

            foreach (Car c in carLot)
            {
                Console.WriteLine("{0} is going {1} MPH", c.PetName, c.CurrentSpeed);
            }

            foreach (Car c in carLot.GetTheCars(true))
            {
                Console.WriteLine("{0} is going {1} MPH", c.PetName, c.CurrentSpeed);
            }

            Car[] myAutos = new Car[5];
            myAutos[0] = new Car("Rusty", 80, 1);
            myAutos[1] = new Car("Mary", 40, 234);
            myAutos[2] = new Car("Viper", 40, 34);
            myAutos[3] = new Car("Mel", 40, 4);
            myAutos[4] = new Car("Chucky", 40, 5);

            foreach (Car c in myAutos)
            {
                Console.WriteLine("Car: {0}, ID: {1}", c.PetName, c.CarID);
            }
            Console.WriteLine("After NormalSort:");
            Array.Sort(myAutos);

            foreach (Car c in myAutos)
            {
                Console.WriteLine("Car: {0}, ID: {1}", c.PetName, c.CarID);
            }

            Array.Sort(myAutos, Car.SortByPetName);
            Console.WriteLine("After PetNameSort:");
            foreach (Car c in myAutos)
            {
                Console.WriteLine("Car: {0}, ID: {1}", c.PetName, c.CarID);
            }
            Console.ReadLine();

        }
    }
}
