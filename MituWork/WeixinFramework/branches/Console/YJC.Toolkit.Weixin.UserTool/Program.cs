using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.UserTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Argument arg = new Argument(args);
            ToolApp.Initialize(false);
            Process(arg);

            Console.ReadKey();
        }

        private static bool InitializeContext(Argument arg)
        {
            WeixinXml xml = WeUtil.GetWeixinXml(arg.WeixinXml);
            new WeixinSettings(xml);
            ApplicationXml appXml = new ApplicationXml();
            appXml.ReadXmlFromFile(arg.ApplicationXml);
            if (appXml.Databases != null)
            {
                DbContextConfig config = appXml.Databases["Weixin"];
                if (config != null)
                {
                    ToolApp.AddContextConfig(config);
                    return true;
                }
            }

            Console.WriteLine(string.Format(ObjectUtil.SysCulture, 
                DataString.NoDbConfig, arg.ApplicationXml));
            return false;
        }

        private static bool CheckFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine(string.Format(ObjectUtil.SysCulture, DataString.NoFile, fileName));
                return false;
            }
            return true;
        }

        private static void Process(Argument arg)
        {
            if (arg.Help)
            {
                Console.WriteLine(DataString.Usage);
                return;
            }

            if (!CheckFile(arg.WeixinXml))
                return;
            if (!CheckFile(arg.ApplicationXml))
                return;

            if (!InitializeContext(arg))
                return;
            //if (WeixinSettings.Current.Mode == WeixinMode.Normal)
            //    ProcessNormalMode(arg, xml);
            //else
            //    ProcessCorpMode(arg, xml);
        }
    }
}
