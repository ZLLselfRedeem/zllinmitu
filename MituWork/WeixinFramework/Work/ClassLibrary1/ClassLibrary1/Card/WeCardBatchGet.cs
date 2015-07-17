using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    internal class WeCardBatchGet
    {
        public WeCardBatchGet(int offset, int count)
        {
            Offset = offset;
            Count = count;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public int Offset { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public int Count { get; private set; }
    }
}
