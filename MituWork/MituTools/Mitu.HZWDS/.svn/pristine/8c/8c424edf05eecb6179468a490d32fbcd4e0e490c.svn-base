using System.Collections.Generic;
using System.Linq;
using YJC.Toolkit.Right;

namespace Cxcs.Data
{
    [OperateRight(Author = "YJC", CreateDate = "2014-12-15", Description = "设置文档的操作符")]
    class DocumentOperateRight : IOperateRight
    {
        #region IOperateRight 成员

        public IEnumerable<string> GetOperator(OperateRightEventArgs e)
        {
            if (e.Row == null)
                return new string[] { "Insert", "InsertTools" };
            string massFlag = e.Row["MassFlag"].ToString();
            string sourceId = e.Row["SourceId"].ToString();
            string massOper = null;
            switch (massFlag)
            {
                case "0":
                case "2":
                case "":
                    massOper = "SendMass";
                    break;
                case "1":
                    massOper = "ShowMass";
                    break;
                case "4":
                    massOper = "NoMass";
                    break;
            }
            string updateOper = "Update"; // string.IsNullOrEmpty(sourceId) ? "Update" : null;

            var result = from item in new string[] { massOper, updateOper, "Delete" }
                         where !string.IsNullOrEmpty(item)
                         select item;
            return result;
        }

        #endregion
    }
}
