using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.ShakeAround
{
    public class WeShakePage
    {
        internal WeShakePage()
        { 
        }

        public WeShakePage(int id, string title, string description, string pageUrl, string iconUrl)
        {
            TkDebug.AssertArgumentNullOrEmpty(title, "title", null);
            TkDebug.AssertArgumentNullOrEmpty(description, "description", null);
            TkDebug.AssertArgumentNullOrEmpty(pageUrl, "pageUrl", null);
            TkDebug.AssertArgumentNullOrEmpty(iconUrl, "iconUrl", null);

            PageId = id;
            Title = title;
            Description = description;
            PageUrl = pageUrl;
            IconUrl = iconUrl;
        }

        [SimpleElement(Order = 5, NamingRule = NamingRule.UnderLineLower)]
        public int PageId { get; private set; }

        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public string Title { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Description { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public string PageUrl { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        public string Comment { get; set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public string IconUrl { get; private set; }

        public static string MaterialUpload(string fileName, byte[] fileData)
        {
            string url = WeUtil.GetUrl(WeShakeConst.MATERIAL_ADD);
            var result = WeUtil.UploadFile(url, fileName, fileData, new WePicUrl());
            return result.PicUrl;
        }

        public static int PageAdd(string title, string description, string pageUrl, 
            string iconUrl, string comment)
        {
            TkDebug.AssertArgumentNullOrEmpty(title, "title", null);
            TkDebug.AssertArgumentNullOrEmpty(description, "description", null);
            TkDebug.AssertArgumentNullOrEmpty(pageUrl, "pageUrl", null);
            TkDebug.AssertArgumentNullOrEmpty(iconUrl, "iconUrl", null);

            InternalShakePage page = new InternalShakePage(title, description, pageUrl, iconUrl) 
            { 
                Comment = comment 
            };
            return page.Add();
        }

        public int PageUpdate()
        {
            string url = WeUtil.GetUrl(WeShakeConst.PAGE_UPDATE);
            var result = WeUtil.PostDataToUri(url, this.WriteJson(), new WePageId());
            return result.PageId;
        }

        private static IEnumerable<WeShakePage> Query(string json)
        {
            string url = WeUtil.GetUrl(WeShakeConst.PAGE_SEARCH);
            var result = WeUtil.PostDataToUri(url, json, new WePageData());
            return result.Data.Pages;
        }

        public static IEnumerable<WeShakePage> PageQuery(int beg, int cnt) 
        {
            WePageQuery pages = new WePageQuery(beg, cnt);
            return Query(pages.WriteJson());
        }

        public static IEnumerable<WeShakePage> PageQuery(params int[] idList)
        {
            TkDebug.AssertArgumentNull(idList, "idList", null);

            WePageIdList ids = new WePageIdList(idList);
            return Query(ids.WriteJson());
        }

        public static WeixinResult PageDelete(params int[] idList)
        {
            TkDebug.AssertArgumentNull(idList, "idList", null);

            string url = WeUtil.GetUrl(WeShakeConst.PAGE_DELETE);
            WePageIdList ids = new WePageIdList(idList);
            return WeUtil.PostDataToUri(url, ids.WriteJson(), new WeixinResult());
        }
    }
}
