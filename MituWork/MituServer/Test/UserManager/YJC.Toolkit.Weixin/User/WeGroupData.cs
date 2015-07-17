using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.User
{
    internal class WeGroupData : WeixinResult
    {
        public WeGroupData(string name)
        {
            Group = new WeGroup { Name = name };
        }

        public WeGroupData(WeGroup group)
        {
            Group = group;
        }

        [ObjectElement(NamingRule = NamingRule.Camel, UseConstructor = true)]
        public WeGroup Group { get; private set; }
    }
}
