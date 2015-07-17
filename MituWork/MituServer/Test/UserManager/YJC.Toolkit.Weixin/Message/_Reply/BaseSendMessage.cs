using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public abstract class BaseSendMessage : BaseMessage
    {
        protected BaseSendMessage(string toUser, MessageType type)
        {
            TkDebug.AssertArgumentNullOrEmpty(toUser, "toUser", null);

            MsgType = type;
            CreateTime = DateTime.Now;
            ToUserName = toUser;
            FromUserName = WeixinSettings.Current.OpenId;
        }
    }
}
