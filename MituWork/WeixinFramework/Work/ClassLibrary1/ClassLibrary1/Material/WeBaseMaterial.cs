using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Material
{
    public abstract class WeBaseMaterial
    {
        protected WeBaseMaterial()
        {
        }

        public abstract WeMediaId Add();

        internal static WeMaterialCount Count()
        {
            string url = WeUtil.GetUrl(WeMaterialConst.GET_MATERIAL_COUNT);
            var result = WeUtil.GetFromUri<WeMaterialCount>(url);
            return result;
        }

        internal static WeMaterialPageData GetPageData(MediaType type, int offset, int count)
        {
            string url = WeUtil.GetUrl(WeMaterialConst.BATCH_GET_MATERIAL);
            WeMaterialQueryCondition request = new WeMaterialQueryCondition(type, offset, count);
            WeixinResult res = WeUtil.PostDataToUri(url, request.WriteJson(), new WeixinResult());
            var result = WeUtil.PostDataToUri(url, request.WriteJson(), new WeMaterialPageData());
            return result;
        }
    }
}
