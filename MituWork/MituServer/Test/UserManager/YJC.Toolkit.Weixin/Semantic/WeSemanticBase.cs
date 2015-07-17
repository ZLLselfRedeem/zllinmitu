using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Semantic
{
    public abstract class WeSemanticBase : WeixinResult
    {
        protected WeSemanticBase()
        {
        }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public string Query { get; protected set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        public string Type { get; protected set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.Lower)]
        public string Answer { get; private set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.Lower)]
        public string Text { get; private set; }
    }
}
