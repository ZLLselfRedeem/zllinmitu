using System.Collections;
using System.Collections.Generic;
using YJC.Toolkit.Data;
using YJC.Toolkit.Weixin.Corporation;

namespace YJC.Toolkit.Weixin.Data
{
    [ObjectSource(Author = "YJC", CreateDate = "2014-11-19",
        Description = "微信企业号的标签列表数据源")]
    public sealed class CorpTagListObjectSource : BaseWeixinListSource
    {
        private readonly IList<CorpTag> fTags;

        public CorpTagListObjectSource()
        {
            var tags = WeDataUtil.GetCacheData<CorpTagList>(WeDataConst.CORP_TAG_NAME);
            fTags = tags.TagList;
        }

        protected override int Count
        {
            get
            {
                return fTags == null ? 0 : fTags.Count;
            }
        }

        protected override IEnumerable AllData
        {
            get
            {
                return fTags;
            }
        }
    }
}
