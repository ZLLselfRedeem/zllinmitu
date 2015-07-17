using YJC.Toolkit.Sys;
using YJC.Toolkit.Web;

namespace YJC.Toolkit.Web
{
    [RegClass(Author = "YJC", CreateDate = "2015/03/09",
        Description = "WebExcelImportHttpHandler注册")]
    internal sealed class WebExcelImportHttpHandler : ToolkitHttpHandler
    {
        protected override WebBasePage CreatePage()
        {
            return new WebExcelImportPage();
        }
    }
}
