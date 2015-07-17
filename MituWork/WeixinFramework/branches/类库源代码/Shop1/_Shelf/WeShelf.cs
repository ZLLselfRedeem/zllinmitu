using System.Collections.Generic;
using System.Linq;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class WeShelf
    {
        internal WeShelf()
        {
        }

        public WeShelf(ShelfControlList shelfData, string shelfBanner, string shelfName)
        {
            TkDebug.AssertArgumentNull(shelfData, "shelfData", null);
            TkDebug.AssertArgumentNullOrEmpty(shelfBanner, "shelfBanner", null);
            TkDebug.AssertArgumentNullOrEmpty(shelfName, "shelfName", null);

            ShelfData = shelfData;
            ShelfBanner = shelfBanner;
            ShelfName = shelfName;
        }

        public WeShelf(ShelfControlList shelfData, string shelfBanner, string shelfName, int shelfId)
            : this(shelfData, shelfBanner, shelfName)
        {
            ShelfId = shelfId;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public int ShelfId { get; private set; }

        [ObjectElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public ShelfControlList ShelfData { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public string ShelfBanner { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        public string ShelfName { get; private set; }

        public WeShelf Insert()
        {
            string url = WeUtil.GetUrl(WeShopConst.ADD_SHELF_URL);
            var result = WeUtil.PostToUri(url, this.WriteJson(), new WeShelfId());
            ShelfId = result.ShelfId;
            return this;
        }

        public WeixinResult Update()
        {
            string url = WeUtil.GetUrl(WeShopConst.UPDATE_SHELF_URL);
            var reuslt = WeUtil.PostToUri(url, this.WriteJson(), new WeixinResult());
            return reuslt;
        }

        //public WeShelf FetchDetail()
        //{
        //    var result = QueryById(ShelfId);
        //    this.ShelfData = result.ShelfData;
        //    this.ShelfBanner = result.ShelfBanner;
        //    this.ShelfName = result.ShelfName;
        //    return this;
        //}

        public static WeixinResult Delete(int shelfId)
        {
            string url = WeUtil.GetUrl(WeShopConst.DELETE_SHELF_URL);
            WeShelfId request = new WeShelfId(shelfId);
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeixinResult());
            return result;
        }

        public static WeShelf QueryById(int shelfId)
        {
            string url = WeUtil.GetUrl(WeShopConst.SHELF_ID_URL);
            WeShelfId request = new WeShelfId(shelfId);
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeShelfInfo());
            return (WeShelf)result;
        }

        public static IEnumerable<WeShelf> Query()
        {
            string url = WeUtil.GetUrl(WeShopConst.ALL_SHELF_URL);
            var result = WeUtil.GetFromUri(url, new WeShelves());
            var convertResult = from weshelf in result.Shelves
                                select (WeShelf)weshelf;
            return convertResult;
        }
    }
}
