using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Material;

namespace YJC.Toolkit.Weixin.Data
{

    [ObjectSource(Author = "YJC", CreateDate = "2015-06-15",
        Description = "微信公众号视频素材的编辑数据源")]
    internal class WeVideoMaterialEditObjectSource : IInsertObjectSource, IDeleteObjectSource
    {
        public OutputData Delete(IInputData input, string id)
        {
            WeMediaId mediaId = new WeMediaId(id);
            mediaId.Delete();
            return OutputData.CreateToolkitObject(KeyData.Empty);
        }

        public object CreateNew(IInputData input)
        {
            return new WeMaterialUploadObject();
        }

        public OutputData Insert(IInputData input, object instance)
        {
            WeMaterialUploadObject mediaObject = instance.Convert<WeMaterialUploadObject>();
            WeVideoMaterial material = new WeVideoMaterial(mediaObject.ServerPath, mediaObject.Title, mediaObject.Introduction);
            var res = material.Add();
            return OutputData.CreateToolkitObject(KeyData.Empty);
        }
    }
}
