﻿using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class NewsCorpMessage : BaseCorpMessage
    {
        private readonly List<Article> fArticles;

        public NewsCorpMessage()
            : base(MessageType.News)
        {
            fArticles = new List<Article>();
        }

        [TagElement(LocalName = "news", Order = 30)]
        [ObjectElement(IsMultiple = true, LocalName = "articles")]
        internal List<Article> Articles
        {
            get
            {
                return fArticles;
            }
        }

        public void Add(Article article)
        {
            TkDebug.AssertArgumentNull(article, "article", this);

            fArticles.Add(article);
        }

        public override string ToJson()
        {
            return this.WriteJson(WeConst.JSON_MODE, WeConst.WRITE_SETTINGS);
        }
    }
}
