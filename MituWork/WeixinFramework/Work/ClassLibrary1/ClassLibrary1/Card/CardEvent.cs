using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    [EnumCodeTable(Author = "YJC", CreateDate = "2015-03-27", UseIntValue = false,
        Description = "事件类型")]
    public enum CardEvent
    {
        [DisplayName("卡券通过审核")]
        [EnumFieldValue("card_pass_check")]
        CardPassCheck,
        [DisplayName("卡券未通过审核")]
        [EnumFieldValue("card_not_pass_check")]
        CardNotPassCheck,
        [DisplayName("用户领取卡券")]
        [EnumFieldValue("user_get_card")]
        UserGetcard,
        [DisplayName("用户删除卡券")]
        [EnumFieldValue("user_del_card")]
        UserDelCard,
        [DisplayName("用户进入会员卡")]
        [EnumFieldValue("user_view_card")]
        UserViewCard,
        [DisplayName("核销事件")]
        [EnumFieldValue("user_consume_card")]
        UserConsumeCode,
        [DisplayName("门店审核")]
        [EnumFieldValue("poi_check_notify")]
        POIChechNotify
    }
}
