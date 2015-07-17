
namespace YJC.Toolkit.Weixin.Card
{
    public static class WePoiUtil
    {
        //public static WeixinResult Add(WePoiBaseInfo baseInfo)
        //{
        //    string url = WeUtil.GetUrl(WeCardConst.ADD_POI);
        //    WePoi poi = new WePoi(baseInfo);
        //    return WeUtil.PostDataToUri(url, poi.WriteJson(), new WeixinResult());
        //}

        //public static WePoiBaseInfo Query(string poiId)
        //{
        //    TkDebug.AssertArgumentNullOrEmpty(poiId, "poiId", null);

        //    string url = WeUtil.GetUrl(WeCardConst.GET_POI);
        //    WePoiId id = new WePoiId(poiId);
        //    return WeUtil.PostDataToUri(url, id.WriteJson(), new WePoi()).BaseInfo;
        //}

        //public static IEnumerable<WePoiBaseInfo> PoiListQuery(int beg, int limit)
        //{
        //    string url = WeUtil.GetUrl(WeCardConst.GET_POI_LIST);
        //    WePoiQuery query = new WePoiQuery(beg, limit);
        //    var result = WeUtil.PostDataToUri(url, query.WriteJson(), new WePoiInfoList());
        //    List<WePoiBaseInfo> poiList = new List<WePoiBaseInfo>();
        //    foreach (var re in result.BusinessList)
        //    {
        //        poiList.Add(re.BaseInfo);
        //    }
        //    return poiList;
        //}

        //public static WeixinResult Delete(string poiId)
        //{
        //    TkDebug.AssertArgumentNullOrEmpty(poiId, "poiId", null);

        //    string url = WeUtil.GetUrl(WeCardConst.DEL_POI);
        //    WePoiId id = new WePoiId(poiId);
        //    return WeUtil.PostDataToUri(url, id.WriteJson(), new WeixinResult());
        //}

        ///// <summary>
        ///// 门店的服务信息只能修改传入参数的七个字段信息。
        ///// 若字段填写内容，则为覆盖更新，若无内容则视为不修改，维持原有内容
        ///// </summary>
        ///// 通过方法的传入参数来控制可更新字段。
        //public static WeixinResult Update(string poiId, string telephone, List<WePhotoUrl> phList,
        //    string special, string recommend, string introduction, TimeSpan? beg, TimeSpan? end, int? avgPrice)
        //{
        //    TkDebug.AssertArgumentNullOrEmpty(poiId, "poiId", null);

        //    string url = WeUtil.GetUrl(WeCardConst.UPDATE_POI);
        //    WePoiBaseInfo updateInfo = new WePoiBaseInfo(poiId, telephone, phList, recommend, special,
        //        introduction, beg, end, avgPrice);
        //    WePoi poi = new WePoi(updateInfo);
        //    return WeUtil.PostDataToUri(url, poi.WriteJson(), new WeixinResult());
        //}
    }
}
