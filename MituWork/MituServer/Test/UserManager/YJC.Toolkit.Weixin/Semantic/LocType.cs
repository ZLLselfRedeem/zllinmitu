using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Semantic
{
    public enum LocType
    {
        [EnumFieldValue("LOC_COUNTRY")]
        LocCountry,
        [EnumFieldValue("LOC_PROVINCE")]
        LocProvince,
        [EnumFieldValue("LOC_CITY")]
        LocCity,
        [EnumFieldValue("LOC_TOWN")]
        LocTown,
        [EnumFieldValue("LOC_POI")]
        LocPoi,
        [EnumFieldValue("NORMAL_POI")]
        NormalPoi
    }
}
