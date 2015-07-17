using YJC.Toolkit.Data;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Data
{
    [TypeScheme(Author = "YJC", CreateDate = "2015-06-16", Description = "微信上传素材对象")]
    [RegType(Author = "YJC", CreateDate = "2015-06-16", Description = "微信上传素材对象")]
    class WeMaterialUploadObject : BaseUploadObject
    {
        [SimpleAttribute]
        [FieldInfo(Length = 255, IsEmpty = false)]
        [FieldControl(ControlType.Hidden, Order = 20)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("标题")]
        public string Title { get; set; }

        [SimpleAttribute]
        [FieldInfo(Length = 255)]
        [FieldControl(ControlType.Hidden, Order = 30)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("描述")]
        public string Introduction { get; set; }

        [SimpleAttribute]
        [FieldInfo(Length = 255)]
        [FieldControl(ControlType.Hidden, Order = 30)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("素材名称")]
        public string Name { get; set; }
    }
}
