using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleClassExample
{
    class SimpleUtilityClass
    {
        public static readonly DateTime dt;
        public Employee Person { get; set; }

        // 每创建一个实例，静态量dt就会被更新一次， 这个构造函数明显就是不合适的
        public SimpleUtilityClass()
        {
            dt = DateTime.Now;
        }
        
    }
}
