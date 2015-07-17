using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Service
{
    [EnumCodeTable(Author = "YJC", CreateDate = "2015-05-15", UseIntValue = false,
        Description = "会话事件")]
    public enum SessionEvent
    {
        [DisplayName("接入会话")]
        [EnumFieldValue("kf_create_session")]
        KfCreateSession,
        [DisplayName("关闭会话")]
        [EnumFieldValue("kf_close_session")]
        KfCloseSession,
        [DisplayName("转接会话")]
        [EnumFieldValue("kf_switch_session")]
        KfSwitchSession
    }
}
