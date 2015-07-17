using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Corporation
{
    internal class CorpInviteResult : WeixinResult
    {
        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public InviteType Type { get; private set; }
    }
}
