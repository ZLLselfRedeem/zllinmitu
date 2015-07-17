using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;

namespace YJC.Toolkit.Weixin.Pay
{
    [EnumCodeTable(Author = "YJC", CreateDate = "2015-04-13", UseIntValue = false,
        Description = "交易状态")]
    public enum TradeState
    {
        [DisplayName("支付成功")]
        Success,
        [DisplayName("转入退款")]
        Refund,
        [DisplayName("未支付")]
        NotPay,
        [DisplayName("已关闭")]
        Closed,
        [DisplayName("已撤销")]
        Revoked,
        [DisplayName("用户支付中")]
        UserPaying,
        [DisplayName("未支付")]
        NoPay,
        [DisplayName("支付失败")]
        PayError
    }
}
