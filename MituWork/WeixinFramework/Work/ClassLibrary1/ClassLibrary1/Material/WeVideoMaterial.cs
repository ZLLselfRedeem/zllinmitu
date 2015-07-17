using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Material
{
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

        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public string Title { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Description { get; private set; }

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
