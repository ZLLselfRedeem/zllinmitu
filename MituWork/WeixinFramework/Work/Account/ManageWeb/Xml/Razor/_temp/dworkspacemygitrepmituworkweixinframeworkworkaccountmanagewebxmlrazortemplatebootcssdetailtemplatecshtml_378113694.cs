//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18444
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace YJC.Toolkit.Razor.Dynamic {
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using YJC.Toolkit.Razor;
    using YJC.Toolkit.Web;
    using YJC.Toolkit.Sys;
    
    
    public class dworkspacemygitrepmituworkweixinframeworkworkaccountmanagewebxmlrazortemplatebootcssdetailtemplatecshtml : YJC.Toolkit.Razor.NormalDetailTemplate {
        
#line hidden
        
        public dworkspacemygitrepmituworkweixinframeworkworkaccountmanagewebxmlrazortemplatebootcssdetailtemplatecshtml() {
        }
        
        public override void Execute() {
  
    NormalDetailData pageData = (NormalDetailData)ViewBag.PageData;
    bool showPicture = pageData.ShowPicture;
    string title = HtmlUtil.GetTitle(pageData.TitleFormat, ViewBag.Title);

WriteLiteral("\r\n");

DefineSection("DefaultHeader", () => {

WriteLiteral("\r\n");

    
     if (pageData.Header != null)
    {
        
   Write(RenderRazorOutputData(pageData.Header, Model));

                                                      
    }
    else
    {

WriteLiteral("        <h1>");

       Write(title);

WriteLiteral("</h1>\r\n");

    }

});

DefineSection("DefaultFooter", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

Write(RenderRazorOutputData(pageData.Footer, Model));

WriteLiteral("\r\n");

});

WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <title>");

      Write(title);

WriteLiteral("</title>\r\n    <meta");

WriteLiteral(" http-equiv=\"X-UA-Compatible\"");

WriteLiteral(" content=\"IE=edge\"");

WriteLiteral(" />\r\n    <meta");

WriteLiteral(" http-equiv=\"Content-Type\"");

WriteLiteral(" content=\"text/html; charset=utf-8\"");

WriteLiteral(" />\r\n    <meta");

WriteLiteral(" name=\"viewport\"");

WriteLiteral(" content=\"width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable" +
"=0\"");

WriteLiteral(" />\r\n");

WriteLiteral("    ");

Write(RenderLayoutPartial("../bin/css.cshtml", null));

WriteLiteral(" \r\n");

WriteLiteral("    ");

Write(ViewBag.Script.CreateUserCss());

WriteLiteral("\r\n</head>\r\n<body");

WriteAttribute("id", Tuple.Create(" id=\"", 1004), Tuple.Create("\"", 1035)
, Tuple.Create(Tuple.Create("", 1009), Tuple.Create<System.Object, System.Int32>(HtmlUtil.GetPageId(Model)
, 1009), false)
);

WriteLiteral(" class=\"tk-dataPage\"");

WriteLiteral(" data-webpath=\"");

                                                                   Write(HtmlUtil.AppVirtualPath);

WriteLiteral("\"");

WriteLiteral(" data-dialog-height=\"");

                                                                                                                 Write(pageData.DialogHeight);

WriteLiteral("\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"container-fluid\"");

WriteLiteral(">\r\n");

        
         if (pageData.ShowTitle)
        {
            
       Write(RenderSectionOrDefault("Header", "DefaultHeader"));

                                                              
        }

WriteLiteral("        ");

         if (showPicture)
        {
            
       Write(RenderSectionIfDefined("Picture", "picture.cshtml", Model));

                                                                       
        }

WriteLiteral("        ");

   Write(RenderSectionIfDefined("Main", "main.cshtml", Model));

WriteLiteral("\r\n");

WriteLiteral("        ");

   Write(RenderSectionOrDefault("Footer", "DefaultFooter"));

WriteLiteral("\r\n    </div>\r\n");

WriteLiteral("    ");

Write(RenderLayoutPartial("../bin/js.cshtml", null));

WriteLiteral("\r\n    ");

WriteLiteral("\r\n");

WriteLiteral("    ");

Write(ViewBag.Script.CreateUserJavaScript());

WriteLiteral("\r\n</body>\r\n\r\n</html>\r\n");

        }
    }
}
