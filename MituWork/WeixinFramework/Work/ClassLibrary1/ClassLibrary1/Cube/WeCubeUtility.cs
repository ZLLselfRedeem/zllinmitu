using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Cube
{
    public static class WeCubeUtility
    {
        public static WeDataUserSummary GetUserSummary(DateTime beg, DateTime end)
        {
            WeDataTimespan timespan = new WeDataTimespan(beg, end);
            string url = WeUtil.GetUrl(WeDataConst.USER_SUMMARY);
            var result = WeUtil.PostDataToUri(url, timespan.WriteJson(), new WeDataUserSummary());
            return result;
        }

        public static WeDataUserCumulate GetUserCumulate(DateTime beg, DateTime end)
        {
            WeDataTimespan timespan = new WeDataTimespan(beg, end);
            string url = WeUtil.GetUrl(WeDataConst.USER_CUMULATE);
            var result = WeUtil.PostDataToUri(url, timespan.WriteJson(), new WeDataUserCumulate());
            return result;
        }

        public static WeDataArticleSummary GetArticleSummary(DateTime beg, DateTime end)
        {
            WeDataTimespan timespan = new WeDataTimespan(beg, end);
            string url = WeUtil.GetUrl(WeDataConst.ARTICLE_SUMMARY);
            var result = WeUtil.PostDataToUri(url, timespan.WriteJson(), new WeDataArticleSummary());
            return result;
        }

        public static WeDataArticleTotal GetArticleTotal(DateTime beg, DateTime end)
        {
            WeDataTimespan timespan = new WeDataTimespan(beg, end);
            string url = WeUtil.GetUrl(WeDataConst.ARTICLE_TOTAL);
            var result = WeUtil.PostDataToUri(url, timespan.WriteJson(), new WeDataArticleTotal());
            return result;
        }

        public static WeDataUserRead GetUserRead(DateTime beg, DateTime end)
        {
            WeDataTimespan timespan = new WeDataTimespan(beg, end);
            string url = WeUtil.GetUrl(WeDataConst.USER_READ);
            var result = WeUtil.PostDataToUri(url, timespan.WriteJson(), new WeDataUserRead());
            return result;
        }

        public static WeDataUserReadHour GetUserReadHour(DateTime beg, DateTime end)
        {
            WeDataTimespan timespan = new WeDataTimespan(beg, end);
            string url = WeUtil.GetUrl(WeDataConst.USER_READ_HOUR);
            var result = WeUtil.PostDataToUri(url, timespan.WriteJson(), new WeDataUserReadHour());
            return result;
        }

        public static WeDataUserShare GetUserShare(DateTime beg, DateTime end)
        {
            WeDataTimespan timespan = new WeDataTimespan(beg, end);
            string url = WeUtil.GetUrl(WeDataConst.USER_SHARE);
            var result = WeUtil.PostDataToUri(url, timespan.WriteJson(), new WeDataUserShare());
            return result;
        }

        public static WeDataUserShareHour GetUserShareHour(DateTime beg, DateTime end)
        {
            WeDataTimespan timespan = new WeDataTimespan(beg, end);
            string url = WeUtil.GetUrl(WeDataConst.USER_SHARE_HOUR);
            var result = WeUtil.PostDataToUri(url, timespan.WriteJson(), new WeDataUserShareHour());
            return result;
        }

        public static WeDataUpStreamMsg GetUpStreamMsg(DateTime beg, DateTime end)
        {
            WeDataTimespan timespan = new WeDataTimespan(beg, end);
            string url = WeUtil.GetUrl(WeDataConst.UP_STREAM_MSG);
            var result = WeUtil.PostDataToUri(url, timespan.WriteJson(), new WeDataUpStreamMsg());
            return result;
        }

        public static WeDataUpStreamMsgHour GetUpStreamMsgHour(DateTime beg, DateTime end)
        {
            WeDataTimespan timespan = new WeDataTimespan(beg, end);
            string url = WeUtil.GetUrl(WeDataConst.UP_STREAM_MSG_HOUR);
            var result = WeUtil.PostDataToUri(url, timespan.WriteJson(), new WeDataUpStreamMsgHour());
            return result;
        }

        public static WeDataUpStreamMsg GetUpStreamMsgWeek(DateTime beg, DateTime end)
        {
            WeDataTimespan timespan = new WeDataTimespan(beg, end);
            string url = WeUtil.GetUrl(WeDataConst.UP_STREAM_MSG_WEEK);
            var result = WeUtil.PostDataToUri(url, timespan.WriteJson(), new WeDataUpStreamMsg());
            return result;
        }

        public static WeDataUpStreamMsg GetUpStreamMsgMonth(DateTime beg, DateTime end)
        {
            WeDataTimespan timespan = new WeDataTimespan(beg, end);
            string url = WeUtil.GetUrl(WeDataConst.UP_STREAM_MSG_MONTH);
            var result = WeUtil.PostDataToUri(url, timespan.WriteJson(), new WeDataUpStreamMsg());
            return result;
        }

        public static WeDataUpStreamMsgDist GetUpStreamMsgDist(DateTime beg, DateTime end)
        {
            WeDataTimespan timespan = new WeDataTimespan(beg, end);
            string url = WeUtil.GetUrl(WeDataConst.UP_STREAM_MSG_DIST);
            var result = WeUtil.PostDataToUri(url, timespan.WriteJson(), new WeDataUpStreamMsgDist());
            return result;
        }

        public static WeDataUpStreamMsgDist GetUpStreamMsgDistWeek(DateTime beg, DateTime end)
        {
            WeDataTimespan timespan = new WeDataTimespan(beg, end);
            string url = WeUtil.GetUrl(WeDataConst.UP_STREAM_MSG_DIST_WEEK);
            var result = WeUtil.PostDataToUri(url, timespan.WriteJson(), new WeDataUpStreamMsgDist());
            return result;
        }

        public static WeDataUpStreamMsgDist GetUpStreamMsgDistMonth(DateTime beg, DateTime end)
        {
            WeDataTimespan timespan = new WeDataTimespan(beg, end);
            string url = WeUtil.GetUrl(WeDataConst.UP_STREAM_MSG_DIST_MONTH);
            var result = WeUtil.PostDataToUri(url, timespan.WriteJson(), new WeDataUpStreamMsgDist());
            return result;
        }

        public static WeDataInterfaceSummary GetInterfaceSummary(DateTime beg, DateTime end)
        {
            WeDataTimespan timespan = new WeDataTimespan(beg, end);
            string url = WeUtil.GetUrl(WeDataConst.INTERFACE_SUMMARY);
            var result = WeUtil.PostDataToUri(url, timespan.WriteJson(), new WeDataInterfaceSummary());
            return result;
        }

        public static WeDataInterfaceSummaryHour GetInterfaceSummaryHour(DateTime beg, DateTime end)
        {
            WeDataTimespan timespan = new WeDataTimespan(beg, end);
            string url = WeUtil.GetUrl(WeDataConst.INTERFACE_SUMMARY_HOUR);
            var result = WeUtil.PostDataToUri(url, timespan.WriteJson(), new WeDataInterfaceSummaryHour());
            return result;
        }
    }
}
