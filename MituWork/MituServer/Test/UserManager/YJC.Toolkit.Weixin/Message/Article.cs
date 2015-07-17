using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class Article
    {
        [SimpleElement(Order = 10, UseCData = true)]
        [NameModel(WeConst.JSON_MODE, NamingRule = NamingRule.Camel)]
        public string Title { get; set; }

        [SimpleElement(Order = 20, UseCData = true)]
        [NameModel(WeConst.JSON_MODE, NamingRule = NamingRule.Camel)]
        public string Description { get; set; }

        [SimpleElement(Order = 30, UseCData = true)]
        [NameModel(WeConst.JSON_MODE, NamingRule = NamingRule.Lower)]
        public string PicUrl { get; set; }

        [SimpleElement(Order = 40, UseCData = true)]
        [NameModel(WeConst.JSON_MODE, NamingRule = NamingRule.Camel)]
        public string Url { get; set; }
    }
}
