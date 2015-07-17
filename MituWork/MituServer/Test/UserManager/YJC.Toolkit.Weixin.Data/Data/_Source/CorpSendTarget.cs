using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;

namespace YJC.Toolkit.Weixin.Data
{
    [EnumCodeTable(Author = "YJC", CreateDate = "2014-12-16", UseIntValue = false,
        Description = "企业号发送对象")]
    public enum CorpSendTarget
    {
        [DisplayName("全部")]
        All,
        [DisplayName("标签")]
        Tag,
        [DisplayName("部门")]
        Department,
        [DisplayName("个人")]
        User
    }
}
