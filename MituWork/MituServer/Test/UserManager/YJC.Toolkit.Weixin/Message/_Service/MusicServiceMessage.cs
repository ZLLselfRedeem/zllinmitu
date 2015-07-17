using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class MusicServiceMessage : BaseServiceMessage
    {
        public MusicServiceMessage(string toUser, string thumbMediaId, string title,
            string description, string musicUrl, string hqMusicUrl)
            : base(toUser, MessageType.Music)
        {
            TkDebug.AssertArgumentNullOrEmpty(thumbMediaId, "thumbMediaId", null);

            Music = new MusicServiceMediaType
            {
                ThumbMediaId = thumbMediaId,
                Title = title,
                Description = description,
                MusicUrl = musicUrl,
                HQMusicUrl = hqMusicUrl
            };
        }

        [ObjectElement(NamingRule = NamingRule.Camel, Order = 50)]
        internal MusicServiceMediaType Music { get; private set; }
    }
}
