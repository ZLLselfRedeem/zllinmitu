using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class GroupInfo1
    {
        internal GroupInfo1()
        {
        }

        public GroupInfo1(int count, int groupId)
        {
            ShelfControlFilter filter = new ShelfControlFilter(count);
            Filter = filter;
            GroupId = groupId;
        }

        public GroupInfo1(GroupInfo groupInfo)
            : this(groupInfo.Filter.Count, groupInfo.GroupId)
        {
        }

        [ObjectElement(Order = 10, NamingRule = NamingRule.Lower)]
        public ShelfControlFilter Filter { get; protected set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public int GroupId { get; protected set; }

        public override string ToString()
        {
            return string.Format(ObjectUtil.SysCulture, "GroupInfo1:{0}", Filter);
        }
    }
}
