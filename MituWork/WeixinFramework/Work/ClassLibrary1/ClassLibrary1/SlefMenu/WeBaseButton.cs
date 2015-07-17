using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Menu
{
    public abstract class WeBaseButton
    {
        protected WeBaseButton()
        {
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public string Name { get; protected set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Url { get; protected set; }

    }
}
