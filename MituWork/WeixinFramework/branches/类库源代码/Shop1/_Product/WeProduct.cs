using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class WeProduct : WeixinResult
    {
        internal WeProduct()
        {
        }

        private WeProduct(string productId, WeProductBase productBase, DeliveryInfo deliveryInfo,
            ProductStatusType status)
        {
            TkDebug.AssertArgumentNullOrEmpty(productId, "productId", null);
            TkDebug.AssertArgumentNull(ProductBase, "ProductBase", null);
            TkDebug.AssertArgumentNull(deliveryInfo, "deliveryInfo", null);

            ProductId = productId;
            SkuList = new List<SkuListElement>();
            ProductBase = productBase;
            DeliveryInfo = deliveryInfo;
            Status = status;
        }

        public WeProduct(string productId, WeProductBase productBase, SkuListElement sku,
            DeliveryInfo deliveryInfo, ProductStatusType status)
            : this(productId, productBase, deliveryInfo, status)
        {
            TkDebug.AssertArgumentNull(sku, "sku", null);

            SkuList.Add(sku);
        }

        public WeProduct(string productId, WeProductBase productBase, DeliveryInfo deliveryInfo,
            ProductStatusType status, params SkuListElement[] skuList)
            : this(productId, productBase, deliveryInfo, status)
        {
            TkDebug.AssertArgumentNull(skuList, "skuList", null);

            SkuList.AddRange(skuList);
        }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public string ProductId { get; protected set; }

        [ObjectElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        public WeProductBase ProductBase { get; protected set; }

        [ObjectElement(IsMultiple = true, Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public List<SkuListElement> SkuList { get; protected set; }

        [ObjectElement(Order = 60, NamingRule = NamingRule.Camel)]
        public Attrex Attrex { get; set; }

        [ObjectElement(Order = 70, NamingRule = NamingRule.UnderLineLower)]
        public DeliveryInfo DeliveryInfo { get; protected set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.Camel)]
        public ProductStatusType Status { get; protected set; }

        public WeProduct Insert()
        {
            string url = WeUtil.GetUrl(WeShopConst.ADD_PRODUCT_URL);
            var result = WeUtil.PostToUri(url, this.WriteJson(), new WeProductId());
            ProductId = result.ProductId;
            return this;
        }

        public WeixinResult Update()
        {
            string url = WeUtil.GetUrl(WeShopConst.UPDATE_PRODUCT_URL);
            var result = WeUtil.PostToUri(url, this.WriteJson(), new WeixinResult());
            return result;
        }

        public static WeixinResult Delete(string productId)
        {
            TkDebug.AssertArgumentNullOrEmpty(productId, "productId", null);
            string url = WeUtil.GetUrl(WeShopConst.DELETE_PRODUCT_URL);
            WeProductId request = new WeProductId(productId);
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeixinResult());
            return result;
        }

        public static WeProduct QueryById(string productId)
        {
            TkDebug.AssertArgumentNullOrEmpty(productId, "productId", null);
            string url = WeUtil.GetUrl(WeShopConst.QUERY_PRODUCT_URL);
            WeProductId request = new WeProductId(productId);
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeProduct());
            return result;
        }

        public static IEnumerable<WeProduct> QueryByStatus(ProductStatusType status)
        {
            string url = WeUtil.GetUrl(WeShopConst.PRODUCT_STATUS_URL);
            WeProductStatus request = new WeProductStatus(status);
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeProductsInfo());
            return result.ProductsInfo;
        }

        public static WeixinResult ModProductStatus(string productId, ProductStatusType status)
        {
            TkDebug.AssertArgumentNullOrEmpty(productId, "productId", null);
            string url = WeUtil.GetUrl(WeShopConst.PRODUCT_SHELF_URL);
            WeProductModStatus request = new WeProductModStatus(status, productId);
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeixinResult());
            return result;
        }
    }
}
