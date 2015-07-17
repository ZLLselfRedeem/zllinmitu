using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anonymous
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstCar = new { Color = "Bright Pink", Make = "Saab", CurrentSpeed = 55};
            var SecondCar = new { Color = "Bright Pin", Make = "Saab", CurrentSpeed = 55 };
            // 匿名类型重写的Equals()是基于值类型的实现
            if (firstCar.Equals(SecondCar))
            {
                Console.WriteLine("Equals 是相等的");
            }
            else 
            {
                Console.WriteLine("Equals 是不相等的");
            }
            // 因为匿名对象没有重写C#的相等操作符（==和！=）所以直接比较引用，
            //即这两个引用是不是指向同一个对象
            // 如果重载==和！=  应该调用已经重写了的Equals()
            if (firstCar == SecondCar)
            {
                Console.WriteLine("refer to the same object");
            }
            else 
            {
                Console.WriteLine("Refer to the different object");
            }

            if (firstCar.GetType().Name == SecondCar.GetType().Name) 
            {
                Console.WriteLine("一个类的两个对象");
            }

        }


        public void BuildAnonType(string make, string color, int currSp) 
        {
            // 关键字var，编译器会在编译时自动生成新的类定义
            //初始化语法告诉编译器为新创建的类型定义私有的后台字段和（只读）属性
            var car = new {Make = make, Color = color, Speed = currSp };
            //通过对象获取属性
            Console.WriteLine("You have a {0} {1} going {2} MPH", car.Color, car.Make, car.Speed);

            //匿名类型包含对System.Object中每个虚方法的自定义实现。
            Console.WriteLine("ToString() == {0}", car.ToString());
        }
    }
}
