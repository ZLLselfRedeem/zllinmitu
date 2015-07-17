using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.KFSession
{
    internal class WaitSessionList : WeixinResult
    {
        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public int Count { get; private set; }

        [ObjectElement(IsMultiple = true, Order = 40, LocalName = "waitcaselist"
            , UseConstructor = true)]
        public List<KfSession> WaitSessions { get; private set; }
    }
}