using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleDelegate
{
    public delegate void BinaryOp(int x, int y);
    public delegate void CarEngineHandler(string msgForCaller);
    
    public class Car 
    {
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string PetName { get; set; }

        private bool carIsDead;

        public Car() 
        {
            MaxSpeed = 100;
        }

        public Car(string name, int maxSp, int currSp) 
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }
        //虽然此处可以把委托成员public，就可以不需要额外一个RegisterWithCarEngine
        // 方法了，但是private 的访问修饰符可以更好的封装服务，以及提供更强的类型安全。
        // 同时由发布方决定什么时候引发事件，而不是由订阅方随意的订阅事件。
        private CarEngineHandler listOfHandlers;

        public void RegisterWithCarEngine(CarEngineHandler methodToCall) 
        {
            //去调用Delegate.Comine()方法
            listOfHandlers += methodToCall;
            // 等价于
            //if (listOfHandlers == null)
            //    listOfHandlers = methodToCall;
            //else
            //    Delegate.Combine(listOfHandlers, methodToCall);
        }

        public void Accelerate(int delta)
        {
            if (carIsDead)
            {
                // 我们在调用listOfHandlers之前先检查一下listOfHandlers是否为空
                // 因为委托或者事件的订阅是有客户来完成的
                if (listOfHandlers != null)
                    listOfHandlers("Sorry, this car is dead...");
            }
            else 
            {
                CurrentSpeed += delta;
                if (10 == (MaxSpeed - CurrentSpeed) && listOfHandlers != null) 
                {
                    listOfHandlers("Careful buddy! Gonna blow");
                }
                if (CurrentSpeed >= MaxSpeed)
                    carIsDead = true;
                else
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
            }
        }
    }
    public class SimpleMath 
    {
        public static void Add(int x, int y) 
        {
            Console.WriteLine("Result: {0}", x + y);
        }

        public void Subtract(int x, int y) 
        {
            Console.WriteLine("Result: {0}",x - y);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BinaryOp bp = new BinaryOp(SimpleMath.Add);
            bp += (new SimpleMath()).Subtract;
            DisplayDelegateInfo(bp);
            // 通过访问从MulticastDelegate中继承的类方法Invoke()
            bp(20, 10);

            Car car = new Car("zyy", 100, 10);
            car.RegisterWithCarEngine(new CarEngineHandler(OnCarEngineEnvent1));
            car.RegisterWithCarEngine(new CarEngineHandler((new Program()).OnCarEngineEnvent2));

            //当我们调用方法以委托作为参数时，我们可以直接提供方法名，而不需要委托的实例。
            car.RegisterWithCarEngine(OnCarEngineEnvent1);
            car.RegisterWithCarEngine((new Program()).OnCarEngineEnvent2)
            for (int i = 0; i < 6; i++) 
            {
                car.Accelerate(20);
            }

        }

        public static void OnCarEngineEnvent1(string msg) 
        {
            Console.WriteLine("Method1: {0}", msg);
        }

        public void OnCarEngineEnvent2(string msg)
        {
            Console.WriteLine("Another Method1: {0}", msg);
        }

        static void DisplayDelegateInfo(Delegate delObj) 
        {
            foreach (Delegate d in delObj.GetInvocationList())
            {
                Console.WriteLine("Method Name: {0}", d.Method);
                Console.WriteLine("Type Name: {0}", d.Target);
            }
        }
    }
}
