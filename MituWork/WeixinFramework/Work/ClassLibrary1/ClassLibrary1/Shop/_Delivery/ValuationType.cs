using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;

namespace YJC.Toolkit.Weixin.Shop
{
    /// <summary>
    /// 目前只支持按件计费，默认为0
    /// </summary>
    [EnumCodeTable(Author = "YJC", CreateDate = "2015-3-26", UseIntValue = false,
        Description = "计费单位")]
    public enum ValuationType
    {
        [DisplayName("按件计费")]
        Quantity = 0,
        [DisplayName("按重量计费")]
        Weight = 1,
        [DisplayName("按体积计费")]
        Volume = 2
    }
}
