using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Data;
using YJC.Toolkit.Right;

namespace Cxcs.Data
{
    [Source(Author = "YJC", CreateDate = "2014/12/18",
        Description = "获取米兔云助手文档库的数据源")]
    internal class ToolsDocumentSource : DbListSource
    {
        internal class ListOperators : IOperatorsConfig, IConfigCreator<IOperateRight>
        {
            private readonly List<OperatorConfig> fOperators;

            public ListOperators()
            {
                var oper = new OperatorConfig("Copy", "复制", OperatorPosition.Row, "AjaxUrl",
                    new MarcoConfigItem(true, false, "~/Library/WebModuleContentPage.tkx?Source=CXCS/CopyDocument&DocId=*DocId*"));
                fOperators = new List<OperatorConfig> { oper };
            }

            #region IOperatorsConfig 成员

            public IEnumerable<OperatorConfig> Operators
            {
                get
                {
                    return fOperators;
                }
            }

            public IConfigCreator<IOperateRight> Right
            {
                get
                {
                    return this;
                }
            }

            #endregion

            #region IConfigCreator<IOperateRight> 成员

            public IOperateRight CreateObject(params object[] args)
            {
                return null;
            }

            #endregion
        }


        public ToolsDocumentSource()
        {
            OrderBy = "ORDER BY DOC_ORGIN_DATE DESC";
            SortQuery = true;
            Context = DbContextUtil.CreateDbContext("Tools");
            MainResolver = new TaxDocumentResolver(this);
            Operators = new ListOperators();

            using (var idSource = new EmptyDbDataSource())
            {
                SqlSelector.Select(idSource.Context, idSource.DataSet, "Document",
                    "SELECT DISTINCT DOC_SOURCE_ID FROM CS_DOCUMENT WHERE DOC_SOURCE_ID IS NOT NULL");
                DataTable table = idSource.DataSet.Tables["Document"];
                if (table == null || table.Rows.Count == 0)
                    FilterSql = new MarcoConfigItem(false, false, "DOC_VERIFY_FLAG > 0");
                else
                {
                    var ids = from row in table.AsEnumerable()
                              select row["DOC_SOURCE_ID"].ToString();
                    string sql = string.Format(ObjectUtil.SysCulture,
                        "DOC_VERIFY_FLAG > 0 AND DOC_DOC_ID NOT IN ({0})", string.Join(",", ids));
                    FilterSql = new MarcoConfigItem(false, false, sql);
                }
            }
        }
    }
}
