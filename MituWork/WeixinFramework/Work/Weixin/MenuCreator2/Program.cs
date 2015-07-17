using System;
using System.IO;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Menu;

namespace YJC.Toolkit.Weixin.MenuCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            // 注意命令行参数，尤其是地址中不能出现空格
            Argument arg = new Argument(args);
            ToolApp.Initialize(false);

            Process(arg);
            Console.ReadKey();
        }

        private static void WriteResult(WeixinResult result, string successString)
        {
            if (result.IsError)
                Console.WriteLine(result.ErrorMsg);
            else
                Console.WriteLine(successString);
        }

        private static void ProcessNormalMode(Argument arg, WeixinXml xml)
        {
            WeMenu menu;
            WeixinResult result;
            switch (arg.Action)
            {
                case MenuAction.Create:
                    WeixinMenuXml menuXml = WeUtil.LoadMenu(xml.Weixin.Normal.Menu);
                    if (menuXml == null)
                    {
                        Console.WriteLine("没有配置菜单，不创建");
                        break;
                    }
                    menu = menuXml.CreateMenu();
                    if (arg.PrintMenu)
                    {
                        Console.WriteLine(menu.ToJson());
                    }
                    else
                    {
                        result = menu.CreateMenu();
                        WriteResult(result, "菜单创建成功");
                    }
                    break;
                case MenuAction.Query:
                    menu = WeMenu.QueryMenu();
                    WriteResult(menu, menu.ToJson());
                    break;
                case MenuAction.Delete:
                    result = WeMenu.DeleteMenu();
                    WriteResult(result, "菜单删除成功");
                    break;
            }
        }

        private static WeixinXml InitializeContext(Argument arg)
        {
            WeixinXml xml = WeUtil.GetWeixinXml(arg.WeixinXml);
            new WeixinSettings(xml);
            ApplicationXml appXml = new ApplicationXml();
            appXml.ReadXmlFromFile(arg.ApplicationXml);
            if (appXml.Hosts != null)
                foreach (var item in appXml.Hosts)
                    ToolApp.AddHost(item.Key, item.Value);
            return xml;
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

        private static string GetAppName(WeixinCorpConfig config)
        {
            return string.Format(ObjectUtil.SysCulture, "应用[{0}]", config.AppName);
        }

        private static void ProcessCorpMode(Argument arg, WeixinXml xml)
        {
            if (string.IsNullOrEmpty(arg.Appid))
            {
                switch (arg.Action)
                {
                    case MenuAction.Create:
                        foreach (var item in xml.Weixin.CorpApps)
                        {
                            CreateMenu(arg, item);
                        }
                        break;
                    case MenuAction.Query:
                        foreach (var item in xml.Weixin.CorpApps)
                        {
                            QueryMenu(item);
                        }
                        break;
                    case MenuAction.Delete:
                        foreach (var item in xml.Weixin.CorpApps)
                        {
                            DeleteMenu(item);
                        }
                        break;
                }
            }
            else
            {
                var item = xml.Weixin.CorpApps[arg.Appid];
                if (item != null)
                    switch (arg.Action)
                    {
                        case MenuAction.Create:
                            CreateMenu(arg, item);
                            break;
                        case MenuAction.Query:
                            QueryMenu(item);
                            break;
                        case MenuAction.Delete:
                            DeleteMenu(item);
                            break;
                    }
                else
                    Console.WriteLine(DataString.Invalid, "Appid");
            }
        }

        private static void CreateMenu(Argument arg, WeixinCorpConfig item)
        {
            WeixinMenuXml menuXml = WeUtil.LoadMenu(item.Menu);
            if (menuXml != null)
            {
                WeMenu menu = menuXml.CreateMenu();

                Console.WriteLine(GetAppName(item));
                if (arg.PrintMenu)
                {
                    Console.WriteLine(menu.ToJson());
                }
                else
                {
                    var result = menu.CreateCorpMenu(item.AppId);
                    WriteResult(result, "菜单创建成功");
                }
            }
        }

        private static void QueryMenu(WeixinCorpConfig item)
        {
            Console.WriteLine(GetAppName(item));
            WeMenu menu = WeMenu.QueryCorpMenu(item.AppId);
            WriteResult(menu, menu.ToJson());
        }

        private static void DeleteMenu(WeixinCorpConfig item)
        {
            Console.WriteLine(GetAppName(item));
            var result = WeMenu.DeleteCorpMenu(item.AppId);
            WriteResult(result, "菜单删除成功");
        }

        private static void Process(Argument arg)
        {
            if (arg.Help)
            {
                Console.WriteLine(DataString.Usage);
                return;
            }

            if (arg.Error)
            {
                Console.WriteLine(DataString.Invalid, "命令行参数");
                return;
            }

            if (!CheckFile(arg.WeixinXml))
                return;
            if (!CheckFile(arg.ApplicationXml))
                return;

            WeixinXml xml = InitializeContext(arg);

            if (WeixinSettings.Current.Mode == WeixinMode.Normal)
                ProcessNormalMode(arg, xml);
            else
                ProcessCorpMode(arg, xml);
        }
    }
}
