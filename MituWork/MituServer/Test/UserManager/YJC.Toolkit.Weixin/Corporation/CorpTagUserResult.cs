using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Corporation
{
    public class CorpTagUserResult : WeixinResult
    {
        [SimpleElement(LocalName = "invalidlist", Order = 30)]
        public string InvalidList { get; private set; }
    }
}
