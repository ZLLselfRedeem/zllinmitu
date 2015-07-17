using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    [RegClass(Author = "YJC", CreateDate = "2014-09-20", RegName = "WeixinCorpMessage",
        Description = "微信企业公众号回调方式接受的消息")]
    public class CorpEncodeReceiveMessage : EncodeReceiveMessage
    {
        public CorpEncodeReceiveMessage()
        {
        }

        public CorpEncodeReceiveMessage(string toUserName, int agentId, string encrypt)
        {
            ToUserName = toUserName;
            AgentId = agentId;
            Encrypt = encrypt;
        }

        [SimpleElement(LocalName = "AgentID")]
        public int AgentId { get; private set; }

        public ReceiveMessage CreateCorpReceiveMessage(string msgSignature,
            string timeStamp, string nonce)
        {
            var xml = WeCorpUtil.DecryptMsg(this, msgSignature, timeStamp, nonce);
            if (string.IsNullOrEmpty(xml))
                return null;

            return CreateReceiveMessage(xml);
        }
    }
}
