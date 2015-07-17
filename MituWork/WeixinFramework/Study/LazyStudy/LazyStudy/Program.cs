using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LazyStudy
{
    class AllTracks 
    {
        private string[] allSongs = new string[1000];

        public AllTracks() 
        {
            Console.WriteLine("the default constructor");
        }

        public AllTracks(int i ) 
        {
            Console.WriteLine("the constructor required an int arg: {0}", i);
        }
    }

    class MediaPlayer 
    {
        public void play() { }
        // 主要此处使用的AllTracks的默认构造函数进行初始化的
        //但是Lazy<>类允许指定一个泛型委托作为可选参数，可以加入额外的代码，或者调用非默认构造函数
        // 但是该委托必须返回ALltracks 类型的实例。
        private Lazy<AllTracks> allSongs = new Lazy<AllTracks>(() =>
            {
                Console.WriteLine("Lambda expression");
                return new AllTracks(2);
            }
            );

        public AllTracks GetAllTracks()
        {
            return allSongs.Value;
        }
        //private AllTracks allSongs = new AllTracks();
        //public AllTracks GetAllTracks()
        //{
        //    return allSongs;
        //}
    }

    class Program
    {
        static void Main(string[] args)
        {
            // ||右侧代码未运行
            //bool b = true || DoOneThing() > 0;
            // 在DoSomeThing()中不管是否需要b的值，DoOneThing()该
            //方法都已经运行了。
            //DoSomeThing(false, DoOneThing());
            // 尽管实现了有需求的时候在运行的原则，但是
            // 委托的传递，不方便，并且有的值求过了以后保存下来，多次使用会显得更有效率
            //DoSomeThing(() => false, () => DoOneThing());
            DoSomeThing(new LazyS<bool>(() => true), new LazyS<int>(() => DoOneThing()));
            Console.ReadKey();
        }

        static int DoOneThing() 
        {
            Console.WriteLine("DoOneThing 已经求值");
            return 45;
        }

        //static void DoSomeThing(bool a, int b) 
        //{
        //    Console.WriteLine("DoSomeThing 开始执行");
        //    if(a)
        //        Console.WriteLine("the b is : {0}", b);
        //    Console.WriteLine("DoSomeThing 执行完成");
        //}

        static void DoSomeThing(LazyS<bool> a, LazyS<int> b)
        {
            Console.WriteLine("DoSomeThing 开始执行");
            if (a.Value)
                Console.WriteLine("the b is : {0}", b.Value *b.Value);
            Console.WriteLine("DoSomeThing 执行完成");
        }

    }
    public class LazyS<T> 
    {
        private T value;
        Func<T> function;
        bool isCreate;

        public LazyS(Func<T> func) 
        {
            function = func;
        }

        // 只有在调用Value属性时才胡执行该函数并将值保存
        // 而在下次调用时，如果已经求过值了，直接返回缓存过的值。
        public T Value 
        {
            get 
            {
                if (!isCreate) 
                {
                    value = function();
                    isCreate = true;
                }
                return value;
            }
        }
    }
}
