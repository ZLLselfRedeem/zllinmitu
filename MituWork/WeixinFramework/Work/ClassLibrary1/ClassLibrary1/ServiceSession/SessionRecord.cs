using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Service
{
    internal class SessionRecord : WeixinResult
    {
        internal SessionRecord()
        {
        }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public int RetCode { get; private set; }

        [ObjectElement(IsMultiple = true, LocalName = "recordlist", Order = 40,
            UseConstructor = true)]
        public List<RecordInfo> Recoreds { get; private set; }
    }
}
