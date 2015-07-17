using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Rule
{
    [ReplyMessage(CreateDate = "2014-12-24", Author = "YJC",
        Description = "企业号用户退订时数据库登记")]
    internal class CorpUnSubscribeRule : IRule
    {
        #region IRule 成员

        public BaseSendMessage Reply(ReceiveMessage message)
        {
            return RuleUtil.Execute(RuleUtil.ProcessCorpUser, false, message.FromUserName);
        }

        #endregion
    }
}
