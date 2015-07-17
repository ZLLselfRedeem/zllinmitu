using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;

namespace YJC.Toolkit.Weixin.Card
{
    [EnumCodeTable(Author = "YJC", CreateDate = "2015-04-13", UseIntValue = false,
        Description = "使用时间的类型")]
    public enum CardDateType
    {
        [DisplayName("固定日期区间")]
        DateInterval = 1,
        [DisplayName("固定时长")]
        DaySpan = 2
    }
}
