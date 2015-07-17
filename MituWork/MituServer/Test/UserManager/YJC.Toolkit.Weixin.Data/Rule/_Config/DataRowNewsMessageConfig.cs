using System.Collections.Generic;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Rule
{
    [ReplyMessageConfig(NamespaceType = NamespaceType.Toolkit, Author = "YJC",
        CreateDate = "2014-03-16",
        Description = "根据配置的Sql来生成图文消息，DataRow的每一个字段可以用宏:FieldName来定义")]
    internal class DataRowNewsMessageConfig : IConfigCreator<IRule>
    {
        #region IConfigCreator<IReplyMessage> 成员

        public IRule CreateObject(params object[] args)
        {
            return new DataRowNewsMessage(this);
        }

        #endregion

        [SimpleAttribute]
        public string Context { get; private set; }

        [ObjectElement(NamespaceType.Toolkit)]
        public MarcoConfigItem Sql { get; private set; }

        [ObjectElement(NamespaceType.Toolkit, IsMultiple = true, LocalName = "Article")]
        public List<ArticleConfigItem> Articles { get; private set; }

        [ObjectElement(NamespaceType.Toolkit)]
        public DataRowArticle DataRowArticle { get; private set; }

        [ObjectElement(NamespaceType.Toolkit)]
        public ArticleConfigItem FootArticle { get; private set; }

        [ObjectElement(NamespaceType.Toolkit)]
        public MultiLanguageText EmptyMessage { get; private set; }
    }
}
