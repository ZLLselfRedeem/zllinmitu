using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CustomConvert
{
    static class AnnoyingExtensions 
    {
        // 在LINQ中，最常见的被扩展项是实现了IEnumerable泛型版本接口的类或结构
        public static void PrintDataAndBeep(this System.Collections.IEnumerable iterator) 
        {
            foreach(var item in iterator)
            {
                Console.WriteLine(item);
                Console.Beep();
            }
        }
    }
    public static class MyExtensions 
    {
        //扩张所有类。
        public static void DisplayDefiingAssebly(this object obj)
        {
            Console.WriteLine("{0} lives here: =>{1}\n",obj.GetType().Name, 
                Assembly.GetAssembly(obj.GetType()).GetName().Name);
        }

        // 只是扩展整型类
        public static int ReverseDIgits(this int i) 
        {
            char[] digits = i.ToString().ToCharArray();
            Array.Reverse(digits);
            string newDigits = new string(digits);
           // return int.Parse(newDigits);
            int mid;
            int.TryParse(newDigits, out mid);
            return mid;
        }
        //只有第一个参数可以使用关键字this进行修饰，其他参数将被视为工方法使用的普通传入参数
    }
    public struct Rectangle 
    {
        public int Width { get; set; }
        public int Heigh { get; set; }

        // 在这两个结构体的构造函数中，都显式链接到了默认构造函数。
        // 因为这两个结构体重使用了自动属性，所有自定义构造函数都必须显式
        //调用默认构造函数，来初始化私有的后台字段
        // 同时：this()这句语法也间接的声明了一个缺省构造函数。
        public Rectangle(int w, int h)
            :this()
        {
            Width = w;
            Heigh = h;
        }

        public override string ToString()
        {
            return string.Format("[Width = {0}; Height = {1}]", Width, Heigh);
        }

  

    }

    public struct Square 
    {
        public int Length { get; set; }

        public Square(int l)
            : this() 
        {
            Length = l;
        }

        public override string ToString()
        {
            return string.Format("[Length = {0}]", Length);
        }

        // 显式转换操作符 public static explicit operator TargetClass (SourceClass)
        // {//定义如何进行转化},必须是静态的。
        public static explicit operator Square(Rectangle r)
        {
            Square s = new Square();
            s.Length = r.Heigh;
            return s;
        }

        // 定义了Square类与int类之间的相互装换。
        public static explicit operator Square(int sidelength) 
        {
            return new Square(sidelength);
        }

        public static explicit operator int(Square s) 
        {
            return s.Length;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle re = new Rectangle();
            Square sq = (Square)re;
            int myInt = 1212824900;

            System.Data.DataSet d = new System.Data.DataSet();
            d.DisplayDefiingAssebly();

            myInt.DisplayDefiingAssebly();
            var result = myInt.ReverseDIgits();
        }

        static void BuildAnonType(string make, string color, int currSp) 
        {
            var car = new { Make = make, Color = color, Speed = currSp };
            Console.WriteLine("you hava a {0} {1} going {2} MPG", car.Color, car.Make, car.Speed);
            // 匿名类型包含对System.Object中每个虚方法的自定义实现，例如：
            // 此外还有Equals()和GetHashCode();
            Console.WriteLine("ToString() = {0}", car.ToString());
        }
    }
}
