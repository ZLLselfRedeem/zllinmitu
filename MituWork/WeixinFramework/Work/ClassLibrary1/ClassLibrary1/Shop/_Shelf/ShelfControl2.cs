using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class ShelfControl2 : WeBaseShelfControl
    {
        internal ShelfControl2()
        {
            EId = 2;
        }

        public ShelfControl2(GroupInfo2 groupInfos)
            : this()
        {
            TkDebug.AssertArgumentNull(groupInfos, "groupInfos", null);

            GroupInfos = groupInfos;
        }

        [ObjectElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public GroupInfo2 GroupInfos { get; private set; }
    }
}
