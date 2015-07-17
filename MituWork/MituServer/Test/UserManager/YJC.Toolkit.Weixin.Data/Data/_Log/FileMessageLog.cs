using System;
using System.IO;
using System.Text;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Data
{
    internal class FileMessageLog : IMessageLog
    {
        public FileMessageLog(string basePath)
        {
            if (string.IsNullOrEmpty(basePath))
                BasePath = Path.Combine(BaseAppSetting.Current.XmlPath, @"weixin\log");
            else
                BasePath = basePath;

            if (!Directory.Exists(BasePath))
                Directory.CreateDirectory(BasePath);
        }

        #region IMessageLog 成员

        public void Log(ReceiveMessage message)
        {
            string fileName = DateTime.Now.ToString("yyyyMMdd_hhmmss_ffff",
                ObjectUtil.SysCulture) + ".xml";
            string content = message.WriteXml();

            FileUtil.SaveFile(Path.Combine(BasePath, fileName), content, Encoding.UTF8);
        }

        #endregion

        public string BasePath { get; private set; }
    }
}
