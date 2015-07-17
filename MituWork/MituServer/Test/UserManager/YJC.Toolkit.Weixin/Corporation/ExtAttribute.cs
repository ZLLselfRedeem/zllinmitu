using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Corporation
{
    public class ExtAttribute
    {
        protected ExtAttribute()
        {
        }

        public ExtAttribute(string name, string value)
        {
            Name = name;
            Value = value;
        }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 10)]
        public string Name { get; private set; }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 20)]
        public string Value { get; private set; }
    }
}
