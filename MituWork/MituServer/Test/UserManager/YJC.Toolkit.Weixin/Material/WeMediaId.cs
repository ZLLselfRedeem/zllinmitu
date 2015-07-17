﻿using System;
using System.Net;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Material
{
    [TypeScheme(Author = "YJC", CreateDate = "2015-06-02", Description = "微信素材信息")]
    [RegType(Author = "YJC", CreateDate = "2015-06-02", Description = "微信素材信息")]
    public class WeMediaId
    {
        internal WeMediaId()
        {
        }

        public WeMediaId(string mediaId)
        {
            TkDebug.AssertArgumentNullOrEmpty(mediaId, "mediaId", null);

            MediaId = mediaId;
        }

        [FieldInfo(Length = 255)]
        [FieldControl(ControlType.Hidden, Order = 20)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("素材ID")]
        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string MediaId { get; internal set; }

        [FieldInfo(Length = 255)]
        [FieldControl(ControlType.Text, Order = 10)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("素材名称")]
        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Name { get; internal set; }

        [FieldInfo(Length = 255)]
        [FieldControl(ControlType.DateTime, Order = 30)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("最后更新时间")]
        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(WeixinDateTimeConverter))]
        public DateTime UpdateTime { get; internal set; }

        [FieldInfo(Length = 255)]
        [FieldControl(ControlType.Hidden, Order = 40)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("图片URL")]
        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        public string Url { get; internal set; }
        public WeixinResult Delete()
        {
            string url = WeUtil.GetUrl(WeMaterialConst.DEL_MATERIAL);
            var result = WeUtil.PostDataToUri(url, this.WriteJson(), new WeixinResult());
            return result;
        }

        private T Create<T>(T result) where T : WeBaseMaterial
        {
            string url = WeUtil.GetUrl(WeMaterialConst.GET_MATERIAL);
            result = WeUtil.PostDataToUri(url, WeMaterialConst.NAME_MODEL, this.WriteJson(), result);
            return result;
        }

        public virtual WeNewsMaterial CreateNewsMaterial()
        {
            return Create(new WeNewsMaterial());
        }

        public WeVideoMaterial CreateVideoMaterial()
        {
            return Create(new WeVideoMaterial());
        }

        private byte[] CreateOtherMaterial()
        {
            string url = WeUtil.GetUrl(WeMaterialConst.GET_MATERIAL);
            WebResponse reWeb = NetUtil.HttpPost(new Uri(url), this.WriteJson());
            byte[] buffer = NetUtil.GetResponseData(reWeb);
            return buffer;
        }

        public WeVoiceMaterial CreateVoiceMaterial()
        {
            return new WeVoiceMaterial(Name, CreateOtherMaterial());
        }

        public WeImageMaterial CreateImageMaterial()
        {
            return new WeImageMaterial(Name, CreateOtherMaterial());
        }
    }
}
