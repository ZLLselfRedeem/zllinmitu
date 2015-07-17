using YJC.Toolkit.Collections;
using YJC.Toolkit.Decoder;

namespace YJC.Toolkit.Weixin.Corporation
{
    [CodeTable(Author = "YJC", CreateDate = "2014-12-16", Description = "微信企业号标签的代码表")]
    internal class WeixinCorpCodeTable : RegNameListCodeTable<WeixinCorpConfig>
    {
        public WeixinCorpCodeTable()
            : base(CreateList())
        {
        }

        private static RegNameList<WeixinCorpConfig> CreateList()
        {
            RegNameList<WeixinCorpConfig> result = WeixinSettings.Current.CorpApps;
            if (result == null)
                result = new RegNameList<WeixinCorpConfig>();

            return result;
        }
    }
}
