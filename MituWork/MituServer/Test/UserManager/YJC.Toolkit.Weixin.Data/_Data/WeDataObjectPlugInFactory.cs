using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin
{
    internal class WeDataObjectPlugInFactory : BasePlugInFactory
    {
        public const string REG_NAME = "_tk_weixin_Retrieve_Data";
        private const string DESCRIPTION = "获取批量微信数据的插件工厂";

        public WeDataObjectPlugInFactory()
            : base(REG_NAME, DESCRIPTION)
        {
        }
    }
}
