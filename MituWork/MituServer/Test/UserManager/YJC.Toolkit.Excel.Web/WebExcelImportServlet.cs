using YJC.Toolkit.Web;

namespace YJC.Toolkit.Web
{
    public class WebExcelImportServlet : ToolkitServlet
    {
        protected override WebBasePage CreatePage()
        {
            return new WebExcelImportPage();
        }
    }
}
