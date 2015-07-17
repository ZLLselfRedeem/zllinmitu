using System;
using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;

namespace YJC.Toolkit.Weixin.Service
{
    [Flags]
    [EnumCodeTable(Author = "YJC", CreateDate = "2015-05-15", UseIntValue = false,
        Description = "客服在线状态")]
    public enum ServiceStatus
    {
        [DisplayName("pc在线")]
        PC = 1,
        [DisplayName("手机在线")]
        MobilePhone = 2
    }
}
