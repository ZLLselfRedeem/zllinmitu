using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class WeProductBase
    {
        internal WeProductBase()
        {
            CategoryIds = new List<string>();
            Properties = new List<ProductProperty>();
            SkuInfos = new List<SkuInfo>();
            Imgs = new List<string>();
            Details = new List<WeProductDetail>();
        }

        private WeProductBase(string name, string mainImg)
        {
            TkDebug.AssertArgumentNullOrEmpty(name, "name", null);
            TkDebug.AssertArgumentNullOrEmpty(mainImg, "mainImg", null);

            Name = name;
            MainImg = mainImg;
            CategoryIds = new List<string>();
            Properties = new List<ProductProperty>();
            SkuInfos = new List<SkuInfo>();
            Imgs = new List<string>();
            Details = new List<WeProductDetail>();
        }

        public WeProductBase(string categoryId, ProductProperty property, string name, SkuInfo skuInfo,
            string mainImg, string img, WeProductDetail detail)
            : this(name, mainImg)
        {
            TkDebug.AssertArgumentNullOrEmpty(categoryId, "categoryId", null);
            TkDebug.AssertArgumentNull(property, "property", null);
            TkDebug.AssertArgumentNull(skuInfo, "skuInfo", null);
            TkDebug.AssertArgumentNullOrEmpty(img, "img", null);
            TkDebug.AssertArgumentNull(detail, "detail", null);

            CategoryIds.Add(categoryId);
            Properties.Add(property);
            SkuInfos.Add(skuInfo);
            Imgs.Add(img);
            Details.Add(detail);
        }

        public WeProductBase(string[] categoryIds, ProductProperty[] propertys, string name, SkuInfo[] skuInfos,
            string mainImg, string[] imgs, WeProductDetail[] details)
            : this(name, mainImg)
        {
            TkDebug.AssertArgumentNull(categoryIds, "categoryIds", null);
            TkDebug.AssertArgumentNull(propertys, "propertys", null);
            TkDebug.AssertArgumentNull(skuInfos, "propertys", null);
            TkDebug.AssertArgumentNull(imgs, "img", null);
            TkDebug.AssertArgumentNull(details, "details", null);

            CategoryIds.AddRange(categoryIds);
            Properties.AddRange(propertys);
            SkuInfos.AddRange(skuInfos);
            Imgs.AddRange(imgs);
            Details.AddRange(details);
        }

        [SimpleElement(IsMultiple = true, Order = 10, LocalName = "category_id")]
        public List<string> CategoryIds { get; private set; }

        [ObjectElement(IsMultiple = true, Order = 20, LocalName = "property")]
        public List<ProductProperty> Properties { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Camel)]
        public string Name { get; private set; }

        [ObjectElement(IsMultiple = true, Order = 40, LocalName = "sku_info")]
        public List<SkuInfo> SkuInfos { get; private set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public string MainImg { get; private set; }

        [SimpleElement(IsMultiple = true, Order = 60, LocalName = "img")]
        public List<string> Imgs { get; private set; }

        [ObjectElement(IsMultiple = true, Order = 70, LocalName = "detail")]
        public List<WeProductDetail> Details { get; private set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.UnderLineLower)]
        public int BuyLimit { get; set; }
    }
}
