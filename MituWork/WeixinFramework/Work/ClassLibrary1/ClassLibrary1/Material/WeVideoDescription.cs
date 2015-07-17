using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Material
{
    internal class WeVideoDescription
    {
        public WeVideoDescription(string title, string introduction)
        {
            Title = title;
            Introduction = introduction;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public string Title { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Introduction { get; private set; }
    }
}
