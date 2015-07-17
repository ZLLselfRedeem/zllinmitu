using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Semantic
{
    internal class WeSemanticRequest
    {
        public WeSemanticRequest()
        {
            Appid = "wxf3f273709c656249";
            Uid = "oyyPUjprmJtrweCrPX_1is6-FRY4";
        }

        public WeSemanticRequest(string query, string category, string city)
            : this()
        {
            TkDebug.AssertArgumentNullOrEmpty(query, "query", null);
            TkDebug.AssertArgumentNullOrEmpty(category, "category", null);
            TkDebug.AssertArgumentNullOrEmpty(city, "city", null);

            Query = query;
            Category = category;
            City = city;
        }

        public WeSemanticRequest(string query, string category, float latitude, float longitude)
        {
            TkDebug.AssertArgumentNullOrEmpty(query, "query", null);
            TkDebug.AssertArgumentNullOrEmpty(category, "category", null);

            Query = query;
            Category = category;
            Latitude = latitude;
            Longitude = longitude;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public string Query { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Category { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public float? Latitude { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        public float? Longitude { get; private set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.Lower)]
        public string City { get; private set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.Lower)]
        public string Region { get; set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.Lower)]
        public string Appid { get; private set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.Lower)]
        public string Uid { get; private set; }
    }
}
