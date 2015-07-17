using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    internal class AllShelfControlInfo : WeBaseShelfControl
    {
        [ObjectElement(NamingRule = NamingRule.UnderLineLower)]
        public GroupInfo GroupInfo { get; private set; }

        [ObjectElement(NamingRule = NamingRule.UnderLineLower)]
        public GroupInfos GroupInfos { get; private set; }

        public WeBaseShelfControl ConvertToShelf()
        {
            switch (EId)
            {
                case 1:
                    return new ShelfControl1(new GroupInfo1(GroupInfo));
                case 2:
                    return new ShelfControl2(new GroupInfo2(GroupInfos == null ? null : GroupInfos.Groups));
                case 3:
                    return new ShelfControl3(new GroupInfo3(GroupInfo));
                case 4:
                    return new ShelfControl4(new GroupInfo4(GroupInfos));
                case 5:
                    return new ShelfControl5(new GroupInfo5(GroupInfos));
                default:
                    break;
            }
            return null;
        }
    }
}
