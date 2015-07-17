using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    internal class WeGroupProductAction
    {
        internal WeGroupProductAction()
        {
        }

        public WeGroupProductAction(string productId, GroupAction modaction)
        {
            ModAction = modaction;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string ProductId { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public GroupAction ModAction { get; private set; }

        public override string ToString()
        {
            return string.Format(ObjectUtil.SysCulture, "{0}:{1}", ProductId, ModAction);
        }
    }
}
