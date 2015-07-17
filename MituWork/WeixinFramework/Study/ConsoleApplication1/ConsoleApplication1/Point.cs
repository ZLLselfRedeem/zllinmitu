using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumerator
{
    public class Point : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public PointDescription desc = new PointDescription();
        public Point(int xPos, int yPos, string petName)
        {
            X = xPos;
            Y = yPos;
            desc.PetName = petName;
        }

        public Point()
        { 
        }

        public override string ToString()
        {
            return string.Format("X = {0}, Y = {1}, Name = {2};\nID = {3}\n", X, Y, desc.PetName, desc.PointID);
        }

        // 创建了一个当前对象的副本
        public object Clone()
        {
            //// 逐个复制每个Point字段成员，在Point类型中不包含引用类型变量的情况下，这样子也可以实现深复制
            //// 如果Point类型包含引用类型，在新Point对象中的那些引用类型还是浅复制。
            //return this.MemberwiseClone();
            //// return new Point(X, Y);

            //clone过程的要点：1仅包含值类型的类或者结果，直接使用MemberwiseClone()来实现Clone()方法
            // 2如果包含引用类型，在用MemberwiseClone()之后，对每个引用类型成员变量都考虑重新创建一个新对象。
            Point newPoint = (Point)MemberwiseClone();
            PointDescription currentDesc = new PointDescription() { PetName = desc.PetName };
            newPoint.desc = currentDesc;
            return newPoint;
        }
    }
}
