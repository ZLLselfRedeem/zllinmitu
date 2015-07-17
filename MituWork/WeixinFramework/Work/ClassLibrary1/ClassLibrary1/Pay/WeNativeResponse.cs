using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    public class WeNativeResponse : BasePayResponse
    {
        public WeNativeResponse(WePaymentResponse payResponse)
        {
            TkDebug.AssertArgumentNull(payResponse, "payResponse", null);

            AppId = payResponse.AppId;
            MchId = payResponse.MchId;
            NonceStr = payResponse.NonceStr;
            ReturnCode = payResponse.ReturnCode;
            ReturnMsg = payResponse.ReturnMsg;
            ResultCode = payResponse.ResultCode;
            ErrCodeDes = payResponse.ErrCodeDes;
            ErrCode = payResponse.ErrCode;
            PrepayId = payResponse.PrepayId;

            Sign = WePayUtil.CreateSign(this);
        }

        [SimpleElement(Order = 70, NamingRule = NamingRule.UnderLineLower)]
        public string PrepayId { get; private set; }
    }
}
