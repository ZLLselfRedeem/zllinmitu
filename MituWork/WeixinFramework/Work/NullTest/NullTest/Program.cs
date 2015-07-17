using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullTest
{

    class Student
    {
        // 私有字段
        private string fName;
        private int fAge;
        private static int fCount; // 静态支持字段

        // 属性
        public string Name
        {
            get 
            {
                return fName;
            }
            set
            {
                fName = value;
            }
        }

        public int Age
        {
            get 
            {
                return fAge; 
            }
            set 
            {
                if (value < 0 | value > 150)
                    throw new ArgumentOutOfRangeException("the value of age must between 0 and 150.");
                else
                    fAge = value;
            }
        }

        public static int Count
        {
            get { return fCount; }
        }

        public Student()
        {
            fCount++;
        }
    }

    interface IEquatable<T>
    {
        bool Equals(T obj);
    }

    public class Car : IEquatable<Car>
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }

        public bool Equals(Car obj)
        {
            if (Make == obj.Make && Model == obj.Model && Year == obj.Year)
            {
                return true;
            }
            else
                return false;
        }
    }

    interface IICanDo 
    {
        //不能有public等访问修饰符
        void Speak();
        string Read();
    }

    public class Person : IICanDo
    {
        // 自动声明为public
        public void Speak()
        {
            Console.WriteLine("I love play basketball");
        }

        // 使用虚函数的方式实现接口，以便在派生类中进行重载
        public virtual string Read()
        {
            string readDomain = "Book";
            return readDomain;
        }
    }

    public class Boy : Person
    {
        public override string Read()
        {
            string read = "Sport";
            return read;
        }
    }

    public class Girl : Person, IICanDo
    {
        // 重新实现接口中Speak（）来覆盖Person关于该接口的Speak()方法的实现。
        public void Speak()
        {
            Console.WriteLine("I love read book");
        }
    }

    interface IEnglishDimensions
    {
        float getLenth();
        float getWidth();
    }
    interface IMetricDimensions
    {
        float getWidth();
        float getLenth();
    }

    interface ITest
    {
        float getWidth();
    }

    interface ITotal : ITest, IEnglishDimensions
    {
        void Display();
    }

    class Car : ITotal
    {

        public void Display()
        {
            throw new NotImplementedException();
        }

        float ITest.getWidth()
        {
            throw new NotImplementedException();
        }

        float IEnglishDimensions.getWidth()
        {
            throw new NotImplementedException();
        }

        public float getLenth()
        {
            throw new NotImplementedException();
        }
    }
    class Box : IEnglishDimensions, IMetricDimensions
    {
        float lengthInches;
        float widthInches;

        internal Box(float length, float width)
        {
            lengthInches = length;
            widthInches = width;
        }

        // 两个接口都进行显式实现
        //float IEnglishDimensions.getLenth()
        //{
        //    return lengthInches;
        //}

        //float IEnglishDimensions.getWidth()
        //{
        //    return widthInches;
        //}

        // 如果想要使用英制作为默认的测量方式,那么就以如下方式实现：
        public float getLenth()
        {
            return lengthInches;
        }

        public float getWidth()
        {
            return widthInches;
        }

        float IMetricDimensions.getLenth()
        {
            return lengthInches * 2.54f;
        }

        float IMetricDimensions.getWidth()
        {
            return widthInches * 2.54f;
        }

        public void Test()
        {
            Console.WriteLine("Length: {0}", getLenth());
        }
    }

    interface ILeft
    {
        int P { get; }
    }

    interface IRight
    {
        int P();
    }

    //要么显式实现特性P,要么显式实现方法P,要么两者都显式实现。
    class Middle : ILeft, IRight
    {

        public int P()
        {
            return 0;
        }

        int ILeft.P
        {
            get 
            { 
                return 0; 
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Box box = new Box(30.0f, 25.0f);
            //IEnglishDimensions eDimensions = (IEnglishDimensions)box;
            IMetricDimensions mDimensions = (IMetricDimensions)box;

            // the method member of interface that is explicitly 
            // implimented must be called by IDimensions instances.
            //Console.WriteLine("Length:{0}", eDimensions.getLenth());
            //Console.WriteLine("width:{0}", eDimensions.getWidth());
            //以英制做为默认实现方式：
            Console.WriteLine("Length:{0}", box.getLenth());
            Console.WriteLine("width:{0}", box.getWidth());

            Console.WriteLine("Length:{0}", mDimensions.getLenth());
            Console.WriteLine("width:{0}", mDimensions.getWidth());
            // 而隐式接口的话类和接口都可以调用。
        }

    }
}
