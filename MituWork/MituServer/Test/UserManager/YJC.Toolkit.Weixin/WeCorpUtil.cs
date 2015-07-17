using System;
using System.Collections.Generic;
using System.IO;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Corporation;
using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin
{
    public static class WeCorpUtil
    {
        public static bool VerifySignature(string token, string timeStamp, string nonce,
            string msgEncrypt, string sigture)
        {
            string hash = WeUtil.CreateSignature(token, timeStamp, nonce, msgEncrypt);
            return hash == sigture;
        }

        //验证URL
        // @param sMsgSignature: 签名串，对应URL参数的msg_signature
        // @param sTimeStamp: 时间戳，对应URL参数的timestamp
        // @param sNonce: 随机串，对应URL参数的nonce
        // @param sEchoStr: 随机串，对应URL参数的echostr
        // @param sReplyEchoStr: 解密之后的echostr，当return返回0时有效
        // @return：成功0，失败返回对应的错误码
        public static string VerifyURL(int appId, string msgSignature, string timeStamp,
            string nonce, string echoStr)
        {
            Tuple<string, string> token = WeixinSettings.Current.GetToken(appId);
            if (VerifySignature(token.Item1, timeStamp, nonce, echoStr, msgSignature))
            {
                string corpId;
                string result = Cryptography.AesDecrypt(echoStr, token.Item2, out corpId);
                return result;
            }
            return null;
        }

        // 检验消息的真实性，并且获取解密后的明文
        // @param sMsgSignature: 签名串，对应URL参数的msg_signature
        // @param sTimeStamp: 时间戳，对应URL参数的timestamp
        // @param sNonce: 随机串，对应URL参数的nonce
        // @param sPostData: 密文，对应POST请求的数据
        // @param sMsg: 解密后的原文，当return返回0时有效
        // @return: 成功0，失败返回对应的错误码
        public static string DecryptMsg(CorpEncodeReceiveMessage message, string msgSignature,
            string timeStamp, string nonce)
        {
            Tuple<string, string> token = WeixinSettings.Current.GetToken(message.AgentId);

            string encryptMsg = message.Encrypt;

            //verify signature
            if (VerifySignature(token.Item1, timeStamp, nonce, encryptMsg, msgSignature))
            {
                string corpId;
                string sMsg = Cryptography.AesDecrypt(encryptMsg, token.Item2, out corpId);
                return sMsg;
            }
            return null;
        }

        //将企业号回复用户的消息加密打包
        // @param sReplyMsg: 企业号待回复用户的消息，xml格式的字符串
        // @param sTimeStamp: 时间戳，可以自己生成，也可以用URL参数的timestamp
        // @param sNonce: 随机串，可以自己生成，也可以用URL参数的nonce
        // @param sEncryptMsg: 加密后的可以直接回复用户的密文，包括msg_signature, timestamp, nonce, encrypt的xml格式的字符串,
        //						当return返回0时有效
        // return：成功0，失败返回对应的错误码
        public static EncodeReplyMessage EncryptMsg(int appId, string replyMsg,
            string timeStamp, string nonce)
        {
            Tuple<string, string> token = WeixinSettings.Current.GetToken(appId);
            string raw = Cryptography.AesEncrypt(replyMsg, token.Item2, WeixinSettings.Current.AppId);

            return WeUtil.EncodeReplyMessage(timeStamp, nonce, token.Item1, raw);
        }

        public static string GetCorpUrl(string urlTemplate, string secret)
        {
            return string.Format(ObjectUtil.SysCulture, urlTemplate,
                CorpAccessToken.GetTokenWithSecret(secret));
        }

        internal static string GetCorpMenuUrl(string urlTemplate, int appId)
        {
            string secret = WeixinSettings.Current.CorpMenuSecret;
            return string.Format(ObjectUtil.SysCulture, urlTemplate,
                CorpAccessToken.GetTokenWithSecret(secret), appId);
        }

        private static int GetMaxLength(MediaType mediaType)
        {
            int maxLength = 0;
            switch (mediaType)
            {
                case MediaType.Image:
                    maxLength = WeCorpConst.MAX_IMAGE_SIZE;
                    break;
                case MediaType.Voice:
                    maxLength = WeCorpConst.MAX_VOICE_SIZE;
                    break;
                case MediaType.Video:
                    maxLength = WeCorpConst.MAX_VIDEO_SIZE;
                    break;
                case MediaType.File:
                    maxLength = WeCorpConst.MAX_FILE_SIZE;
                    break;
            }
            return maxLength;
        }

        public static DownloadMediaData DownloadFile(string secret, string mediaId)
        {
            TkDebug.AssertArgumentNullOrEmpty(secret, "secret", null);
            TkDebug.AssertArgumentNullOrEmpty(mediaId, "mediaId", null);

            string url = string.Format(ObjectUtil.SysCulture, WeCorpConst.DOWNLOAD_URL,
                CorpAccessToken.GetTokenWithSecret(secret), mediaId);
            return WeUtil.InternalDownloadData(url);
        }

        public static MediaId UploadFile(string secret, MediaType mediaType, string path)
        {
            TkDebug.AssertArgumentNullOrEmpty(path, "path", null);

            byte[] data = File.ReadAllBytes(path);
            return UploadFile(secret, mediaType, path, data);
        }

        public static MediaId UploadFile(string secret, MediaType mediaType,
            string fileName, byte[] fileData)
        {
            TkDebug.AssertArgumentNullOrEmpty(secret, "secret", null);
            TkDebug.AssertArgumentNullOrEmpty(fileName, "fileName", null);
            TkDebug.AssertArgumentNull(fileData, "fileData", null);

            int maxLength = GetMaxLength(mediaType);
            string url = string.Format(ObjectUtil.SysCulture, WeCorpConst.UPLOAD_URL,
                CorpAccessToken.GetTokenWithSecret(secret),
                mediaType.ToString().ToLower(ObjectUtil.SysCulture));

            return WeUtil.InternalUploadFile(mediaType, fileName, fileData, maxLength, url);
        }

        internal static CorpAuthToken GetToken(int appId, string code)
        {
            //var current = WeixinSettings.Current;
            string url = string.Format(ObjectUtil.SysCulture, WeCorpConst.AUTH_ACCESS_TOKEN,
                CorpAccessToken.GetTokenWithAppId(appId), code, appId);
            return WeUtil.GetFromUri<CorpAuthToken>(url);
        }

        public static List<string> GetServerIpList()
        {
            string url = GetCorpUrl(WeCorpConst.IP_LIST, WeixinSettings.Current.CorpUserManagerSecret);
            var result = WeUtil.GetFromUri<WeIpList>(url);
            return result.IpList;
        }
    }
}
