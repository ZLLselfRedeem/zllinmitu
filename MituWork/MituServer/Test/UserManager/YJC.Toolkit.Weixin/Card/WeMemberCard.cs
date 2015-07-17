using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    public class WeMemberCard
    {
        internal WeMemberCard()
        {
        }

        //支持储值和积分
        public WeMemberCard(WeCardBaseInfo baseInfo, string bonusClared, string bonusRules,
            string balanceRules, string prerogative, CardUrlType urlType, string cardUrl)
        {
            SupplyBonus = true;
            SupplyBalance = true;

            TkDebug.AssertArgumentNull(baseInfo, "baseInfo", null);
            TkDebug.AssertArgumentNullOrEmpty(prerogative, "prerogative", null);
            TkDebug.AssertArgumentNullOrEmpty(cardUrl, "cardUrl", null);

            BonusCleared = bonusClared;
            BonusRules = bonusRules;
            BalanceRules = balanceRules;
            Prerogative = prerogative;

            switch (urlType)
            {
                case CardUrlType.OldCardUrl:
                    BindOldCardUrl = cardUrl;
                    break;
                case CardUrlType.ActivateUrl:
                    ActivateUrl = cardUrl;
                    break;
                default:
                    break;
            }
        }

        // 仅支持积分、不支持储值
        public WeMemberCard(WeCardBaseInfo baseInfo, string bonusClared, string bonusRules,
            string prerogative, CardUrlType urlType, string cardUrl)
            : this(baseInfo, bonusClared, bonusRules, null, prerogative, urlType, cardUrl)
        {
            SupplyBalance = false;
        }

        public WeMemberCard(WeCardBaseInfo baseInfo, string balanceRules, string prerogative,
            CardUrlType urlType, string cardUrl)
            : this(baseInfo, null, null, balanceRules, prerogative, urlType, cardUrl)
        {
            SupplyBonus = false;
        }

        public WeMemberCard(WeCardBaseInfo baseInfo, string prerogative, CardUrlType urlType, string cardUrl)
            : this(baseInfo, null, null, null, prerogative, urlType, cardUrl)
        {
            SupplyBonus = false;
            SupplyBalance = false;
        }

        public WeMemberCard(WeCardBaseInfo baseInfo, string bonusCleared, string bonusRules, string prerogative)
        {
            TkDebug.AssertArgumentNull(baseInfo, "baseInfo", null);
            TkDebug.AssertArgumentNullOrEmpty(bonusCleared, "bonusCleared", null);
            TkDebug.AssertArgumentNullOrEmpty(bonusRules, "bonusRules", null);

            BaseInfo = baseInfo;
            BonusCleared = bonusCleared;
            BonusRules = bonusRules;
            Prerogative = prerogative;
        }

        [ObjectElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public WeCardBaseInfo BaseInfo { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public bool SupplyBonus { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public bool SupplyBalance { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        public string BonusCleared { get; private set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public string BonusRules { get; private set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        public string BalanceRules { get; private set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.Lower)]
        public string Prerogative { get; private set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.UnderLineLower)]
        public string BindOldCardUrl { get; private set; }

        [SimpleElement(Order = 90, NamingRule = NamingRule.UnderLineLower)]
        public string ActivateUrl { get; private set; }

        [SimpleElement(Order = 100, NamingRule = NamingRule.UnderLineLower)]
        public bool NeedPushOnView { get; set; }
    }
}
