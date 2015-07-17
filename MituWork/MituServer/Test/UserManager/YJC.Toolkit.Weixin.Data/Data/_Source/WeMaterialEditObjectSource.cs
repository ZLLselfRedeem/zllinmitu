using System.IO;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Material;

namespace YJC.Toolkit.Weixin.Data
{
    [ObjectSource(Author = "YJC", CreateDate = "2015-06-02",
        Description = "微信公众号素材的编辑数据源")]
    internal class WeMaterialEditObjectSource : IInsertObjectSource, IDeleteObjectSource
    {

        public object CreateNew(IInputData input)
        {
            return new WeMaterialUploadObject();
        }

        public OutputData Insert(IInputData input, object instance)
        {
            WeMaterialUploadObject mediaObject = instance.Convert<WeMaterialUploadObject>();
            byte[] fileData = File.ReadAllBytes(mediaObject.ServerPath);
            string fileName = "";
            if (string.IsNullOrEmpty(mediaObject.Name))
            {
                fileName = mediaObject.FileName;
            }
            else
            {
                fileName = mediaObject.Name + Path.GetExtension(mediaObject.FileName);
            }

            WeOtherMaterial material = new WeOtherMaterial(fileName, fileData);
            var res = material.Add();
            return OutputData.CreateToolkitObject(KeyData.Empty);
        }

        public OutputData Delete(IInputData input, string id)
        {
            WeMediaId mediaId = new WeMediaId(id);
            mediaId.Delete();
            return OutputData.CreateToolkitObject(KeyData.Empty);
        }
    }
}
