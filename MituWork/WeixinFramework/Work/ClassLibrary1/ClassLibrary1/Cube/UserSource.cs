using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;

namespace YJC.Toolkit.Weixin.Cube
{
    [EnumCodeTable(Author = "YJC", CreateDate = "2015-04-01", UseIntValue = false,
        Description = "用户的渠道")]
    public enum UserSource
    {
        [DisplayName("其他")]
        Others = 0,
        [DisplayName("名片分享")]
        Card = 17,
        [DisplayName("二维码")]
        QrCode = 30,
        [DisplayName("搜号码")]
        Number = 35,
        [DisplayName("查询微信公众账号")]
        Account = 39,
        [DisplayName("图文页右上角菜单")]
        Munu = 43
    }
}
