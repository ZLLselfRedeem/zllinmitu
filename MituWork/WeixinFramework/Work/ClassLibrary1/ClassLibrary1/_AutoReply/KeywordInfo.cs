using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class KeywordInfo : SimpleReplyInfo
    {
        internal KeywordInfo()
        {
        }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(LowerCaseEnumConverter), UseObjectType = true)]
        public KeywordMatch MatchMode { get; private set; }
    }
}
