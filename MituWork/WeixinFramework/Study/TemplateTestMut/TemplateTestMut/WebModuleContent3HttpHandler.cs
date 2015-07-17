using YJC.Toolkit.Sys;

namespace TemplateTestMut
{
    [RegClass(Author = "zll", CreateDate = "$shorttime$",
        Description = "WebModuleContent3HttpHandler注册")]
    internal sealed class WebModuleContent3HttpHandler : ToolkitHttpHandler
    {
        protected override WebBasePage CreatePage()
        {
            return new WebModuleContent3Page();
        }
    }
}
