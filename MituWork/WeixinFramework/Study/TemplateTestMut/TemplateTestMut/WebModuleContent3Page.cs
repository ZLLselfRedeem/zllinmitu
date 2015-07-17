﻿using YJC.Toolkit.Data;

namespace TemplateTestMut
{
    internal class WebModuleContent3Page : WebBaseModuleContentPage
    {
        private readonly IModule fModule;

        public WebModuleContent3Page()
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
