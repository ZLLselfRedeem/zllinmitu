using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin
{
    public class WeManagerType : WeixinResult
    {
        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public InviteType Type { get; private set; }
    }
}
