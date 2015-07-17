using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Data
{
    public interface IMessageLog
    {
        void Log(ReceiveMessage message);
    }
}
