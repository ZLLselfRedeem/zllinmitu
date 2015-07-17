using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin;
using YJC.Toolkit.Weixin.Message;
using YJC.Toolkit.Weixin.User;

namespace Cxcs.Data
{
    [Source(Author = "YJC", CreateDate = "2014-10-30",
        Description = "发送")]
    class SendMassMessageSource : BaseDbSource
    {
        public override OutputData DoAction(IInputData input)
        {
            using (TaxDocumentResolver docResolver = new TaxDocumentResolver(this))
            using (WeixinMassResolver massResolver = new WeixinMassResolver(this))
            using (WeixinMassDetailResolver detailResolver = new WeixinMassDetailResolver(this))
            {
                DataRow row = massResolver.Query(input.QueryString);
                if (row["SendFlag"].Value<int>() == 4) // 已发送的不在发送
                    return OutputData.Create("-2");

                massResolver.SetCommands(AdapterCommand.Update);
                docResolver.SetCommands(AdapterCommand.Update);

                DateTime current = DateTime.Now;
                row.BeginEdit();
                row["SendFlag"] = 4;
                row["SendDate"] = row["UpdateDate"] = current;
                row["SendId"] = row["UpdateId"] = BaseGlobalVariable.UserId;
                row.EndEdit();

                MpNewsMassMessage msg = new MpNewsMassMessage();
                string basePath = Path.Combine(BaseAppSetting.Current.AppPath, @"..\pic\sys\");
                string path = Path.Combine(basePath, "hzwtitle.jpg");
                //MediaId mId = WeUtil.UploadFile(MediaType.Image, path);
                string mediaId = WeDataUtil.GetMediaId(MediaType.Image, path);
                DataRow docRow = UpdateDocRow(docResolver, row, current, 4);
                msg.AddArticle(CreateArticle(docRow, mediaId));

                detailResolver.SelectWithParam(string.Empty, "ORDER BY WMD_ORDER_NUM",
                    "MassId", input.QueryString["MassId"]);
                DataTable childTable = detailResolver.HostTable;
                if (childTable != null)
                {
                    foreach (DataRow childRow in childTable.Rows)
                    {
                        docRow = UpdateDocRow(docResolver, childRow, current, 2);
                        path = Path.Combine(basePath, string.Format("A{0}.jpg", docRow["Catelog"]));
                        mediaId = WeDataUtil.GetMediaId(MediaType.Image, path);
                        msg.AddArticle(CreateArticle(docRow, mediaId));
                    }
                }

                UpdateUtil.UpdateTableResolvers(null, docResolver, massResolver);

                var media_Id = msg.UploadMessage();
                var users = WeFanContainter.GetAllUsers();

                var result = msg.Send(users);
                if (result > 0)
                    return OutputData.Create("0");

                return OutputData.Create("-1");
            }
        }

        private static DataRow UpdateDocRow(TaxDocumentResolver docResolver, DataRow row, DateTime current, int flag)
        {
            DataRow docRow = docResolver.SelectRowWithKeys(row["DocId"]);
            docRow.BeginEdit();
            if (flag == 4)
                docRow["MassFlag"] = flag;
            else
            {
                int oldFlag = docRow["MassFlag"].Value<int>();
                if (oldFlag < flag)
                    docRow["MassFlag"] = flag;
            }
            docRow["MassDate"] = current;
            docRow.EndEdit();
            return docRow;
        }

        private static MpNewsArticle CreateArticle(DataRow docRow, string mediaId)
        {
            MpNewsArticle article = new MpNewsArticle(docRow["Title"].ToString(), mediaId, docRow["Content"].ToString())
            {
                //Author = docRow["OrginOrg"].ToString(),
                Digest = docRow["PrevContent"].ToString(),
                ContentSourceUrl = "http://cxcs.mituyun.com/doc.vp?" + docRow["DocId"],
                ShowCoverPic = false
            };

            return article;
        }
    }
}
