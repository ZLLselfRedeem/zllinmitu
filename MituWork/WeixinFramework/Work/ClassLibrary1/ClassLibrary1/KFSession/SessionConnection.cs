using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.KFSession
{
    /// <summary>
    /// Create and close session
    /// </summary>
    public class SessionConnection
    {
        [SimpleElement(Order = 10)]
        public string ToUserName { get; private set; }

        [SimpleElement(Order = 20)]
        public string FromUserName { get; private set; }

        [SimpleElement(Order = 30)]
        [TkTypeConverter(typeof(WeixinDateTimeConverter))]
        public DateTime CreateTime { get; private set; }

        [SimpleElement(Order = 40)]
        public string MsgType { get; private set; }

        [SimpleElement(Order = 50)]
        [TkTypeConverter(typeof(EnumFieldValueTypeConverter), UseObjectType = true)]
        public SessionEvent Event { get; private set; }

        [SimpleElement(Order = 60)]
        public string KfAccount { get; private set; }
    }
}
