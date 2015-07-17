using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class UploadImg : WeixinResult
    {
        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public string ImgUrl { get; private set; }

        public static UploadImg Upload(string fileName, byte[] fileData)
        {
            TkDebug.AssertArgumentNullOrEmpty(fileName, "fileName", null);
            TkDebug.AssertArgumentNull(fileData, "fileData", null);

            string url = string.Format(ObjectUtil.SysCulture, WeShopConst.UPLOAD_IMG_URL,
                AccessToken.CurrentToken, fileName);

            var result = NetUtil.FormUploadFile(new Uri(url), "File", fileName, fileData);
            return NetUtil.ReadObjectFromResponse(result, null, new UploadImg());
        }
    }
}
