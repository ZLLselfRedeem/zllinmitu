using YJC.Toolkit.Sys;

namespace TemplateTestMut
{
    [RegClass(Author = "zll", CreateDate = "2014/12/30 21:19:18",
        Description = "WebModuleContent2HttpHandler注册")]
    internal sealed class WebModuleContent2HttpHandler : ToolkitHttpHandler
    {
        protected override WebBasePage CreatePage()
        {
            return new WebModuleContent2Page();
        }
    }
}
