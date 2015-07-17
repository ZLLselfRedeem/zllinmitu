using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Corporation
{
    public sealed class CorpDetailUserList : WeixinResult
    {
        internal CorpDetailUserList()
        {
        }

        [ObjectElement(IsMultiple = true, Order = 30, NamingRule = NamingRule.Lower, UseConstructor = true)]
        public List<CorpUser> UserList { get; private set; }
    }
}
