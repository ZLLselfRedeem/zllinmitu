using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    public class WeCardBaseInfo
    {
        internal WeCardBaseInfo()
        {
        }
        public WeCardBaseInfo(string logo, CodeType codeType, string brandName, string title,
            string color, string notice, string description, WeDateInfo dateInfo, int quantity)
        {
            TkDebug.AssertArgumentNullOrEmpty(logo, "logo", null);
            TkDebug.AssertArgumentNullOrEmpty(brandName, "brandName", null);
            TkDebug.AssertArgumentNullOrEmpty(title, "title", null);
            TkDebug.AssertArgumentNullOrEmpty(color, "color", null);
            TkDebug.AssertArgumentNullOrEmpty(notice, "notice", null);
            TkDebug.AssertArgumentNullOrEmpty(description, "description", null);
            TkDebug.AssertArgumentNull(dateInfo, "dateInfo", null);

            LogoUrl = logo;
            CodeType = codeType;
            BrandName = brandName;
            Title = title;
            Color = color;
            Notice = notice;
            Description = description;
            DateInfo = dateInfo;
            Quantity = quantity;

            // 最大领取次数，不填写默认为quantity
            GetLimit = quantity;
        }

        public WeCardBaseInfo(string logoUrl, string notice, string description)
        {
            TkDebug.AssertArgumentNullOrEmpty(logoUrl, "logoUrl", null);
            TkDebug.AssertArgumentNullOrEmpty(notice, "notice", null);
            TkDebug.AssertArgumentNullOrEmpty(description, "description", null);

            LogoUrl = logoUrl;
            Notice = notice;
            Description = description;
        }

        [SimpleElement(Order = 5, NamingRule = NamingRule.Lower)]
        public string Id { get; private set; }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string LogoUrl { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(EnumFieldValueTypeConverter), UseObjectType = true)]
        public CodeType CodeType { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public string BrandName { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        public string Title { get; private set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public string SubTitle { get; set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.Lower)]
        public string Color { get; private set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.Lower)]
        public string Notice { get; private set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.Lower)]
        public string Description { get; private set; }

        [ObjectElement(Order = 90, NamingRule = NamingRule.UnderLineLower)]
        public WeDateInfo DateInfo { get; private set; }

        [TagElement(Order = 100, LocalName = "sku")]
        [SimpleElement(NamingRule = NamingRule.Lower)]
        public int Quantity { get; private set; }

        [SimpleElement(IsMultiple = true, Order = 110, NamingRule = NamingRule.UnderLineLower)]
        public List<int> LocationIdList { get; set; }

        [SimpleElement(Order = 120, NamingRule = NamingRule.UnderLineLower)]
        public bool UseCustomCode { get; set; }

        [SimpleElement(Order = 130, NamingRule = NamingRule.UnderLineLower)]
        public bool BindOpenid { get; set; }

        [SimpleElement(Order = 140, NamingRule = NamingRule.UnderLineLower)]
        public bool CanShare { get; set; }

        [SimpleElement(Order = 150, NamingRule = NamingRule.UnderLineLower)]
        public bool CanGiveFriend { get; set; }

        [SimpleElement(Order = 155, NamingRule = NamingRule.UnderLineLower)]
        public int UseLimit { get; private set; }

        [SimpleElement(Order = 160, NamingRule = NamingRule.UnderLineLower)]
        public int GetLimit { get; set; }

        [SimpleElement(Order = 170, NamingRule = NamingRule.UnderLineLower)]
        public string ServicePhone { get; set; }

        [SimpleElement(Order = 180, NamingRule = NamingRule.Lower)]
        public string Source { get; set; }

        [SimpleElement(Order = 190, NamingRule = NamingRule.UnderLineLower)]
        public string CustomUrlName { get; set; }

        [SimpleElement(Order = 200, NamingRule = NamingRule.UnderLineLower)]
        public string CustomUrl { get; set; }

        [SimpleElement(Order = 210, NamingRule = NamingRule.UnderLineLower)]
        public string CustomUrlSubTitle { get; set; }

        [SimpleElement(Order = 220, NamingRule = NamingRule.UnderLineLower)]
        public string PromotionUrlName { get; set; }

        [SimpleElement(Order = 230, NamingRule = NamingRule.UnderLineLower)]
        public string PromotionUrl { get; set; }

        [SimpleElement(Order = 240, NamingRule = NamingRule.UnderLineLower)]
        public string PromotionUrlSubTitle { get; set; }

        [SimpleElement(Order = 250, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public CardStatus Status { get; private set; }
    }
}
