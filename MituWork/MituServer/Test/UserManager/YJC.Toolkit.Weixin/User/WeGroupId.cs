using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.User
{
    class WeGroupId : WeixinResult
    {
        [SimpleElement(LocalName = "groupid")]
        public int GroupId { get; private set; }
    }
}
