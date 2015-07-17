using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    internal class ExpressTemplate
    {
        public ExpressTemplate()
        {
        }

        public ExpressTemplate(WeDeliveryTemplate deliverytemplate)
        {
            DeliveryTemplate = deliverytemplate;
        }

        [SimpleElement(NamingRule = NamingRule.UnderLineLower, Order = 10)]
        public long TemplateId { get; set; }

        [ObjectElement(NamingRule = NamingRule.UnderLineLower, Order = 20)]
        public WeDeliveryTemplate DeliveryTemplate { get; private set; }
    }
}
