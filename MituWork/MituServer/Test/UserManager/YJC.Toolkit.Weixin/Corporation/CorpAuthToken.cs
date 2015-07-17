using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Corporation
{
    public class CorpAuthToken : WeixinResult
    {
        [SimpleElement(Order = 30)]
        public string UserId { get; private set; }

        [SimpleElement(Order = 40)]
        public string DeviceId { get; private set; }
    }
}
