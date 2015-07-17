using System.Collections.Generic;
using System.Data;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.SimpleRight
{
    class FunctionItem
    {
        private HashSet<string> fSubFunction;

        public FunctionItem(DataRow row)
        {
            Id = row["FN_ID"].Value<int>();
            Key = row["FN_SHORT_NAME"].ToString();
            IsLeaf = row["FN_IS_LEAF"].ToString() == "1";
        }

        public string Key { get; private set; }

        public bool IsLeaf { get; private set; }

        public int Id { get; private set; }

        public void AddSubFunctions(IEnumerable<DataRow> rows)
        {
            fSubFunction = new HashSet<string>();
            foreach (DataRow row in rows)
                fSubFunction.Add(row["SF_NAME_ID"].ToString());
        }

        public bool IsSubFunction(string subKey)
        {
            if (!IsLeaf)
                return false;
            if (fSubFunction == null)
                return false;
            return fSubFunction.Contains(subKey);
        }

        public IEnumerable<string> SubFunctions
        {
            get
            {
                return fSubFunction;
            }
        }
    }
}
