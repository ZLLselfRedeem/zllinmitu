using System;
using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class KeywordRuleInfo
    {
        internal KeywordRuleInfo()
        {
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string RuleName { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(WeixinDateTimeConverter))]
        public DateTime CreateTime { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(EnumFieldValueTypeConverter), UseObjectType = true)]
        public ReplyType ReplyMode { get; private set; }

        [ObjectElement(IsMultiple = true, Order = 40, NamingRule = NamingRule.UnderLineLower, UseConstructor = true)]
        public List<KeywordInfo> KeywordListInfo { get; private set; }

        [ObjectElement(IsMultiple = true, Order = 50, NamingRule = NamingRule.UnderLineLower, UseConstructor = true)]
        public List<NewsReplyInfo> ReplyListInfo { get; private set; }
    }
}
