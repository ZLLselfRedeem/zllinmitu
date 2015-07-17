using YJC.Toolkit.Web;

namespace YJC.Toolkit.Web
{
    public class WebExcelServlet : ToolkitServlet
    {
        protected override WebBasePage CreatePage()
        {
            return new WebExcelPage();
        }
    }
}
