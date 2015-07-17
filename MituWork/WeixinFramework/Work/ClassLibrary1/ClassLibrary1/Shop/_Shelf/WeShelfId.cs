using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    internal class WeShelfId : WeixinResult
    {
        public WeShelfId()
        {
        }

        public WeShelfId(int shelfId)
        {
            ShelfId = shelfId;
        }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public int ShelfId { get; private set; }

        public override string ToString()
        {
            return string.Format(ObjectUtil.SysCulture, "ShelfId:{0}", ShelfId);
        }
    }
}
