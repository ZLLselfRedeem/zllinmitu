using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;

namespace YJC.Toolkit.Weixin.Shop
{
    [EnumCodeTable(Author = "YJC", CreateDate = "2015-3-26", UseIntValue = false,
        Description = "商品状态")]
    public enum ProductStatus
    {
        [DisplayName("全部")]
        All = 0,
        [DisplayName("上架")]
        On = 1,
        [DisplayName("下架")]
        Down = 2
    }
}
