using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    class WeCardExt
    {
        internal WeCardExt()
        {
        }

        public WeCardExt(DateTime timestamp, CardType cardType)
        {
            string apiTicket = WeCardInfo.ApiTicketGet(cardType);
            Timestamp = timestamp;
            Signature = "sha1";
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public string Code { get; set; }

        [SimpleElement(Order = 20, LocalName = "openid")]
        public string OpenId { get; set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(WeixinDateTimeConverter))]
        public DateTime Timestamp { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        public string Signature { get; set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public int OuterId { get; set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.Lower)]
        public int Balance { get; set; }
    }
}
