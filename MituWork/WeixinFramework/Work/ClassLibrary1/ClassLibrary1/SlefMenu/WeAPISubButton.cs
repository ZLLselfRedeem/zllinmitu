using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Menu
{
    public class WeAPISubButton : WeBaseButton
    {
        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(EnumFieldValueTypeConverter), UseObjectType = true)]
        public ButtonType Type { get; protected set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        public string Key { get; protected set; }

    }
}
