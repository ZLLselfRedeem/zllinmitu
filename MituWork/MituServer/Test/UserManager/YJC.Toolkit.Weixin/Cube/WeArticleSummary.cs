using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Cube
{
    public class WeArticleSummary : WeUserRead
    {
        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Msgid { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public string Title { get; private set; }
    }
}
