using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;

namespace YJC.Toolkit.Weixin.Cube
{
    [EnumCodeTable(Author = "YJC", CreateDate = "2015-04-01", UseIntValue = false,
        Description = "消息类型")]
    public enum DataMsg
    {
        [DisplayName("文字")]
        Text = 1,
        [DisplayName("图片")]
        Img = 2,
        [DisplayName("语音")]
        Voice = 3,
        [DisplayName("视频")]
        Vedio = 4,
        [DisplayName("第三方引用消息")]
        ThirdParty = 6
    }
}
