using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    public class WeLuckyMoney
    {
        internal WeLuckyMoney()
        {
        }

        public WeLuckyMoney(WeCardBaseInfo baseInfo)
        {
            TkDebug.AssertArgumentNull(baseInfo, "baseInfo", null);

            BaseInof = baseInfo;
        }

        [ObjectElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public WeCardBaseInfo BaseInof { get; private set; }
    }
}
