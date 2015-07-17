using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.User;

namespace YJC.Toolkit.Weixin.Corporation
{
    class CorpAuthStateConfig : AuthStateConfig
    {
        [SimpleAttribute]
        public int AppId { get; protected set; }
    }
}
