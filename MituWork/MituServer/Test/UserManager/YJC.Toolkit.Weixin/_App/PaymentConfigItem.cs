using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin
{
    internal class PaymentConfigItem
    {
        [SimpleAttribute]
        public string MchId { get; private set; }

        [SimpleAttribute]
        public string Key { get; private set; }

        [SimpleAttribute]
        public string DeviceInfo { get; private set; }

        [SimpleAttribute]
        public string DeviceIp { get; private set; }

        [SimpleAttribute]
        public string NotifyUrl { get; private set; }

        [SimpleAttribute]
        public string NotifyBaseUrl { get; private set; }
    }
}
