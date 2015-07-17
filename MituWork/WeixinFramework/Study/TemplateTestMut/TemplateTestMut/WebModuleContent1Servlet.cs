namespace TemplateTestMut
{
    public class WebModuleContent1Servlet : ToolkitServlet
    {
        protected override WebBasePage CreatePage()
        {
            return new WebModuleContent1Page();
        }
    }
}
