using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    internal class WeShelfInfo : WeixinResult
    {
        public static explicit operator WeShelf(WeShelfInfo wf)
        {
            WeShelf ws = new WeShelf(new ShelfControlList(wf.ShelfInfo), wf.ShelfBanner, wf.ShelfName, wf.ShelfId);
            return ws;
        }

        [ObjectElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public WeShelfControlInfos ShelfInfo { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        public string ShelfBanner { get; private set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public string ShelfName { get; private set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        public int ShelfId { get; private set; }

        public override string ToString()
        {
            return string.Format(ObjectUtil.SysCulture, "ShelfName:{0}", ShelfName);
        }
    }
}
