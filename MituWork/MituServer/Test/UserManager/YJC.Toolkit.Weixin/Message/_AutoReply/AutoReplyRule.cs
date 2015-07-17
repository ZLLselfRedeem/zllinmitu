using System;
using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class AutoReplyRule
    {
        private AutoReplyRule()
        {
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool IsAddFriendReplyOpen { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool IsAutoreplyOpen { get; private set; }

        [ObjectElement(Order = 30, NamingRule = NamingRule.UnderLineLower, UseConstructor = true)]
        public SimpleReplyInfo AddFriendAutoreplyInfo { get; private set; }

        [ObjectElement(Order = 40, NamingRule = NamingRule.UnderLineLower, UseConstructor = true)]
        public SimpleReplyInfo MessageDefaultAutoreplyInfo { get; private set; }

        [TagElement(Order = 50, LocalName = "keyword_autoreply_info")]
        [ObjectElement(IsMultiple = true, LocalName = "list", UseConstructor = true)]
        public List<KeywordRuleInfo> KeywordRuleList { get; private set; }

        public static AutoReplyRule GetCurrentRule()
        {
            string url = WeUtil.GetUrl("https://api.weixin.qq.com/cgi-bin/get_current_autoreply_info?access_token={0}");
            var result = NetUtil.HttpGetReadJson(new Uri(url), new AutoReplyRule());
            return result;
        }
    }
}
