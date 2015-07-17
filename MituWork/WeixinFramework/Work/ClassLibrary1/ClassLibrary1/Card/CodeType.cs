using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    [EnumCodeTable(Author = "YJC", CreateDate = "2015-03-27", UseIntValue = false,
        Description = "code码展示类型")]

    public enum CodeType
    {
        [DisplayName("文本")]
        [EnumFieldValue("CODE_TYPE_TEXT")]
        CodeTypeText,
        [DisplayName("一维码")]
        [EnumFieldValue("CODE_TYPE_BARCODE")]
        CodeTypeBarcode,
        [DisplayName("二维码")]
        [EnumFieldValue("CODE_TYPE_QRCODE")]
        CodeTypeQrcode,
        [DisplayName("二维码无code显示")]
        [EnumFieldValue("CODE_TYPE_ONLY_QRCODE")]
        CodeTypeOnlyQrcode,
        [DisplayName("一维码无code显示")]
        [EnumFieldValue("CODE_TYPE_ONLY_BARCODE")]
        CodeTypeOnlyBarcode
    }
}
