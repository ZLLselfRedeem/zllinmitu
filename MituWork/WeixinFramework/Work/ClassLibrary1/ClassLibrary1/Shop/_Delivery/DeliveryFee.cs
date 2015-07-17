using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class DeliveryFee
    {
        internal DeliveryFee()
        {
        }

        private DeliveryFee(ExpressType type, NormalFeeMethod normal)
        {
            Type = type;
            Normal = normal;
            Customs = new List<CustomFeeMethod>();
        }

        public DeliveryFee(ExpressType type, NormalFeeMethod normal, CustomFeeMethod customs)
            : this(type, normal)
        {
            TkDebug.AssertArgumentNull(normal, "normal", null);
            TkDebug.AssertArgumentNull(customs, "customs", null);

            Customs.Add(customs);
        }

        public DeliveryFee(ExpressType type, NormalFeeMethod normal, CustomFeeMethod[] customs)
            : this(type, normal)
        {
            TkDebug.AssertArgumentNull(normal, "normal", null);
            TkDebug.AssertArgumentNull(customs, "customs", null);

            Customs.AddRange(customs);
        }

        [SimpleElement(Order = 10)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public ExpressType Type { get; private set; }

        [ObjectElement(Order = 20, UseConstructor = true)]
        public NormalFeeMethod Normal { get; private set; }

        [ObjectElement(IsMultiple = true, LocalName = "Custom", Order = 30)]
        public List<CustomFeeMethod> Customs { get; private set; }
    }
}
