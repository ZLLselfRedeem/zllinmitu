using System;
using System.Collections.Generic;
using System.IO;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Corporation;
using YJC.Toolkit.Weixin.Data;
using YJC.Toolkit.Weixin.Message;
using YJC.Toolkit.Weixin.Rule;
using YJC.Toolkit.Weixin.User;

namespace YJC.Toolkit.Weixin
{
    internal sealed class WeixinToolkitSettings
    {
        private static WeixinToolkitSettings fCurrent;
        private readonly MessageEngine fEngine;
        private readonly WeixinAuthConfig fAuthConfig;
        private readonly WeixinCorpAuthConfig fCorpAuthConfig;
        private readonly IMessageLog fLog;
        private readonly DefaultEngine fNormalDefault;
        private readonly Dictionary<int, DefaultEngine> fCorpDefault;

        internal WeixinToolkitSettings(WeixinExtraXml xml, BaseAppSetting appsetting)
        {
            fCurrent = this;

            fEngine = new MessageEngine();
            if (xml.Weixin.Normal != null)
            {
                fNormalDefault = new DefaultEngine(xml.Weixin.Normal.DefaultMessage);

                fAuthConfig = new WeixinAuthConfig();
                string authFileName = Path.Combine(appsetting.XmlPath, @"Weixin\Auth.xml");
                if (File.Exists(authFileName))
                    fAuthConfig.ReadXmlFromFile(authFileName);
            }
            else if (xml.Weixin.CorpApps != null)
            {
                fCorpDefault = new Dictionary<int, DefaultEngine>();
                foreach (var item in xml.Weixin.CorpApps)
                    fCorpDefault.Add(item.AppId, new DefaultEngine(item.DefaultMessage));

                fCorpAuthConfig = new WeixinCorpAuthConfig();
                string authFileName = Path.Combine(appsetting.XmlPath, @"Weixin\CorpAuth.xml");
                if (File.Exists(authFileName))
                    fCorpAuthConfig.ReadXmlFromFile(authFileName);
            }
            else
                TkDebug.ThrowImpossibleCode(this);

            if (xml.Weixin.MessageLog != null)
                fLog = xml.Weixin.MessageLog.CreateObject();

        }

        internal MessageEngine Engine
        {
            get
            {
                return fEngine;
            }
        }

        public static WeixinToolkitSettings Current
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

        internal string GetStateUrl(string state)
        {
            WeixinSettings.Current.AssertNormalMode();
            return fAuthConfig.GetStateUrl(state);
        }

        internal Tuple<int, string> GetCorpStateUrl(string state)
        {
            WeixinSettings.Current.AssertCorpMode();
            return fCorpAuthConfig.GetStateUrl(state);
        }

        private void ExecuteLog(ReceiveMessage message)
        {
            fLog.Log(message);
        }

        public BaseSendMessage NormalReply(ReceiveMessage message)
        {
            BaseSendMessage result;
            if (Engine.Reply(message, out result))
                return result;
            if (WeixinSettings.Current.EnableService)
            {
                return new ServiceSendMessage(message);
            }
            return fNormalDefault.Reply(message);
        }

        public BaseSendMessage CorpReply(ReceiveMessage message)
        {
            BaseSendMessage result;
            if (Engine.Reply(message, out result))
                return result;

            DefaultEngine defaultEngine;
            if (fCorpDefault.TryGetValue(message.AgentId, out defaultEngine))
                return defaultEngine.Reply(message);
            TkDebug.ThrowToolkitException(string.Format(ObjectUtil.SysCulture,
                "weixin.xml中没有给AppId为{0}配置", message.AgentId), this);
            return null;
        }

        internal void Log(ReceiveMessage message)
        {
            if (fLog != null)
            {
                TkDebug.ThrowIfNoGlobalVariable();
                TkDebug.ThrowIfNoAppSetting();

                if (BaseAppSetting.Current.UseWorkThread)
                    BaseGlobalVariable.Current.BeginInvoke(new Action<ReceiveMessage>(ExecuteLog), message);
                else
                    ExecuteLog(message);
            }
        }
    }
}
