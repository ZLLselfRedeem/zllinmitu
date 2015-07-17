using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoWenXuexiDelegate
{

    public class Heater 
    {
        private int temperature;
        public string type = "RealFire 001";
        public string area = "China Xian";

        public delegate void BoiledEventHandler(Object sender, BoiledEventArgs e);
        public event BoiledEventHandler Boiled;

        // 定义BoildeEventArgs类，传递给Observer所感兴趣的信息
        // System.EventArgs 是包含事件数据的类的基类。
        public class BoiledEventArgs : EventArgs 
        {
            public readonly int temperature;
            public BoiledEventArgs(int temperature) 
            {
                this.temperature = temperature;
            }
        }

        // 派生类可以重写这个函数。通过这个函数调用事件，主要是在派生类的时候，
        // 可以在调用事件之前进行一些额外的操作，或者剔除事件操作。
        protected virtual void OnBoiled(BoiledEventArgs e) 
        {
            if (Boiled != null)
                Boiled(this, e);
        }

        public void BoildWater() 
        {
            for (int i = 0; i <= 100; i++) 
            {
                temperature = i;
                if (temperature > 95) 
                {
                    BoiledEventArgs e = new BoiledEventArgs(temperature);
                    OnBoiled(e);
                }
            }
        }
    }

    class BigHeater : Heater 
    {
        // 可以达到剔除事件的效果
        protected override void OnBoiled(BoiledEventArgs e)
        {
            //base.OnBoiled(e);
        }
    }

    public class Program 
    {
        static void Main(string[] args) 
        {
            Heater ht = new Heater();
            Alarm alarm = new Alarm();
            ht.Boiled += alarm.MakeAlert;
            ht.Boiled += (new Alarm()).MakeAlert;
            ht.Boiled += Display.ShowMsg;
            ht.BoildWater();
        }
    }

    public class Alarm 
    {
        public void MakeAlert(Object sender, Heater.BoiledEventArgs e) 
        {
            Heater heater = (Heater)sender;
            Console.WriteLine("Alarm: {0} - {1}", heater.type, heater.area);
            Console.WriteLine("Alarm: 嘀嘀嘀，水已经 {0} 度了：", e.temperature);
            Console.WriteLine();
        }
    }

    public class Display 
    {
        public static void ShowMsg(Object sender, Heater.BoiledEventArgs e) 
        {
            Heater heater = (Heater)sender;
            Console.WriteLine("Alarm：{0} - {1}: ", heater.area, heater.type);
            Console.WriteLine("Display：水快烧开了，当前温度：{0}度。", e.temperature);
            Console.WriteLine();
        }
    }
}
