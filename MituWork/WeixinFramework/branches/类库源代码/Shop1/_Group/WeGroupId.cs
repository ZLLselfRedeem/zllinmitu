using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class WeGroupId : WeixinResult
    {
        internal WeGroupId()
        {
        }

        public WeGroupId(int groupId)
        {
            GroupId = GroupId;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public int GroupId { get; set; }
    }
}
