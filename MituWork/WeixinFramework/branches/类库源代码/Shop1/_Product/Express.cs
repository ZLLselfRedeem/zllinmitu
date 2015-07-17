using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class Express
    {
        internal Express()
        {
        }

        public Express(ExpressType id, int price)
        {
            Id = id;
            Price = price;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.Camel)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public ExpressType Id { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Camel)]
        public int Price { get; private set; }

        public override string ToString()
        {
            return string.Format(ObjectUtil.SysCulture, "{0}:{1}", Id, Price);
        }
    }
}
