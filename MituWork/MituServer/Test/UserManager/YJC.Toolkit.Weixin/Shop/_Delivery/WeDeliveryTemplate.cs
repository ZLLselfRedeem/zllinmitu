using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class WeDeliveryTemplate
    {
        public WeDeliveryTemplate()
        {
        }

        private WeDeliveryTemplate(string name, AssumeType assumer, ValuationType valuation)
        {
            TkDebug.AssertArgumentNullOrEmpty(name, "name", null);
            Name = name;
            Assumer = assumer;
            Valuation = valuation;
            TopFees = new List<DeliveryFee>();
        }

        public WeDeliveryTemplate(string name, AssumeType assumer, ValuationType valuation,
            DeliveryFee topFees)
            : this(name, assumer, valuation)
        {
            TkDebug.AssertArgumentNull(topFees, "topFees", null);
            TopFees.Add(topFees);
        }

        public WeDeliveryTemplate(string name, AssumeType assumer, ValuationType valuation,
            params DeliveryFee[] topFees)
            : this(name, assumer, valuation)
        {
            TkDebug.AssertArgumentNull(topFees, "topFees", null);
            TopFees.AddRange(topFees);
        }

        [SimpleElement(Order = 10)]
        public long Id { get; private set; }

        [SimpleElement(Order = 20)]
        public string Name { get; protected set; }

        [SimpleElement(Order = 30)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public AssumeType Assumer { get; protected set; }

        [SimpleElement(Order = 40)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public ValuationType Valuation { get; protected set; }

        [ObjectElement(IsMultiple = true, LocalName = "TopFee", Order = 50)]
        public List<DeliveryFee> TopFees { get; protected set; }

        public WeDeliveryTemplate Insert()
        {
            string url = WeUtil.GetUrl(WeShopConst.ADD_TEMPLATE_URL);
            ExpressTemplate request = new ExpressTemplate(this);
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeTemplateId());
            Id = result.TemplateId;
            //if (result.IsError)
            //    Assign(result);
            return this;
        }

        public WeixinResult Update()
        {
            string url = WeUtil.GetUrl(WeShopConst.UPDATE_TEMPLATE_URL);
            ExpressTemplate request = new ExpressTemplate(this)
            {
                TemplateId = Id
            };
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeixinResult());
            return result;
        }

        public static WeixinResult Delete(long templateId)
        {
            string url = WeUtil.GetUrl(WeShopConst.DELETE_TEMPLATE_URL);
            WeTemplateId request = new WeTemplateId(templateId);
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeixinResult());
            return result;
        }

        public static WeDeliveryTemplate Query(long templateId)
        {
            WeTemplateId request = new WeTemplateId(templateId);
            string url = WeUtil.GetUrl(WeShopConst.TEMPLATE_ID_URL);
            var response = WeUtil.PostToUri(url, request.WriteJson(), new WeTemplateInfo());
            return response.TemplateInfo;
        }

        public static IEnumerable<WeDeliveryTemplate> QueryAllTemplates()
        {
            string url = WeUtil.GetUrl(WeShopConst.ALL_TEMPLATE_URL);
            var result = WeUtil.GetFromUri(url, new WeTemplateInfoList());
            return result.TemplatesInfos;
        }
    }
}
