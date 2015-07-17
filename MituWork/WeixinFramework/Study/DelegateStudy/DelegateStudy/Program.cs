using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateStudy
{
    public delegate int BinaryOp(int x, int y);

    public class SimpleMath 
    {
        public static int Add(int x, int y) 
        {
            return x + y;
        }

        public static int Substract(int x, int y) 
        {
            return x - y;
        }
    }

    public class Car 
    {
        public int CurrentSpeed { get; set; }
        public int MaxSpedd { get; set; }
        public string PetName { get; set; }

        private bool carsIsDead;

        public Car() 
        {
            MaxSpedd = 100;
        }

        public Car(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpedd = maxSp;
            PetName = name;
        }

        // 从语法上来说，我们可以将成员变量listOfHandlers定义为公有的
        // 这样就不许要创建额外的注册方法，
        //但是定义为私有，可以强制封装服务，并提供了类型安全的解决方案。
        public delegate void CarEngineHandler(string msgForCaller);
        //private CarEngineHandler listOfHandlers;
        //public void RegisterWithCarEngine(CarEngineHandler methodToCall) 
        //{
        //    //实际上是在调用静态的Delegate.Combine()方法
        //    listOfHandlers += methodToCall;
        //}
        public event CarEngineHandler Exploded;
        public event CarEngineHandler AboutToBlow;
        // 有了事件就不需要声明委托成员变量，也不需要自定义注册函数

        //public void UnRegisterWithCarEngine(CarEngineHandler methodToCall)
        //{
        //    listOfHandlers -= methodToCall;
        //}

        public void Accelerate(int delta) 
        {
            if (carsIsDead)
            {
                if (Exploded != null)
                {
                    Exploded("Sorry, this car is dead...");
                }
            }
            else
            {
                CurrentSpeed +=delta;
                if (10 == (MaxSpedd - CurrentSpeed) && AboutToBlow != null)
                {
                    AboutToBlow("Careful buddy!Gonna blow!");
                }
                if(CurrentSpeed >= MaxSpedd)
                    carsIsDead= true;
                else
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
            } 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 可以通过反射来查看Binary这个类型的相关信息，也可以通过ildasm.exe反编译来查看

            BinaryOp b = new BinaryOp(SimpleMath.Add);
            Console.WriteLine("10 + 11 = {0}", b(10, 11));
            Console.WriteLine("10 + 11 = {0}", b.Invoke(10, 11));
            DisplayDelegateInfo(b);

            Car c1 = new Car("SlugBug", 100, 10);
            c1.Exploded += OnCarEngineEvent;

            c1.AboutToBlow += OnCarEngineEvent2;
            c1.AboutToBlow += OnCarEngineEvent3;

            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }
            Console.ReadLine();
        }

        public static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("\n***** Message From Car Object *****");
            Console.WriteLine("=> {0}", msg);
            Console.WriteLine("*************************************\n");
        }

        public static void OnCarEngineEvent2(string msg)
        {
            Console.WriteLine("\n***** Message From Car Object *****");
            Console.WriteLine("=> {0}", msg.ToUpper());
            Console.WriteLine("*************************************\n");
        }

        public static void OnCarEngineEvent3(string msg)
        {
            Console.WriteLine("\n***** Message From Car Object *****");
            Console.WriteLine("=> {0}", msg.ToLower());
            Console.WriteLine("*************************************\n");
        }
        static void DisplayDelegateInfo(Delegate delObje)
        {
            foreach (Delegate d in delObje.GetInvocationList())
            {
                Console.WriteLine("Method Name: {0}", d.Method);
                Console.WriteLine("Type Name: {0}", d.Target);

            }
        }
    }
}
