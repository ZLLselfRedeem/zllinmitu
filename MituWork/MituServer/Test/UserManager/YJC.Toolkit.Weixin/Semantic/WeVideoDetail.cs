using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Semantic
{
    public class WeVideoDetail
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public string Name { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Actor { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public string Director { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        public string Category { get; private set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.Lower)]
        public string Tag { get; private set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.Lower)]
        public string Country { get; private set; }

        [ObjectElement(Order = 70, NamingRule = NamingRule.Lower)]
        public WeNumber Season { get; private set; }

        [ObjectElement(Order = 80, NamingRule = NamingRule.Lower)]
        public WeNumber Episode { get; private set; }

        [SimpleElement(Order = 90, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public VideoSort Sort { get; private set; }
    }
}
