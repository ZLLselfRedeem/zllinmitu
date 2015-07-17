using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    // ICustomReader 提供给一些需要以特殊方法类的一个借口
    public class WeRefundQueryResponse : BasePayResponse, ICustomReader
    {
        public const string REFUNDNO = "out_refund_no_";
        public const string REFUNDID = "refund_id_";
        public const string REFUNDCHANNEL = "refund_channel_";
        public const string REFUNDFEE = "refund_fee_";
        public const string COUPONREFUNDFEE = "coupon_refund_fee_";
        public const string REFUNDSTATUS = "refund_status_";

        internal readonly Dictionary<int, string> fOutRefundNo;
        internal readonly Dictionary<int, string> fRefundId;
        internal readonly Dictionary<int, RefundChannel> fRefundChannel;
        internal readonly Dictionary<int, int> fRefundFee;
        internal readonly Dictionary<int, int> fCouponRefundFee;
        internal readonly Dictionary<int, RefundStatus> fRefundStatus;

        public WeRefundQueryResponse()
        {
            fOutRefundNo = new Dictionary<int, string>();
            fRefundId = new Dictionary<int, string>();
            fRefundChannel = new Dictionary<int, RefundChannel>();
            fRefundFee = new Dictionary<int, int>();
            fCouponRefundFee = new Dictionary<int, int>();
            fRefundStatus = new Dictionary<int, RefundStatus>();
        }

        [SimpleElement(Order = 100, NamingRule = NamingRule.UnderLineLower)]
        public string DeviceInfo { get; private set; }

        [SimpleElement(Order = 110, NamingRule = NamingRule.UnderLineLower)]
        public string TransactionId { get; private set; }

        [SimpleElement(Order = 120, NamingRule = NamingRule.UnderLineLower)]
        public string OutTradeNo { get; set; }

        [SimpleElement(Order = 130, NamingRule = NamingRule.UnderLineLower)]
        public int RefundCount { get; private set; }

        public CustomPropertyInfo CanRead(string localName)
        {
            if (localName.StartsWith(REFUNDNO, System.StringComparison.Ordinal))
                return new CustomPropertyInfo(typeof(string), new SimpleElementAttribute());
            else if (localName.StartsWith(REFUNDID, System.StringComparison.Ordinal))
                return new CustomPropertyInfo(typeof(string), new SimpleElementAttribute());
            else if (localName.StartsWith(REFUNDCHANNEL, System.StringComparison.Ordinal))
                return new CustomPropertyInfo(typeof(RefundChannel), new SimpleElementAttribute());
            else if (localName.StartsWith(REFUNDFEE, System.StringComparison.Ordinal))
                return new CustomPropertyInfo(typeof(int), new SimpleElementAttribute());
            else if (localName.StartsWith(COUPONREFUNDFEE, System.StringComparison.Ordinal))
                return new CustomPropertyInfo(typeof(int), new SimpleElementAttribute());
            else if (localName.StartsWith(REFUNDSTATUS, System.StringComparison.Ordinal))
                return new CustomPropertyInfo(typeof(RefundStatus), new SimpleElementAttribute());
            else
                return null;
        }

        public object GetValue(string localName)
        {
            return null;
        }

        public void SetValue(string localName, object value)
        {
            if (localName.StartsWith(REFUNDNO, System.StringComparison.Ordinal))
            {
                int index = localName.Substring(14).Value<int>();
                fOutRefundNo[index] = (string)value;
            }
            else if (localName.StartsWith(REFUNDID, System.StringComparison.Ordinal))
            {
                int index = localName.Substring(10).Value<int>();
                fRefundId[index] = (string)value;
            }
            else if (localName.StartsWith(REFUNDCHANNEL, System.StringComparison.Ordinal))
            {
                int index = localName.Substring(15).Value<int>();
                fRefundChannel[index] = (RefundChannel)value;
            }
            else if (localName.StartsWith(REFUNDFEE, System.StringComparison.Ordinal))
            {
                int index = localName.Substring(11).Value<int>();
                fRefundFee[index] = (int)value;
            }
            else if (localName.StartsWith(COUPONREFUNDFEE, System.StringComparison.Ordinal))
            {
                int index = localName.Substring(18).Value<int>();
                fCouponRefundFee[index] = (int)value;
            }
            else if (localName.StartsWith(REFUNDSTATUS, System.StringComparison.Ordinal))
            {
                int index = localName.Substring(14).Value<int>();
                fRefundStatus[index] = (RefundStatus)value;
            }
        }
    }
}
