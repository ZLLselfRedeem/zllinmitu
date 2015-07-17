using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin
{
    public sealed class WeixinCryptoException : ToolkitException
    {
        public WeixinCryptoException()
        {
        }

        public WeixinCryptoException(string message, object errorObject)
            : base(message, errorObject)
        {
        }
    }
}
