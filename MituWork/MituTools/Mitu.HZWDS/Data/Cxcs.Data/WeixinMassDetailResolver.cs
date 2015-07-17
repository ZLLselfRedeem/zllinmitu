using System.Data;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;

namespace Cxcs.Data
{
    [Resolver(Author = "YJC", CreateDate = "2014-10-29",
        Description = "群发从表(CS_WEIXIN_MASS_DETAIL)的数据访问层类")]
    class WeixinMassDetailResolver : Tk5TableResolver
    {
        internal const string DATAXML = "CXCS/WeixinMassDetail.xml";

        public WeixinMassDetailResolver(IDbDataSource source)
            : base(DATAXML, source)
        {
            if (EditSource != null)
                EditSource.PreparedPostObject += EditSource_PreparedPostObject;
        }

        private void EditSource_PreparedPostObject(object sender, PreparePostObjectEventArgs e)
        {
            DataSet postDataSet = e.InputData.PostObject.Convert<DataSet>();

            DataTable table = postDataSet.Tables[TableName];
            if (table != null)
            {
                int index = 1;
                foreach (DataRow row in table.Rows)
                    row["OrderNum"] = (index++) * 10;
            }
        }
    }
}
