using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Rule
{
    [ReplyMessageConfig(NamespaceType = NamespaceType.Toolkit, Author = "YJC",
        CreateDate = "2015-02-12", Description = "空消息")]
    internal class EmptyMessageConfig : IRule, IConfigCreator<IRule>
    {
        #region IConfigCreator<IRule> 成员

        public IRule CreateObject(params object[] args)
        {
            return this;
        }

        #endregion

        #region IRule 成员

        public BaseSendMessage Reply(ReceiveMessage message)
        {
            return null;
        }

        #endregion
    }
}
