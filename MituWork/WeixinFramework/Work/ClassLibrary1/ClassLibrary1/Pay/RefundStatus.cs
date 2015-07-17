using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;

namespace YJC.Toolkit.Weixin.Pay
{
    [EnumCodeTable(Author = "YJC", CreateDate = "2015-04-13", UseIntValue = false,
        Description = "退款状态")]
    public enum RefundStatus
    {
        [DisplayName("退款成功")]
        Success,
        [DisplayName("退款失败")]
        Fail,
        [DisplayName("退款处理中")]
        Procession,
        [DisplayName("未确定")]
        NotSure,
        [DisplayName("转入代发")]
        Change
    }
}
