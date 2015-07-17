using System.Data;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Rule
{
    public class DataRowArticle
    {
        [ObjectElement(NamespaceType.Toolkit)]
        public MarcoConfigItem Title { get; private set; }

        [ObjectElement(NamespaceType.Toolkit)]
        public MarcoConfigItem Description { get; private set; }

        [ObjectElement(NamespaceType.Toolkit)]
        public UrlMacroConfig PicUrl { get; private set; }

        [ObjectElement(NamespaceType.Toolkit)]
        public UrlMacroConfig Url { get; private set; }

        private static string ExecuteMarco(MarcoConfigItem marco, IDbDataSource source,
            DataRow row, ReceiveMessage message)
        {
            if (marco == null)
                return null;
            return Expression.Execute(marco, source, row, message);
        }

        private static string ExecuteUrl(UrlMacroConfig marco, IDbDataSource source,
            DataRow row, ReceiveMessage message)
        {
            if (marco == null)
                return null;
            string content = Expression.Execute(marco, source, row, message);
            return marco.ToUri(content);
        }

        public Article CreateArticle(IDbDataSource source, DataRow row, ReceiveMessage message)
        {
            Article result = new Article
            {
                Title = ExecuteMarco(Title, source, row, message),
                Description = ExecuteMarco(Description, source, row, message),
                PicUrl = ExecuteUrl(PicUrl, source, row, message),
                Url = ExecuteUrl(Url, source, row, message)
            };
            return result;
        }
    }
}
