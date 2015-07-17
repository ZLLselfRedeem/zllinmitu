using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectOverrdes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with System.Object *****\n");
            Person p1 = new Person("zeng", "Yudan", 20);
            Person p2 = new Person("zeng", "Yudan", 20);

            Console.WriteLine("p1.ToString() = {0}", p1.ToString());
            Console.WriteLine("p2.ToString() = {0}", p2.ToString());
            Console.WriteLine("p1 = p2? {0}", p1.Equals(p2));
            Console.WriteLine("The Same Hash Code? {0}", p1.GetHashCode() == p2.GetHashCode());

            Console.WriteLine("Hash code: {0}", p1.GetHashCode());
            Console.WriteLine("Hash code: {0}", p2.GetHashCode());
            Console.WriteLine("Type: {0}", p1.GetType());

            Console.WriteLine("p1 = p2? {0}", object.Equals(p1, p2));
            Console.WriteLine("p1 and p2 are pointing to same objec: {0}", object.ReferenceEquals(p1, p2));

            p2.Age = 50;

            Console.WriteLine("p1.ToString() = {0}", p1.ToString());
            Console.WriteLine("p2.ToString() = {0}", p2.ToString());
            Console.WriteLine("p1 = p2? {0}", p1.Equals(p2));
            Console.WriteLine("The Same Hash Code? {0}", p1.GetHashCode() == p2.GetHashCode());

            Console.WriteLine("Hash code: {0}", p1.GetHashCode());
            Console.WriteLine("Hash code: {0}", p2.GetHashCode());
        }
    }
}
