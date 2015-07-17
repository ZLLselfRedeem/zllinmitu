using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    public class WeScenicTicket
    {
        internal WeScenicTicket()
        {
        }

        public WeScenicTicket(WeCardBaseInfo baseInfo)
        {
            TkDebug.AssertArgumentNull(baseInfo, "baseInfo", null);

            BaseInfo = baseInfo;
        }

        [ObjectElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public WeCardBaseInfo BaseInfo { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public string TicketClass { get; set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public string GuideUrl { get; set; }
    }
}
