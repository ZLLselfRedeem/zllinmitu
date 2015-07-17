using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqOverArray
{
    class Program
    {
        static void QueryOverString() 
        {
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};
            //查询的结果集是一个实现了IEnumeatble<T>泛型版本接口的对象
            // 看不到Func<>委托，也用不到考虑对Enumerable类型的成员方法的调用
            // LINQ查询操作符只不过是调用由Enumerable类型定义的各种扩展方法的速记版。
            IEnumerable<string> subset = from game in currentVideoGames
                                         where game.Contains(" ")
                                         orderby game
                                         select game;
            IEnumerable<string> subset1 = currentVideoGames.Where(game => game.Contains(" ")).OrderBy(game => game).Select(game => game);

            IEnumerable<int> subsetint = from game in currentVideoGames
                                         where game.Length > 6
                                         select game.Length;
            
            Console.WriteLine("the length of the Item:");
            foreach(int i in subsetint)
                Console.WriteLine("{0}",i);    
            foreach(string s in subset)
                Console.WriteLine("Item: {0}", s);

            // 反射LINQ结果集 可以知道subset实际上是OrderedEnumerable<TElement, TKey>类型
            ReflectOverResults(subset);
            // 而subsetint是WhereSelectArrayIterator<T>类型的
            ReflectOverResults(subsetint);
        }

        static void QueryOverInts() 
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
            var subset = from i in numbers
                         where i < 10
                         select i;
            foreach(var i in subset)
                Console.WriteLine("item < 10: {0}", i);

            //关于延迟执行
            //LINQ查询表达式一个重要的地方是在我们迭代内容之前，他们不会真正进行运算，
            //可以为相同的容器多次应用相同的查询，而始终可以获得最新的最好的结果。
            Console.WriteLine("#######Revised#########");
            numbers[0] = 6;
            foreach(var i in subset)
                Console.WriteLine("Item < 10: {0}", i);
            // 如果想要在foreach逻辑外部运算LINQ表达式的话，可以调用由Enumerable类型定义的许多扩展方法
            //诸如 ToArray<T>(), ToDirectionary<TSource, TKey>()以及ToLis<T>()等扩展方法。

            // 立即执行。
            int[] subsetArrayInt = (from i in numbers where i % 10 == 0 select i).ToArray();
        }

        static IEnumerable<string> GetStringSubset() 
        {
            string[] colors = { "Light Red", "Green", "Yellow", "Dark Red", "Red", "Purple" };
            IEnumerable<string> theRedColors = from color in colors
                                               where color.Contains("Red")
                                               select color;
            return theRedColors;
        }

        static string[] GetStringSubsetAsArray() 
        {
            string[] colors = { "Light Red", "Green", "Yellow", "Dark Red", "Red", "Purple" };
            //IEnumerable<string> theRedColors = from color in colors
            //                                   where color.Contains("Red")
            //                                   select color;
            //return theRedColors.ToArray();
            return (from color in colors where color.Contains("Red") select color).ToArray();
        }

        static void ReflectOverResults(object resultSet) 
        {
            Console.WriteLine("####### Info about your query #######");
            Console.WriteLine("resultSet is of type: {0}", resultSet.GetType().Name);
            Console.WriteLine("resultSet location: {0}", resultSet.GetType().Assembly.GetName().Name);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("********* Fun with LINQ to Object **********");
            QueryOverString();
            QueryOverInts();
            Console.ReadLine();
        }
    }
}
