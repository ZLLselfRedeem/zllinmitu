using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExceptionHander
{
    /// <summary>
    /// 遵守.NET异常处理的最佳实现
    /// 1、继承自Exception/ApplicationException类
    /// 2、由[System.Serializable]特性标记
    /// 3、定义一个默认构造函数
    /// 4、定义一个设定继承的Message属性的构造函数
    /// 5、定义一个处理”内部异常“的构造函数
    /// 6、定义一个处理类型序列化的构造函数
    /// </summary>
    [Serializable]
    public class MyException : Exception
    {
        public MyException() { }
        public MyException(string message) : base(message) { }
        public MyException(string message, Exception inner) : base(message, inner) { }
        protected MyException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
