using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ComparableCar
{
    public class PetNameComparer : IComparer 
    {
        int IComparer.Compare(object x, object y)
        {
            Car c1 = x as Car;
            Car c2 = y as Car;
            if (c1 != null && c2 != null)
            {
                return String.Compare(c1.PetName, c2.PetName);
            }
            else
                throw new ArgumentException("Parameter is not a Car!");
        }
    }
    class Car : IComparable
    {
        // Constant for maximum speed.
        public const int MaxSpeed = 100;
        public int CarId { get; set; }
        // Car properties.
        public int CurrentSpeed { get; set; }
        public string PetName { get; set; }

        // Is the car still operational?
        private bool carIsDead;

        // A car has-a radio.
        private Radio theMusicBox = new Radio();

        // Constructors.
        public Car() { }
        public Car(string name, int speed, int id)
        {
            CurrentSpeed = speed;
            PetName = name;
            CarId = id;
        }

        #region Methods
        public void CrankTunes(bool state)
        {
            // Delegate request to inner object.
            theMusicBox.TurnOn(state);
        }

        // See if Car has overheated.
        // This time, throw an exception if the user speeds up beyond MaxSpeed.
        public void Accelerate(int delta)
        {
            if (carIsDead)
                Console.WriteLine("{0} is out of order...", PetName);
            else
            {
                CurrentSpeed += delta;
                if (CurrentSpeed >= MaxSpeed)
                {
                    carIsDead = true;
                    CurrentSpeed = 0;

                    // We need to call the HelpLink property, thus we need
                    // to create a local variable before throwing the Exception object.
                    Exception ex =
                      new Exception(string.Format("{0} has overheated!", PetName));
                    ex.HelpLink = "http://www.CarsRUs.com";

                    // Stuff in custom data regarding the error.
                    ex.Data.Add("TimeStamp",
                      string.Format("The car exploded at {0}", DateTime.Now));
                    ex.Data.Add("Cause", "You have a lead foot.");
                    throw ex;
                }
                else
                    Console.WriteLine("=> CurrentSpeed = {0}", CurrentSpeed);
            }
        }
        #endregion

        //public int CompareTo(object obj)
        //{
        //    Car temp = obj as Car;
        //    if (temp != null)
        //    {
        //        if (this.CarId > temp.CarId)
        //            return 1;
        //        if (this.CarId < temp.CarId)
        //            return -1;
        //        else
        //            return 0;
        //    }
        //    else
        //        throw new ArgumentException("Parameter is not a Car!");
        //}

        public int CompareTo(object obj) 
        {
            Car temp = obj as Car;
            if (temp != null)
                return this.CarId.CompareTo(temp.CarId);
            else
                throw new ArgumentException("Parameter is not a Car");
        }

        public override string ToString()
        {
            return string.Format("Car {0} drive in {1}MPH, ID: {2}", this.PetName, this.CurrentSpeed, this.CarId);
        }

        // 可以使用自定义特性来帮助用户进行对象的排序
        public static IComparer SortByPetName
        {
            get 
            {
                return (IComparer)new PetNameComparer();
            }
        }

        //  现在Car类排序可以这样子,使用强相关的特性去排序，
        // 而不是仅仅去使用一个不相关的类
        // Array.Sort(myAutos, Car.SortByPetName);
    }

    class Radio
    {
        public void TurnOn( bool on )
        {
            if (on)
                Console.WriteLine("Jamming...");
            else
                Console.WriteLine("Quiet time...");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Object Sorting *****");
            Car[] myAutos = new Car[5];
            myAutos[0] = new Car("Rusty", 80, 1);
            myAutos[1] = new Car("Mary", 40, 234);
            myAutos[2] = new Car("Viper", 40, 34);
            myAutos[3] = new Car("Mel", 40, 4);
            myAutos[4] = new Car("Chucky", 40, 5);
            foreach(Car c in myAutos)
                Console.WriteLine(c);

            Array.Sort(myAutos);
            foreach(Car c in myAutos)
                Console.WriteLine(c);

            // 传入实现了IComparer接口的对象，可以自动调用ICompare方法
            Array.Sort(myAutos, new PetNameComparer());
            foreach(Car c in myAutos)
                Console.WriteLine(c);
        }

        // 传入的参数一个ICloneable接口类型，这个方法可以接受任何实现了ICloneable接口的
        // 类型
        private static void CloneMe(ICloneable c) 
        {
            object theClone = c.Clone();
            Console.WriteLine("Your clone is a: {0}", theClone.GetType().Name);
        }


    }
}
