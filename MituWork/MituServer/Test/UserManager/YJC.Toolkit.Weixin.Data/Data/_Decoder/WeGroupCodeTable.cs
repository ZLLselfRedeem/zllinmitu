using YJC.Toolkit.Collections;
using YJC.Toolkit.Decoder;
using YJC.Toolkit.Weixin.User;

namespace YJC.Toolkit.Weixin.Data
{
    [CodeTable(Author = "YJC", CreateDate = "2014-11-21", Description = "微信用户组的代码表")]
    internal sealed class WeGroupCodeTable : RegNameListCodeTable<WeGroup>
    {
        public WeGroupCodeTable()
            : base(CreateList())
        {
        }

        private static RegNameList<WeGroup> CreateList()
        {
            var list = WeDataUtil.GetCacheData<WeGroupCollection>(WeDataConst.WEGROUP_NAME);
            return list.Groups;
        }
    }
}
