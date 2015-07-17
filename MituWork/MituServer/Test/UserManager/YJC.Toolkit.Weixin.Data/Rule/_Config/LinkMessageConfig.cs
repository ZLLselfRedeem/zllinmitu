using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Rule
{
    [ReplyMessageConfig(NamespaceType = NamespaceType.Toolkit, Author = "YJC",
       CreateDate = "2014-04-04",
       Description = "串联执行每个配置的消息，并返回最后一个消息的返回结果")]
    internal class LinkMessageConfig : IConfigCreator<IRule>
    {
        #region IConfigCreator<IRule> 成员

        public IRule CreateObject(params object[] args)
        {
            return new LinkRule(this);
        }

        #endregion

        [TagElement(NamespaceType.Toolkit, LocalName = "Item")]
        [DynamicElement(ReplyMessageConfigFactory.REG_NAME, IsMultiple = true)]
        public List<IConfigCreator<IRule>> Items { get; private set; }
    }
}
