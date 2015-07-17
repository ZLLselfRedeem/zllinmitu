using System.Collections;
using YJC.Toolkit.Collections;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Service;

namespace YJC.Toolkit.Weixin.Data
{
    [ObjectSource(Author = "YJC", CreateDate = "2015-05-19",
        Description = "微信公众号客服的列表数据源")]
    internal class WeServiceAccountListObjectSource : BaseWeixinListSource
    {
        private readonly RegNameList<ServiceAccount> fList;

        public WeServiceAccountListObjectSource()
        {
            fList = ServiceAccount.GetAccountList().Convert<RegNameList<ServiceAccount>>();
        }
        protected override int Count
        {
            get
            {
                return fList.Count;
            }
        }

        protected override IEnumerable AllData
        {
            get
            {
                return fList;
            }
        }
    }
}
