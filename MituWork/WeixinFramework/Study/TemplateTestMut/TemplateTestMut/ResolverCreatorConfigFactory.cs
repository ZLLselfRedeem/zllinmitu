using YJC.Toolkit.Sys;

namespace TemplateTestMut
{
    public class ResolverCreatorConfigFactory : BaseXmlConfigFactory
    {
        public const string REG_NAME = "_tk_Resolver_Creator";
        private const string DESCRIPTION = "TableResolver配置插件工厂";

        public ResolverCreatorConfigFactory()
            : base(REG_NAME, DESCRIPTION)
        {
        }
    }
}
