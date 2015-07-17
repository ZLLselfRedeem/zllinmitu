using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    class WeCodeDecrypt
    {
        public WeCodeDecrypt(string encryptcode)
        {
            EncryptCode = encryptcode;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string EncryptCode { get; private set; }
    }
}
