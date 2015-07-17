using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LambdaStudy
{
    public class SimpleMath 
    {
        public delegate void MathMessage(string msg, int result);
        private MathMessage mmDelegate;

        public void SetMathHandler(MathMessage target) 
        {
            mmDelegate = target;
        }

        public void Add(int x, int y) 
        {
            if(mmDelegate != null)
            {
                mmDelegate.Invoke("Adding has completed!", x + y);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SimpleMath sm = new SimpleMath();
            sm.SetMathHandler((msg, result) =>
                {
                    Console.WriteLine("Message: {0}, Result: {1}", msg, result);
                });
            sm.Add(10, 30);
           // TraditionalDelegateSyntax();
        }

        static void TraditionalDelegateSyntax() 
        {
            List<int> list = new List<int> { 20, 1, 4, 8, 9, 44 };
            //使用Predicate委托进行的
            //Predicate<int> callBack = new Predicate<int>(IsEvenNumber);
            //List<int> evenNumbers = list.FindAll(callBack);

            //使用匿名方法
            //List<int> evenNumbers = list.FindAll(
            //    delegate(int i)
            //    {
            //        return (i % 2) != 0;
            //    }
            //    );

            //使用lambda表达式，lambda表达式可以应用于任何匿名方法或者是强类型委托可以应用的场合
            // 编译器会把lambda表达式翻译为使用委托delegate的标准匿名方法。
            //List<int> evenNumbers = list.FindAll(i => (i % 2) == 0);

            List<int> evenNumbers = list.FindAll((int i) =>
                {
                    Console.WriteLine("value of i is currently: {0}", i);
                    bool isEven = ((i % 2) == 0);
                    return isEven;
                });

            foreach(int e in evenNumbers)
                Console.Write("{0}\t", e);
            Console.WriteLine();
        }

        //该方法只有在某一次特定的查找需求中才会用到，一般情况下不会使用
        static bool IsEvenNumber(int i) 
        {
            return (i % 2) == 0;
        }
    }
}
