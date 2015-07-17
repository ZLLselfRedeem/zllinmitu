using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Material
{
    internal class WeMaterialQueryCondition
    {
        public WeMaterialQueryCondition(MediaType type, int offset, int count)
        {
            Type = type;
            Offset = offset;
            Count = count;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(LowerCaseEnumConverter), UseObjectType = true)]
        public MediaType Type { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public int Offset { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public int Count { get; private set; }
    }
}
