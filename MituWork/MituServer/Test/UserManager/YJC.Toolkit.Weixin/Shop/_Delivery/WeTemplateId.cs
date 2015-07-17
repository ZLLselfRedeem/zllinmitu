using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    internal class WeTemplateId : WeixinResult
    {
        internal WeTemplateId()
        {
        }

        internal WeTemplateId(long id)
        {
            TemplateId = id;
        }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public long TemplateId { get; private set; }
    }
}
