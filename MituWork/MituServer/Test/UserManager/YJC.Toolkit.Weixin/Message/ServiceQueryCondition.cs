using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class ServiceQueryCondition
    {
        [SimpleElement(LocalName = "starttime", Order = 10)]
        public DateTime StartTime { get; private set; }

        [SimpleElement(LocalName = "endtime", Order = 20)]
        public DateTime EndTime { get; private set; }

        [SimpleElement(LocalName = "openid", Order = 30)]
        public string OpenId { get; private set; }

        [SimpleElement(LocalName = "pagesize", Order = 40)]
        public int PageSize { get; private set; }

        [SimpleElement(LocalName = "pageindex", Order = 50)]
        public int PageIndex { get; set; }
    }
}
