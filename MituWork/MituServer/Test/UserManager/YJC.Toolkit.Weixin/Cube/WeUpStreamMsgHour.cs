using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Cube
{
    public class WeUpStreamMsgHour : WeUpStreamMsg
    {
        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public int RefHour { get; private set; }
    }
}
