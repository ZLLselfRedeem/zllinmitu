using System;
using YJC.Toolkit.Data;

namespace Cxcs.Data
{
    [Resolver(Author = "YJC", CreateDate = "2014-08-07",
        Description = "用户绑定(CS_BINDING)的数据访问层类")]
    class BindingResolver : Tk5TableResolver
    {
        internal const string DATAXML = "CXCS/Binding.xml";

        public BindingResolver(IDbDataSource source)
            : base(DATAXML, source)
        {
        }

        protected override void OnUpdatingRow(UpdatingEventArgs e)
        {
            base.OnUpdatingRow(e);

            switch (e.Status)
            {
                case UpdateKind.Insert:
                    e.Row["BindId"] = CreateUniId();
                    e.Row["CreateDate"] = DateTime.Now;
                    e.Row["CheckFlag"] = 0;
                    break;
                case UpdateKind.Update:
                    break;
                case UpdateKind.Delete:
                    break;
            }
        }
    }
}
