using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Cube
{
    public class WeDataArticleSummary
    {
        [ObjectElement(IsMultiple = true, NamingRule = NamingRule.Lower)]
        public List<WeArticleSummary> List { get; private set; }
    }
}
