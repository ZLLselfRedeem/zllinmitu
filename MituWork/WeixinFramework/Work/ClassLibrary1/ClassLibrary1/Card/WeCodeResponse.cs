using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    public class WeCodeResponse : WeixinResult
    {
        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public string OpenId { get; private set; }

        [ObjectElement(Order = 40, NamingRule = NamingRule.Lower)]
        public WeCardvalidityTime Card { get; private set; }
    }
}
