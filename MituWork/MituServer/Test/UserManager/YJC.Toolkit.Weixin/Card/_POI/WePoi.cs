using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    internal class WePoi : WeixinResult
    {
        public WePoi()
        {
        }

        public WePoi(WePoiBaseInfo baseInfo)
        {
            BaseInfo = baseInfo;
        }

        [TagElement(Order = 10, LocalName = "business")]
        [ObjectElement(NamingRule = NamingRule.UnderLineLower, UseConstructor = true)]
        public WePoiBaseInfo BaseInfo { get; private set; }
    }
}
