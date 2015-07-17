using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Corporation
{
    public class CorpUserList : WeixinResult
    {
        internal CorpUserList()
        {
        }

        [ObjectElement(IsMultiple = true, Order = 30, NamingRule = NamingRule.Lower, UseConstructor = true)]
        public List<CorpSimpleUser> UserList { get; protected set; }
    }
}
