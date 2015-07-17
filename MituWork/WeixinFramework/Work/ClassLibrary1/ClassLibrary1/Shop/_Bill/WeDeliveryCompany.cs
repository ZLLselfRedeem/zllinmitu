using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    [EnumCodeTable(Author = "YJC", CreateDate = "2015-3-26", UseIntValue = false,
        Description = "物流公司")]
    public enum WeDeliveryCompany
    {
        [DisplayName("邮政EMS")]
        [EnumFieldValue("Fsearch_code")]
        EMS,
        [DisplayName("申通快递")]
        [EnumFieldValue("002shentong")]
        ShenTong,
        [DisplayName("中通速递")]
        [EnumFieldValue("066zhongtong")]
        ZhongTong,
        [DisplayName("圆通速递")]
        [EnumFieldValue("056yuantong")]
        YuanTong,
        [DisplayName("天天快递")]
        [EnumFieldValue("042tiantian")]
        TianTian,
        [DisplayName("顺丰速运")]
        [EnumFieldValue("003shunfeng")]
        ShunFeng,
        [DisplayName("韵达快运")]
        [EnumFieldValue("059Yunda")]
        YunDa,
        [DisplayName("宅急送")]
        [EnumFieldValue("064zhaijisong")]
        ZhaiJiSong,
        [DisplayName("汇通快运")]
        [EnumFieldValue("020huitong")]
        HuiTong,
        [DisplayName("易迅快递")]
        [EnumFieldValue("zj001yixun")]
        YiXun
    }
}
