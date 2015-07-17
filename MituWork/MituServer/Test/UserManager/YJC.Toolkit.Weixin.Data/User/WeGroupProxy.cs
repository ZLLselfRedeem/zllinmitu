using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.User
{
    [RegType(Author = "YJC", CreateDate = "2014-11-19", RegName = "WeGroup",
        Description = "微信用户组信息")]
    class WeGroupProxy
    {
        [SimpleAttribute]
        public string Id { get; private set; }

        [SimpleAttribute]
        public string Name { get; private set; }
    }
}
