using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    internal class WeBillDelivery
    {
        internal WeBillDelivery()
        {
        }

        internal WeBillDelivery(string orderId)
        {
            OrderId = orderId;
            NeedDelivery = false;
        }

        internal WeBillDelivery(string orderId, bool isOthers,
            WeDeliveryCompany deliveryCompany, string deliveryTrackNo)
        {
            OrderId = orderId;
            NeedDelivery = true;
            IsOthers = isOthers;
            DeliveryCompany = deliveryCompany;
            DeliveryTrackNo = deliveryTrackNo;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string OrderId { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(EnumFieldValueTypeConverter), UseObjectType = true)]
        public WeDeliveryCompany DeliveryCompany { get; set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public string DeliveryTrackNo { get; set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool NeedDelivery { get; set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool IsOthers { get; set; }

        public override string ToString()
        {
            return string.Format(ObjectUtil.SysCulture, "{0}:{1}", OrderId, DeliveryCompany);
        }
    }
}
