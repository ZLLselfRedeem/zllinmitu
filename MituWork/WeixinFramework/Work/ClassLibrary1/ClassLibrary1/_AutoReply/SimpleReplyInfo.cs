using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Menu;

namespace YJC.Toolkit.Weixin.Message
{
    public class SimpleReplyInfo
    {
        internal SimpleReplyInfo()
        {
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(EnumFieldValueTypeConverter), UseObjectType = true)]
        public ButtonType Type { get; protected set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Content { get; protected set; }
    }
}
