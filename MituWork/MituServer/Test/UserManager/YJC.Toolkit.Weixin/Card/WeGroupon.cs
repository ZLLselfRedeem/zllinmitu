using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    public class WeGroupon
    {
        public WeGroupon()
        {
        }

        public WeGroupon(WeCardBaseInfo baseInfo, string dealDatail)
        {
            TkDebug.AssertArgumentNull(baseInfo, "baseInfo", null);
            TkDebug.AssertArgumentNullOrEmpty(dealDatail, "dealDatail", null);

            BaseInfo = baseInfo;
            DealDetail = dealDatail;
        }

        [ObjectElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public WeCardBaseInfo BaseInfo { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public string DealDetail { get; private set; }
    }
}
