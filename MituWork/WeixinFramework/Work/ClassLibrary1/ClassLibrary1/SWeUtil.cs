using System;
using System.Text;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    public static class SWeUtil
    {
        public static string ToXml(object obj)
        {
            WriteSettings settings = new WriteSettings
            {
                CloseInput = true,
                Encoding = new UTF8Encoding(false),
                OmitHead = true
            };
            string xml = obj.WriteXml(settings, WePayConst.QNAME_XML);
            return xml;
        }

        public static void Traversal(RefundInquiryResponse rf)
        {
            foreach (var key in rf.fOutRefundNo)
            {
                Console.WriteLine("Number:{0}, Value:{1}.", key.Key, key.Value);
            }
            foreach (var key in rf.fRefundId)
            {
                Console.WriteLine("Number:{0}, Value:{1}.", key.Key, key.Value);
            }
            foreach (var key in rf.fRefundChannel)
            {
                Console.WriteLine("Number:{0}, Value:{1}.", key.Key, key.Value);
            }
            foreach (var key in rf.fRefundFee)
            {
                Console.WriteLine("Number:{0}, Value:{1}.", key.Key, key.Value);
            }
            foreach (var key in rf.fCouponRefundFee)
            {
                Console.WriteLine("Number:{0}, Value:{1}.", key.Key, key.Value);
            }
            foreach (var key in rf.fRefundStatus)
            {
                Console.WriteLine("Number:{0}, Value:{1}.", key.Key, key.Value);
            }
        }
    }
}
