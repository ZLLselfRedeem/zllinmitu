using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    internal class GroupInfos : GroupInfo4
    {
        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public string ImgBackground { get; private set; }

        public override string ToString()
        {
            return string.Format(ObjectUtil.SysCulture, "GroupInfos ImgBackground:{0}", ImgBackground);
        }
    }
}
