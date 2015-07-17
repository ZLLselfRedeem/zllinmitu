using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class ShelfControl5 : WeBaseShelfControl
    {
        internal ShelfControl5()
        {
            EId = 5;
        }

        public ShelfControl5(GroupInfo5 groupInfos)
            : this()
        {
            TkDebug.AssertArgumentNull(groupInfos, "groupInfos", null);

            GroupInfos = groupInfos;
        }

        [ObjectElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public GroupInfo5 GroupInfos { get; private set; }

        public override string ToString()
        {
            return string.Format(ObjectUtil.SysCulture, "GroupInfos:{0}", GroupInfos);
        }
    }
}
