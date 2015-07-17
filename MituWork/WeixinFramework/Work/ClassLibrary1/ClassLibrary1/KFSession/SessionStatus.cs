using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;

namespace YJC.Toolkit.Weixin.KFSession
{
    [EnumCodeTable(Author = "YJC", CreateDate = "2015-05-18", UseIntValue = false,
        Description = "会话状态")]
    public enum SessionStatus
    {
        [DisplayName("创建未接入会话")]
        OutSession = 1000,
        [DisplayName("接入会话")]
        InSession = 1001,
        [DisplayName("主动发起会话")]
        CreateSession = 1002,
        [DisplayName("关闭会话")]
        CloseSession = 1004,
        [DisplayName("抢接会话")]
        GetSession = 1005,
        [DisplayName("公众号收到消息")]
        WeReceiveMsg = 2001,
        [DisplayName("客服发送消息")]
        KfSendMsg = 2002,
        [DisplayName("客服收到消息")]
        KfReceiveMsg = 2003
    }
}
