using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Web
{
    [RegClass(Author = "YJC", CreateDate = "2015/02/03",
        Description = "WebExcelHttpHandler注册")]
    internal sealed class WebExcelHttpHandler : ToolkitHttpHandler
    {
        protected override WebBasePage CreatePage()
        {
            return new WebExcelPage();
        }
    }
}
