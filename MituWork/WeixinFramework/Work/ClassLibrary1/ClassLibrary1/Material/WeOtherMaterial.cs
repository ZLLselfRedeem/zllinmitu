using System.IO;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Material
{
    public abstract class WeOtherMaterial : WeBaseMaterial
    {
        private readonly byte[] fData;
        private readonly string fFileName;

        protected WeOtherMaterial()
        {
        }

        protected WeOtherMaterial(string fileName)
        {
            TkDebug.AssertArgumentNullOrEmpty(fileName, "fileName", null);

            fFileName = fileName;
            fData = File.ReadAllBytes(fFileName);
        }

        protected WeOtherMaterial(string fileName, byte[] fileData)
        {
            TkDebug.AssertArgumentNullOrEmpty(fileName, "fileName", null);
            TkDebug.AssertArgumentNull(fileData, "fileData", null);

            fFileName = fileName;
            fData = fileData;
        }

        public byte[] CreateMediaData()
        {
            return fData;
        }

        public override WeMediaId Add()
        {
            string url = WeUtil.GetUrl(WeMaterialConst.ADD_MATERIAL);
            var result = WeUtil.UploadFile(url, fFileName, fData, new WeMediaId());
            return result;
        }
    }
}
