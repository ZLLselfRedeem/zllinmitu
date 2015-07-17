using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class ShelfControlFilter
    {
        internal ShelfControlFilter()
        {
        }

        public ShelfControlFilter(int count)
        {
            Count = count;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public int Count { get; protected set; }

        public override string ToString()
        {
            return string.Format(ObjectUtil.SysCulture, "Count:{0}", Count);
        }
    }
}
