using YJC.Toolkit.Sys;

namespace TemplateTestMut
{
    [RegClass(Author = "zll", CreateDate = "2014/12/31 8:40:22",
        Description = "WebModuleContent1HttpHandler注册")]
    internal sealed class WebModuleContent1HttpHandler : ToolkitHttpHandler
    {
        protected override WebBasePage CreatePage()
        {
            return new WebModuleContent1Page();
        }
    }
}
