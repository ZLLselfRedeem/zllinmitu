using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    public class WeLocationInit
    {
        public WeLocationInit(string businessName, string province, string city, string district,
            string address, string telephone, string category, double longitude, double latitude)
        {
            TkDebug.AssertArgumentNullOrEmpty(businessName, "businessName", null);
            TkDebug.AssertArgumentNullOrEmpty(province, "province", null);
            TkDebug.AssertArgumentNullOrEmpty(city, "city", null);
            TkDebug.AssertArgumentNullOrEmpty(district, "district", null);
            TkDebug.AssertArgumentNullOrEmpty(address, "address", null);
            TkDebug.AssertArgumentNullOrEmpty(telephone, "telephone", null);
            TkDebug.AssertArgumentNullOrEmpty(category, "category", null);

            BusinessName = businessName;
            Province = province;
            City = city;
            District = district;
            Address = address;
            Telephone = telephone;
            Category = category;
            Longitude = longitude;
            Latitude = latitude;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string BusinessName { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public string BranchName { get; set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public string Province { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        public string City { get; private set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.Lower)]
        public string District { get; private set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.Lower)]
        public string Address { get; private set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.Lower)]
        public string Telephone { get; private set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.Lower)]
        public string Category { get; private set; }

        [SimpleElement(Order = 90, NamingRule = NamingRule.Lower)]
        public double Longitude { get; private set; }

        [SimpleElement(Order = 100, NamingRule = NamingRule.Lower)]
        public double Latitude { get; private set; }
    }
}
