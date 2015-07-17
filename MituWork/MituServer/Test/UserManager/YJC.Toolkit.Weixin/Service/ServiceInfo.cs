using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Service
{
    public class ServiceInfo : IRegName
    {
        internal ServiceInfo()
        {
        }

        #region IRegName 成员

        public string RegName
        {
            get
            {
                return Account;
            }
        }

        #endregion


        [SimpleElement(Order = 10, LocalName = "kf_account")]
        public string Account { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public ServiceStatus Status { get; private set; }

        [SimpleElement(Order = 30, LocalName = "kf_id")]
        public string Id { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        public int AutoAccept { get; private set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public int AcceptedCase { get; private set; }
    }
}
