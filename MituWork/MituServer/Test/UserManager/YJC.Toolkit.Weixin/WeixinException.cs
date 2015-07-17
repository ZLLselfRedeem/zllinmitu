using YJC.Toolkit.Data;

namespace YJC.Toolkit.Weixin
{
    public class WeixinException : WebPostException
    {
        public WeixinException(WeixinResult weixinResult)
            : base(weixinResult.ToString())
        {
            WeixinResult = weixinResult;
        }

        public WeixinResult WeixinResult { get; private set; }
    }
}
