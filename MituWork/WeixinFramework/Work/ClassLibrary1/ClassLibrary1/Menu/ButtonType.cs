using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Menu
{
    public enum ButtonType
    {
        [EnumFieldValue("")]
        Parent,
        [EnumFieldValue("click")]
        Click,
        [EnumFieldValue("view")]
        View,
        [EnumFieldValue("scancode_push")]
        ScanCodePush,
        [EnumFieldValue("scancode_waitmsg")]
        ScanCodeWaitmsg,
        [EnumFieldValue("pic_sysphoto")]
        PicSysPhoto,
        [EnumFieldValue("pic_photo_or_album")]
        PicPhotoAlbum,
        [EnumFieldValue("pic_weixin")]
        PicWeixin,
        [EnumFieldValue("location_select")]
        LocationSelect,
        [EnumFieldValue("text")]
        Text,
        [EnumFieldValue("img")]
        Image,
        [EnumFieldValue("photo")]
        Photo,
        [EnumFieldValue("video")]
        Video,
        [EnumFieldValue("voice")]
        Voice,
        [EnumFieldValue("news")]
        News

    }
}
