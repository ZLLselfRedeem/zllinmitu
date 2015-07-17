using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Rule
{
    public interface IRule
    {
        BaseSendMessage Reply(ReceiveMessage message);
    }
}
