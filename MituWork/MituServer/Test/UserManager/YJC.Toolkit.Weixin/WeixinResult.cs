using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin
{
    public class WeixinResult
    {
        [SimpleElement(LocalName = "errcode", Order = 10)]
        public int ErrorCode { get; protected set; }

        [SimpleElement(LocalName = "errmsg", Order = 20)]
        public string ErrorMsg { get; protected set; }

        public bool IsError
        {
            get
            {
                return ErrorCode > 0;
            }
        }

        public void Assign(WeixinResult other)
        {
            if (other == null)
                return;

            ErrorCode = other.ErrorCode;
            ErrorMsg = other.ErrorMsg;
        }

        public override string ToString()
        {
            return ErrorCode == 0 ? ErrorMsg :
                string.Format(ObjectUtil.SysCulture, "{0}:{1}", ErrorCode, ErrorMsg);
        }
    }
}
