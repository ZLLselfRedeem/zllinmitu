using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace FunWithGenericCollections
{
    // Using where 关键字
    // MyGenericClass derives from object, while
    // contained items must have a default cotr
    public class MyGenericClass<T> where T : new()
    {
    }


    //MyGenericClass derives from object, while
    // contained items must be a class implementing ICollection 
    // and must support a default
    // 主要 new()限制必须在列表的最后面，限制的先后顺序，以及限制的范畴。
    public class MyGenericClasses<T> where T : class, ICollection, new()
    {
    }

    //public class MyGenericclass<T> where T :new(), class
    //{
    //}
    // Multiple type parameters
    public class MyGenericClass<K, T>
        where K : class, new()
        where T : struct, IComparable<T>
    {

        static void Swap<V>(ref V a, ref V b) where V : struct
        {

        }
    }
    public struct Point<T>
    {
        private T xPos;
        private T yPos;

        public Point(T xpos, T ypos)
        {
            xPos = xpos;
            yPos = ypos;
        }

        public T X
        {
            get
            {
                return xPos;
            }

            set
            {
                xPos = value;
            }
        }

        public T Y
        {
            get
            {
                return yPos;
            }

            set
            {
                yPos = value;
            }
        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}]", xPos, yPos);
        }

        public void ResetPoint()
        {
            xPos = default(T);
            yPos = default(T);
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return string.Format("Name: {0}, Age: {1}", FirstName + LastName, Age);
        }
    }

    class SortPeopleByAge : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x.Age > y.Age)
                return 1;
            if (x.Age < y.Age)
                return -1;
            else
                return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // UseGenericList();
            // UseGenericStack();

            //TestObservableCollection();
            //SwapGeneric();


            //// Make an array if string data, having a fixed size of 3.
            //string[] strArray = { "First", "Sencond", "THird" };
            //// IndexOutOfRangeException
            //strArray[3] = "new item?";
            SimpleBoxUnboxOperation();

        }
        static void SimpleBoxUnboxOperation() 
        {
            int myInt = 25;
            // Box the int into an object reference
            object boxedInt = myInt;

            // Unbox the reference back into a corresponding int
            int unboxedInt = (int)boxedInt;

            try
            {
                double unboxeddouble = (double)boxedInt;
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }

            ArrayList myInts = new ArrayList();
            //值类型会自动装箱
            myInts.Add(10);
            myInts.Add(20);
            myInts.Add(30);

            // 注意此处ArrayList[index]返回的是object类型，所以要进行拆箱
            int i = (int)myInts[1];
        }

        private static void SwapGeneric()
        {
            int a = 10;
            int b = 90;
            Console.WriteLine("Before Swap : {0}, {1}", a, b);
            // 显式的指定类型参数，这是一个好习惯
            // 虽然编译器可以自己推断出来类型参数的准确类型，但是是在至少有一个实参的情况。
            Swap<int>(ref a, ref b);
            Console.WriteLine("After Swap: {0}, {1}", a, b);
            DisplayBaseClass<int>();

            Point<int> p = new Point<int>(10, 10);
            Console.WriteLine("p.ToString()= {0}", p.ToString());
            p.ResetPoint();
            Console.WriteLine("p.ToString()= {0}", p.ToString());
        }

        // 至少有一个实参才可以推断，如下方法就无法推断实际参数类型
        static void DisplayBaseClass<T>()
        {
            Console.WriteLine("Base class of {0} is {1}.", typeof(T), typeof(T).BaseType);
        }

        // 在方法名前，参数列表后，指定类型参数
        static void Swap<T>(ref T a, ref T b)
        {
            Console.WriteLine("You sent the Swap() method a {0}", typeof(T));
            T temp;
            temp = a;
            a = b;
            b = temp;
        }

        private static void TestObservableCollection()
        {
            ObservableCollection<Person> people = new ObservableCollection<Person>()
            {
                new Person{FirstName = "Peter", LastName = "Murpyh", Age = 12},
                new Person{FirstName = "goudan", LastName = "chagnchun", Age = 5}
            };

            people.CollectionChanged += people_CollectionChanged;

            people.Add(new Person { FirstName = "Fred", LastName = "Smith", Age = 32 });
            people.RemoveAt(1);
        }

        static void people_CollectionChanged(object sender,
            System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Action for this event: {0}", e.Action);

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Here are the old Items:");
                foreach (Person p in e.OldItems)
                    Console.WriteLine(p);
                Console.WriteLine();
            }

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                Console.WriteLine("Here are the New items:");
                foreach (Person p in e.NewItems)
                    Console.WriteLine(p);
                Console.WriteLine();
            }
        }


        static void GetCoffee(Person p)
        {
            Console.WriteLine("{0} got coffee!", p.FirstName);
        }

        static void UseGenericQueue()
        {
            Queue<Person> peopleQ = new Queue<Person>();
            peopleQ.Enqueue(new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 });
            peopleQ.Enqueue(new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 });
            peopleQ.Enqueue(new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 });
            GetCoffee(peopleQ.Dequeue());
            GetCoffee(peopleQ.Dequeue());
            GetCoffee(peopleQ.Dequeue());
        }
        static void UseSortedSet()
        {
            SortedSet<Person> setOfPeople = new SortedSet<Person>(new SortPeopleByAge())
            {
                               new Person{FirstName = "zll", LastName = "Chian", Age = 24},
                new Person{FirstName = "zyd", LastName = "Changchun", Age = 20},
                new Person{FirstName = "YJc", LastName = "mitu", Age = 40},
                new Person{FirstName = "xiaopengyou", LastName = "Hangzhou", Age = 10}
            };

            foreach (Person p in setOfPeople)
                Console.WriteLine(p);
            setOfPeople.Add(new Person { FirstName = "Saku", LastName = "Hones", Age = 3 });

            foreach (Person p in setOfPeople)
                Console.WriteLine(p);
        }

        static void UseGenericStack()
        {
            Stack<Person> stackOfPeople = new Stack<Person>();
            stackOfPeople.Push(new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 });
            stackOfPeople.Push(new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 });
            stackOfPeople.Push(new Person { FirstName = "Lisa", LastName = "Simpson", Age = 17 });
            Console.WriteLine("First person is: {0}", stackOfPeople.Peek());
            Console.WriteLine("Popped off {0}", stackOfPeople.Pop());

            Console.WriteLine("First person is: {0}", stackOfPeople.Peek());
            Console.WriteLine("Popped off {0}", stackOfPeople.Pop());

            Console.WriteLine("First person is: {0}", stackOfPeople.Peek());
            Console.WriteLine("Popped off {0}", stackOfPeople.Pop());

            try
            {
                Console.WriteLine("First person is: {0}", stackOfPeople.Peek());
                Console.WriteLine("Popped off {0}", stackOfPeople.Pop());
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("\nError! {0}", ex.Message);
            }
        }
        private static void UseGenericList()
        {
            //使用初始化语法来创建List<Person>对象，
            // 实际上初始化语法是作为多次访问Add()方法的一个简化速记
            // 实际上是通过Add来实现的
            // 你只能对哪些实现了Add()方法的类，应用集合初始化语法
            // 如何来证明这件事情呢？

            List<Person> lp = new List<Person>
            {
                new Person{FirstName = "zll", LastName = "Chian", Age = 24},
                new Person{FirstName = "zyd", LastName = "Changchun", Age = 20},
                new Person{FirstName = "YJc", LastName = "mitu", Age = 40},
                new Person{FirstName = "xiaopengyou", LastName = "Hangzhou", Age = 10}
            };

            Console.WriteLine("Items in the list: {0}", lp.Count);
            foreach (Person p in lp)
                Console.WriteLine(p);

            lp.Insert(2, new Person { FirstName = "Inserter", LastName = "Outer", Age = 100 });

            Person[] arrayOfPerson = lp.ToArray();

            Console.WriteLine("Items in the list: {0}", lp.Count);
            foreach (Person p in lp)
                Console.WriteLine(p);
        }
    }
}
