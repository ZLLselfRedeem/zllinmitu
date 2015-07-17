using System.IO;
using YJC.Toolkit.Cache;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Service;

namespace YJC.Toolkit.Weixin.Data
{
    [ObjectSource(Author = "YJC", CreateDate = "2015-05-19",
        Description = "微信公众号客服的列表数据源")]
    [InstancePlugIn, AlwaysCache]
    internal class WeServiceUploadImgObjectSource : IInsertObjectSource
    {
        public static object Instance = new WeServiceUploadImgObjectSource();

        #region IInsertObjectSource 成员

        public object CreateNew(IInputData input)
        {
            WeServiceUploadImgObject result = new WeServiceUploadImgObject()
            {
                Account = input.QueryString["Account"]
            };
            return result;
        }

        public OutputData Insert(IInputData input, object instance)
        {
            WeServiceUploadImgObject uploadObj = instance.Convert<WeServiceUploadImgObject>();
            if (string.IsNullOrEmpty(uploadObj.FileName))
                throw new WebPostException("没有上传头像文件");
            byte[] fileData = File.ReadAllBytes(uploadObj.ServerPath);
            WeixinResult res = ServiceAccount.UploadHeadImg(uploadObj.Account, uploadObj.FileName, fileData);
            return OutputData.CreateToolkitObject(KeyData.Empty);
        }

        #endregion
    }
}
