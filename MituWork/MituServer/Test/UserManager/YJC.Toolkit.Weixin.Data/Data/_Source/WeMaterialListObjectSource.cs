using System.Collections;
using System.Collections.Generic;
using YJC.Toolkit.Data;
using YJC.Toolkit.Weixin.Material;

namespace YJC.Toolkit.Weixin.Data
{
    [ObjectSource(Author = "YJC", CreateDate = "2015-06-02",
        Description = "微信公众号素材的列表数据源")]
    internal class WeMaterialListObjectSource : BaseWeixinListSource
    {
        private readonly List<WeMediaId> fList = new List<WeMediaId>();

        public WeMaterialListObjectSource()
        {
            // List<WeMediaId> listTemp;
            for (int i = 0; i < 2; i++)
            {
                foreach (var item in WeBaseMaterial.GetAllData((MediaType)i))
                {
                    fList.Add(item);
                }
            }
        }
        protected override int Count
        {
            get
            {
                return fList.Count;
            }
        }

        protected override IEnumerable AllData
        {
            get
            {
                return fList;
            }
        }
    }
}
