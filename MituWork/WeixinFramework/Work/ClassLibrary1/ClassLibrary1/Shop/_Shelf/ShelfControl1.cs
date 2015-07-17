using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class ShelfControl1 : WeBaseShelfControl
    {
        internal ShelfControl1()
        {
            EId = 1;
        }

        public ShelfControl1(GroupInfo1 groupInfo)
            : this()
        {
            TkDebug.AssertArgumentNull(groupInfo, "groupInfo", null);

            GroupInfo = groupInfo;
        }

        [ObjectElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public GroupInfo1 GroupInfo { get; private set; }

        public override string ToString()
        {
            return string.Format(ObjectUtil.SysCulture, "GroupInfo:{0}", GroupInfo);
        }
    }
}
