using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Rule
{
    [ReplyMessageConfig(NamespaceType = NamespaceType.Toolkit, Author = "YJC",
        CreateDate = "2015-01-13", Description = "语音消息")]
    internal class VoiceMessageConfig : IConfigCreator<IRule>, IRule
    {
        #region IConfigCreator<IRule> 成员

        public IRule CreateObject(params object[] args)
        {
            return this;
        }

        #endregion

        #region IRule 成员

        public BaseSendMessage Reply(ReceiveMessage message)
        {
            string fileName = FileUtil.GetRealFileName(FileName, Position);

            string mediaId;
            if (WeixinSettings.Current.Mode == WeixinMode.Normal)
                mediaId = WeDataUtil.GetMediaId(Weixin.MediaType.Voice, fileName);
            else
                mediaId = WeDataUtil.GetMediaId(message.AgentId, Weixin.MediaType.Voice, fileName);

            VoiceSendMessage reply = new VoiceSendMessage(message, mediaId);
            return reply;
        }

        #endregion

        [SimpleAttribute]
        public string FileName { get; private set; }

        [SimpleAttribute(DefaultValue = FilePathPosition.Xml)]
        public FilePathPosition Position { get; private set; }
    }
}
