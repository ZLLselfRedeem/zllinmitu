namespace TemplateTestMut
{
    public class WebModuleContent3Servlet : ToolkitServlet
    {
        protected override WebBasePage CreatePage()
        {
            return new WebModuleContent3Page();
        }
    }
}
