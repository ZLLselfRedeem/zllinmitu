using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    class WeCode : WeixinResult
    {
        internal WeCode()
        {
        }

        public WeCode(string code)
        {
            Code = code;
        }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public string Code { get; private set; }
    }
}
