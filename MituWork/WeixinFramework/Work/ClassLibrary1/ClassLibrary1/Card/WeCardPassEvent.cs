using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    class WeCardPassEvent
    {
        [SimpleElement(Order = 10)]
        public string ToUserName { get; protected set; }

        [SimpleElement(Order = 20)]
        public string FromUserName { get; protected set; }

        [SimpleElement(Order = 30)]
        [TkTypeConverter(typeof(WeixinDateTimeConverter))]
        public DateTime CreateTime { get; protected set; }

        [SimpleElement(Order = 40)]
        public string MsgType { get; protected set; }

        [SimpleElement(Order = 50)]
        [TkTypeConverter(typeof(EnumFieldValueTypeConverter), UseObjectType = true)]
        public CardEvent Event { get; protected set; }

        [SimpleElement(Order = 60)]
        public string CardId { get; protected set; }
    }
}
