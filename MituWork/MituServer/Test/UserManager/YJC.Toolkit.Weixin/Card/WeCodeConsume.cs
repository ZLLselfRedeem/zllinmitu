using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    internal class WeCodeConsume
    {
        internal WeCodeConsume()
        {
        }

        public WeCodeConsume(string code)
        {
            Code = code;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public string Code { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public string CardId { get; set; }
    }
}
