using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;

namespace YJC.Toolkit.Weixin.Shop
{
    [EnumCodeTable(Author = "YJC", CreateDate = "2015-3-26", UseIntValue = false,
       Description = "运费支付方式")]
    public enum AssumeType
    {
        [DisplayName("买家承担运费")]
        Buyer = 0,
        [DisplayName("卖家承担运费")]
        Seller = 1
    }
}
