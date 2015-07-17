using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.User
{
    class WeGroupUser
    {
        [SimpleElement(LocalName = "openid", Order = 10)]
        public string OpenId { get; set; }

        [SimpleElement(LocalName = "to_groupid", Order = 20)]
        public int GroupId { get; set; }
    }
}
