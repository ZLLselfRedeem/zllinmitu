using System.Collections.Generic;
using System.Linq;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.User
{
    public class WeFanContainter : WeixinResult
    {
        internal WeFanContainter()
        {
        }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 10)]
        public int Total { get; private set; }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 20)]
        public int Count { get; private set; }

        [TagElement(LocalName = "data", Order = 30)]
        [SimpleElement(LocalName = "openid", IsMultiple = true)]
        public List<string> OpenIds { get; private set; }

        [SimpleElement(LocalName = "next_openid", Order = 40)]
        public string NextOpenId { get; private set; }

        public static WeFanContainter GetFans()
        {
            return GetFans(null);
        }

        public static WeFanContainter GetFans(WeFanContainter prev)
        {
            string url = WeUtil.GetUrl(WeConst.FAN_URL);
            if (prev != null)
                url += "&next_openid=" + prev.NextOpenId;

            WeFanContainter result = new WeFanContainter();
            return WeUtil.GetFromUri(url, result);
        }

        public static IEnumerable<string> GetAllUsers()
        {
            List<WeFanContainter> list = new List<WeFanContainter>();
            WeFanContainter item = GetFans();
            list.Add(item);

            while (!(string.IsNullOrEmpty(item.NextOpenId)))
            {
                item = GetFans(item);
                if (item.Count > 0)
                    list.Add(item);
            }

            var result = from fan in list
                         from id in fan.OpenIds
                         where fan.OpenIds != null
                         select id;
            return result;
        }
    }
}
