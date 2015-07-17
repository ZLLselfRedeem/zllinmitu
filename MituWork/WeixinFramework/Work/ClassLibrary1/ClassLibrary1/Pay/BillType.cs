using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;

namespace YJC.Toolkit.Weixin.Pay
{
    [EnumCodeTable(Author = "YJC", CreateDate = "2015-04-13", UseIntValue = false,
        Description = "账单类型")]
    public enum BillType
    {
        [DisplayName("返回当日所有订单消息")]
        All,
        [DisplayName("返回当日成功支付的订单")]
        Success,
        [DisplayName("返回当日退款订单")]
        Refund
    }
}
