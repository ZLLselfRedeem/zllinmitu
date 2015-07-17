using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndexerStudy
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int xp, int yp)
        {
            X = xp;
            Y = yp;
        }

        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }
        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}]", this.X, this.Y);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Point pt1 = new Point(100, 1000);
            Point pt2 = new Point(40, 20);

            Console.WriteLine("pt1 + pt2: {0}", pt1 + pt2);
            Console.WriteLine("pt1 - pt2: {0}", pt1 - pt2);
        }
    }
}
