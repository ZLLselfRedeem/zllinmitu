using YJC.Toolkit.Data;

namespace YJC.Toolkit.Web.Page
{
    internal class WebModuleContentPage : WebBaseModuleContentPage
    {
        private readonly IModule fModule;

        public WebModuleContentPage()
        {
            fModule = InternalWebUtil.CreateModuleXml(Request);
        }

        protected override IModule Module
        {
            get
            {
                return fModule;
            }
        }

        protected override bool SupportLogOn
        {
            get
            {
                return fModule.IsSupportLogOn(this);
            }
            set
            {
                base.SupportLogOn = value;
            }
        }
    }
}
