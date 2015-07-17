using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    [EnumCodeTable(Author = "YJC", CreateDate = "2015-03-27", UseIntValue = false,
        Description = "卡券类型")]

    public enum CardType
    {
        [DisplayName("通用券")]
        [EnumFieldValue("GENERAL_COUPON")]
        GeneralCoupon,
        [DisplayName("团购券")]
        [EnumFieldValue("GROUPON")]
        GroupOn,
        [DisplayName("折扣券")]
        [EnumFieldValue("DISCOUNT")]
        Discount,
        [DisplayName("礼品券")]
        [EnumFieldValue("GIFT")]
        Gift,
        [DisplayName("代金券")]
        [EnumFieldValue("CASH")]
        Cash,
        [DisplayName("会员卡")]
        [EnumFieldValue("MEMBER_CARD;")]
        MemberCard,
        [DisplayName("景点门票")]
        [EnumFieldValue("SCENIC_TICKET")]
        ScenicTicket,
        [DisplayName("电影票")]
        [EnumFieldValue("MOVIE_TICKET")]
        MovieTicket,
        [DisplayName("飞机票")]
        [EnumFieldValue("BOARDING_PASS")]
        BoardingPass,
        [DisplayName("红包")]
        [EnumFieldValue("LUCKY_MONEY")]
        LuckyMoney,
        [DisplayName("会议门票")]
        [EnumFieldValue("MEERING_TICKET")]
        MeeringTicket
    }
}
