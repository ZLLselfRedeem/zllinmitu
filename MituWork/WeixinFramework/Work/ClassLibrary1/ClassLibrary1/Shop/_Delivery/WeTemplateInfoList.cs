using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    internal class WeTemplateInfoList : WeixinResult
    {
        [ObjectElement(IsMultiple = true, LocalName = "templates_info")]
        public List<WeDeliveryTemplate> TemplatesInfos { get; private set; }
    }
}
