using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;

namespace YJC.Toolkit.Weixin.Card
{
    [EnumCodeTable(Author = "YJC", CreateDate = "2015-03-27", UseIntValue = false,
       Description = "门店审核状态")]
    public enum AvailableState
    {
        [DisplayName("系统错误")]
        SystemError = 1,
        [DisplayName("审核中")]
        Checking = 2,
        [DisplayName("审核通过")]
        Passed = 3,
        [DisplayName("审核驳回")]
        Rejected = 4
    }
}
