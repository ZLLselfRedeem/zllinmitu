using System.Collections.Generic;
using System.Linq;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class WeGroup : WeixinResult
    {
        private WeGroup()
        {
            ProductList = new List<string>();
        }

        public WeGroup(string product)
            : this()
        {
            TkDebug.AssertArgumentNullOrEmpty(product, "product", null);
            ProductList.Add(product);
        }

        public WeGroup(params string[] productList)
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
        public List<string> ProductList { get; set; }

        public WeGroupId Insert()
        {
            string url = WeUtil.GetUrl(WeShopConst.ADD_GROUP_URL);
            WeGroupDetail request = new WeGroupDetail(this);
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeGroupId());
            GroupId = result.GroupId;
            return result;
        }

        public WeixinResult Delete()
        {
            string url = WeUtil.GetUrl(WeShopConst.DELETE_GROUP_URL);
            var result = WeUtil.PostToUri(url, this.WriteJson(), new WeixinResult());
            return result;
        }

        public WeixinResult UpdateProperty()
        {
            string url = WeUtil.GetUrl(WeShopConst.UPDATE_GROUP_PROPERTY_URL);
            var result = WeUtil.PostToUri(url, this.WriteJson(), new WeixinResult());
            return result;
        }

        public WeixinResult UpdateProducts(IEnumerable<string> insertProducts, IEnumerable<string> deleteProducts)
        {
            WeGroupProductList request = new WeGroupProductList
            {
                GroupId = GroupId
            };

            if (insertProducts != null)
            {
                var added = from item in insertProducts
                            select new WeGroupProduct(item, ModActionType.Add);
                request.Product.AddRange(added);
            }

            if (deleteProducts != null)
            {
                var deleted = from item in deleteProducts
                              select new WeGroupProduct(item, ModActionType.Remove);
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

        public static IList<WeGroup> Query()
        {
            string url = WeUtil.GetUrl(WeShopConst.ALL_GROUP_URL);
            var result = WeUtil.GetFromUri(url, new WeGroupsList());
            return result.GroupsDetail;
        }

        public static WeGroup Query(int groupId)
        {
            string url = WeUtil.GetUrl(WeShopConst.GROUP_ID_URL);
            WeGroupId request = new WeGroupId(groupId);
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeGroup());
            return result;
        }
    }
}
