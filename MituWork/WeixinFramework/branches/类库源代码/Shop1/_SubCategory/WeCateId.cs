using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    internal class WeCateId
    {
        internal WeCateId()
        {
        }

        public WeCateId(string cateId)
        {
            CateId = cateId;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string CateId { get; private set; }
    }
}
