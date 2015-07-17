using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Service
{
    internal class ServiceSessionList : WeixinResult
    {
        [ObjectElement(IsMultiple = true, Order = 30, LocalName = "sessionlist",
            UseConstructor = true)]
        public List<ServiceSession> Sessions { get; private set; }
    }
}