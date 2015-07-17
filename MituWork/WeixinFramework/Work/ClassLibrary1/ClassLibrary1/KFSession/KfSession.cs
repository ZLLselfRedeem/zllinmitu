using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.KFSession
{
    public class KfSession : WeixinResult
    {
        internal KfSession()
        {
        }

        public KfSession(string kfAccount, string openid)
        {
            TkDebug.AssertArgumentNullOrEmpty(kfAccount, "kfAccount", null);
            TkDebug.AssertArgumentNullOrEmpty(openid, "openid", null);

            KfAccount = kfAccount;
            OpenId = openid;
            CreateTime = DateTime.Now;
        }

        [SimpleElement(Order = 5, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(WeixinDateTimeConverter))]
        public DateTime CreateTime { get; private set; }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string KfAccount { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string OpenId { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public string Text { get; set; }

        public WeixinResult Create()
        {
            string url = WeUtil.GetUrl(WeSessionConst.SESSION_CREATE);
            return WeUtil.PostDataToUri(url, this.WriteJson(), new WeixinResult());
        }

        public WeixinResult Close()
        {
            string url = WeUtil.GetUrl(WeSessionConst.SESSION_CLOSE);
            return WeUtil.PostDataToUri(url, this.WriteJson(), new WeixinResult());
        }

        public static KfSession QueryClientSession(string openid)
        {
            TkDebug.AssertArgumentNullOrEmpty(openid, "openid", null);

            string url = string.Format(ObjectUtil.SysCulture, WeSessionConst.SESSION_GET,
                AccessToken.CurrentToken, openid);
            KfSession session = WeUtil.GetFromUri(url, new KfSession());
            session.OpenId = openid;
            return session;
        }

        public static IEnumerable<KfSession> QueryKfSession(string kfAccount)
        {
            TkDebug.AssertArgumentNullOrEmpty(kfAccount, "kfAccount", null);

            string url = string.Format(ObjectUtil.SysCulture, WeSessionConst.SESSION_LIST_GET,
                AccessToken.CurrentToken, kfAccount);
            var result = WeUtil.GetFromUri(url, new KfSessionList()).Sessions;
            foreach (var res in result)
            {
                res.KfAccount = kfAccount;
            }
            return result;
        }

        public static IEnumerable<KfSession> QueryWaitingSession()
        {
            string url = WeUtil.GetUrl(WeSessionConst.WAIT_CAST_GET);
            return WeUtil.GetFromUri(url, new WaitSessionList()).WaitSessions;
        }

        public static IEnumerable<RecordInfo> GetSeesionRecord(string openid, DateTime start, DateTime end,
            int index, int size)
        {
            RecordQuery query = new RecordQuery(start, end, index, size) { OpenId = openid };
            string url = WeUtil.GetUrl(WeSessionConst.RECORD_GET);
            // WeixinResult resutl = WeUtil.PostDataToUri(url, query.WriteXml(), new SessionRecord());
            string request = query.WriteJson();
            //string xml = query.WriteXml();
            WebResponse response = HttpPost(new Uri(url), Encoding.UTF8.GetBytes(request), "application/json");
            var res = WeUtil.PostDataToUri(url, request, new SessionRecord());
            // var resul = NetUtil.ReadObjectFromResponse(NetUtil.HttpPost(new Uri(url), xml, "text/xml"), null, new SessionRecord());
            return WeUtil.PostDataToUri(url, request, new SessionRecord()).Recoreds;
        }

        private static WebResponse HttpPost(Uri uri, byte[] postData, string contentType)
        {
            WebRequest request = WebRequest.Create(uri);
            Trace.WriteLine(uri.ToString(), "Toolkit HttpPost");
            request.Method = "POST";
            request.ContentType = contentType;
            request.ContentLength = postData.Length;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(postData, 0, postData.Length);
            }
            WebResponse res;
            try
            {
                res = (WebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                res = (WebResponse)ex.Response;
            }
            return res;
        }
    }
}
