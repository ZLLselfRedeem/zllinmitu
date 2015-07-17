using System;
using System.Collections.Generic;
using System.IO;

namespace YJC.Toolkit.Weixin.MenuCreator
{
    class Argument
    {
        public Argument(string[] args)
        {
            Hosts = new List<Tuple<string, string>>();

            int index = 0;
            int count = args.Length;
            string path = null;
            Action = MenuAction.Create;
            while (index < count)
            {
                string arg = args[index].ToLower();
                switch (arg)
                {
                    case "-?":
                        Help = true;
                        return;
                    case "-path":
                        path = args[++index];
                        break;
                    case "-query":
                        Action = MenuAction.Query;
                        break;
                    case "-create":
                        Action = MenuAction.Create;
                        break;
                    case "-delete":
                        Action = MenuAction.Delete;
                        break;
                    case "-print":
                        PrintMenu = true;
                        break;
                    case "-host":
                        while (++index < count)
                        {
                            string hostName = args[index];
                            if (hostName.StartsWith("-", StringComparison.Ordinal))
                                break;
                            string hostValue = args[++index];
                            Hosts.Add(Tuple.Create(hostName, hostValue));
                        }
                        continue;
                }
                ++index;
            }
            if (string.IsNullOrEmpty(path))
                path = Environment.CurrentDirectory;
            WeixinXml = Path.Combine(path, "Weixin.xml");
        }

        public bool Help { get; private set; }

        public MenuAction Action { get; private set; }

        public bool PrintMenu { get; private set; }

        public string WeixinXml { get; private set; }

        public List<Tuple<string, string>> Hosts { get; private set; }
    }
}
