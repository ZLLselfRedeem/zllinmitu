using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Motorcycle
{
    [Obsolete("Hello,attribute")]
    [Serializable]
    public class Motorcycle 
    {
        //一个特性只能被应用在紧接在下面的那个对象，但是一个项可以被加上多种特性。
        
        [NonSerialized]
        float weghtOfCurrentPassengers;

        bool hasRadioSystem;
        bool hasHeadSet;
        bool hasSissyBar;
    }
// 当给特性提供构造参数时，直到该参数被其他类型或外部工具反射后，特性才被分配到内存中。
    // 定义在特性级的字符串数据只是作为元数据介绍，被存储在程序集中。
    class Program
    {
        static void Main(string[] args)
        {
            // 此时是C#的编译器在反射[Obsolete]特性的参数。
            Motorcycle mc = new Motorcycle();
        }
    }
}
