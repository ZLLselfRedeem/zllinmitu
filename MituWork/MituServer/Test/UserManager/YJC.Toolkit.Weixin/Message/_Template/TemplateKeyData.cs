using System.Drawing;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class TemplateKeyData
    {
        [SimpleElement(NamingRule = NamingRule.Camel, Order = 10)]
        public string Value { get; set; }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 20)]
        [TkTypeConverter(typeof(ColorTypeConverter))]
        public Color Color { get; set; }
    }
}
