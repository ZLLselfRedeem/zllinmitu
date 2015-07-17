using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    public class WePaymentRequest : WeCloseOrderRequest
    {
        public static readonly string LocallIp = GetLocalIP();

        private WePaymentRequest()
        {
            DeviceInfo = "1000";
            SpbillCreateIp = LocallIp;
        }

        public WePaymentRequest(string body, int totalFee, string notifyUrl,
            WePaymentType tradeType)
            : this()
        {
            TkDebug.AssertArgumentNullOrEmpty(body, "body", null);
            TkDebug.AssertArgumentNullOrEmpty(notifyUrl, "notifyUrl", null);

            Body = body;
            TotalFee = totalFee;
            NotifyUrl = notifyUrl;
            TradeType = tradeType;
        }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        public string DeviceInfo { get; set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.Camel, UseCData = true)]
        public string Body { get; private set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.Camel)]
        public string Attach { get; set; }

        [SimpleElement(Order = 90, NamingRule = NamingRule.UnderLineLower)]
        public int TotalFee { get; private set; }

        [SimpleElement(Order = 100, NamingRule = NamingRule.UnderLineLower)]
        public string SpbillCreateIp { get; private set; }

        [SimpleElement(Order = 110, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(DateTimeStringTypeConverter))]
        public DateTime TimeStart { get; set; }

        [SimpleElement(Order = 120, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(DateTimeStringTypeConverter))]
        public DateTime TimeExpire { get; set; }

        [SimpleElement(Order = 130, NamingRule = NamingRule.UnderLineLower)]
        public string GoodsTag { get; set; }

        [SimpleElement(Order = 140, NamingRule = NamingRule.UnderLineLower)]
        public string NotifyUrl { get; private set; }

        [SimpleElement(Order = 150, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(UpperCaseEnumConverter), UseObjectType = true)]
        public WePaymentType TradeType { get; private set; }

        [SimpleElement(Order = 160, NamingRule = NamingRule.Camel)]
        public string Openid { get; set; }

        [SimpleElement(Order = 170, NamingRule = NamingRule.UnderLineLower)]
        public string ProductId { get; set; }

        [SimpleElement(Order = 180, NamingRule = NamingRule.UnderLineLower)]
        public string PrepayId { get; set; }

        [SimpleElement(Order = 190, NamingRule = NamingRule.UnderLineLower)]
        public string CodeUrl { get; set; }

        private static string GetLocalIP()
        {
            IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
            var result = (from item in ipEntry.AddressList
                          where item.AddressFamily == AddressFamily.InterNetwork
                          select item.ToString()).FirstOrDefault();
            return result;
        }

        public WePaymentRequest Pay()
        {
            string url = WeUtil.GetUrl(WePayConst.UNIFIED_ORDER_URL);
            var result = WeUtil.PostDataToUri(url, this.WriteXml(), new WePaymentResponse());
            TradeType = result.TradeType;
            PrepayId = result.PrepayId;
            CodeUrl = result.CodeUrl;
            return this;
        }

        public WeOrderQueryResponse Query()
        {
            string url = WeUtil.GetUrl(WePayConst.ORDER_QUERY_URL);
            var result = WeUtil.PostDataToUri(url, this.WriteXml(), new WeOrderQueryResponse());
            return result;
        }

        public WeCloseOrderResponse OrderClose()
        {
            string url = WeUtil.GetUrl(WePayConst.CLOSE_ORDER_URL);
            var result = WeUtil.PostDataToUri(url, this.WriteXml(), new WeCloseOrderResponse());
            return result;
        }

        public static WeRefundResponse Refund(string orderId, int totalFee, int refundFee,
                                             string opUserId, WeOrderName orderName)
        {
            TkDebug.AssertArgumentNullOrEmpty(orderId, "outRefundNo", null);
            TkDebug.AssertArgumentNullOrEmpty(opUserId, "opUserId", null);

            string url = WeUtil.GetUrl(WePayConst.REFUND_URL);
            WeRefundRequest request = new WeRefundRequest(orderId, totalFee, refundFee, opUserId, orderName);
            WeRefundResponse result = WeUtil.PostDataToUri(url, request.WriteXml(), new WeRefundResponse());
            return result;
        }

        public static WeRefundQueryResponse RefundQuery(string orderId, WeOrderName orderName)
        {
            TkDebug.AssertArgumentNullOrEmpty(orderId, "orderId", null);

            string url = WeUtil.GetUrl(WePayConst.REFUND_QUERY_URL);
            WeRefundQueryRequest request = new WeRefundQueryRequest(orderId, orderName);
            var result = WeUtil.PostDataToUri(url, request.WriteXml(), new WeRefundQueryResponse());
            return result;
        }

        public static WeDownloadBillResponse DownloadBill(string billDate)
        {
            TkDebug.AssertArgumentNullOrEmpty(billDate, "billDate", null);

            string url = WeUtil.GetUrl(WePayConst.DOWNLOAD_BILL_URL);
            DateTime dTime = DateTime.Parse(billDate);
            WeDownloadBillRequest request = new WeDownloadBillRequest(dTime);
            var result = WeUtil.PostDataToUri(url, request.WriteXml(), new WeDownloadBillResponse());
            return result;
        }

        public static WeShortUrlResponse ShortUrl(string longUrl)
        {
            TkDebug.AssertArgumentNullOrEmpty(longUrl, "longUrl", null);

            string url = WeUtil.GetUrl(WePayConst.SHORT_URL);
            WeShortUrlRequest request = new WeShortUrlRequest(longUrl);
            var result = WeUtil.PostDataToUri(url, request.WriteXml(), new WeShortUrlResponse());
            return result;
        }

        public static WeReportResponse Report(string interfaceUrl, int executeTime,
                                            WePaymentResultCode returnCode, WePaymentResultCode resultCode)
        {
            TkDebug.AssertArgumentNullOrEmpty(interfaceUrl, "interfaceUrl", null);

            string url = WeUtil.GetUrl(WePayConst.REPORT_URL);
            WeReportRequest request = new WeReportRequest(interfaceUrl, executeTime, returnCode, resultCode);
            var result = WeUtil.PostDataToUri(url, request.WriteXml(), new WeReportResponse());
            return result;
        }
    }
}
