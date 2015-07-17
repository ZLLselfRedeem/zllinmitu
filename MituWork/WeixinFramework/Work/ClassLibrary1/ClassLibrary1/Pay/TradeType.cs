using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;

namespace YJC.Toolkit.Weixin.Pay
{
    [EnumCodeTable(Author = "YJC", CreateDate = "2015-04-13", UseIntValue = false,
        Description = "交易类型")]
    public enum TradeType
    {
        [DisplayName("JSAPI")]
        JsApi,
        [DisplayName("NATIVE")]
        Native,
        [DisplayName("MICROPAY")]
        MicroPay,
        [DisplayName("APP")]
        App
    }
}
