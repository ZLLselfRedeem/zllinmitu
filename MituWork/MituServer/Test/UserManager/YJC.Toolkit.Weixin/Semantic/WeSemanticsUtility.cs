using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Semantic
{
    public static class WeSemanticsUtility
    {
        private const string SEMANTIC_REQUEST =
            "https://api.weixin.qq.com/semantic/semproxy/search?access_token={0}";
        private static readonly string url = WeUtil.GetUrl(SEMANTIC_REQUEST);

        public static WeServer<T> Query<T>(string query, string category, string city, string region)
        {
            WeSemanticRequest request = new WeSemanticRequest(query, category, city) { Region = region };
            WeServer<T> result = WeUtil.PostToUri(url, request.WriteJson(), new WeServer<T>());
            return result;
        }

        public static WeServer<T> Query<T>(string query, string category, float latitude, float longitude)
        {
            WeSemanticRequest request = new WeSemanticRequest(query, category, latitude, longitude);
            WeServer<T> result = WeUtil.PostToUri(url, request.WriteJson(), new WeServer<T>());
            return result;
        }

        //public static WeMap MapQuery()
        //{
        //    var result = WeUtil.PostToUri(url, this.WriteJson(), new WeMap());
        //    return result;
        //}

        //public static WeNearby NearbyQuery()
        //{
        //    var result = WeUtil.PostToUri(url, this.WriteJson(), new WeNearby());
        //    return result;
        //}

        //public static WeCoupon CouponQuery()
        //{
        //    WeCoupon result = WeUtil.PostToUri(url, this.WriteJson(), new WeCoupon());
        //    return result;
        //}

        //public static WeHotel HotelQuery()
        //{
        //    WeHotel result = WeUtil.PostToUri(url, this.WriteJson(), new WeHotel());
        //    return result;
        //}

        //public static WeTravel TravelQuery()
        //{
        //    WeTravel result = WeUtil.PostToUri(url, this.WriteJson(), new WeTravel());
        //    return result;
        //}

        //public static WeFlight FlightQuery()
        //{
        //    WeFlight result = WeUtil.PostToUri(url, this.WriteJson(), new WeFlight());
        //    return result;
        //}

        //public static WeTrain TrainQuery()
        //{
        //    WeTrain result = WeUtil.PostToUri(url, this.WriteJson(), new WeTrain());
        //    return result;
        //}

        //public static WeMovie MovieQuery()
        //{
        //    WeMovie result = WeUtil.PostToUri(url, this.WriteJson(), new WeMovie());
        //    return result;
        //}

        //public static WeMusic MusicQuery()
        //{
        //    WeMusic result = WeUtil.PostToUri(url, this.WriteJson(), new WeMusic());
        //    return result;
        //}

        //public static WeVideo VideoQuery()
        //{
        //    WeVideo result = WeUtil.PostToUri(url, this.WriteJson(), new WeVideo());
        //    return result;
        //}

        //public static WeNovel NovelQuery()
        //{
        //    WeNovel result = WeUtil.PostToUri(url, this.WriteJson(), new WeNovel());
        //    return result;
        //}

        //public static WeWeather WeatherQuery()
        //{
        //    var result = WeUtil.PostToUri(url, this.WriteJson(), new WeWeather());
        //    return result;
        //}

        //public static WeStock StockQuery()
        //{
        //    var result = WeUtil.PostToUri(url, this.WriteJson(), new WeStock());
        //    return result;
        //}

        //public static WeRemind RemindQuery()
        //{
        //    WeRemind result = WeUtil.PostToUri(url, this.WriteJson(), new WeRemind());
        //    return result;
        //}

        //public static WeTelephone TelephoneQuery()
        //{
        //    WeTelephone result = WeUtil.PostToUri(url, this.WriteJson(), new WeTelephone());
        //    return result;
        //}

        //public static WeCookbook CookbookQuery()
        //{
        //    WeCookbook result = WeUtil.PostToUri(url, this.WriteJson(), new WeCookbook());
        //    return result;
        //}

        //public static WeBaike BaikeQuery()
        //{
        //    WeBaike result = WeUtil.PostToUri(url, this.WriteJson(), new WeBaike());
        //    return result;
        //}

        //public static WeNews NewsQuery()
        //{
        //    WeNews result = WeUtil.PostToUri(url, this.WriteJson(), new WeNews());
        //    return result;
        //}

        //public static WeTv TvQuery()
        //{
        //    WeTv result = WeUtil.PostToUri(url, this.WriteJson(), new WeTv());
        //    return result;
        //}

        //public static WeInstruction InstructionQuery()
        //{
        //    var result = WeUtil.PostToUri(url, this.WriteJson(), new WeInstruction());
        //    return result;
        //}

        //public static WeTvInstruction TvInstructionQuery()
        //{
        //    WeTvInstruction result = WeUtil.PostToUri(url, this.WriteJson(), new WeTvInstruction());
        //    return result;
        //}

        //public static WeCarInstruction CarInstructionQuery()
        //{
        //    WeCarInstruction result = WeUtil.PostToUri(url, this.WriteJson(), new WeCarInstruction());
        //    return result;
        //}

        //public static WeAppServer AppQuery()
        //{
        //    WeAppServer result = WeUtil.PostToUri(url, this.WriteJson(), new WeAppServer());
        //    return result;
        //}

        //public static WeWebsite WebsiteQuery()
        //{
        //    WeWebsite result = WeUtil.PostToUri(url, this.WriteJson(), new WeWebsite());
        //    return result;
        //}

        //public static WeSearch SearchQuery()
        //{
        //    WeSearch result = WeUtil.PostToUri(url, this.WriteJson(), new WeSearch());
        //    return result;
        //}
    }
}
