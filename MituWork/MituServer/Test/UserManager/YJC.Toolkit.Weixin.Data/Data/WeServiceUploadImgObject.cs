using YJC.Toolkit.Data;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Data
{
    [TypeScheme(Author = "YJC", CreateDate = "2015-06-15", Description = "微信上传文件对象")]
    [RegType(Author = "YJC", CreateDate = "2015-06-15", Description = "微信上传文件对象")]
    class WeServiceUploadImgObject : BaseUploadObject
    {
        [SimpleAttribute]
        [FieldInfo(Length = 255)]
        [FieldControl(ControlType.Label, Order = 10)]
        [FieldLayout]
        [DisplayName("用户名")]
        public string Account { get; set; }
    }
}
