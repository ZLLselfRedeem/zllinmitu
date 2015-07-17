using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ReviewStudy
{
    // 结构中不能使用自动属性
    internal struct Test 
    {
        //// 错误 结构不能包含显式的无参数构造函数
        //Test()
        //{ 
        //}

        //结构体的构造函数要为所有的字段赋值。
        // 如果有属性的话，必须对属性所封装的字段进行赋值。
        Test(int counter)
        {
            testCounter = counter;
            age = 0;
        }

        private int age;
        public int Age
        {
            get 
            {
                return age;
            }
            set 
            {
                age = value;
            }
        }
        public int testCounter;
  //      public int name;
    }
    [Flags]
    enum Day 
    {
        None = 0x0,
        Sunday = 0x1,
        Monday = 0x2,
        Tuesday = 0x4,
        Wednesday = 0x8,
        Thursday = 0x10,
        Friday = 0x20,
        Saturday = 0x40
    }

    [Description("会员等级")]
    enum MemberLevel
    {
        [Description("金牌会员")]
        gold = 1,
        [Description("银牌会员")]
        silver = 2,
        [Description("铜牌会员")]
        copper = 3
    }

    public static class EnumHelper 
    {
        public static string GetDescription(this Enum value, bool isTop = true)
        {
            Type enumType = value.GetType();
            DescriptionAttribute attr = null;
            if (isTop)
            {
                attr = (DescriptionAttribute)Attribute.GetCustomAttribute(enumType, typeof(DescriptionAttribute));
            }
            else 
            {
                //获取枚举常数名称
                string name = Enum.GetName(enumType, value);
                if (name != null)
                {
                    FieldInfo fieldInfo = enumType.GetField(name);
                    if(fieldInfo != null)
                    {
                        attr = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute), false) as DescriptionAttribute;
                    }
                }
            }
            if (attr != null && !string.IsNullOrEmpty(attr.Description))
                return attr.Description;
            else
                return string.Empty;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string enumName = Enum.GetName(typeof(MemberLevel), 2);
            Console.WriteLine("the names of enum MemberLevel");
            foreach (string name in Enum.GetNames(typeof(MemberLevel)))
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("the values of enum MemberLevel");
            foreach (int i in Enum.GetValues(typeof(MemberLevel)))
            {
                Console.WriteLine(i);
            }

            foreach (MemberLevel i in Enum.GetValues(typeof(MemberLevel)))
            {
                Console.WriteLine(i);
            }

            Day meetingDays = Day.Tuesday | Day.Thursday;
            meetingDays = meetingDays | Day.Friday;
            Console.WriteLine("Meeting days are {0}", meetingDays);
            // 当枚举定义中没有Flags特性时，输出为52，
            // 若标记了[Flags]则输出为Tuesday, Thursday, Friday.

            meetingDays = meetingDays ^ Day.Thursday;
            Console.WriteLine("Meeting days are {0}", meetingDays);

            
            MemberLevel gold = MemberLevel.gold;
            Console.WriteLine(gold.GetDescription(false));
            // Enum.GetUnderlyingType()要求我们传入System.Type作为第一个参数，Type便是某个.NET实体的元数据描述
            Console.WriteLine("MemberLevel uses a {0} for storage", Enum.GetUnderlyingType(gold.GetType()));
        }
    }

    // 当类第一次被加载到内存的时候，该类的所有静态成员会被加载到静态存储区
    // 并且只被创建一次，且直到程序退出时才会被释放。
    // 什么时候该定义静态的成员？变量需要被共享，或者方法需要被反复调用的时候。
    public class Person
    {
        // 自定义类型转货必须是static和public属性修饰的。
        public static explicit operator string(Person p)
        {
            return p.GetName();
        }

        Person()
        {
        }

        public Person(string name)
        {
            this.name = name;
        }

        static Person()
        {
            pAge = 15;
        }

        public static int pAge;
        public string name = "zhangfei";

        // 在静态方法中不能直接调用实例成员
        // 因为当第一次加载时，静态成员已经被加载到静态存储区，此时类的实例对
        // 象有可能还未被创建，所以静态方法中不能调用类成员字段。
        // 当然this和base() 关键字也不能在静态方法中使用。
        public static void Where()
        {
            Person ps = new Person();

            Console.WriteLine(ps.name);

        }

        // 实例方法调用时，其实例对象肯定已经创建完成了，
        // 所有可以调用静态的或者非静态的所有成员。
        // 在实例方法中，可以调用静态方法和静态数据成员。
        public string AllNmae()
        {
            Where();
            return name + pAge;
        }
    }

    // 定义两个静态类
    // 静态类不能创建实例，当然不能有实例，即使有实例成员，也没办法通过实例对象进行调用。
    // 静态类不能有实例构造函数，因为静态类中没有实例成员
    // 静态类也不能实例化
    // 静态类可以有静态构造函数（所有的类可以有静态构造函数）

    public static class ExternPerson
    {
        public static string GetName(this Person pson)
        {
            return pson.name;
        }
    }

    public static class Dog
    {
        static Dog()
        {
            age = 15;
        }

        // 静态类不能有实例构造函数
        //public Dog()
        //{ 
        //}
        public const string name = "zhejianghangzhou";
        // .field public static literal string name = "zhejianghangzhou"
        public static int age;

        // 不能在静态类中声明实例成员
        // internal string name;
    }

    // Dog类编译后的IL代码如下，可以看出来静态类的本质是一个抽象密封类

    //.class public abstract auto ansi sealed ReviewStudy.Dog
    //   extends [mscorlib]System.Object
    //{
    //    .field public static int32 age
    //    .method private hidebysig specialname rtspecialname static 
    //      void  .cctor() cil managed
    //    {
    //     代码大小       9 (0x9)
    //    .maxstack  8
    //    IL_0000:  nop
    //    IL_0001:  ldc.i4.s   15
    //    IL_0003:  stsfld     int32 ReviewStudy.Dog::age
    //    IL_0008:  ret
    //    } // end of method Dog::.cctor

    //    } // end of class ReviewStudy.Dog
    //}
}
