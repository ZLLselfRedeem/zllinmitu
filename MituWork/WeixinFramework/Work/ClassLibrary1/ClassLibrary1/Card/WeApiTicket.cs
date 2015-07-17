using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    internal class WeApiTicket : WeQrcodeTicket
    {
        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        public int ExpiresIn { get; private set; }
    }
}
