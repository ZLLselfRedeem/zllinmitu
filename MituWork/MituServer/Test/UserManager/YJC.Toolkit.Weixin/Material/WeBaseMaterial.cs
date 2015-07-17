using System.Collections.Generic;
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
            var result = WeUtil.PostDataToUri(url, request.WriteJson(), new WeMaterialPageData());
            return result;
        }

        internal static List<WeMediaId> GetAllData(MediaType type)
        {
            List<WeMediaId> listTemp;
            List<WeMediaId> fList = new List<WeMediaId>();

            bool flag = true;
            int pageIndex = 0;
            while (flag)
            {
                listTemp = GetPageData(type, pageIndex, 20).Items;

                if (listTemp == null)
                {
                    flag = false;
                }
                else
                {
                    foreach (var item in listTemp)
                    {
                        if (type == MediaType.News)
                        {
                            WeMaterialItem materialItem = item as WeMaterialItem;
                            if (materialItem != null)
                            {
                                item.Name = materialItem.NewsItem[0].Title;
                            }
                        }
                        fList.Add(item);
                    }

                    if (listTemp.Count != 20)
                    {
                        flag = false;
                    }
                    else
                    {
                        pageIndex += 20;
                    }
                }
            }
            return fList;
        }
    }
}
