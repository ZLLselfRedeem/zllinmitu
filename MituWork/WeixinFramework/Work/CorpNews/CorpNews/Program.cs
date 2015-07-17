using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleApp.Initialize();

            //string description = "这是一家创立于北京中关村，致力于向人们提供“简单，可依赖”的信息获取方式";
            //string picUrl = "http://p.img.eol.cn/images/1022/2011/0919/1316394859_12_iyeh.jpg";
            //Article ar = new Article()
            //{
            //    Title = "企业简介",
            //    Description = description,
            //    Url = "http://baike.sogou.com/v6234.htm",
            //    PicUrl = picUrl
            //};

            //NewsCorpMessage nMsg = new NewsCorpMessage();
            //nMsg.SetUser("zll");
            //nMsg.Add(ar);
            //WeixinResult result = nMsg.Send(0);

            //string oppid = "oyyPUjvZNtOaKqJ3Nh5KIOOsclGA";
            //NewsServiceMessage nMsg = new NewsServiceMessage(oppid);
            //nMsg.Add(ar);
            //WeixinResult result = nMsg.Send();

            //WeManagerInvite test = new WeManagerInvite("zll") { InviteTips = "请关注米兔企业号" };
            //var result = test.Invite();
            var result = GetIp();
            Console.WriteLine(result.WriteJson());

        }

        public static WeCallBack GetIp()
        {
            const string IP_LIST = "https://qyapi.weixin.qq.com/cgi-bin/getcallbackip?access_token={0}";
            string url = WeCorpUtil.GetCorpUrl(IP_LIST, WeixinSettings.Current.CorpUserManagerSecret);
            var result = NetUtil.HttpGetReadJson(new Uri(url), new WeCallBack());
            return result;
        }
    }
}
