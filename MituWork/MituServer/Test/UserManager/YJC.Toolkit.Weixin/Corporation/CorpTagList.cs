using YJC.Toolkit.Cache;
using YJC.Toolkit.Collections;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Corporation
{
    [DayChangeCache]
    internal class CorpTagList : WeixinResult
    {
        [ObjectElement(IsMultiple = true, LocalName = "taglist", Order = 30, UseConstructor = true)]
        public RegNameList<CorpTag> TagList { get; private set; }
    }
}
