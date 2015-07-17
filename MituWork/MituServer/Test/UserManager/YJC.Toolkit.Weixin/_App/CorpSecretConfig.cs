using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin
{
    internal class CorpSecretConfig
    {
        [SimpleAttribute]
        public string UserManager { get; private set; }

        [SimpleAttribute]
        public string Menu { get; private set; }
    }
}
