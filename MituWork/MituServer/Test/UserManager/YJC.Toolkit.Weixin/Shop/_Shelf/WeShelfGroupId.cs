using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class WeShelfGroupId
    {
        internal WeShelfGroupId()
        {
        }

        public WeShelfGroupId(int groupId)
        {
            GroupId = groupId;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public int GroupId { get; protected set; }

        public override string ToString()
        {
            return string.Format(ObjectUtil.SysCulture, "GroupId:{0}", GroupId);
        }
    }
}
