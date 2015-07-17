using System;

namespace DelegateAdvanced
{

    public delegate int BinaryOp(int x, int y);

    public class SimpleMath
    {
        public static int Add(int x, int y)
        {
            return x + y;
        }
        public static int Subtract(int x, int y)
        {
            return x - y;
        }
    }

    public class CarEventArgs : EventArgs
    {
        public readonly string msg;
        public CarEventArgs(string message)
        {
            msg = message;
        }
    }

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
            PetName = name;
            MaxSpeed = maxSp;
            CurrentSpeed = currSp;
        }
        // 定义了委托类型
        // public delegate void CarEngineHandler(object sender, CarEventArgs e);
        //使用危险EventHandler<T>委托
        public event EventHandler<CarEventArgs> Exploded;
        public event EventHandler<CarEventArgs> AboutToBlow;

        //private CarEngineHandler listOfHandlers;

        //public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        //{
        //    listOfHandlers = methodToCall;
        //}

        public void Accelerate(int delta)
        {
            if (carIsDead)
            {
                if (Exploded != null)
                {
                    Exploded(this, new CarEventArgs("Sorry, this car is dead..."));
                }
            }
            else
            {
                CurrentSpeed += delta;
                if (10 == (MaxSpeed - CurrentSpeed) && AboutToBlow != null)
                {
                    AboutToBlow(this, new CarEventArgs("Carefull buddy! Gonna blow!"));
                }
                if (CurrentSpeed >= MaxSpeed)
                    carIsDead = true;
                else
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
            }

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Car c1 = new Car("SlugBug", 100, 10);
            ////c1.AboutToBlow += new Car.CarEngineHandler(CarIsAlmostDoomed);
            //// 当没有参数传入时可以省略掉delegate之后的()部分
            //c1.AboutToBlow += delegate(object sender, CarEventArgs e)
            //{
            //    Console.WriteLine("{0} says: {1}", sender, e.msg);
            //};
            //// 使用方法组转换，+=直接结合方法名进行操作
            //c1.AboutToBlow += CarAboutToBlow;
            //EventHandler<CarEventArgs> d = new EventHandler<CarEventArgs>(CarExploaded);
            //c1.Exploded += d;

            //for (int i = 0; i < 6; i++)
            //{
            //    c1.Accelerate(20);
            //}

            //c1.Exploded -= CarExploaded;
            //c1.AboutToBlow -= CarAboutToBlow;
            //for (int i = 0; i < 6; i++)
            //{
            //    c1.Accelerate(20);
            //}

            Shape shape = new Shape();
            Subscriber1 sub = new Subscriber1(shape);
            Subscribe2 sub2 = new Subscribe2(shape);
            shape.Draw();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        public static void CarAboutToBlow(object sender, CarEventArgs e)
        {
            Console.WriteLine("{0} says: {1}", sender, e.msg);
        }

        public static void CarIsAlmostDoomed(object sender, CarEventArgs e)
        {
            //如果接受者想与发送事件的对象交互，我们可以显示强制类型转换System.Object为Car类型，这样就可以
            // 使用传递给事件通知对象中的任何公共成员
            if (sender is Car)
            {
                Car c = sender as Car;
                Console.WriteLine("=>Critical Message from {0}: {1}", c.PetName, e.msg);
            }
        }

        public static void CarExploaded(object sender, CarEventArgs e)
        {
            Console.WriteLine(e.msg);
        }

        // 注意Delegate 与delegate的区别，Delegate是一个类，所有委托类的积累，而delegate只是一个关键字，
        // 声明委托类型时使用到, 跟class关键字相似。
        static void DisplayDelegateInfo(Delegate deleObje)
        {
            foreach (Delegate d in deleObje.GetInvocationList())
            {
                Console.WriteLine("Method Name: {0}", d.Method);
                // 静态方法 返回NULL，实例方法就返回该方法的对象的类型。
                Console.WriteLine("Type Name: {0}", d.Target);

            }
        }
    }
}
