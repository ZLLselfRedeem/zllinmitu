using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;

namespace YJC.Toolkit.Weixin.Pay
{
    [EnumCodeTable(Author = "YJC", CreateDate = "2015-04-14", UseIntValue = false,
        Description = "退款渠道")]
    public enum RefundChannel
    {
        [DisplayName("原路退款")]
        Original,
        [DisplayName("退回到余额")]
        Balance
    }
}
