﻿using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Rule
{
    [MatchRuleConfig(NamespaceType = NamespaceType.Toolkit, Author = "YJC",
        CreateDate = "2014-03-06", Description = "匹配接收的链接消息")]
    internal class LinkRuleConfig : IConfigCreator<RuleAttribute>
    {
        #region IConfigCreator<RuleAttribute> 成员

        public RuleAttribute CreateObject(params object[] args)
        {
            return new LinkRuleAttribute();
        }

        #endregion
    }
}
