namespace YJC.Toolkit.Weixin.Material
{
    public class WeImageMaterial : WeOtherMaterial
    {
        public WeImageMaterial(string media)
            : base(media)
        {
        }

        internal WeImageMaterial(string fileName, byte[] fileData)
            : base(fileName, fileData)
        {
        }

        public static WeMaterialPageData GetMaterials(int pageSize, int pageCount)
        {
            return WeBaseMaterial.GetPageData(MediaType.Image, pageSize, pageCount);
        }

        public static int TotalCount
        {
            get
            {
                return WeBaseMaterial.Count().ImageCount;
            }
        }
    }
}
