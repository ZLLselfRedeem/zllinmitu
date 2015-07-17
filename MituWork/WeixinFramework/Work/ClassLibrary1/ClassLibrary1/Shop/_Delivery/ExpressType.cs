using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;

namespace YJC.Toolkit.Weixin.Shop
{
    [EnumCodeTable(Author = "YJC", CreateDate = "2015-3-26", UseIntValue = false,
        Description = "快递列表")]
    public enum ExpressType
    {
        [DisplayName("平邮")]
        Normal = 10000027,
        [DisplayName("快递")]
        Express = 10000028,
        [DisplayName("EMS")]
        EMS = 10000029
    }
}
