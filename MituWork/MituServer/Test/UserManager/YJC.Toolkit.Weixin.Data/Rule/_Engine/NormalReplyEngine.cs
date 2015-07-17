using System.Collections.Generic;
using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Rule
{
    class NormalReplyEngine : IMessageReplyEngine
    {
        private readonly List<RuleAttribute> fList;

        public NormalReplyEngine()
        {
            fList = new List<RuleAttribute>();
        }

        #region IMessageReplyEngine 成员

        public void Add(RuleAttribute attribute)
        {
            fList.Add(attribute);
        }

        public RuleAttribute Match(ReceiveMessage message)
        {
            bool isCorpMode = WeixinSettings.Current.Mode == WeixinMode.Corporation;
            foreach (var attr in fList)
            {
                if (isCorpMode)
                {
                    if (attr.AppId != message.AgentId)
                        continue;
                }
                if (attr.Match(message))
                    return attr;
            }

            return null;
        }

        #endregion
    }
}
