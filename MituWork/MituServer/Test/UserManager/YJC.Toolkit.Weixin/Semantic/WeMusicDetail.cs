using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Semantic
{
    public class WeMusicDetail
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public string Song { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Singer { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public string Album { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        public string Category { get; private set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.Lower)]
        public string Language { get; private set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.Lower)]
        public string Movie { get; private set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.Lower)]
        public string Tv { get; private set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.Lower)]
        public string Show { get; private set; }

        [SimpleElement(Order = 90, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public MusicSort Sort { get; private set; }
    }
}
