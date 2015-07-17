using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    internal class WeGroupDetail
    {
        internal WeGroupDetail()
        {
        }

        public WeGroupDetail(WeGroup groupDetail)
        {
            GroupDetail = groupDetail;
        }

        [ObjectElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public WeGroup GroupDetail { get; private set; }
    }
}
