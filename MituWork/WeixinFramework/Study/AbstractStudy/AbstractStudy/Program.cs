using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractStudy
{
    public class Amal
    {
        Amal()
        {
 
        }
    }
    public abstract class Animal
    {
        protected Animal()
        { 
        }

        protected string name;
        //声明抽象属性
        public abstract string Name
        {
            get;
        }

        // 声明抽象方法
        public abstract void Show();

        // 实现一般方法
        public void MakeVoice()
        {
            Console.WriteLine("All animals can make voice!");
        }

        protected string myCorp;
        public abstract string MyCorp { get; set; }
    }

    public interface IAction
    {
        void Move();
    }

    public class Duck : Animal, IAction
    {
        public override string MyCorp
        {
            get
            {
                return "mitu";
            }
            set
            {
                myCorp = value;
            }
        }

        public Duck(string _name)
        {
            name = _name;
        }

        //重载抽象方法

        public override void Show()
        {
            Console.WriteLine(name + " is showing for you.");
        }

        public override string Name
        {
            get { return name; }
        }

        public void Move()
        {
            Console.WriteLine("Duck alse can swim.");
        }
    }

    public class Dog : Animal, IAction
    {
  
        public override string MyCorp
        {
            get
            {
                return "mitu";
            }
            set
            {
                myCorp = value;
            }
        }
        public Dog(string name)
        {
            this.name = name;
        }

        public override void Show()
        {
            Console.WriteLine(name +　"　is showing for you.");
        }

        public override string Name
        {
            get { return name; }
        }

        public void Move()
        {
            Console.WriteLine(name +" alse can run.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Animal duck = new Duck("Duck");
            duck.MakeVoice();
            duck.Show();

            Animal dog = new Dog("Dog");
            dog.MakeVoice();
            dog.Show();

            IAction dogAction = new Dog("A big dog");
            dogAction.Move();


            Duck dck = new Duck("A good Duck");
            dck.Show();
            dck.MakeVoice();
            dck.Move();

            Encoding encoding = Encoding.UTF8;

            byte[] testr = encoding.GetBytes("nihao你好");
            string result = encoding.GetString(testr);


        }
    }
}
