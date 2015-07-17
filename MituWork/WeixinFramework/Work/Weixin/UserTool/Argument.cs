using System;
using System.IO;

namespace YJC.Toolkit.Weixin.UserTool
{
    class Argument
    {
        public Argument(string[] args)
        {
            int index = 0;
            int count = args.Length;
            Action = Action.None;
            string path = null;
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
                    //case "-corp":
                    //    Action = Action.CorpUser;
                    //    break;
                    //case "-normal":
                    //    Action = Action.WeUser;
                    //    break;
                }
                ++index;
            }
            //if (Action == Action.None)
            //    Help = true;
            if (string.IsNullOrEmpty(path))
                path = Environment.CurrentDirectory;
            WeixinXml = Path.Combine(path, "Weixin.xml");
            ApplicationXml = Path.Combine(path, "Application.xml");
        }

        public bool Help { get; private set; }

        public Action Action { get; private set; }

        public string WeixinXml { get; private set; }

        public string ApplicationXml { get; private set; }
    }
}
