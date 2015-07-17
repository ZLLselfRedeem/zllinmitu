using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    [TypeScheme(Author = "YJC", CreateDate = "2015-06-02", Description = "微信图文素材信息")]
    [RegType(Author = "YJC", CreateDate = "2015-06-02", Description = "微信图文素材信息")]
    public class MpNewsArticle
    {
        internal MpNewsArticle()
        {
        }

        public MpNewsArticle(string title, string thumbMediaId, string content)
        {
            TkDebug.AssertArgumentNullOrEmpty(title, "title", null);
            TkDebug.AssertArgumentNullOrEmpty(thumbMediaId, "thumbMediaId", null);
            TkDebug.AssertArgumentNull(content, "content", null);

            Title = title;
            ThumbMediaId = thumbMediaId;
            Content = content;
        }

        [FieldInfo(Length = 255, IsEmpty = false)]
        [FieldControl(ControlType.Text, Order = 20)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("图文消息封面图片ID")]
        [SimpleElement(LocalName = "thumb_media_id", Order = 10)]
        public string ThumbMediaId { get; private set; }


        [FieldInfo(Length = 255, IsEmpty = false)]
        [FieldControl(ControlType.Text, Order = 30)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("作者")]
        [SimpleElement(NamingRule = NamingRule.Camel, Order = 20)]
        public string Author { get; set; }

        [FieldInfo(Length = 255, IsEmpty = false)]
        [FieldControl(ControlType.Text, Order = 10)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("标题")]
        [SimpleElement(NamingRule = NamingRule.Camel, Order = 25)]
        public string Title { get; private set; }

        [FieldInfo(Length = 255, IsEmpty = false)]
        [FieldControl(ControlType.Text, Order = 70)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("原文地址")]
        [SimpleElement(LocalName = "content_source_url", Order = 30)]
        public string ContentSourceUrl { get; set; }

        [FieldInfo(Length = 255, IsEmpty = false)]
        [FieldControl(ControlType.Text, Order = 60)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("具体内容")]
        [SimpleElement(NamingRule = NamingRule.Camel, Order = 40)]
        public string Content { get; private set; }

        [FieldInfo(Length = 255)]
        [FieldControl(ControlType.Text, Order = 40)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("摘要")]
        [SimpleElement(NamingRule = NamingRule.Camel, Order = 50)]
        public string Digest { get; set; }

        [FieldInfo(Length = 255, IsEmpty = false)]
        [FieldControl(ControlType.Text, Order = 50)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("否是显示封面")]
        [SimpleElement(LocalName = "show_cover_pic", Order = 60)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool ShowCoverPic { get; set; }

        [FieldInfo(Length = 255, IsEmpty = false)]
        [FieldControl(ControlType.Hidden, Order = 80)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("图文页URL")]
        [SimpleElement(NamingRule = NamingRule.Lower, Order = 55)]
        public string Url { get; private set; }
        public static MpNewsArticle CreateArticle(string title, string content, string path)
        {
            TkDebug.AssertArgumentNullOrEmpty(path, "path", null);

            MediaId media = WeUtil.UploadFile(MediaType.Image, path);
            return new MpNewsArticle(title, media.Id, content);
        }

        public static MpNewsArticle CreateArticle(string title, string content, int appId, string path)
        {
            TkDebug.AssertArgumentNullOrEmpty(path, "path", null);

            string secret = WeixinSettings.Current.GetCorpSecret(appId);
            MediaId media = WeCorpUtil.UploadFile(secret, MediaType.Image, path);
            return new MpNewsArticle(title, media.Id, content);
        }
    }
}
