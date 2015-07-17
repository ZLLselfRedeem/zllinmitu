
namespace YJC.Toolkit.Weixin.Message
{
    public class ServiceSendMessage : BaseSendMessage
    {
        public ServiceSendMessage(string toUser)
            : base(toUser, MessageType.Transfer_Customer_Service)
        {
        }

        internal ServiceSendMessage(ReceiveMessage message)
            : this(message.FromUserName)
        {
        }
    }
}
