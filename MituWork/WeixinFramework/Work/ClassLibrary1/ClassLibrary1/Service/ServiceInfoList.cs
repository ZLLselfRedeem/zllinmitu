using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Service
{
    internal class ServiceInfoList : WeixinResult
    {
        [ObjectElement(IsMultiple = true, Order = 30, LocalName = "kf_online_list",
            UseConstructor = true)]
        public List<ServiceInfo> ServiceInfos { get; private set; }
    }
}
