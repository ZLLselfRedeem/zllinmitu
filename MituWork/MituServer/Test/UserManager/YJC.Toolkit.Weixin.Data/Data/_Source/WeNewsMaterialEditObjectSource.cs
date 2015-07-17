using System;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Material;
using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Data
{
    [ObjectSource(Author = "YJC", CreateDate = "2015-06-03",
        Description = "微信公众号图文素材的编辑数据源")]
    internal class WeNewsMaterialEditObjectSource : IInsertObjectSource, IUpdateObjectSource,
        IDeleteObjectSource
    {

        public object CreateNew(IInputData input)
        {
            return new MpNewsArticle();
        }

        public OutputData Insert(IInputData input, object instance)
        {
            MpNewsArticle article = instance as MpNewsArticle;
            WeNewsMaterial news = new WeNewsMaterial(article);
            news.Add();
            return OutputData.CreateToolkitObject(new KeyData(article.Title, article.Content));
        }

        public OutputData Update(IInputData input, object instance)
        {
            throw new NotImplementedException();
        }

        public object Query(IInputData input, string id)
        {
            WeMediaId mediaId = new WeMediaId(id);
            return mediaId.CreateNewsMaterial().Articles[0];
        }

        public OutputData Delete(IInputData input, string id)
        {
            WeMediaId mediaId = new WeMediaId(id);
            WeixinResult res = mediaId.Delete();
            return OutputData.CreateToolkitObject(KeyData.Empty);
        }
    }
}
