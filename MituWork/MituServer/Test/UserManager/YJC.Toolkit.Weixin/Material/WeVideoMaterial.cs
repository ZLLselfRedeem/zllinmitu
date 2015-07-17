using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Material
{
    [TypeScheme(Author = "YJC", CreateDate = "2015-06-02", Description = "微信视频素材信息")]
    [RegType(Author = "YJC", CreateDate = "2015-06-02", Description = "微信视频素材信息")]
    public class WeVideoMaterial : WeBaseMaterial
    {
        private readonly string fMedia;
        private readonly WeVideoDescription fDesc;

        internal WeVideoMaterial()
        {
        }

        public WeVideoMaterial(string filePath, string title, string introduction)
        {
            TkDebug.AssertArgumentNullOrEmpty(filePath, "filePath", null);
            TkDebug.AssertArgumentNullOrEmpty(title, "title", null);

            fMedia = filePath;
            fDesc = new WeVideoDescription(title, introduction);
        }

        [FieldInfo(Length = 255)]
        [FieldControl(ControlType.Text, Order = 10)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("素材名称")]
        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public string Title { get; private set; }

        [FieldInfo(Length = 255)]
        [FieldControl(ControlType.Text, Order = 20)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("素材描述")]
        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Description { get; private set; }

        [FieldInfo(Length = 255)]
        [FieldControl(ControlType.Text, Order = 30)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("素材链接")]
        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        internal string DownUrl { get; private set; }

        public override WeMediaId Add()
        {
            string descStr = fDesc.WriteJson();
            KeyValuePair<string, string> descPair = new KeyValuePair<string, string>("description", descStr);
            string url = WeUtil.GetUrl(WeMaterialConst.ADD_MATERIAL);
            var result = NetUtil.ReadObjectFromResponse(
                NetUtil.FormUploadFile(new Uri(url), "media", fMedia, descPair), null, new WeMediaId());
            return result;
        }

        public byte[] CreateMediaData()
        {
            if (!string.IsNullOrEmpty(fMedia))
            {
                return File.ReadAllBytes(fMedia);
            }
            else if (DownUrl != null)
            {
                WebResponse response = NetUtil.HttpGet(new Uri(DownUrl));
                return NetUtil.GetResponseData(response);
            }
            return null;
        }

        public static WeMaterialPageData GetMaterials(int pageSize, int pageCount)
        {
            return WeBaseMaterial.GetPageData(MediaType.Video, pageSize, pageCount);
        }

        public static int TotalCount
        {
            get
            {
                return WeBaseMaterial.Count().VideoCount;
            }
        }
    }
}
