using System.Collections.Generic;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Rule
{
    public class LinkRule : IRule
    {
        private readonly List<IRule> fLinkList;

        public LinkRule()
        {
            fLinkList = new List<IRule>();
        }

        internal LinkRule(LinkMessageConfig config)
            : this()
        {
            if (config.Items != null)
            {
                foreach (var item in config.Items)
                {
                    IRule rule = item.CreateObject();
                    if (rule != null)
                        AddRule(rule);
                }
            }
        }

        #region IRule 成员

        public BaseSendMessage Reply(ReceiveMessage message)
        {
            BaseSendMessage result = null;
            foreach (IRule rule in fLinkList)
                try
                {
                    result = rule.Reply(message);
                }
                catch
                {
                }

            return result;
        }

        #endregion

        public void AddRule(IRule rule)
        {
            TkDebug.AssertArgumentNull(rule, "rule", this);

            fLinkList.Add(rule);
        }
    }
}
