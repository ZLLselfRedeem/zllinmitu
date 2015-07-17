using System.Collections;
using System.Collections.Generic;
using YJC.Toolkit.Data;
using YJC.Toolkit.Weixin.Material;

namespace YJC.Toolkit.Weixin.Data
{
    [ObjectSource(Author = "YJC", CreateDate = "2015-06-15",
        Description = "微信公众号视频素材的列表数据源")]
    internal class WeVideoMaterialListObjectSource : BaseWeixinListSource
    {
        // private readonly List<WeVideoMaterial> fList = new List<WeVideoMaterial>();
        private readonly List<WeMediaId> fList = new List<WeMediaId>();

        public WeVideoMaterialListObjectSource()
        {
            fList = WeBaseMaterial.GetAllData(MediaType.Video);
            //foreach (var id in pList)
            //{
            //    fList.Add(id.CreateVideoMaterial());
            //}
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
