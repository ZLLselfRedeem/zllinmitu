using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class Location
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.Camel)]
        public string Country { get; set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Camel)]
        public string Province { get; set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Camel)]
        public string City { get; set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Camel)]
        public string Address { get; set; }

        public override string ToString()
        {
            return string.Format(ObjectUtil.SysCulture, "Location:{0},{1}", Country, Province);
        }
    }
}
