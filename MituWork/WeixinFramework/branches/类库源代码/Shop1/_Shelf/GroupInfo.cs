using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class GroupInfo
    {
        [ObjectElement(Order = 10, NamingRule = NamingRule.Lower)]
        public ShelfControlFilter Filter { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public int GroupId { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public string Img { get; private set; }

        public override string ToString()
        {
            return string.Format(ObjectUtil.SysCulture, "Filter:{0}", Filter, GroupId);
        }
    }
}
