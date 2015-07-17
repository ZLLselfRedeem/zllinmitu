using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class MusicSendMessage : BaseSendMessage
    {
        public MusicSendMessage(string toUser, string thumbMediaId, string title,
            string description, string musicUrl, string hqMusicUrl)
            : base(toUser, MessageType.Music)
        {
            TkDebug.AssertArgumentNullOrEmpty(thumbMediaId, "thumbMediaId", null);

            Music = new MusicMediaType
            {
                ThumbMediaId = thumbMediaId,
                Title = title,
                Description = description,
                MusicUrl = musicUrl,
                HQMusicUrl = hqMusicUrl
            };
        }

        internal MusicSendMessage(ReceiveMessage message, string thumbMediaId, string title,
            string description, string musicUrl, string hqMusicUrl)
            : this(message.FromUserName, thumbMediaId, title, description, musicUrl, hqMusicUrl)
        {
        }

        [ObjectElement(Order = 50)]
        internal MusicMediaType Music { get; private set; }
    }
}
