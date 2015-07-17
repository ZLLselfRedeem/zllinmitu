using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    public static class WePayUtil
    {
        private static string fKey;

        public static string Key
        {
            get
            {
                if (string.IsNullOrEmpty(fKey))
                    fKey = "&key=" + WeixinSettings.Current.PayKey;
                return fKey;
            }
        }

        internal static string CreateSign(object obj)
        {
            string queryString = obj.WriteQueryString(QueryStringOutput.WeixinOutput);
            queryString += Key;
            return WeUtil.Md5(queryString);
        }

        private static T PostData<T>(string url, BasePayRequest request) where T : BasePayResponse, new()
        {
            request.CreateSign();
            var result = WeUtil.PostDataToUri(url, request.ToXml(), new T());
            return result;
        }

        public static WeOrderQueryResponse QueryOrder(string outTradeNo)
        {
            TkDebug.AssertArgumentNullOrEmpty(outTradeNo, "outTradeNo", null);

            WeCloseOrderRequest request = new WeCloseOrderRequest(outTradeNo);
            return PostData<WeOrderQueryResponse>(WePayConst.ORDER_QUERY_URL, request);
        }

        public static BasePayResponse CloseOrder(string outTradeNo)
        {
            TkDebug.AssertArgumentNullOrEmpty(outTradeNo, "outTradeNo", null);

            WeCloseOrderRequest request = new WeCloseOrderRequest(outTradeNo);
            return PostData<BasePayResponse>(WePayConst.CLOSE_ORDER_URL, request);
        }

        public static WeRefundResponse Refund(OrderType orderName, string orderId,
            string outRefundNo, int totalFee, int refundFee)
        {
            TkDebug.AssertArgumentNullOrEmpty(orderId, "orderId", null);

            WeRefundRequest request = new WeRefundRequest(orderName, orderId, outRefundNo,
                totalFee, refundFee);
            return PostData<WeRefundResponse>(WePayConst.REFUND_URL, request);
        }

        public static WeRefundQueryResponse RefundQuery(OrderType orderType, string orderId)
        {
            TkDebug.AssertArgumentNullOrEmpty(orderId, "orderId", null);

            WeRefundQueryRequest request = new WeRefundQueryRequest(orderType, orderId);
            return PostData<WeRefundQueryResponse>(WePayConst.REFUND_QUERY_URL, request);
        }

        public static string ConvertToShortUrl(string longUrl)
        {
            TkDebug.AssertArgumentNullOrEmpty(longUrl, "longUrl", null);

            string url = WeUtil.GetUrl(WePayConst.SHORT_URL);
            WeShortUrlRequest request = new WeShortUrlRequest(longUrl);
            var result = WeUtil.PostDataToUri(url, request.WriteXml(), new WeShortUrlResponse());
            if (result.ReturnCode == PayResult.Success && result.ResultCode == PayResult.Success)
                return result.ShortUrl;

            return null;
        }

        public static BasePayResponse Report(BasePayResponse response, string outTradeNo,
          string interfaceUrl, int executeTime)
        {
            WeReportRequest request = new WeReportRequest(response, outTradeNo, interfaceUrl, executeTime);
            return PostData<BasePayResponse>(WePayConst.REPORT_URL, request);
        }

        public static WeReverseResponse ReversePay(OrderType orderType, string orderId)
        {
            TkDebug.AssertArgumentNullOrEmpty(orderId, "orderId", null);

            WeReverseRequest request = new WeReverseRequest(orderType, orderId);
            return PostData<WeReverseResponse>(WePayConst.REVERSE_URL, request);
        }
    }
}
