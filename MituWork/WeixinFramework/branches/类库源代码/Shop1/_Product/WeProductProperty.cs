using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class ProductProperty
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public string Id { get; set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Vid { get; set; }

        public override string ToString()
        {
            return string.Format(ObjectUtil.SysCulture, "{0}:{1}", Id, Vid);
        }
    }
}
