using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class CorpMessageResult : WeixinResult
    {
        internal CorpMessageResult()
        {
        }

        [SimpleElement(LocalName = "invaliduser", Order = 30)]
        public string InvalidUser { get; private set; }

        [SimpleElement(LocalName = "invalidparty", Order = 40)]
        public string InvalidParty { get; private set; }

        [SimpleElement(LocalName = "invalidtag", Order = 50)]
        public string InvalidTag { get; private set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
