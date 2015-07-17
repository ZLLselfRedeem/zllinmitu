namespace YJC.Toolkit.Weixin.Pay
{
    public class BasePayRequest : BasePayData
    {
        protected BasePayRequest()
        {
            AppId = WeixinSettings.Current.AppId;
            MchId = WeixinSettings.Current.MchId;
            NonceStr = WeUtil.CreateNonceStr();
        }

        public void CreateSign()
        {
            Sign = WePayUtil.CreateSign(this);
        }

        public string ToXml()
        {
            return WeUtil.ToXml(this);
        }
    }
}
