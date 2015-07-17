using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;

namespace YJC.Toolkit.Weixin.Shop
{
    [EnumCodeTable(Author = "YJC", CreateDate = "2015-3-26", UseIntValue = false,
        Description = "运费类型")]
    public enum DeliveryType
    {
        [DisplayName("默认邮费模板")]
        Express = 0,
        [DisplayName("自定义邮费模板")]
        TemplateId = 1
    }
}
