using System.Collections.Generic;
using System.Data;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Rule
{
    public class DataRowNewsMessage : IRule
    {
        private const int MAX_COUNT = 10;
        private const string TABLE_NAME = "_Weixin";
        private readonly List<Article> fFirstArticles;

        public DataRowNewsMessage(MarcoConfigItem sql, DataRowArticle dataRowArticle, string emptyMessage)
        {
            TkDebug.AssertArgumentNull(sql, "sql", null);
            TkDebug.AssertArgumentNull(dataRowArticle, "dataRowArticle", null);
            TkDebug.AssertArgumentNullOrEmpty(emptyMessage, "emptyMessage", null);

            Sql = sql;
            DataRowArticle = dataRowArticle;
            fFirstArticles = new List<Article>();
            EmptyMessage = emptyMessage;
        }

        internal DataRowNewsMessage(DataRowNewsMessageConfig config)
            : this(config.Sql, config.DataRowArticle, config.EmptyMessage.ToString())
        {
            if (config.Articles != null)
            {
                foreach (var article in config.Articles)
                    AddFirstArticle(article.CreateArticle());
            }
            if (config.FootArticle != null)
                FootArticle = config.FootArticle.CreateArticle();
            ContextName = config.Context;
        }

        #region IReplyMessage 成员

        public BaseSendMessage Reply(ReceiveMessage message)
        {
            TkDbContext context;
            if (string.IsNullOrEmpty(ContextName))
                context = DbContextUtil.CreateDefault();
            else
                context = DbContextUtil.CreateDbContext(ContextName);
            using (EmptyDbDataSource source = new EmptyDbDataSource())
            {
                source.Context = context;
                string sql = Expression.Execute(Sql, source);
                SqlSelector.Select(source.Context, source.DataSet, TABLE_NAME, sql);
                DataTable table = source.DataSet.Tables[TABLE_NAME];
                if (table.Rows.Count == 0)
                {
                    TextSendMessage result = new TextSendMessage(message, EmptyMessage);
                    return result;
                }
                else
                {
                    NewsSendMessage result = new NewsSendMessage(message);
                    int count = 0;
                    if (fFirstArticles.Count > 0)
                    {
                        foreach (var article in fFirstArticles)
                        {
                            result.Add(article);
                            ++count;
                        }
                    }

                    int maxCount = MAX_COUNT;
                    if (FootArticle != null)
                        maxCount--;
                    foreach (DataRow row in table.Rows)
                    {
                        if (++count > maxCount)
                            break;
                        Article article = DataRowArticle.CreateArticle(source, row, message);
                        result.Add(article);
                    }

                    if (FootArticle != null)
                        result.Add(FootArticle);

                    return result;
                }
            }
        }

        #endregion

        public string ContextName { get; set; }

        public string EmptyMessage { get; private set; }

        public MarcoConfigItem Sql { get; private set; }

        public DataRowArticle DataRowArticle { get; private set; }

        public Article FootArticle { get; set; }

        public void AddFirstArticle(Article article)
        {
            if (article != null)
                fFirstArticles.Add(article);
        }
    }
}
