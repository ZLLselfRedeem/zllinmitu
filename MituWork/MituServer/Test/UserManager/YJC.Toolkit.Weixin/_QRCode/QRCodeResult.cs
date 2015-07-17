using System;
using System.Net;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin
{
    public sealed class QRCodeResult : WeixinResult
    {
        internal QRCodeResult()
        {
        }

        [SimpleElement(LocalName = "ticket", Order = 10)]
        public string Ticket { get; private set; }

        [SimpleElement(LocalName = "expire_seconds", Order = 20)]
        public int? ExpireSeconds { get; private set; }

        public byte[] DownloadTicket()
        {
            string url = string.Format(ObjectUtil.SysCulture, WeConst.QR_TICKET,
                Uri.EscapeDataString(Ticket));

            HttpWebResponse response = NetUtil.HttpGet(new Uri(url)).Convert<HttpWebResponse>();
            if (response.StatusCode == HttpStatusCode.OK)
                return NetUtil.GetResponseData(response);
            else
                response.DisposeObject();
            return null;
        }
    }
}
