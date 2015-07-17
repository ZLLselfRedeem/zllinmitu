using System;
using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    public class WePoiBaseInfo
    {
        internal WePoiBaseInfo()
        {
        }

        /// <summary>
        /// 构造用于修改门店的BaseInfo
        /// </summary>
        internal WePoiBaseInfo(string poiId, string telephone, List<WePhotoUrl> phList,
            string recommend, string special, string introduction, TimeSpan? beg, TimeSpan? end, int? avgPrice)
        {
            PoiId = poiId;
            Telephone = telephone;
            PhotoList = phList;
            Recommend = recommend;
            Special = special;
            Introduction = introduction;
            AvgPrice = avgPrice;

            if (beg != null && end != null)
            {

                OpenTime = ((TimeSpan)beg).ToString("hh\\:mm") + "-" + ((TimeSpan)end).ToString("hh\\:mm");
            }
            else
            {
                OpenTime = null;
            }
        }

        /// <summary>
        /// 创建门店的构造函数
        /// </summary>
        public WePoiBaseInfo(string bName, string prov, string city, string addr, string tel,
            List<string> cate, OffsetType offset, double lgt, double lat, List<WePhotoUrl> phList,
            string special, TimeSpan beg, TimeSpan end)
        {
            TkDebug.AssertArgumentNullOrEmpty(bName, "bName", null);
            TkDebug.AssertArgumentNullOrEmpty(prov, "prov", null);
            TkDebug.AssertArgumentNullOrEmpty(city, "city", null);
            TkDebug.AssertArgumentNullOrEmpty(addr, "addr", null);
            TkDebug.AssertArgumentNullOrEmpty(tel, "tel", null);
            TkDebug.AssertArgumentNull(cate, "cate", null);
            TkDebug.AssertArgumentNull(phList, "phList", null);
            TkDebug.AssertArgumentNullOrEmpty(special, "special", null);

            BusinessName = bName;
            Province = prov;
            City = city;
            Address = addr;
            Telephone = tel;
            Categories = cate;
            OffsetType = offset;
            Longitude = lgt;
            Latitude = lat;
            PhotoList = phList;
            Special = special;
            OpenTime = beg.ToString("hh\\:mm") + "-" + end.ToString("hh\\:mm");
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public string SId { get; set; }

        [SimpleElement(Order = 15, NamingRule = NamingRule.UnderLineLower)]
        public string PoiId { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public string BusinessName { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public string BranchName { get; set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        public string Province { get; private set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.Lower)]
        public string City { get; private set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.Lower)]
        public string District { get; set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.Lower)]
        public string Address { get; private set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.Lower)]
        public string Telephone { get; private set; }

        [SimpleElement(IsMultiple = true, Order = 90, NamingRule = NamingRule.Lower)]
        public List<string> Categories { get; private set; }

        [SimpleElement(Order = 100, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(OffsetTypeConverter))]
        public OffsetType? OffsetType { get; private set; }

        [SimpleElement(Order = 110, NamingRule = NamingRule.Lower)]
        public double? Longitude { get; private set; }

        [SimpleElement(Order = 120, NamingRule = NamingRule.Lower)]
        public double? Latitude { get; private set; }

        [ObjectElement(IsMultiple = true, Order = 130, NamingRule = NamingRule.UnderLineLower, UseConstructor = true)]
        public List<WePhotoUrl> PhotoList { get; private set; }

        [SimpleElement(Order = 140, NamingRule = NamingRule.Lower)]
        public string Recommend { get; set; }

        [SimpleElement(Order = 150, NamingRule = NamingRule.Lower)]
        public string Special { get; private set; }

        [SimpleElement(Order = 160, NamingRule = NamingRule.Lower)]
        public string Introduction { get; set; }

        [SimpleElement(Order = 170, NamingRule = NamingRule.UnderLineLower)]
        public string OpenTime { get; private set; }

        [SimpleElement(Order = 180, NamingRule = NamingRule.UnderLineLower)]
        public int? AvgPrice { get; set; }

        [SimpleElement(Order = 190, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(AvailableStateConverter))]
        public AvailableState? AvailableState { get; private set; }

        [SimpleElement(Order = 200, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(UpdateStatusConverter))]
        public UpdateStatus? UpdateStatus { get; private set; }

        public WeixinResult Add()
        {
            string url = WeUtil.GetUrl(WeCardConst.ADD_POI);
            WePoi poi = new WePoi(this);
            return WeUtil.PostDataToUri(url, poi.WriteJson(), new WeixinResult());
        }

        public static WePoiBaseInfo Query(string poiId)
        {
            TkDebug.AssertArgumentNullOrEmpty(poiId, "poiId", null);

            string url = WeUtil.GetUrl(WeCardConst.GET_POI);
            WePoiId id = new WePoiId(poiId);
            return WeUtil.PostDataToUri(url, id.WriteJson(), new WePoi()).BaseInfo;
        }

        public static IEnumerable<WePoiBaseInfo> PoiListQuery(int beg, int limit)
        {
            string url = WeUtil.GetUrl(WeCardConst.GET_POI_LIST);
            WePoiQuery query = new WePoiQuery(beg, limit);
            var result = WeUtil.PostDataToUri(url, query.WriteJson(), new WePoiInfoList());
            List<WePoiBaseInfo> poiList = new List<WePoiBaseInfo>();
            foreach (var re in result.BusinessList)
            {
                poiList.Add(re.BaseInfo);
            }
            return poiList;
        }

        public static WeixinResult Delete(string poiId)
        {
            TkDebug.AssertArgumentNullOrEmpty(poiId, "poiId", null);

            string url = WeUtil.GetUrl(WeCardConst.DEL_POI);
            WePoiId id = new WePoiId(poiId);
            return WeUtil.PostDataToUri(url, id.WriteJson(), new WeixinResult());
        }

        /// <summary>
        /// 门店的服务信息只能修改传入参数的七个字段信息。
        /// 若字段填写内容，则为覆盖更新，若无内容则视为不修改，维持原有内容
        /// </summary>
        /// 通过方法的传入参数来控制可更新字段。
        public static WeixinResult Update(string poiId, string telephone, List<WePhotoUrl> phList,
            string special, string recommend, string introduction, TimeSpan? beg, TimeSpan? end, int? avgPrice)
        {
            TkDebug.AssertArgumentNullOrEmpty(poiId, "poiId", null);

            string url = WeUtil.GetUrl(WeCardConst.UPDATE_POI);
            WePoiBaseInfo updateInfo = new WePoiBaseInfo(poiId, telephone, phList, recommend, special,
                introduction, beg, end, avgPrice);
            WePoi poi = new WePoi(updateInfo);
            return WeUtil.PostDataToUri(url, poi.WriteJson(), new WeixinResult());
        }
    }
}
