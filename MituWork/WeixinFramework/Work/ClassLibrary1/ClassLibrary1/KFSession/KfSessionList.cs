using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.KFSession
{
    internal class KfSessionList : WeixinResult
    {
        [ObjectElement(IsMultiple = true, Order = 30, LocalName = "sessionlist",
            UseConstructor = true)]
        public List<KfSession> Sessions { get; private set; }
    }
}