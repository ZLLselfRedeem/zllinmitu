using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Corporation;
using YJC.Toolkit.Weixin.Menu;
using YJC.Toolkit.Weixin.Message;
//using YJC.Toolkit.Weixin.Pay;
using YJC.Toolkit.Weixin.User;

namespace YJC.Toolkit.Weixin
{
    public static class WeUtil
    {
        private const int NONCE_LENGTH = 32;

        private static readonly DateTime Start = TimeZone.CurrentTimeZone.ToLocalTime(
            new DateTime(1970, 1, 1));
        private readonly static char[] CHARS =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
        private readonly static WriteSettings DefaultXmlSettings = new WriteSettings
        {
            CloseInput = true,
            Encoding = ToolkitConst.UTF8,
            OmitHead = true
        };
        public static readonly QName QNAME_XML = QName.Get("xml");

        static WeUtil()
        {
            // 微信某些HTTPS地址存在权限问题
            ServicePointManager.ServerCertificateValidationCallback += ValidateServerCertificate;
        }

        private static bool ValidateServerCertificate(object sender, X509Certificate certificate,
            X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        internal static string InteralCreateSignature(string raw)
        {
            using (var sha = new SHA1CryptoServiceProvider())
            {
                byte[] dataToHash = Encoding.ASCII.GetBytes(raw);
                byte[] dataHashed = sha.ComputeHash(dataToHash);
                string hash = StringUtil.BinaryToHex(dataHashed, true);
                return hash;
            }
        }

        internal static string CreateSignature(params string[] stringList)
        {
            Array.Sort(stringList, WeixinStringComparer.Comparer);
            string raw = string.Join(string.Empty, stringList);

            return InteralCreateSignature(raw);
        }

        internal static EncodeReplyMessage EncodeReplyMessage(string timeStamp, string nonce,
            string token, string raw)
        {
            string msgSigature = CreateSignature(token, timeStamp, nonce, raw);
            if (msgSigature == null)
                return null;
            EncodeReplyMessage msg = new EncodeReplyMessage(raw, msgSigature, timeStamp, nonce);
            return msg;
        }

        public static DateTime ToDateTime(int createTime)
        {
            long tick = createTime * 10000000L;
            return Start + new TimeSpan(tick);
        }

        public static int ToCreateTime(DateTime date)
        {
            return (int)(date - Start).TotalSeconds;
        }

        public static bool CheckSignature(string signature, string timestamp, string nonce)
        {
            string tmpStr = CreateSignature(WeixinSettings.Current.Token, timestamp, nonce);

            return tmpStr == signature;
        }

        public static MediaId UploadFile(MediaType mediaType, string path)
        {
            TkDebug.AssertArgumentNullOrEmpty(path, "path", null);

            byte[] data = File.ReadAllBytes(path);
            return UploadFile(mediaType, path, data);
        }

        private static int GetMaxLength(MediaType mediaType)
        {
            int maxLength = 0;
            switch (mediaType)
            {
                case MediaType.Image:
                    maxLength = WeConst.MAX_IMAGE_SIZE;
                    break;
                case MediaType.Voice:
                    maxLength = WeConst.MAX_VOICE_SIZE;
                    break;
                case MediaType.Video:
                    maxLength = WeConst.MAX_VIDEO_SIZE;
                    break;
                case MediaType.Thumb:
                    maxLength = WeConst.MAX_THUMB_SIZE;
                    break;
            }
            return maxLength;
        }

        internal static MediaId InternalUploadFile(MediaType mediaType, string fileName,
            byte[] fileData, int maxLength, string url)
        {
            int length = fileData.Length;
            if (length > maxLength)
            {
                string message = string.Format(ObjectUtil.SysCulture,
                    "{0}类型的最大长度是{1}k，当前的文件{2}的长度是{3}k，超长了",
                    mediaType, maxLength >> 10, fileName, length >> 10);
                throw new ToolkitException(message, null);
            }

            MediaId result = new MediaId();
            return UploadFile(url, fileName, fileData, result);
        }

        public static MediaId UploadFile(MediaType mediaType, string fileName, byte[] fileData)
        {
            TkDebug.AssertArgumentNullOrEmpty(fileName, "fileName", null);
            TkDebug.AssertArgumentNull(fileData, "fileData", null);

            int maxLength = GetMaxLength(mediaType);
            string url = string.Format(ObjectUtil.SysCulture, WeConst.UPLOAD_URL,
                AccessToken.CurrentToken, mediaType.ToString().ToLower(ObjectUtil.SysCulture));

            return InternalUploadFile(mediaType, fileName, fileData, maxLength, url);
        }

        internal static DownloadMediaData InternalDownloadData(string url)
        {
            WebResponse response = NetUtil.HttpGet(new Uri(url));
            if (response.ContentType == "text/plain")
            {
                WeixinResult result = new WeixinResult();
                return new DownloadMediaData(NetUtil.ReadObjectFromResponse(response, null, result));
            }
            else
            {
                byte[] data = NetUtil.GetResponseData(response);
                return new DownloadMediaData(data);
            }
        }

        public static DownloadMediaData DownloadFile(string mediaId)
        {
            TkDebug.AssertArgumentNullOrEmpty(mediaId, "mediaId", null);

            string url = string.Format(ObjectUtil.SysCulture, WeConst.DOWNLOAD_URL,
                AccessToken.CurrentToken, mediaId);
            return InternalDownloadData(url);
        }

        public static string CreateAuthUrl(string url, AuthType authType, string state)
        {
            TkDebug.AssertArgumentNullOrEmpty(url, "url", null);

            string authUrl = string.Format(ObjectUtil.SysCulture, WeConst.AUTH_URL,
               WeixinSettings.Current.AppId, Uri.EscapeDataString(url),
               "snsapi_" + authType.ToString().ToLower(ObjectUtil.SysCulture), state ?? string.Empty);

            return authUrl;
        }
        //public static string GetSXCode(TkDbContext context, string province, string city,
        //    string defaultCode = "000000")
        //{
        //    const string sql = "SELECT MIN(CODE_VALUE) FROM CD_SX";
        //    IParamBuilder builder = SqlParamBuilder.CreateParamBuilder(
        //        SqlParamBuilder.CreateEqualSql(context, "CODE_WX_PROVINCE", TkDataType.String, province),
        //        SqlParamBuilder.CreateEqualSql(context, "CODE_WX_CITY", TkDataType.String, city));
        //    object value = DbUtil.ExecuteScalar(sql, context, builder);
        //    if (value == DBNull.Value)
        //        return defaultCode;
        //    return value.ToString();
        //}

        public static T PostDataToUri<T>(string url, string postData, T obj)
        {
            return PostDataToUri(url, null, postData, obj);
        }

        public static T PostDataToUri<T>(string url, string modelName, string postData, T obj)
        {
            WebResponse response = NetUtil.HttpPost(new Uri(url), postData, ContentTypeConst.JSON);
            return NetUtil.ReadObjectFromResponse(response, modelName, obj);
        }

        public static T PostToUri<T>(string url, string postData, T obj) where T : WeixinResult
        {
            return PostToUri(url, null, postData, obj, true);
        }

        public static T PostToUri<T>(string url, string modelName, string postData,
            T obj) where T : WeixinResult
        {
            return PostToUri(url, modelName, postData, obj, true);
        }

        public static T PostToUri<T>(string url, string modelName, string postData, T obj,
            bool checkError) where T : WeixinResult
        {
            T result = PostDataToUri(url, modelName, postData, obj);
            if (checkError && result.IsError)
                throw new WeixinException(result);
            return result;
        }

        public static T GetFromUri<T>(string url) where T : WeixinResult, new()
        {
            T obj = new T();
            return GetFromUri(url, null, obj, true);
        }

        public static T GetFromUri<T>(string url, T obj) where T : WeixinResult
        {
            return GetFromUri(url, null, obj, true);
        }

        public static T GetFromUri<T>(string url, string modelName, T obj,
            bool checkError) where T : WeixinResult
        {
            T result = NetUtil.HttpGetReadJson(new Uri(url), modelName, obj);
            if (checkError && result.IsError)
                throw new WeixinException(result);

            return result;
        }

        public static T UploadFile<T>(string url, string fileName, byte[] fileData, T obj)
        {
            WebResponse response = NetUtil.FormUploadFile(new Uri(url), "media", fileName, fileData);
            return NetUtil.ReadObjectFromResponse(response, null, obj);
        }

        public static string GetUrl(string urlTemplate)
        {
            return string.Format(ObjectUtil.SysCulture, urlTemplate, AccessToken.CurrentToken);
        }

        internal static AuthToken GetToken(string code)
        {
            var current = WeixinSettings.Current;
            string url = string.Format(ObjectUtil.SysCulture, WeConst.AUTH_ACCESS_TOKEN,
                current.AppId, current.AppSecret, code);
            return NetUtil.HttpGetReadJson<AuthToken>(new Uri(url));
        }

        internal static WeixinXml GetWeixinXml(string weixinXml)
        {
            WeixinXml xml = new WeixinXml();
            xml.ReadXmlFromFile(weixinXml);
            return xml;
        }

        internal static WeixinMenuXml LoadMenu(WeixinMenuConfigItem menuItem)
        {
            if (menuItem == null)
                return null;

            string path = Path.Combine(WeixinSettings.Current.WeixinPath, menuItem.FileName);
            WeixinMenuXml xml = new WeixinMenuXml();
            xml.ReadXmlFromFile(path);

            return xml;
        }

        public static EncodeReplyMessage EncryptMsg(string replyMsg, string timeStamp, string nonce)
        {
            var setting = WeixinSettings.Current;
            string raw = Cryptography.AesEncrypt(replyMsg, setting.EncodingAESKey, setting.AppId);

            return EncodeReplyMessage(timeStamp, nonce, setting.Token, raw);
        }

        public static string DecryptMsg(EncodeReceiveMessage message, string msgSignature,
            string timeStamp, string nonce)
        {
            string encryptMsg = message.Encrypt;

            var setting = WeixinSettings.Current;
            //verify signature
            if (WeCorpUtil.VerifySignature(setting.Token, timeStamp, nonce, encryptMsg, msgSignature))
            {
                string appId;
                string sMsg = Cryptography.AesDecrypt(encryptMsg, setting.EncodingAESKey, out appId);
                return sMsg;
            }
            return null;
        }

        public static string CreateShortUrl(string longUrl)
        {
            TkDebug.AssertArgumentNullOrEmpty(longUrl, "longUrl", null);

            ShortUrlInput input = new ShortUrlInput { LongUrl = longUrl };
            string url = GetUrl(WeConst.SHORT_URL);
            var result = PostToUri(url, input.WriteJson(), new ShortUrlResult());
            return result.ShortUrl;
        }

        public static string Md5(string text)
        {
            TkDebug.AssertArgumentNullOrEmpty(text, "text", null);

            using (MD5 md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.UTF8.GetBytes(text));
                return StringUtil.BinaryToHex(result, false);
            }
        }

        public static string CreateNonceStr()
        {
            char[] data = new char[NONCE_LENGTH];
            int srcLength = CHARS.Length;
            Random rand = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            for (int i = 0; i < NONCE_LENGTH; ++i)
                data[i] = CHARS[rand.Next(srcLength)];

            return new string(data);
        }

        public static List<string> GetServerIpList()
        {
            string url = GetUrl(WeConst.IP_LIST);
            var result = WeUtil.GetFromUri<WeIpList>(url);
            return result.IpList;
        }

        public static string ToXml(object obj)
        {
            string xml = obj.WriteXml(DefaultXmlSettings, QNAME_XML);
            return xml;
        }
    }
}
