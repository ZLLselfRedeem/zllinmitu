using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace InterfaceTest
{
    public class ResultHolder :IEnumerable<int>
    {
        public ResultHolder()
        {
        }

        private List<int> ResultList = new List<int>();
        // public string SheetName { get; private set; }

        internal void Add(int iResult)
        {
            ResultList.Add(iResult);
        }

        public int Count
        {
            get
            {
                return ResultList.Count;
            }
        }


        public IEnumerator<int> GetEnumerator()
        {
            return ResultList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ResultHolder rh = new ResultHolder();
            rh.Add(1);
            rh.Add(21);
            rh.Add(32);
            foreach(int i in rh)
                Console.WriteLine("{0}", i);
        }
    }
}
