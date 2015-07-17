using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Rule
{
    internal interface IMessageReplyEngine
    {
        void Add(RuleAttribute attribute);

        RuleAttribute Match(ReceiveMessage message);
    }
}
