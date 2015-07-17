using System.Collections;
using System.Collections.Generic;
using YJC.Toolkit.Data;
using YJC.Toolkit.Weixin.User;

namespace YJC.Toolkit.Weixin.Data
{
    [ObjectSource(Author = "YJC", CreateDate = "2014-11-19",
        Description = "微信公众号用户组的列表数据源")]
    public sealed class WeGroupListObjectSource : BaseWeixinListSource
    {
        private readonly IList<WeGroup> fGroups;

        public WeGroupListObjectSource()
        {
            var groups = WeDataUtil.GetCacheData<WeGroupCollection>(WeDataConst.WEGROUP_NAME);
            fGroups = groups.Groups;
        }

        protected override int Count
        {
            get
            {
                return fGroups.Count;
            }
        }

        protected override IEnumerable AllData
        {
            get
            {
                return fGroups;
            }
        }
    }
}
