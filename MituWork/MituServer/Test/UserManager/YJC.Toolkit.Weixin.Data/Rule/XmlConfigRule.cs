using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Rule
{
    internal class XmlConfigRule : IRule
    {
        private readonly RuleConfigItem fConfig;

        public XmlConfigRule(RuleConfigItem config)
        {
            fConfig = config;
        }

        #region IReplyMessage 成员

        public BaseSendMessage Reply(ReceiveMessage message)
        {
            IRule reply = fConfig.Reply.CreateObject();
            return reply.Reply(message);
        }

        #endregion
    }
}
