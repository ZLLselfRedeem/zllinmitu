using System.Collections.Generic;
using System.Linq;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class WeMerchantGroup : WeixinResult
    {
        private WeMerchantGroup()
        {
            ProductList = new List<string>();
        }

        public WeMerchantGroup(string product)
            : this()
        {
            TkDebug.AssertArgumentNullOrEmpty(product, "product", null);

            ProductList.Add(product);
        }

        public WeMerchantGroup(params string[] productList)
            : this()
        {
            TkDebug.AssertArgumentNull(productList, "productList", null);

            ProductList.AddRange(productList);
        }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public int GroupId { get; set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        public string GroupName { get; set; }

        [SimpleElement(IsMultiple = true, Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public List<string> ProductList { get; private set; }

        public WeMerchantGroup Insert()
        {
            string url = WeUtil.GetUrl(WeShopConst.ADD_GROUP_URL);
            WeMerchantGroupFetchData request = new WeMerchantGroupFetchData(this);
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeGroupId());
            GroupId = result.GroupId;
            if (result.IsError)
            {
                ErrorCode = result.ErrorCode;
                ErrorMsg = result.ErrorMsg;
            }
            return this;
        }

        public static WeixinResult Delete(int groupId)
        {
            string url = WeUtil.GetUrl(WeShopConst.DELETE_GROUP_URL);
            WeGroupId id = new WeGroupId(groupId);
            var result = WeUtil.PostToUri(url, id.WriteJson(), new WeixinResult());
            return result;
        }

        public WeixinResult Update()
        {
            string url = WeUtil.GetUrl(WeShopConst.UPDATE_GROUP_PROPERTY_URL);
            var result = WeUtil.PostToUri(url, this.WriteJson(), new WeixinResult());
            return result;
        }

        public WeixinResult UpdateProducts(IEnumerable<string> insertProducts, IEnumerable<string> deleteProducts)
        {
            WeGroupProductActionList request = new WeGroupProductActionList
            {
                GroupId = GroupId
            };

            if (insertProducts != null)
            {
                var added = from item in insertProducts
                            select new WeGroupProductAction(item, GroupAction.Add);
                request.Product.AddRange(added);
            }

            if (deleteProducts != null)
            {
                var deleted = from item in deleteProducts
                              select new WeGroupProductAction(item, GroupAction.Remove);
                request.Product.AddRange(deleted);
            }

            string url = WeUtil.GetUrl(WeShopConst.UPDATE_GROUP_PRODUCT_URL);
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeixinResult());
            FetchDetail();
            return result;
        }

        public void FetchDetail()
        {
            var result = Query(GroupId);
            GroupName = result.GroupName;
            ProductList = result.ProductList;
        }

        public static IList<WeMerchantGroup> QueryAllGroups()
        {
            string url = WeUtil.GetUrl(WeShopConst.ALL_GROUP_URL);
            var result = WeUtil.GetFromUri(url, new WeMerchantGroupList());
            return result.GroupsDetail;
        }

        public static WeMerchantGroup Query(int groupId)
        {
            string url = WeUtil.GetUrl(WeShopConst.GROUP_ID_URL);
            WeGroupId request = new WeGroupId(groupId);
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeMerchantGroupFetchData());
            return result.GroupDetail;
        }
    }
}
