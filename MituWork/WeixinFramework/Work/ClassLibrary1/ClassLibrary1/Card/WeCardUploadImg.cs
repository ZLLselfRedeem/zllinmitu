using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    class WeCardUploadImg
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public string Buffer { get; private set; }
    }
}
