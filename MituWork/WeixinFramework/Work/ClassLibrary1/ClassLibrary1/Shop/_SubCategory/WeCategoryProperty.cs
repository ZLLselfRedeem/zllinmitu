using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class WeCategoryProperty
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.Camel)]
        public string Id { get; protected set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Camel)]
        public string Name { get; protected set; }

        public override string ToString()
        {
            return string.Format(ObjectUtil.SysCulture, "{0}:{1}", Id, Name);
        }
    }
}
