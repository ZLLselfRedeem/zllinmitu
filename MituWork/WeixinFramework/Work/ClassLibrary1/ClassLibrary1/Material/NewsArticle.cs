using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Material
{
    public class NewsArticle
    {
        internal NewsArticle()
        { }

        public NewsArticle(string title, string content, string mediaId)
        {
            Title = title;
            Content = content;
            ThumbMediaId = mediaId;
        }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 40)]
        public string Author { get; set; }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 60)]
        public string Content { get; private set; }

        [SimpleElement(LocalName = "content_source_url", Order = 80)]
        public string ContentSourceUrl { get; set; }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 50)]
        public string Digest { get; set; }

        [SimpleElement(LocalName = "show_cover_pic", Order = 30), TkTypeConverter(typeof(BoolIntConverter))]
        public bool ShowCoverPic { get; set; }

        [SimpleElement(LocalName = "thumb_media_id", Order = 20)]
        public string ThumbMediaId { get; private set; }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 10)]
        public string Title { get; private set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.Lower)]
        public string Url { get; private set; }
    }
}
