namespace YJC.Toolkit.Weixin.Material
{
    public class WeVoiceMaterial : WeOtherMaterial
    {
        public WeVoiceMaterial(string media)
            : base(media)
        {
        }

        internal WeVoiceMaterial(string fileName, byte[] fileData)
            : base(fileName, fileData)
        {
        }


        public static WeMaterialPageData GetMaterials(int pageSize, int pageCount)
        {
            return WeBaseMaterial.GetPageData(MediaType.Video, pageSize, pageCount);
        }

        public static int TotalCount
        {
            get
            {
                return WeBaseMaterial.Count().VoiceCount;
            }
        }
    }
}
