using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    internal class WeTemplateInfo : WeixinResult
    {
        [ObjectElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public WeDeliveryTemplate TemplateInfo { get; private set; }
    }
}

