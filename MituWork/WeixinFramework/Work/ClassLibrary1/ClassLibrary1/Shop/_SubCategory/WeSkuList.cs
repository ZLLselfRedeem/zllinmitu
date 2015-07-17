﻿using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class WeSkuList : WeixinResult
    {
        [ObjectElement(IsMultiple = true, Order = 30, NamingRule = NamingRule.UnderLineLower)]
        [NameModel(WeShopConst.LIST_NAME_MODEL, LocalName = "properties")]
        public List<SubSkuTable> SkuTable { get; private set; }

        public static WeSubCategoryList QueryAllSubCategories(string cateId)
        {
            TkDebug.AssertArgumentNullOrEmpty(cateId, "cateId", null);

            string url = WeUtil.GetUrl(WeShopConst.ALL_SUB_CATE_URL);
            WeCategoryId request = new WeCategoryId(cateId);
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeSubCategoryList());
            return result;
        }

        public WeSkuList QueryAllSku(string cateId)
        {
            TkDebug.AssertArgumentNullOrEmpty(cateId, "cateId", this);

            string url = WeUtil.GetUrl(WeShopConst.ALL_SKU_URL);
            WeCategoryId request = new WeCategoryId(cateId);
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeSkuList());
            SkuTable = result.SkuTable;
            return this;
        }

        public WeSkuList QueryAllProperties(string cateId)
        {
            TkDebug.AssertArgumentNullOrEmpty(cateId, "cateId", this);

            string url = WeUtil.GetUrl(WeShopConst.ALL_PROPERTY_URL);
            WeCategoryId request = new WeCategoryId(cateId);
            var result = WeUtil.PostToUri(url, WeShopConst.LIST_NAME_MODEL, request.WriteJson(), new WeSkuList());
            SkuTable = result.SkuTable;
            return this;
        }
    }
}
