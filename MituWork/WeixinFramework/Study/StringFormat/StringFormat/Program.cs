using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringFormat
{
    class Person 
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    class PersonWithToString 
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public string ToString(string format) 
        {
            switch(format)
            {
                case "UPP":
                    return Name.ToUpper();
                case "LOW":
                    return Name.ToLower();
                default:
                    return Name;
            }
        }
    }

    public class Person2 : IFormattable 
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
        
        #region IFormattable Members
        //总结：一.对于实现IFormattable 接口时，如果format参数为null(即不带格式化参数的情况，
        // 如{0})则应该调用重载的 ToString()方法，而不应该自己去另外写代码。
        //  二.如果找不到相应的格式化参数，例如{0:AAA},在Person2的switch中并无匹配的AAA，
        // 这种情况一般也应该去调用重载的 ToString()方法。
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
                return ToString();

            switch (format)
            {
                case "UPP":
                    return Name.ToUpper();
                case "LOW":
                    return Name.ToLower();
                default:
                    return Name;
            }
        }
        #endregion
    }
    // string 类的静态方法 public static string Format(IFormatProvider provider,
    //string format,params Object[] args)这个方法不需要为后面的参数对象实现
    //IFormattable接口就可以使用自定义的格式化参数

    class Square 
    {
        public string Name { get; set; }
        public double Side { get; set; }

        public override string ToString()
        {
            return string.Format("{0} (side: {1})", Name, Side);
        }
    }

    class Rectangle 
    {
        public string Name { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public override string ToString()
        {
            return string.Format("{0}(Width:{1},Height:{2})", Name, Width, Height);
        }
    }

    // GetFormat返回的是真正进行格式化操作的类。
    public class MyHelloFormatProvider : IFormatProvider
    {
        #region IFormatProvider Members
        public object GetFormat(Type formatType)
        {
            return new MyHelloFormatter();
        }
        #endregion
    }

    //返回MyHelloFormatter对象之后，在MyHelloFormatter中具体进行格式化操作
    public class MyHelloFormatter : ICustomFormatter
    {
        public string Format(string format, object arg, IFormatProvider formatProvider) 
        {
            var t = "Hello";
            switch (format) 
            {
                case "UPP":
                    t = t.ToUpper();
                    break;
                case "LOW":
                    t = t.ToLower();
                    break;
                default:
                    break;
            }

            return t + arg.ToString();
        }
    }

    public class Circle : IFormattable
    {
        public string Name { get; set; }

        public double Radius { get; set; }

        public override string ToString()
        {
            return string.Format("{0}(Radius:{1})", Name, Radius);
        }

        #region IFormattable Members

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
                return ToString();

            var t = "Circle ";
            switch (format)
            {
                case "UPP":
                    t = t.ToUpper();
                    break;
                default:
                    break;
            }

            return t + Name;
        }

        #endregion
    }

    class Program
    {
        static void Main(string[] args)
        {
            string name = "Zhezhe";

            //Format方法在取到第一个参数"Hello Cnblogs, I am {0},Today is {1:yyyy-MM-dd} {2}."之后便将其分解成多个部分
            //  "Hello Cnblogs, I am ", "{0}" ,",Today is ", "{1:yyyy-MM-dd}","  "  "{2}","."
            // 其内部是用StringBuild来进行实现的，性能比较高
            StringBuilder sb = new StringBuilder();
            sb.Append("{Hello Cnblogs}, I a,m");
            sb.Append(name);
            sb.Append(", Today is");
            sb.Append(DateTime.Now.ToString("yyyy-MM-dd"));
            sb.Append(DateTime.Now.DayOfWeek);
            sb.Append(".");
            string result = sb.ToString();

            //{1:yyyy-MM-dd} 冒号后面是一个预定义的标签
            string msg = string.Format("{{Hello Cnblogs}}, I am {0}, Today is {1:yyyy-MM-dd} {2}.",
                name, DateTime.Now, DateTime.Now.DayOfWeek);

            string msg2 = string.Format("{{Hello Cnblogs}}, I am {0}, Today is {1:yyyy-MM-dd} {2}.",
                new Person() { Name = "Zhezhe"}, DateTime.Now, DateTime.Now.DayOfWeek);

            string msg3 = string.Format("{{Hello Cnblogs}}, I am {0}, Today is {1:yyyy-MM-dd} {2}.",
                new PersonWithToString() { Name = "Zhezhe" }.ToString("UPP"), DateTime.Now, DateTime.Now.DayOfWeek);
      
            // {0:UPP}真正调用的方法签名是string ToString(string format, IFormatProvider),并且也不是直接调用该方法，
            // 而是通过IFormattable来实现的
            string msg4 = string.Format("{{Hello Cnblogs}}, I am {0:UPP}, Today is {1:yyyy-MM-dd} {2}.",
                new PersonWithToString() { Name = "Zhezhe" }, DateTime.Now, DateTime.Now.DayOfWeek);

            string msg5 = string.Format("{{Hello Cnblogs}}, I am {0:UPP}, Today is {1:yyyy-MM-dd} {2}.",
                new Person2() { Name = "Zhezhe" }, DateTime.Now, DateTime.Now.DayOfWeek);

            // {0"UPP}会调用接口定义的ToString方法，那么如果已经实现IFormattable接口，
            // 则{0}不会去调用重载的ToString()，而是调用接口重新定义的ToString()方法
            string msg6 = string.Format("{{Hello Cnblogs}}, I am {0}, Today is {1:yyyy-MM-dd} {2}.",
                new Person2() { Name = "Zhezhe" }, DateTime.Now, DateTime.Now.DayOfWeek);

            // 具体的执行过程：根据MyHelloFormatProvider对象得到MyHelloFormatter对象，
            // 利用MyHelloFormatter对象的Format方法进行格式化
            string msg7 = string.Format(new MyHelloFormatProvider(), "{0}{1}", 
                new Rectangle { Name = "MyRectnagle", Width = 14.3, Height = 10 }, 
                new Square { Name = "MySquare", Side = 24.2 });

            string msg8 = string.Format(new MyHelloFormatProvider(), "{0:LOW}{1:UPP}",
                new Rectangle { Name = "MyRectnagle", Width = 14.3, Height = 10 }, 
                new Square { Name = "MySquare", Side = 24.2 });

            string msg9 = string.Format("Test： {0}", 
                new Circle() { Name = "MyCircle", Radius = 10 });
            
            string msg10 = string.Format("Test： {0:UPP}",
                new Circle() { Name = "MyCircle", Radius = 10 });

            string msg11 = string.Format(new MyHelloFormatProvider(), 
                "Test： {0:LOW}", new Circle() { Name = "MyCircle", Radius = 10 });
            
            Console.WriteLine(msg);
            Console.WriteLine(msg2);
            Console.WriteLine(msg3);
            Console.WriteLine(msg4);
            Console.WriteLine(msg5);
            Console.WriteLine(msg6);
            Console.WriteLine(msg7);
            Console.WriteLine(msg8);
            Console.WriteLine(msg9);
            Console.WriteLine(msg10);
            Console.WriteLine(msg11);
        }
    }
}
