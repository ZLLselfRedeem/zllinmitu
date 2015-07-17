using System;
using System.IO;
using YJC.Toolkit.Collections;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin
{
    public class WeixinSettings
    {
        private static WeixinSettings fCurrent;
        private readonly string fToken;
        private readonly string fAppSecret;
        private readonly RegNameList<WeixinCorpConfig> fCorpApps;
        private readonly string fCorpUserManagerSecret;
        private readonly string fCorpMenuSecret;
        private readonly RegNameList<TemplateMessageConfig> fTemplateMessages;
        private readonly string fMchId;
        private readonly string fPayKey;
        private readonly bool fUsePay;
        private readonly string fDeviceIp;
        private readonly string fDeviceInfo;
        private readonly string fPayNotifyUrl;
        private readonly string fWeixinAccount;
        private readonly bool fEnableService;

        internal WeixinSettings(WeixinXml xml)
        {
            AppId = xml.Weixin.AppId;
            LogRawMessage = xml.Weixin.LogRawMessage;
            WeixinPath = Path.GetDirectoryName(xml.FullPath);
            UseLogOnRight = xml.Weixin.UseLogOnRight;

            WeixinNormalConfig normalConfig = xml.Weixin.Normal;
            if (normalConfig != null)
            {
                Mode = WeixinMode.Normal;
                OpenId = normalConfig.OpenId;
                fAppSecret = normalConfig.Secret;
                fToken = normalConfig.Token;
                MessageMode = normalConfig.MessageMode;
                EncodingAESKey = normalConfig.EncodingAESKey;
                fTemplateMessages = normalConfig.TemplateMessages;
                PaymentConfigItem pay = normalConfig.Pay;
                if (pay != null)
                {
                    fUsePay = true;
                    fMchId = pay.MchId;
                    fPayKey = pay.Key;
                    fDeviceInfo = pay.DeviceInfo;
                    fDeviceIp = pay.DeviceIp;
                    fPayNotifyUrl = UriUtil.CombineUri(pay.NotifyBaseUrl, pay.NotifyUrl).ToString();
                }
                WeixinServiceConfigItem service = normalConfig.Service;
                if (service != null)
                {
                    fEnableService = service.Enabled;
                    fWeixinAccount = service.WeixinAccount;
                }
                else
                    fEnableService = false;

                if (MessageMode != MessageMode.Normal)
                    TkDebug.AssertArgumentNullOrEmpty(EncodingAESKey,
                        "当消息是混合或者安全模式时，请配置EncodingAESKey的内容", xml);
            }
            else if (xml.Weixin.CorpApps != null)
            {
                Mode = WeixinMode.Corporation;
                fCorpApps = xml.Weixin.CorpApps;
                TkDebug.Assert(fCorpApps.Count > 0,
                    "至少需要配置一个tk:CorpApp节点", xml);
                CorpSecretConfig corpSecret = xml.Weixin.CorpSecret;
                TkDebug.AssertNotNull(corpSecret, "需要配置tk:CorpSecret节点", xml);
                fCorpUserManagerSecret = corpSecret.UserManager;
                fCorpMenuSecret = corpSecret.Menu;
                if (string.IsNullOrEmpty(fCorpMenuSecret))
                    fCorpMenuSecret = fCorpUserManagerSecret;
                OpenId = AppId;
            }
            else
                TkDebug.ThrowImpossibleCode(xml);
            fCurrent = this;
        }

        internal string WeixinPath { get; private set; }

        public WeixinMode Mode { get; private set; }

        public MessageMode MessageMode { get; private set; }

        public string EncodingAESKey { get; private set; }

        public string AppId { get; private set; }

        public bool LogRawMessage { get; private set; }

        public bool UseLogOnRight { get; private set; }

        public string MchId
        {
            get
            {
                AssertPayMode();
                return fMchId;
            }
        }

        public string PayKey
        {
            get
            {
                AssertPayMode();
                return fPayKey;
            }
        }


        public string DeviceInfo
        {
            get
            {
                AssertPayMode();
                return fDeviceInfo;
            }
        }

        public string PayNotifyUrl
        {
            get
            {
                AssertPayMode();
                return fPayNotifyUrl;
            }
        }

        public string DeviceIp
        {
            get
            {
                AssertPayMode();
                return fDeviceIp;
            }
        }

        internal RegNameList<WeixinCorpConfig> CorpApps
        {
            get
            {
                return fCorpApps;
            }
        }

        internal RegNameList<TemplateMessageConfig> TemplateMessages
        {
            get
            {
                return fTemplateMessages;
            }
        }

        public string Token
        {
            get
            {
                AssertNormalMode();
                return fToken;
            }
        }

        public string WeixinAccount
        {
            get
            {
                AssertNormalMode();
                return fWeixinAccount;
            }
        }

        public bool EnableService
        {
            get
            {
                AssertNormalMode();
                return fEnableService;
            }
        }


        public string CorpMenuSecret
        {
            get
            {
                AssertCorpMode();
                return fCorpMenuSecret;
            }
        }

        public string AppSecret
        {
            get
            {
                AssertNormalMode();
                return fAppSecret;
            }
        }


        public string OpenId { get; private set; }

        public string CorpUserManagerSecret
        {
            get
            {
                AssertCorpMode();
                return fCorpUserManagerSecret;
            }
        }

        public static WeixinSettings Current
        {
            get
            {
                if (fCurrent == null)
                {
                    string path = Path.Combine(BaseAppSetting.Current.XmlPath, "weixin.xml");
                    TkDebug.ThrowToolkitException(string.Format(ObjectUtil.SysCulture,
                        "{0}没有配置，请检查确认", path), null);
                }
                return fCurrent;
            }
            internal set
            {
                fCurrent = value;
            }
        }

        private void AssertPayMode()
        {
            TkDebug.Assert(fUsePay, "没有在weixin.xml中配置tk:Pay节点", this);
        }

        internal void AssertCorpMode()
        {
            TkDebug.Assert(Mode == WeixinMode.Corporation, string.Format(ObjectUtil.SysCulture,
                "当前模式是{0}，只有在Corporation下才能使用该方法", Mode), this);
        }

        internal void AssertNormalMode()
        {
            TkDebug.Assert(Mode == WeixinMode.Normal, string.Format(ObjectUtil.SysCulture,
                "当前模式是{0}，只有在Normal下才能使用该属性", Mode), this);
        }

        private WeixinCorpConfig GetCorpConfig(int appId)
        {
            AssertCorpMode();

            WeixinCorpConfig config = fCorpApps[appId.ToString()];
            TkDebug.AssertNotNull(config, string.Format(ObjectUtil.SysCulture,
                "配置中不存在AppId为{0}的CorpApp，请确认", appId), this);
            return config;
        }

        public string GetTemplateId(string templateValue)
        {
            TkDebug.AssertArgumentNullOrEmpty(templateValue, "templateValue", this);

            if (fTemplateMessages == null)
                TkDebug.ThrowToolkitException("没有在weixin.xml配置模板消息", this);
            var msg = fTemplateMessages[templateValue];
            TkDebug.AssertNotNull(msg, string.Format(ObjectUtil.SysCulture,
                "没有在weixin.xml配置名称为{0}的模板消息", templateValue), this);

            return msg.TemplateId;
        }

        public string GetCorpSecret(int appId)
        {
            var config = GetCorpConfig(appId);

            return config.Secret;
        }

        public Tuple<string, string> GetToken(int appId)
        {
            var config = GetCorpConfig(appId);

            return Tuple.Create(config.Token, config.EncodingAESKey);
        }
    }
}
