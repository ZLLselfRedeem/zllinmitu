using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Corporation
{
    [RegType(Author = "YJC", CreateDate = "2014-11-19", RegName = "CorpTag",
        Description = "微信企业号的标签信息")]
    class CorpTagProxy
    {
        [SimpleAttribute]
        public string Id { get; private set; }

        [SimpleAttribute]
        public string Name { get; private set; }
    }
}
