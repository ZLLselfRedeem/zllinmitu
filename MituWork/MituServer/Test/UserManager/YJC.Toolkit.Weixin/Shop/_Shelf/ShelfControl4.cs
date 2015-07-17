using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class ShelfControl4 : WeBaseShelfControl
    {
        internal ShelfControl4()
        {
            EId = 4;
        }

        public ShelfControl4(GroupInfo4 groupInfos)
            : this()
        {
            TkDebug.AssertArgumentNull(groupInfos, "groupInfos", null);

            GroupInfos = groupInfos;
        }

        [ObjectElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public GroupInfo4 GroupInfos { get; private set; }
    }
}
