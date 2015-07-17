using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCotr
{
    class CorTest
    {
        public CorTest(int i = 5, string sfield = "test")
        {
            iField = i;
            intField = i;
            sField = sfield;
        }
        public string sField { get; set; }
        public int iField { get; private set; }
        public int intField { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 注意这种形式不是命名参数
            // 对象初始化器
            CorTest ct = new CorTest(5) { intField = 10, sField = "Hello Cor" };
            // 命名参数
            CorTest ct2 = new CorTest(sfield : "hell");
            //
            // 等价如下的形式：
            //
            //CorTest ct2 = new CorTest(5);
            //ct2.intField = 10;
            //ct2.sField = "Hello corr";
        }

    }
}
