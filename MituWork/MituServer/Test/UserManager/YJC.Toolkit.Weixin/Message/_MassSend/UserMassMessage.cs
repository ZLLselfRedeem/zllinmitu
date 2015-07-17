using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public abstract class UserMassMessage : BaseMassMessage
    {
        private readonly List<string> fToUsers;

        protected UserMassMessage(IEnumerable<string> users)
        {
            TkDebug.AssertArgumentNull(users, "users", null);

            fToUsers = new List<string>(users);
        }

        [SimpleElement(LocalName = "touser", IsMultiple = true, Order = 10)]
        public IEnumerable<string> ToUsers
        {
            get
            {
                return fToUsers;
            }
        }

        public long Send()
        {
            string url = WeUtil.GetUrl(WeConst.USER_MASS_MESSAGE_URL);
            var msg = WeUtil.PostToUri(url, this.WriteJson(), new MassMessageResult());
            return msg.ResultId;
        }
    }
}
