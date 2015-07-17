using YJC.Toolkit.Collections;
using YJC.Toolkit.Decoder;
using YJC.Toolkit.Weixin.Corporation;

namespace YJC.Toolkit.Weixin.Data
{
    [CodeTable(Author = "YJC", CreateDate = "2014-11-21", Description = "微信企业号标签的代码表")]
    internal sealed class CorpTagCodeTable : RegNameListCodeTable<CorpTag>
    {
        public CorpTagCodeTable()
            : base(CreateList())
        {
        }

        private static RegNameList<CorpTag> CreateList()
        {
            var list = WeDataUtil.GetCacheData<CorpTagList>(WeDataConst.CORP_TAG_NAME);
            return list.TagList;
        }
    }
}
