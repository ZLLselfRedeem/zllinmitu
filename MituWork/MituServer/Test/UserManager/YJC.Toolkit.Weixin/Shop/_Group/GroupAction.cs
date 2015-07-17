using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;

namespace YJC.Toolkit.Weixin.Shop
{
    [EnumCodeTable(Author = "YJC", CreateDate = "2015-3-26", UseIntValue = false,
        Description = "分组修改操作")]
    public enum GroupAction
    {
        [DisplayName("删除")]
        Remove = 0,
        [DisplayName("增加")]
        Add = 1
    }
}
