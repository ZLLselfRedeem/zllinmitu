using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Rule
{
    [ReplyMessageConfig(NamespaceType = NamespaceType.Toolkit, Author = "YJC",
        CreateDate = "2015-01-13", Description = "视频消息")]
    internal class VideoMessageConfig : IConfigCreator<IRule>, IRule
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
                mediaId = WeDataUtil.GetMediaId(Weixin.MediaType.Video, FileName);
            else
                mediaId = WeDataUtil.GetMediaId(message.AgentId, Weixin.MediaType.Video, FileName);

            VideoSendMessage reply = new VideoSendMessage(message, mediaId, Title, Description);
            return reply;
        }

        #endregion

        [SimpleAttribute]
        public string FileName { get; private set; }

        [SimpleAttribute(DefaultValue = FilePathPosition.Xml)]
        public FilePathPosition Position { get; private set; }

        [SimpleAttribute]
        public string Title { get; private set; }

        [SimpleAttribute]
        public string Description { get; private set; }
    }
}
