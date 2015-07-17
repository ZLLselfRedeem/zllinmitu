using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Rule
{
    [MatchRuleConfig(NamespaceType = NamespaceType.Toolkit, Author = "YJC",
        CreateDate = "2014-03-06", Description = "匹配接收的文本消息")]
    internal class TextRuleConfig : IConfigCreator<RuleAttribute>
    {
        #region IConfigCreator<RuleAttribute> 成员

        public RuleAttribute CreateObject(params object[] args)
        {
            return new TextRuleAttribute(MatchType, Text);
        }

        #endregion

        [SimpleAttribute]
        public TextMatchType MatchType { get; private set; }

        [SimpleAttribute]
        public string Text { get; private set; }
    }
}
