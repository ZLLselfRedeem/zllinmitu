using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestData
{
    public class ResultHolder : IEnumerable<ImportResult>
    {
        public ResultHolder()
        {
            resultList = new List<ImportResult>();
        }

        private List<ImportResult> resultList;

        internal void Add(ImportResult iResult)
        {
            resultList.Add(iResult);
        }

        public int Count
        {
            get
            {
                return resultList.Count;
            }
        }

        IEnumerator<ImportResult> IEnumerable<ImportResult>.GetEnumerator()
        {
            return resultList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return resultList.GetEnumerator();
        }
    }
}
