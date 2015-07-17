using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    internal class WeCategoryId
    {
        internal WeCategoryId()
        {
        }

        public WeCategoryId(string cateId)
        {
            CateId = cateId;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string CateId { get; private set; }
    }
}
