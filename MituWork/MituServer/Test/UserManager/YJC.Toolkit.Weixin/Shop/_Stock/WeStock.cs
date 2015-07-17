using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class WeStock
    {
        public WeStock(WeProductProperty[] skuInfo, int quantity, string productId)
        {
            TkDebug.AssertArgumentNullOrEmpty(productId, "productId", null);
            TkDebug.AssertArgumentNull(skuInfo, "skuInfo", null);

            SkuInfo = new List<WeProductProperty>(skuInfo);
            ProductId = productId;
            Quantity = quantity;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string ProductId { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(SkuTypeConverter))]
        public List<WeProductProperty> SkuInfo { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Camel)]
        public int Quantity { get; private set; }

        public WeixinResult Add()
        {
            string url = WeUtil.GetUrl(WeShopConst.ADD_STOCK_URL);
            var result = WeUtil.PostToUri(url, this.WriteJson(), new WeixinResult());
            return result;
        }

        public WeixinResult Reduce()
        {
            string url = WeUtil.GetUrl(WeShopConst.REDUCE_STOCK_URL);
            var result = WeUtil.PostToUri(url, this.WriteJson(), new WeixinResult());
            return result;
        }
    }
}
