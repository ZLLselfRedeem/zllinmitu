using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Semantic
{
    public class WeNovelDetail
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public string Name { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Author { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public string Category { get; private set; }

        [ObjectElement(Order = 40, NamingRule = NamingRule.Lower)]
        public WeNumber Chapter { get; private set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public NovelSort Sort { get; private set; }
    }
}
