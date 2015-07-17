using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;

namespace YJC.Toolkit.Weixin.Card
{
    [EnumCodeTable(Author = "YJC", CreateDate = "2015-03-27", UseIntValue = false,
           Description = "卡券状态")]
    public enum CardStatus
    {
        [DisplayName("待审核")]
        CardStatusNotVerify,
        [DisplayName("审核失败")]
        CardStatusVerifyFall,
        [DisplayName("通过审核")]
        CardStatusVerifyOk,
        [DisplayName("卡券被用户删除")]
        CardStatusUserDelete,
        [DisplayName("在公众平台投放过的卡券")]
        CardStatusUserDispatch
    }
}
