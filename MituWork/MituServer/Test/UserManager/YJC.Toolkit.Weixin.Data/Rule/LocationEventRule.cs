using System;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Data;
using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Rule
{
    [ReplyMessage(Author = "YJC", CreateDate = "2014-04-02",
        Description = "记录用户的经纬位置")]
    public class LocationEventRule : IRule
    {
        #region IRule 成员

        public BaseSendMessage Reply(ReceiveMessage message)
        {
            BaseGlobalVariable.Current.BeginInvoke(new Action<ReceiveMessage>(SaveLocation), message);

            return null;
        }

        #endregion

        private static void SaveLocation(ReceiveMessage message)
        {
            using (WeixinDataSource source = new WeixinDataSource())
            using (UserLocationResolver resolver = new UserLocationResolver(source))
            {
                resolver.Insert(message);
            }
        }
    }
}
