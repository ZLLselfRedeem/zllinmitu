using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    internal class WePoiId
    {
        internal WePoiId(string poiId)
        {
            PoiId = poiId;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string PoiId { get; private set; }
    }
}
