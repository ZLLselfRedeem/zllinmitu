using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    class WeCodeUnavailable
    {
        public WeCodeUnavailable(string code)
        {
            Code = code;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public string Code { get; protected set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public string CardId { get; set; }
    }
}
