using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace LateBindingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****** Fun with Late Binding ******");
            Assembly a = null;
            try
            {
                // Assembly.Load();CLR将只能探测客户端文件夹
                //当然也可以使用Assembly.LoadForm()项程序集输入一个决定路径。
                a = Assembly.Load("CarLibrary");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            if (a != null)
                CreateUsingLateBinding(a);

            Console.ReadLine();
            

        }
        static void InvokeMethodWithArgsUsingLateBinding(Assembly asm)
        {
            Type sport = asm.GetType("CarLibrary.SportsCar");
            object obj = Activator.CreateInstance(sport);
            MethodInfo method = sport.GetMethod("TurnOnRadio");
            method.Invoke(obj, new object[] { true, 2 });
        }
        static void CreateUsingLateBinding(Assembly asm)
        {
            try
            {
                Type miniVan = asm.GetType("CarLibrary.MiniVan");
                //此处返回一个基本的System.Object类型，而不是一个强类型的MiniVan
                //晚期绑定的重点是建立哎编译时未知类型的实例
                //不能直接通过·操作符来调用对象miniVan的底层方法，但是可以使用反射进行实现
                object obj = Activator.CreateInstance(miniVan);
                Console.WriteLine("Create a {0} using late binding!", obj);
                MethodInfo mi = miniVan.GetMethod("TurboBoost");
                MethodInfo mistatic = miniVan.GetMethod("Display");
                mistatic.Invoke(miniVan, null);
                //传入实例obj和TurbuBoost该方法的参数，进行调用。
                mi.Invoke(obj, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
