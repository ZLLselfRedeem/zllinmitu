using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;

namespace YJC.Toolkit.Weixin.Cube
{
    [EnumCodeTable(Author = "YJC", CreateDate = "2015-04-01", UseIntValue = false,
        Description = "当日发布消息量分布的区间")]
    public enum CountIntervalLevel
    {
        [DisplayName("0")]
        Zero = 0,
        [DisplayName("1-5")]
        BetweenOneAndFive = 1,
        [DisplayName("6-10")]
        BetWeenSixAndTen = 2,
        [DisplayName("10次以上")]
        MoreThanTen = 3
    }
}
