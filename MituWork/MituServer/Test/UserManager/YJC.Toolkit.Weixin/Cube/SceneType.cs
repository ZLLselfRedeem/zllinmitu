using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;

namespace YJC.Toolkit.Weixin.Cube
{
    [EnumCodeTable(Author = "YJC", CreateDate = "2015-04-01", UseIntValue = false,
        Description = "分享的场景")]
    public enum SceneType
    {
        [DisplayName("好友转发")]
        Friend = 1,
        [DisplayName("朋友圈")]
        Circle = 2,
        [DisplayName("腾讯微博")]
        Microblog = 3,
        [DisplayName("其他")]
        Other = 255
    }
}
