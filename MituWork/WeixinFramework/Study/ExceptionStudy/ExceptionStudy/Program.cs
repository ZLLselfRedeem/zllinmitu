using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace ExceptionStudy
{
    class Radio 
    {
        public void TurnOn(bool on) 
        {
            if(on)
                Console.WriteLine("Jamming...");
            else
                Console.WriteLine("Quiet time");
        }
    }

    class Car 
    {
        public const int MaxSpeed = 100;
        public int CurrentSpeed { get; set; }
        public string PetName { get; set; }
        public bool carIsDead;
        private Radio theMusicBox = new Radio();
        
        public Car() 
        {
        }

        public Car(string name, int speed) 
        {
            CurrentSpeed = speed;
            PetName = name;
        }

        public void CrankTunes(bool state) 
        {
            theMusicBox.TurnOn(state);
        }

        // 该方法现在可能引发异常，调用者需要做好准备来处理可能发生的异常。
        // 当调用一个可能引发一场的方法时，应当使用try/catch块。
        // 一旦捕获到异常对象，将能调用异常对象成员来提取问题的详细信息。
        public void Accelerate(int delta) 
        {
            if (delta < 0)
                throw new ArgumentOutOfRangeException("delta", "Speed must be greater than zero!");
            if (carIsDead)
                Console.WriteLine("{0} is out of order...", PetName);
            else 
            {
                CurrentSpeed += delta;
                if (CurrentSpeed > MaxSpeed)
                {
                    Console.WriteLine("{0} has overheated", PetName);
                    CurrentSpeed = 0;
                    carIsDead = true;
                    // 总是由我们决定说引发的问题和何时引发一场
                    // 异常应当仅仅在一个较为知名的条件满足后引发（比如未发现必要的文件，链接数据库失效）
                    //决定什么条件下引发一场是我们必须应对的一个设计问题

                    // Exception ex = new Exception(string.Format("{0} has overheated!", PetName));
                    // 使用自定义的类
                    CarIsDeadException ex = new CarIsDeadException(string.Format("{0} has overheated!", PetName),
                                                                    "You have a laed foot", DateTime.Now);
                    // HttpLink属性能帮助用户找到具体的url或者包含更详细相关信息的标准Windows帮助文件
                    // 在引发异常以前赋值
                    ex.HelpLink = "http://www.CarsRUs.com";
                    //Data属性允许我们使用用户提供的相信信息来填充异常对象
                    // Data属性返回一个实现了定义在System.Collections命名空间下的IDictionary接口的对象。
                    // Data属性非常有用，因为他阴虚我们打包关于“错误”的自定义信息，无需构建全新的类类型来
                    // 扩展Exception基类
                    //ex.Data.Add("TimeStamp", string.Format("The car exploded at {0}", DateTime.Now));
                    //ex.Data.Add("Cause", "YOu have a lead foot");
                    throw ex;
                }
                else
                    Console.WriteLine("=> CurrentSpeed = {0}", CurrentSpeed);
            }
        }
    }

    // 虽然可以一直引发System.Exception的实例来表示运行时错误，但有时构建一个强类型异常来表示当前
    // 问题的独特细节更好。就要创建一个派生自System.Exception或System.ApplicationException的新类
    //（按照约定，所有的异常类均应以“Exception”后缀结束。）一个规则：所有自定义异常类都应该定义为公共类。
    // 异常类通常都会跨程序集边界进行传递，也应该可以被调用代码库访问。
    public class CarIsDeadException : ApplicationException 
    {
        //大多数情况下 自定义异常类都遵循这个简单的模式，自定义异常类的作用并不是提供继承基类以外附加
        // 的功能，而是提供明确标识错误种类的强命名类型，因此客户为会不同类型的异常提供不同的处理程序的逻辑

        //private string messageDetails = String.Empty;
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }
        public CarIsDeadException() { }
        
        public CarIsDeadException(string message, string cause, DateTime time) 
            : base(message)
        {
            //messageDetails = message;
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }

        //public override string Message
        //{
        //    get
        //    {
        //        return string.Format("Car Error Message: {0}", messageDetails);
        //    }
        //}

    }


    [Serializable]
    public class MyException : Exception
    {
        public MyException() { }
        public MyException(string message) : base(message) { }
        public MyException(string message, Exception inner) : base(message, inner) { }
        protected MyException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Simple Exception Example *****");
            Console.WriteLine("=> Creating a car and stepping on it!");
            Car mycar = new Car("Zippy", 20);
            mycar.CrankTunes(true);

            try
            {
                for (int i = 0; i < 10; ++i)
                {
                    mycar.Accelerate(10);
                }
            }
            catch (CarIsDeadException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.ErrorTimeStamp);
                Console.WriteLine(e.ErrorTimeStamp);
                //Console.WriteLine("**** Error ****");
                //Console.WriteLine("Method: {0}", e.TargetSite);
                //Console.WriteLine("Message: {0}", e.Message);
                //Console.WriteLine("Source: {0}", e.Source);
                //Console.WriteLine("Class defining member: {0}", e.TargetSite.DeclaringType);
                //Console.WriteLine("Member type: {0}", e.TargetSite.MemberType);
                //// StackTrace属性是异常创建时自动产生的，无法为其赋值。
                //Console.WriteLine("Stack: {0}", e.StackTrace);
                //Console.WriteLine("Help Link: {0}", e.HelpLink);
                //Console.WriteLine("\n-> Custom Data:");
                //foreach(DictionaryEntry de in e.Data)
                //    Console.WriteLine("->{0}: {1}", de.Key, de.Value);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //当有多个catch的时候，必须注意一个异常引发后将被第一个可用的catch处理
            // catch块按照下面的规则结构化：最前面的catch捕获最特定的异常（排在最上面的派生类）,
            // 最后的catch捕获最普通的异常（最基类）

            // 通用catch块，但是不显示接受由指定成员引发的异常对象
            // 通用类虽然在C#中允许，但不是一个好方法。
            //catch 
            //{
            //    Console.WriteLine("Something bad happened...");
            //}
            finally 
            {
                //不管异常发生与否，一下语句总是被执行。
                //如果不加入一个finally块，当异常发生时（很可能）广播将不会被关闭。
                //在更加现实的场景中，当读者准备进行销毁对象、关闭文件、断开数据库连接等操作时，
                // 在资源清理加入到finally块来确保操作正确执行。

                mycar.CrankTunes(false);
            }

            Console.WriteLine("\n****** Out of exception logic ******");
            Console.ReadLine();
        }
    }
}
