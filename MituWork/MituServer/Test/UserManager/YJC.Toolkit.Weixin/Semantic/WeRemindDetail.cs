using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Semantic
{
    public class WeRemindDetail
    {
        [ObjectElement(Order = 10, NamingRule = NamingRule.Lower)]
        public WeDateTime Datetime { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Event { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public RemindType RemindType { get; private set; }
    }
}
