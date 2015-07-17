using System;
using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class WeBill : WeixinResult
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string OrderId { get; protected set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public WeBillStatusType OrderStatus { get; protected set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public int OrderTotalPrice { get; protected set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(WeixinDateTimeConverter))]
        public DateTime OrderCreateTime { get; protected set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public int OrderExpressPrice { get; protected set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        public string BuyerOpenid { get; protected set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.UnderLineLower)]
        public string BuyerNick { get; protected set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.UnderLineLower)]
        public string ReceiverName { get; protected set; }

        [SimpleElement(Order = 90, NamingRule = NamingRule.UnderLineLower)]
        public string ReceiverProvince { get; protected set; }

        [SimpleElement(Order = 100, NamingRule = NamingRule.UnderLineLower)]
        public string ReceiverCity { get; protected set; }

        [SimpleElement(Order = 110, NamingRule = NamingRule.UnderLineLower)]
        public string ReceiverZone { get; protected set; }

        [SimpleElement(Order = 120, NamingRule = NamingRule.UnderLineLower)]
        public string ReceiverAddress { get; protected set; }

        [SimpleElement(Order = 130, NamingRule = NamingRule.UnderLineLower)]
        public string ReceiverMobile { get; protected set; }

        [SimpleElement(Order = 140, NamingRule = NamingRule.UnderLineLower)]
        public string ReceiverPhone { get; protected set; }

        [SimpleElement(Order = 150, NamingRule = NamingRule.UnderLineLower)]
        public string ProductId { get; protected set; }

        [SimpleElement(Order = 160, NamingRule = NamingRule.UnderLineLower)]
        public string ProductName { get; protected set; }

        [SimpleElement(Order = 170, NamingRule = NamingRule.UnderLineLower)]
        public int ProductPrice { get; protected set; }

        [SimpleElement(Order = 180, NamingRule = NamingRule.UnderLineLower)]
        public string ProductSku { get; protected set; }

        [SimpleElement(Order = 190, NamingRule = NamingRule.UnderLineLower)]
        public int ProductCount { get; protected set; }

        [SimpleElement(Order = 200, NamingRule = NamingRule.UnderLineLower)]
        public string ProductImg { get; protected set; }

        [SimpleElement(Order = 210, NamingRule = NamingRule.UnderLineLower)]
        public string DeliveryId { get; protected set; }

        [SimpleElement(Order = 220, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(EnumFieldValueTypeConverter), UseObjectType = true)]
        public WeDeliveryCompany DeliveryCompany { get; protected set; }

        [SimpleElement(Order = 230, NamingRule = NamingRule.UnderLineLower)]
        public string TransId { get; protected set; }

        public static WeixinResult Close(string orderId)
        {
            TkDebug.AssertArgumentNullOrEmpty(orderId, "orderId", null);

            string url = WeUtil.GetUrl(WeShopConst.CLOSE_BILL_URL);
            WeBillId request = new WeBillId(orderId);
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeixinResult());
            return result;
        }

        public static WeBill QueryById(string orderId)
        {
            TkDebug.AssertArgumentNullOrEmpty(orderId, "orderId", null);

            string url = WeUtil.GetUrl(WeShopConst.BILL_ID_URL);
            WeBillId request = new WeBillId(orderId);
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeBillOrder());
            return result.Order;
        }

        public static IEnumerable<WeBill> QueryByStatus(WeBillStatusType status,
            DateTime begintime, DateTime endtime)
        {
            string url = WeUtil.GetUrl(WeShopConst.BILL_STATUS_URL);
            WeBillStatus request = new WeBillStatus()
                                          {
                                              Status = status,
                                              BeginTime = begintime,
                                              EndTime = endtime
                                          };
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeBillList());
            return result.OrderList;
        }

        public static WeixinResult SetNoDelivery(string orderId)
        {
            TkDebug.AssertArgumentNullOrEmpty(orderId, "orderId", null);

            string url = WeUtil.GetUrl(WeShopConst.SET_DELIVERY_URL);
            WeBillDelivery request = new WeBillDelivery(orderId);
            WeixinResult result = WeUtil.PostToUri(url, request.WriteJson(), new WeixinResult());
            return result;
        }

        public static WeixinResult SetDelivery(string orderId, WeDeliveryCompany deliveryCompany,
            string deliveryTrackNo, bool isOthers)
        {
            TkDebug.AssertArgumentNullOrEmpty(orderId, "orderId", null);
            TkDebug.AssertArgumentNullOrEmpty(deliveryTrackNo, "deliveryTrackNo", null);

            string url = WeUtil.GetUrl(WeShopConst.SET_DELIVERY_URL);
            WeBillDelivery request =
                new WeBillDelivery(orderId, isOthers, deliveryCompany, deliveryTrackNo);
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeixinResult());
            return result;
        }
    }
}
