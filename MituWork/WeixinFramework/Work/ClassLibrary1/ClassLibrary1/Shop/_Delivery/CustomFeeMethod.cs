using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class CustomFeeMethod : NormalFeeMethod
    {
        public CustomFeeMethod()
        {
        }

        public CustomFeeMethod(int startStandards, int startFees, int addStandards, int addFees,
            string destCountry, string destProvince, string destCity)
            : base(startStandards, startFees, addStandards, addFees)
        {
            TkDebug.AssertArgumentNullOrEmpty(destCountry, "destCountry", null);
            TkDebug.AssertArgumentNullOrEmpty(destProvince, "destProvince", null);
            TkDebug.AssertArgumentNullOrEmpty(destCity, "destCity", null);

            DestCountry = destCountry;
            DestProvince = destProvince;
            DestCity = destCity;
        }

        [SimpleElement(Order = 50)]
        public string DestCountry { get; private set; }

        [SimpleElement(Order = 60)]
        public string DestProvince { get; private set; }

        [SimpleElement(Order = 70)]
        public string DestCity { get; private set; }
    }
}
