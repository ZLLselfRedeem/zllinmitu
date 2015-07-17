using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloneablePoint
{
    public class Point : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set;}
        public PointDescription desc = new PointDescription();

        public Point(int xPos, int yPos, string petName)
        {
            X = xPos;
            Y = yPos;
            desc.PetName = petName;
        }

        public Point(int xPos, int yPos) 
        {
            X = xPos;
            Y = yPos;
        }
        public Point() 
        {
        }
        public override string ToString()
        {
            return string.Format("X = {0}; Y = {1}; Name = {2}; \nID = {3}n", X, Y, desc.PetName, desc.PointID);
        }

        // 对于内部有引用类型的自定义类来说，为了实现真正的深拷贝，你需要使用MemberwiseClone返回值
        // 去配置对象
        public object Clone()
        {
            //return new Point(this.X,  this.Y);
            // 因为这个Point类型中不包含任何引用类型变量，所以你可以使用MemberwiseClone
            //return this.MemberwiseClone();
            // 但是如果类中有引用类型的成员的话，那个MemberwiseClone会通过浅拷贝，那些引
            // 用类型

            Point newPoint = (Point)this.MemberwiseClone();
            PointDescription currenDes = new PointDescription();
            currenDes.PetName = this.desc.PetName;
            newPoint.desc = currenDes;
            return newPoint;
        }
    }

    public class PointDescription 
    {
        public string PetName { get; set; }
        public Guid PointID { get; set; }

        public PointDescription() 
        {
            PetName = "No-name";
            PointID = Guid.NewGuid();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        //    Console.WriteLine("C***** Fun with Object Cloning *****\n");
        //    // 两个引用指向内存中的同一个位置，就是同一个对象实例
        //    // 如果你想要在赋值的时候返回本对象的副本，你需要实现这个标准的ICloneable接口
        //    Point p1 = new Point(50, 50);
        //    Point p2 = p1;
        //    p2.X = 0;
        //    Console.WriteLine(p1);
        //    Console.WriteLine(p2);
        //    Console.ReadLine();
        //    Point p3 = new Point(100, 100);
        //    Point p4 = (Point)p3.Clone();
        //    p4.X = 0;
        //    Console.WriteLine(p3);
        //    Console.WriteLine(p4);

            Point p5 = new Point(100, 100, "Jane");
            Point p6 = (Point)p5.Clone();
            Console.WriteLine("p5: {0}", p5);
            Console.WriteLine("P6: {0}", p6);
            p6.X = 9;
            p6.desc.PetName = "My new Point";

            Console.WriteLine("p5: {0}", p5);
            Console.WriteLine("P6: {0}", p6);
        }
    }
}
