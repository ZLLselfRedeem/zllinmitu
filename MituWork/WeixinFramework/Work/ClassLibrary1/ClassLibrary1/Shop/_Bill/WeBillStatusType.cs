using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;

namespace YJC.Toolkit.Weixin.Shop
{
    [EnumCodeTable(Author = "YJC", CreateDate = "2015-3-26", UseIntValue = false,
        Description = "订单状态")]
    public enum WeBillStatusType
    {
        [DisplayName("待发货")]
        WaitForDelivery = 2,
        [DisplayName("已发货")]
        Delivery = 3,
        [DisplayName("已完成")]
        Completed = 5,
        [DisplayName("维权中")]
        Right = 8
    }
}
