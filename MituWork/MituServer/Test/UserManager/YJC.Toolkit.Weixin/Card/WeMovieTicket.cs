using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    public class WeMovieTicket
    {
        internal WeMovieTicket()
        {
        }

        public WeMovieTicket(WeCardBaseInfo baseInfo)
        {
            TkDebug.AssertArgumentNull(baseInfo, "baseInfo", null);

            BaseInfo = baseInfo;
        }

        [ObjectElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public WeCardBaseInfo BaseInfo { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Detail { get; set; }
    }
}
