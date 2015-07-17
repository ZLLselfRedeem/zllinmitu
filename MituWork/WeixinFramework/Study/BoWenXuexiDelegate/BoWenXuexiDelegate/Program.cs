using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoWenXuexiDelegate
{
    class Heater1 
    {
        private int temperatrue;
        public delegate void BoilHandler(int param);
        public event BoilHandler BoilEvent;

        public void BoilWater() 
        {
            for (int i = 0; i <= 100; i++) 
            {
                temperatrue = i;
                if (temperatrue > 95) 
                {
                    if (BoilEvent != null)
                        BoilEvent(temperatrue);
                }
            }
        }
    }

    public class Alarm1
    {    
        public void MakeAlert(int param)
        {
            Console.WriteLine("Alarm: 嘀嘀嘀，水已经 {0} 度了", param);
        }
    }

    public class Display1
    {
        public static void ShowMsg(int param)
        {
            Console.WriteLine("Display: 水快开了，当前温度： {0}度。", param);
        }
    }

    public enum Language 
    {
        English,
        Chinese
    }
    // 定义了一种类型，通过返回值和方法参数来标识这种类型。
    // 委托在声明的时候就声明了一个类，虽然和一般的类申明不一样
    // 但是委托在编译的时候的确会编译成类。因为Delegate是一个类
    // 所以在任何可以声明、定义、使用类的地方都可以使用Delegate
    public delegate void GreetingDelegate(string name);

    public class GreetingManager 
    {
        //MakeGreet事件的声明与之前委托变量delegate的声明唯一的区别就是多了一个
        // 关键字。声明事件不过类似的声明了一个进行了封装的委托类型的变量而已。
        public event GreetingDelegate MakeGreet;
        // 当我们声明一个事件时，
        public void GreetPeople(string name)
        { 
            MakeGreet(name); 
        }
    }
    class Program1
    {
        static void Main(string[] args)
        {
            // 为什么在此处不能引用实例方法
            GreetPeople("zll", EnglishGreeting);
            GreetPeople("周梁亮", ChineseGreeting);

            //GreetingDelegate delegate1, delegate2;
            //delegate1 = EnglishGreeting;
            //delegate1 += ChineseGreeting;
            GreetingDelegate delegate1 = new GreetingDelegate(EnglishGreeting);
            delegate1 += ChineseGreeting;
            //delegate2 = ChineseGreeting;
            //GreetPeople("zll", delegate1);
            //GreetPeople("周梁亮", delegate1);
            //delegate1("zll");
            GreetPeople("zll", delegate1);

            delegate1 -= ChineseGreeting;
            GreetPeople("zll", delegate1);
            // 使用委托可以将多个方法绑定到同一个委托变量，当调用此变量，可以依次调用
            // 所有绑定的方法，返回最后一个方法的结果。
            // delegate2("周梁亮");
            //委托就相当于是一种类型，可以进行复制，只是可以将方法复制给委托
            // 多个方法绑定委托。
            GreetingManager gm = new GreetingManager();
            // gm.MakeGreet = EnglishGreeting;
            // 事件“BoWenXuexiDelegate.GreetingManager.MakeGreet”
            // 只能出现在 += 或 -= 的左边(从类型“BoWenXuexiDelegate.GreetingManager”中使用时除外)
            gm.MakeGreet += ChineseGreeting;
            gm.GreetPeople("zll and zyd");

            Heater ht = new Heater();
            Alarm alarm = new Alarm();
            ht.BoilEvent += alarm.MakeAlert;
            ht.BoilEvent += (new Alarm()).MakeAlert;
            ht.BoilEvent += Display.ShowMsg;
            ht.BoilWater();

        }

        public void GreetPeople(string name, Language lang) 
        {
            switch (lang) 
            {
                case Language.English:
                    EnglishGreeting(name);
                    break;
                case Language.Chinese:
                    ChineseGreeting(name);
                    break;
            }
        }

        public static void GreetPeople(string name, GreetingDelegate MakeGreet) 
        {
            MakeGreet(name);
        }

        public static void EnglishGreeting(string name) 
        {
            Console.WriteLine("Morning, " + name);
        }

        public static void ChineseGreeting(string name) 
        {
            Console.WriteLine("早上好, "+ name);
        }
    }
}
