namespace TemplateTestMut
{
    public class WebModuleContent2Servlet : ToolkitServlet
    {
        protected override WebBasePage CreatePage()
        {
            return new WebModuleContent2Page();
        }
    }
}
