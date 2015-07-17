using System.Collections.Generic;
using System.Data;
using System.Text;
using YJC.Toolkit.Right;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.SimpleRight
{
    class BootstrapMenuBuilder : IMenuScriptBuilder
    {
        private const string HEAD = "<li class=\"dropdown\"><a href=\"#\" class=\"dropdown-toggle\" " +
            "data-toggle=\"dropdown\">{0} <span class=\"caret\"></span></a><ul class=\"dropdown-menu\" role=\"menu\">";
        private const string END = "</ul></li>";
        private const string MENU = "<li><a href=\"#\" data-menu=\"{0}\">{1}</a></li>";

        #region IMenuScriptBuilder 成员

        public string GetMenuScript(DataSet menuDataSet)
        {
            if (menuDataSet == null)
                return string.Empty;
            DataTable table = menuDataSet.Tables["SYS_FUNCTION"];
            if (table == null)
                return string.Empty;

            StringBuilder builder = new StringBuilder();
            var rootRows = GetRows(table, -1);
            foreach (DataRow rootRow in rootRows)
            {
                builder.AppendFormat(HEAD, rootRow["FN_NAME"]);
                var childRows = GetRows(table, rootRow["FN_ID"].Value<int>());
                foreach (DataRow menuRow in childRows)
                {
                    string url = WebUtil.ResolveUrl(menuRow["FN_URL"].ToString());
                    builder.AppendFormat(MENU, url, menuRow["FN_NAME"]);
                }
                builder.AppendFormat(END);
            }
            return builder.ToString();
        }

        #endregion

        private static IEnumerable<DataRow> GetRows(DataTable funcTable, int parentId)
        {
            var result = from row in funcTable.AsEnumerable()
                         where row.Field<int>("FN_PARENT_ID") == parentId
                         select row;
            return result;
        }
    }
}
