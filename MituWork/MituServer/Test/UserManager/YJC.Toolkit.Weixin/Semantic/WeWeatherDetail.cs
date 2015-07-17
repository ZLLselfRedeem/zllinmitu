using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Semantic
{
    public class WeWeatherDetail
    {
        [ObjectElement(Order = 10, NamingRule = NamingRule.Lower)]
        public WeLocation Location { get; private set; }

        [ObjectElement(Order = 20, NamingRule = NamingRule.Lower)]
        public WeDateTime DateTime { get; private set; }
    }
}
