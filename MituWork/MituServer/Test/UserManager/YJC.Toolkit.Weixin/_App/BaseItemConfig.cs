using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin
{
    class BaseItemConfig
    {
        [SimpleAttribute]
        public string Secret { get; protected set; }

        [SimpleAttribute]
        public string Token { get; protected set; }

        [SimpleAttribute]
        public string EncodingAESKey { get; protected set; }

        [ObjectElement(NamespaceType.Toolkit)]
        public WeixinMenuConfigItem Menu { get; protected set; }
    }
}
