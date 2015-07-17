using System.Data;
using System.Web;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;

namespace Cxcs.Data
{
    [Source(Author = "YJC", CreateDate = "2014-10-30",
        Description = "准备群发内容的数据源")]
    class PrepareMassSource : BaseDbSource
    {
        public override OutputData DoAction(IInputData input)
        {
            using (WeixinMassResolver massResolver = new WeixinMassResolver(this))
            using (TaxDocumentResolver docResolver = new TaxDocumentResolver(this))
            {

                string docId = input.QueryString["DocId"];
                DataRow docRow = docResolver.SelectRowWithKeys(docId);
                string massId = docRow["MassId"].ToString();
                if (string.IsNullOrEmpty(massId))
                {
                    docResolver.SetCommands(AdapterCommand.Update);
                    massId = massResolver.NewRow(docId);
                    docRow.BeginEdit();
                    docRow["MassId"] = massId;
                    docRow["MassFlag"] = 0;
                    docRow.EndEdit();
                    UpdateUtil.UpdateTableResolvers(null, docResolver, massResolver);
                }

                string retUrl = input.QueryString["RetUrl"];
                if (!string.IsNullOrEmpty(retUrl))
                    retUrl = "&RetUrl=" + HttpUtility.UrlEncode(retUrl);
                string url = string.Format("~/Library/WebUpdateXmlPage.tkx?Source=CXCS/WeixinMass&MassId={0}{1}", massId, retUrl);
                return OutputData.Create(url);
            }
        }
    }
}
