using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    internal class WeQrcodeTicket : WeixinResult
    {
        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public string Ticket { get; protected set; }
    }
}
