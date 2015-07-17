using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Rule
{
    [ReplyMessageConfig(NamespaceType = NamespaceType.Toolkit, Author = "YJC",
       CreateDate = "2015-01-13", Description = "音乐消息")]
    internal class MusicMessageConfig : IConfigCreator<IRule>, IRule
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
            string fileName = FileUtil.GetRealFileName(ThumbMediaFileName, Position);
            string thumbMediaId;
            var md = WeUtil.UploadFile(Weixin.MediaType.Image, fileName);

            if (WeixinSettings.Current.Mode == WeixinMode.Normal)
                thumbMediaId = WeDataUtil.GetMediaId(Weixin.MediaType.Image, fileName);

            else
                thumbMediaId = WeDataUtil.GetMediaId(message.AgentId, Weixin.MediaType.Image, fileName);

            MusicSendMessage reply = new MusicSendMessage(message, thumbMediaId, Title, Description, MusicUrl, HQMusicUrl);
            return reply;
        }

        #endregion

        [SimpleAttribute]
        public string ThumbMediaFileName { get; private set; }

        [SimpleAttribute(DefaultValue = FilePathPosition.Xml)]
        public FilePathPosition Position { get; private set; }

        [SimpleAttribute]
        public string Title { get; private set; }

        [SimpleAttribute]
        public string Description { get; private set; }

        [SimpleAttribute]
        public string MusicUrl { get; private set; }

        [SimpleAttribute]
        public string HQMusicUrl { get; private set; }
    }
}
