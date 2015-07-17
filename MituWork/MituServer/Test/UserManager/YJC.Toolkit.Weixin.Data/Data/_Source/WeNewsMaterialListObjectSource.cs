using System.Collections;
using System.Collections.Generic;
using YJC.Toolkit.Data;
using YJC.Toolkit.Weixin.Material;

namespace YJC.Toolkit.Weixin.Data
{
    [ObjectSource(Author = "YJC", CreateDate = "2015-06-03",
        Description = "微信公众号图文素材的列表数据源")]
    internal class WeNewsMaterialListObjectSource : BaseWeixinListSource
    {
        private readonly List<WeMediaId> fList = new List<WeMediaId>();

        public WeNewsMaterialListObjectSource()
        {
            fList = WeBaseMaterial.GetAllData(MediaType.News);
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
