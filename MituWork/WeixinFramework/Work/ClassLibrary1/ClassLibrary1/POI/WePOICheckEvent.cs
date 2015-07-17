using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    public class WePoiCheckEvent
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
        public CardEvent Event { get; private set; }

        [SimpleElement(Order = 60, LocalName = "UniqID")]
        public string UniqId { get; private set; }

        [SimpleElement(Order = 70)]
        public string PoiId { get; private set; }

        [SimpleElement(Order = 80)]
        [TkTypeConverter(typeof(EnumFieldValueTypeConverter), UseObjectType = true)]
        public PoiResult Result { get; private set; }

        [SimpleElement(Order = 90)]
        public string Msg { get; private set; }
    }
}
