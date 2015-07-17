using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Corporation
{
    [Flags]
    public enum UserStatus
    {
        [EnumFieldValue("1")]
        Attention = 1,
        [EnumFieldValue("2")]
        Frozen = 2,
        [EnumFieldValue("4")]
        NoAttention = 4
    }
}
