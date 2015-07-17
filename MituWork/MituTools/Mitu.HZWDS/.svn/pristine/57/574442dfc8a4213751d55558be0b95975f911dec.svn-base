using System.Xml.Linq;
using YJC.Toolkit.Data;
using YJC.Toolkit.MetaData;

namespace Cxcs.Data
{
    [Resolver(Author = "YJC", CreateDate = "2014-07-07",
        Description = "财税文档(CS_DOCUMENT)的数据访问层类")]
    class TaxDocumentResolver : Tk5TableResolver
    {
        internal const string DATAXML = "CXCS/Document.xml";

        public TaxDocumentResolver(IDbDataSource source)
            : base(DATAXML, source)
        {
            AutoTrackField = true;
            AutoUpdateKey = true;
        }

        protected override void OnUpdatingRow(UpdatingEventArgs e)
        {
            base.OnUpdatingRow(e);

            switch (e.Status)
            {
                case UpdateKind.Insert:
                    e.Row["SortId"] = 0;
                    e.Row["PrevContent"] = GetPreviewData(e.Row["Content"].ToString());
                    e.Row["MassFlag"] = 0;
                    break;
                case UpdateKind.Update:
                    e.Row["PrevContent"] = GetPreviewData(e.Row["Content"].ToString());
                    break;
                case UpdateKind.Delete:
                    break;
            }
        }

        private static string GetPreviewData(string content)
        {
            if (string.IsNullOrEmpty(content))
                return string.Empty;

            try
            {
                XDocument doc = XDocument.Parse("<text>" + content + "</text>");
                string text = doc.Element("text").Value.Trim();
                if (text.Length > TaxConst.MAX_PREVIEW_LEN)
                    return text.Substring(0, TaxConst.MAX_PREVIEW_LEN);
                return text;
            }
            catch
            {
                return string.Empty;
            }
        }

        protected override void SetListSearches()
        {
            base.SetListSearches();

            IFieldInfo title = GetFieldInfo("Title");
            ListSearches.Add(title, new TwoFieldListSearch(title, GetFieldInfo("KeyWord")));
        }
    }
}
