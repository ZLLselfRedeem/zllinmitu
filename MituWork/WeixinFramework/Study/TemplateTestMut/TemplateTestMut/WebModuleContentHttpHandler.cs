using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Web.Page
{
    [RegClass(Author = "YJC", CreateDate = "2013-10-12",
        Description = "WebModuleContentHttpHandler注册")]
    internal sealed class WebModuleContentHttpHandler : ToolkitHttpHandler
    {
        protected override WebBasePage CreatePage()
        {
            return new WebModuleContentPage();
        }
    }
}
