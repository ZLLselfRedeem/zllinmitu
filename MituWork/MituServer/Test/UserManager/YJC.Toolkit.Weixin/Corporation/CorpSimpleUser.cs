using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Corporation
{
    public class CorpSimpleUser : WeixinResult, IEntity
    {
        protected CorpSimpleUser()
        {
        }

        [SimpleElement(LocalName = "userid", Order = 10)]
        [NameModel(WeCorpConst.USER_MODE, LocalName = "UserLogonName")]
        public string Id { get; protected set; }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 20)]
        [NameModel(WeCorpConst.USER_MODE)]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
