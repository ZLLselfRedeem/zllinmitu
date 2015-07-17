using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Rule
{
    [ReplyMessage(CreateDate = "2014-12-24", Author = "YJC",
        Description = "公众号用户订阅时数据库登记")]
    internal class NormalSubscribleRule : IRule
    {
        #region IRule 成员

        public BaseSendMessage Reply(ReceiveMessage message)
        {
            return RuleUtil.Execute(RuleUtil.ProcessNormalUser, true, message.FromUserName);
        }

        #endregion
    }
}
