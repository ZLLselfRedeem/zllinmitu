using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class DeliveryInfo
    {
        internal DeliveryInfo()
        {
        }

        private DeliveryInfo(DeliveryType deliverType, long templateId)
        {
            DeliveryType = deliverType;
            TemplateId = templateId;
            Expresses = new List<Express>();
        }

        public DeliveryInfo(DeliveryType deliverType, long templateId, Express express)
            : this(deliverType, templateId)
        {
            TkDebug.AssertArgumentNull(express, "express", null);
            Expresses.Add(express);
        }

        public DeliveryInfo(DeliveryType deliverType, long templateId, Express[] expresses)
            : this(deliverType, templateId)
        {
            TkDebug.AssertArgumentNull(expresses, "expresses", null);
            Expresses.AddRange(expresses);
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public DeliveryType DeliveryType { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public long TemplateId { get; private set; }

        [ObjectElement(IsMultiple = true, Order = 30, LocalName = "express")]
        public List<Express> Expresses { get; private set; }
    }
}
