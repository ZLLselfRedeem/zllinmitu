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
            Argument arg = new Argument(args);

            ToolApp.Initialize(false);

            Process(arg);
            //Console.ReadKey();
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

        private static string GetAppName(WeixinCorpConfig config)
        {
            return string.Format(ObjectUtil.SysCulture, "应用[{0}]", config.AppName);
        }

        private static void ProcessCorpMode(Argument arg, WeixinXml xml)
        {
            WeMenu menu;
            WeixinResult result;
            switch (arg.Action)
            {
                case MenuAction.Create:
                    foreach (var item in xml.Weixin.CorpApps)
                    {
                        WeixinMenuXml menuXml = WeUtil.LoadMenu(item.Menu);
                        menu = menuXml.CreateMenu();

                        Console.WriteLine(GetAppName(item));
                        if (arg.PrintMenu)
                        {
                            Console.WriteLine(menu.ToJson());
                        }
                        else
                        {
                            result = menu.CreateCorpMenu(item.AppId);
                            WriteResult(result, "菜单创建成功");
                        }
                    }
                    break;
                case MenuAction.Query:
                    foreach (var item in xml.Weixin.CorpApps)
                    {
                        Console.WriteLine(GetAppName(item));
                        menu = WeMenu.QueryCorpMenu(item.AppId);
                        WriteResult(menu, menu.ToJson());
                    }
                    break;
                case MenuAction.Delete:
                    foreach (var item in xml.Weixin.CorpApps)
                    {
                        Console.WriteLine(GetAppName(item));
                        result = WeMenu.DeleteCorpMenu(item.AppId);
                        WriteResult(result, "菜单删除成功");
                    }
                    break;
            }
        }

        private static void Process(Argument arg)
        {
            if (arg.Help)
            {
                Console.WriteLine(DataString.Usage);
                return;
            }

            string weixinConfig = arg.WeixinXml;
            if (!File.Exists(weixinConfig))
            {
                Console.WriteLine(string.Format(ObjectUtil.SysCulture, DataString.NoFile, weixinConfig));
                return;
            }

            foreach (var item in arg.Hosts)
                ToolApp.AddHost(item.Item1, item.Item2);

            WeixinXml xml = WeUtil.GetWeixinXml(weixinConfig);
            new WeixinSettings(xml);
            if (WeixinSettings.Current.Mode == WeixinMode.Normal)
                ProcessNormalMode(arg, xml);
            else
                ProcessCorpMode(arg, xml);
        }
    }
}
