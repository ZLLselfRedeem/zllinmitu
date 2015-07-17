using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class ShelfControl3 : WeBaseShelfControl
    {
        internal ShelfControl3()
        {
            EId = 3;
        }

        public ShelfControl3(GroupInfo3 groupInfo)
            : this()
        {
            TkDebug.AssertArgumentNull(groupInfo, "groupInfo", null);

            GroupInfo = groupInfo;
        }

        [ObjectElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public GroupInfo3 GroupInfo { get; private set; }

        public override string ToString()
        {
            return string.Format(ObjectUtil.SysCulture, "GroupInfo:{0}", GroupInfo);
        }
    }
}
