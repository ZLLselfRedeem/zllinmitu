using YJC.Toolkit.Data;
using YJC.Toolkit.MetaData;

namespace YJC.Toolkit.Weixin.Data
{
    internal class CorpAppLogResolver : TableResolver
    {
        public CorpAppLogResolver(IDbDataSource source)
            : base(MetaDataUtil.CreateTableScheme("CorpAppLog.xml"), source)
        {
            AutoUpdateKey = true;
        }

        protected override void OnUpdatingRow(UpdatingEventArgs e)
        {
            base.OnUpdatingRow(e);

            switch (e.Status)
            {
                case UpdateKind.Insert:
                    break;
                case UpdateKind.Update:
                    break;
                case UpdateKind.Delete:
                    break;
            }
        }
    }
}
