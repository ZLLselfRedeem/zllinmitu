using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class Package
    {
        public Package() 
        {
            Appid ="wxd930ea5d5a258f4f";
            AuthCode = 123456;
            Body = "test";
            DeviceInfo = 123;
            MchId = "1900000109";
            NonceStr = "960f228109051b9969f76c82bde183ac";
            OutTradeNo = "1400755861";
            SpbillCreateIp = "127.0.0.1";
            TotalFee = 1;
        }
        [SimpleElement(LocalName="appid")]
        public string Appid { get; private set; }

        [SimpleElement(LocalName="auth_code")]
        public long AuthCode { get;private set; }

        [SimpleElement(LocalName = "body")]
        public string Body { get; private set; }

        [SimpleElement(LocalName = "device_info")]
        public int DeviceInfo { get; private set; }

        [SimpleElement(LocalName = "mch_id")]
        public string MchId { get; private set; }

        [SimpleElement(LocalName = "nonce_str")]
        public string NonceStr { get; private set; }

        [SimpleElement(LocalName = "out_trade_no")]
        public string OutTradeNo { get; private set; }

        [SimpleElement(LocalName = "spbill_create_ip")]
        public string SpbillCreateIp { get; private set; }

        [SimpleElement(LocalName = "total_fee")]
        public int TotalFee { get; private set; }
    }
}
