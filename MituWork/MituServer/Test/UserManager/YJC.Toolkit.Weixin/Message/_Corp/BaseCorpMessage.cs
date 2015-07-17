using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public abstract class BaseCorpMessage : BaseJsonMessage
    {
        protected BaseCorpMessage(MessageType msgType)
            : base(msgType)
        {
        }

        protected bool NoUser
        {
            get
            {
                return string.IsNullOrEmpty(ToUser) && string.IsNullOrEmpty(ToParty)
                    && string.IsNullOrEmpty(ToTag);
            }
        }

        [SimpleElement(LocalName = "toparty", Order = 11)]
        public string ToParty { get; protected set; }

        [SimpleElement(LocalName = "totag", Order = 12)]
        public string ToTag { get; protected set; }

        [SimpleElement(LocalName = "agentid", Order = 30)]
        public int AgentId { get; protected set; }

        public void SetAllUser()
        {
            ToUser = "@all";
        }

        public void SetUser(string userId)
        {
            TkDebug.AssertArgumentNullOrEmpty(userId, "userId", this);

            ToUser = userId;
        }

        public void SetUser(params string[] userIds)
        {
            SetUser((IEnumerable<string>)userIds);
        }

        public void SetUser(IEnumerable<string> userIds)
        {
            TkDebug.AssertEnumerableArgumentNullOrEmpty(userIds, "userIds", this);

            string userString = string.Join("|", userIds);
            ToUser = userString;
        }

        public void SetParty(int partyId)
        {
            ToParty = partyId.ToString(ObjectUtil.SysCulture);
        }

        public void SetParty(params int[] partyIds)
        {
            SetParty((IEnumerable<int>)partyIds);
        }

        public void SetParty(IEnumerable<int> partyIds)
        {
            string partyString = string.Join("|", partyIds);
            ToParty = partyString;
        }

        public void SetTag(int tagId)
        {
            ToTag = tagId.ToString(ObjectUtil.SysCulture);
        }

        public void SetTag(params int[] tags)
        {
            SetTag((IEnumerable<int>)tags);
        }

        public void SetTag(IEnumerable<int> tags)
        {
            string tagString = string.Join("|", tags);
            ToTag = tagString;
        }

        public CorpMessageResult Send(int appId)
        {
            AgentId = appId;
            string secret = WeixinSettings.Current.GetCorpSecret(appId);
            string url = WeCorpUtil.GetCorpUrl(WeCorpConst.MESSAGE_URL, secret);
            CorpMessageResult result = new CorpMessageResult();
            result = WeUtil.PostToUri(url, ToJson(), result);
            return result;
        }
    }
}
